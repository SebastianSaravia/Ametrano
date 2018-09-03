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
        public bool ingresarDocente(string cedula, string apellido1, string apellido2, string nombre1, string nombre2, string direccion, string telefono, string email, string[] especialidades)
        {//Metodo que ingresa datos en la base de datos
            bool retorno = false;
            string insert = "INSERT INTO DOCENTE VALUES('" +
                cedula + "','" +
                nombre1 + " " +
                nombre2 + "','" +
                apellido1 + " " + //Sql de insert de docente
                apellido2 + "','" +
                direccion + "','" +
                telefono + "','" +
                email + "');";

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
                }
                else
                {
                    retorno = false;
                }

            }
            else
            {
                retorno = false;
            }



            return retorno;
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
            datos.Fill(tablaDeDatos);
            IDictionary<string, string> mapaDeDatos = new Dictionary<string, string>();

            foreach (DataRow row in tablaDeDatos.Rows)
            {
                foreach (DataColumn column in tablaDeDatos.Columns)
                {
                    mapaDeDatos.Add(column.ColumnName.ToString(), row[column].ToString());
                    testing.MostrarMessageBox(column.ColumnName.ToString() + " --- " + row[column].ToString());
                }
            }
            retorno = true;

            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion datosParaRetornar
             * datosParaRetornar[0] == -> variable bool que determina si la consulta se realizo con exito
             * datosParaRetornar[1] == -> IDictionary que almacena los datos
             */

            datosParaRetornar[0] = retorno;
            datosParaRetornar[1] = mapaDeDatos;


            return datosParaRetornar;
        }

        public bool darBajaPersona(int tipoPersona, string cedulaPersona)
        {//metodo que da de baja una persona
            bool retorno = false;
            string update = "";

            /*TipoPersona explicacion:
            * Variable que determina si la busqueda se enfoca en un docente o alumno
            * tipoPersona==0 -> docente
            * tipoPersona==1 -> alumno
            */

            if (tipoPersona == 0)
            {
                update = "UPDATE DOCENTE SET estado = 0 where cedula_docente = '" + cedulaPersona + "';DELETE FROM cuenta_usuario where usuario = '" + cedulaPersona + "';";
            }
            else{
                update = "UPDATE ALUMNO SET estado = 0 where cedula_docente = '" + cedulaPersona + "';DELETE FROM cuenta_usuario where usuario = '" + cedulaPersona + "';";
            }
            try
            {
                int filasAfectadas = objetoConexion.sqlInsertUpdate(update);
                if (filasAfectadas > 0)
                {
                    retorno = true;
                }else
                {
                    retorno = false;
                }
            }
            catch(Exception e)
            {
                retorno = false;
            }

            return retorno;
        }






    }
}
