using Ametrano.Persistencia;
using Ametrano.Presentacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
    class Principal_Controlador
    {
        TestingClass testing = new TestingClass();//--------------------------------------
        public IDictionary<string, string> mapTextBox = new Dictionary<string, string>();
        ConexionBD objetoConexion = new ConexionBD();
        
        public void abrirConfiguracion()
        {
            Configuracion ventanaConfiguracion = new Configuracion();
            ventanaConfiguracion.Show();
        }

        public dynamic[] ingresarDocente(string cedula, string apellido, string nombre, string direccion, string telefono, string email, string[] especialidades)
        {//Metodo que ingresa datos en la base de datos
            dynamic[] datosParaRetornar = new dynamic[2];
            bool retorno = false;
            string mensajeParaRetornar = "";

            //Verificacion de si ya existe el docente
            string select = "SELECT estado from docente where cedula_docente = '"+cedula+"';";
            MySqlDataAdapter datosConsultaCedula = objetoConexion.consultarDatos(select);
            DataTable selectDT = new DataTable();
            datosConsultaCedula.Fill(selectDT);
            if (selectDT.Rows.Count > 0)
            {
                retorno = false;
                datosParaRetornar[0] = retorno;
                datosParaRetornar[1] = "El docente ya existe";
                return datosParaRetornar;
            }else
            {
                string insert = "INSERT INTO DOCENTE VALUES('" +
                cedula + "','" +
                nombre + "','" +
                apellido + "','" + //Sql de insert de docente
                direccion + "','" +
                telefono + "','" +
                email + "',1);";

                int filasAfectadas = objetoConexion.sqlInsertUpdate(insert);//Se realiza el insert y se guarda la cantidad de filas afectadas
                if (filasAfectadas > 0)
                {//Si el docente se ingreso correctamente
                    int filasAfectadasEspecialidad = 0;//Cantidad de especialidades ingresadas en total
                    for (int i = 0; i < especialidades.Length; i++)
                    {//Se recorre el array de especialidades y se inserta 
                        string especialidadInsert = "INSERT INTO especialidad VALUES('" + cedula + "','" + especialidades[i] + "');";
                        objetoConexion.sqlInsertUpdate(especialidadInsert);
                        filasAfectadasEspecialidad++;//Si se inserta correctamente se aumenta el numero de especialidades ingresadas
                    }

                    if (filasAfectadasEspecialidad == especialidades.Length)
                    {//Si la cantidad de especialidades ingresadas coincide con la cantidad de especialidades recividas para ingresar se devuelve true
                        retorno = true;
                        mensajeParaRetornar = "Docente agregado correctamente";
                    }
                    else
                    {
                        retorno = false;
                        mensajeParaRetornar = "Error al ingresar las especialidades del docente";
                    }

                }
                else
                {
                    retorno = false;
                    mensajeParaRetornar = "Error al ingresar al docente";
                }
                datosParaRetornar[0] = retorno;
                datosParaRetornar[1] = mensajeParaRetornar;
                return datosParaRetornar;
            }

            




            
        }
        
        public dynamic[] consultarPersona(int tipoPersona, int tipoConsulta, string datoDeBusqueda)
        {
            bool retorno = false; //Variable de retorno
            /*TipoPersona explicacion:
             * Variable que determina si la busqueda se enfoca en un docente o alumno
             * tipoPersona==0 -> docente
             * tipoPersona==1 -> alumno
             */

            /*TipoConsulta explicacion:
             * Variable que determina si la busqueda se realiza por cedula o nombre y apellido
             * tipoConsulta==0 -> cedula
             * tipoConsulta==1 -> nombre y apellido
             */
            string consulta = "";
            if (tipoPersona == 0)
            {//Si es un docente
                if (tipoConsulta == 0)
                {//Si es por cedula
                    consulta = "SELECT * FROM DOCENTE WHERE cedula_docente = '" + datoDeBusqueda + "';";
                }
                else
                {//Si es un nombre y apellido
                    consulta = "SELECT * FROM DOCENTE WHERE CONCAT(nombre1,' ',apellido1) LIKE = '%" + datoDeBusqueda + "%';";
                }
            }
            else
            {//Si es un alumno
                if (tipoConsulta == 0)
                {//Si es por cedula
                    consulta = "SELECT * FROM ALUMNO WHERE cedula_alumno = '" + datoDeBusqueda + "';";
                }
                else
                {//Si es un nombre y apellido
                    consulta = "SELECT * FROM ALUMNO WHERE CONCAT(nombre1,' ',apellido1) LIKE = '%" + datoDeBusqueda + "%';";
                }
            }

            MySqlDataAdapter datos = objetoConexion.consultarDatos(consulta);//Ejecuto la consulta
            DataTable tablaDeDatos = new DataTable();
            IDictionary<string, string> mapaDeDatos = new Dictionary<string, string>();
            try
            {
                datos.Fill(tablaDeDatos);//Se llena el datatable con los datos de la base de datos

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    foreach (DataColumn column in tablaDeDatos.Columns)
                    {
                        mapaDeDatos.Add(column.ColumnName.ToString(), row[column].ToString());
                        //testing.MostrarMessageBox(column.ColumnName.ToString() + " --- " + row[column].ToString());
                    }
                }
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
                if (tablaDeDatos.Rows.Count == 0)
                {
                    testing.MostrarMessageBox("No se encontraron usuarios que coincidan con: " + datoDeBusqueda);
                }
            }


            dynamic[] datosParaRetornar = new dynamic[3];
            /*Explicacion datosParaRetornar
             * datosParaRetornar[0] == -> variable bool que determina si la consulta se realizo con exito
             * datosParaRetornar[1] == -> IDictionary que almacena los datos
             */


            string cedula;
            mapaDeDatos.TryGetValue("cedula_docente", out cedula);



            datosParaRetornar[0] = retorno;
            datosParaRetornar[1] = mapaDeDatos;
            if (tipoPersona == 0)
            {
                string consulta2 = "SELECT especialidad FROM especialidad WHERE cedula_docente='" + cedula + "'";
                MySqlDataAdapter datoEspecialidades = objetoConexion.consultarDatos(consulta2);//Ejecuto la consulta


                DataTable tablaDeDatoEspecialidades = new DataTable();
                datoEspecialidades.Fill(tablaDeDatoEspecialidades);

                string[] especialidad = new string[tablaDeDatoEspecialidades.Rows.Count];
                int count = 0;
                foreach (DataRow row in tablaDeDatoEspecialidades.Rows)
                {
                    foreach (DataColumn column in tablaDeDatoEspecialidades.Columns)
                    {

                        especialidad[count] = row[column].ToString();
                        count++;

                    }
                }

                datosParaRetornar[2] = especialidad;
            }


            return datosParaRetornar;
        }
        
        public bool cambiarEstadoPersona(int bajaAlta, int tipoPersona, string cedulaPersona)
        {//metodo que da de baja una persona
            bool retorno = false;
            string update = "";

            /*TipoPersona explicacion:
            * Variable que determina si la busqueda se enfoca en un docente o alumno
            * tipoPersona==0 -> docente
            * tipoPersona==1 -> alumno
            */

            /*bajaAlta explicación
             * bajaAlta = 0 -> baja
             * bajaAlta = 1 -> alta
             */

            if (bajaAlta == 0)
            {//Si se esta dando de baja a la persona en cuestion
                if (tipoPersona == 0)
                {
                    update = "UPDATE DOCENTE SET estado = 0 where cedula_docente = '" + cedulaPersona + "';DELETE FROM cuenta_usuario where usuario = '" + cedulaPersona + "';";
                }
                else
                {
                    update = "UPDATE ALUMNO SET estado = 0 where cedula_alumno = '" + cedulaPersona + "';DELETE FROM cuenta_usuario where usuario = '" + cedulaPersona + "';";
                }
            }
            else
            {//Si se esta dando de alta a la persona en cuestion
                if (tipoPersona == 0)
                {
                    update = "UPDATE DOCENTE SET estado = 1 where cedula_docente = '" + cedulaPersona + "'";
                }
                else
                {
                    update = "UPDATE ALUMNO SET estado = 1 where cedula_alumno = '" + cedulaPersona + "'";
                }
            }
            try
            {
                int filasAfectadas = objetoConexion.sqlInsertUpdate(update);
                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception e)
            {
                retorno = false;
                testing.MostrarMessageBox("ERROR AL DAR DE BAJA O ALTA A LA PERSONA");
            }

            return retorno;
        }
        
    }
}
