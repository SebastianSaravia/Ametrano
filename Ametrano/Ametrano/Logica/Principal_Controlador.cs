using Ametrano.Persistencia;
using Ametrano.Presentacion;
using Ametrano.Verificacion;
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

        public dynamic[] ingresarDocente(DatosDocente infoDocente, string[] especialidades)
        {//Metodo que ingresa datos en la base de datos
            dynamic[] datosParaRetornar = new dynamic[2];
            bool retorno = false;
            string mensajeParaRetornar = "";
            string cedula = infoDocente.obtenerDatosDocente()[0];
            string nombre = infoDocente.obtenerDatosDocente()[1];
            string apellido = infoDocente.obtenerDatosDocente()[2];
            string direccion = infoDocente.obtenerDatosDocente()[3];
            string telefono = infoDocente.obtenerDatosDocente()[4];
            string email = infoDocente.obtenerDatosDocente()[5];

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

            dynamic[] datosParaRetornar = new dynamic[3];
            /*Explicacion datosParaRetornar
             * datosParaRetornar[0] == -> variable bool que determina si la consulta se realizo con exito
             * datosParaRetornar[1] == -> IDictionary que almacena los datos
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
                    consulta = "SELECT * FROM DOCENTE WHERE CONCAT(nombre,' ',apellido) LIKE '%" + datoDeBusqueda + "%';";
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
                    consulta = "SELECT * FROM ALUMNO WHERE CONCAT(nombre1,' ',apellido1) LIKE '%" + datoDeBusqueda + "%';";
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
                    break;
                }
                if (tablaDeDatos.Rows.Count == 0)
                {
                    retorno = false;
                }else
                {
                    retorno = true;
                }
               
            }
            catch (Exception e)
            {
                retorno = false;
                testing.MostrarMessageBox(e.Message);
                if (tablaDeDatos.Rows.Count == 0)
                {
                    testing.MostrarMessageBox("No se encontraron usuarios que coincidan con: " + datoDeBusqueda);
                }
            }

           
            
            datosParaRetornar[0] = retorno;
            datosParaRetornar[1] = mapaDeDatos;
            if (tipoPersona == 0)
            {
                string cedula;
                mapaDeDatos.TryGetValue("cedula_docente", out cedula);
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
            }else if(tipoPersona == 1)
            {
                string cedula;
                mapaDeDatos.TryGetValue("cedula_alumno", out cedula);
                string consulta2 = "SELECT * FROM asiste a join grupo g on g.id_grupo = a.id_grupo WHERE a.cedula_alumno='"+cedula+"' and a.nombre_materia = 'nuevo' and a.fecha = '0001-01-01'";
                MySqlDataAdapter datosAsistencia = objetoConexion.consultarDatos(consulta2);//Ejecuto la consulta
                DataTable dt = new DataTable();

                datosAsistencia.Fill(dt);
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (!column.ColumnName.ToString().Equals("cedula_alumno"))
                            {
                                mapaDeDatos.Add(column.ColumnName.ToString(), row[column].ToString());
                            }
                        }
                        break;
                    }
                }
                catch(Exception e)
                {
                    
                }

              
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
                testing.MostrarMessageBox("ERROR AL DAR DE BAJA O ALTA A LA PERSONA\n"+e.Message);
            }

            return retorno;
        }

        public dynamic[] updateDocente(DatosDocente infoDocente, string[] especialidades,string cedulaAnterior)
        {//Metodo que se encarga de realizar el update del docente en cuestion
            dynamic[] datosParaRetornar = new dynamic[2];

            bool retorno = false;

            string mensajeParaRetornar = "";


            //Verificacion de si ya existe el docente
            string cedula = infoDocente.obtenerDatosDocente()[0];
            string select = "SELECT estado from docente where cedula_docente = '" + cedula + "';";
            MySqlDataAdapter datosConsultaCedula = objetoConexion.consultarDatos(select);
            DataTable selectDT = new DataTable();
            datosConsultaCedula.Fill(selectDT);
            bool cedulaNuevaValida = false;

            if (cedula.Equals(cedulaAnterior))
            {
                cedulaNuevaValida = true;
            }else
            {
                if (selectDT.Rows.Count > 0)
                {//Si la cedula nueva ya existe
                    cedulaNuevaValida = false;
                    retorno = false;
                    datosParaRetornar[0] = retorno;
                    datosParaRetornar[1] = "La nueva cedula ingresada pertenece a un docente ya existente";
                    return datosParaRetornar;
                }else
                {
                    cedulaNuevaValida = true;
                }
            }


            if(cedulaNuevaValida)
            {//Si no existe realizo el update
             //Primero borro especialidades
                string delete = "DELETE FROM ESPECIALIDAD WHERE cedula_docente = '" + cedulaAnterior + "';";//Sql borrar especialidades

                int filasAfectadasDeleteEspecialidades = 0;//Cantidad de especialidades eliminadas

                try
                {//intento eliminar especialidades
                    filasAfectadasDeleteEspecialidades = objetoConexion.sqlInsertUpdate(delete);
                }
                catch (Exception e)
                {
                    retorno = false;
                    mensajeParaRetornar = "Error al eliminar especialidades anteriores";
                    testing.MostrarMessageBox("Error al eliminar especialidades\n" + e.Message);
                }

                if (filasAfectadasDeleteEspecialidades > 0)
                {//Si se eliminaron las especialidades

                    string nombre = infoDocente.obtenerDatosDocente()[1];
                    string apellido = infoDocente.obtenerDatosDocente()[2];
                    string direccion = infoDocente.obtenerDatosDocente()[3];
                    string telefono = infoDocente.obtenerDatosDocente()[4];
                    string email = infoDocente.obtenerDatosDocente()[5];

                    string update = "UPDATE DOCENTE " +
                    "SET cedula_docente = '" + cedula + "'," +
                    " nombre = '" + nombre + "'," +
                    " apellido = '" + apellido + "'," + //Sql de update docente
                    " direccion = '" + direccion + "'," +
                    " telefono = '" + telefono + "'," +
                    " email = '" + email + "'" +
                    " WHERE cedula_docente = '" + cedulaAnterior + "';";
                    int filasAfectadas = 0;
                    try
                    {
                        filasAfectadas = objetoConexion.sqlInsertUpdate(update);//Ejecuto la consulta
                    }
                    catch (Exception e)
                    {
                        retorno = false;
                        mensajeParaRetornar = "Error al realizar el update del docente";
                        testing.MostrarMessageBox("Error al realizar el update del docente\n" + e.Message);
                    }


                    if (filasAfectadas > 0)
                    {//Si se realizo el update correctamente 

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
                            mensajeParaRetornar = "Docente Actualizado correctamente";
                        }
                        else
                        {
                            retorno = false;
                            mensajeParaRetornar = "Error al actualizar docente";
                        }
                    }

                }

                datosParaRetornar[0] = retorno;
                datosParaRetornar[1] = mensajeParaRetornar;

                return datosParaRetornar;

            }else
            {
                retorno = false;
                datosParaRetornar[0] = retorno;
                datosParaRetornar[1] = "La nueva cedula ingresada pertenece a un docente ya existente";
                return datosParaRetornar;
            }


            
        }

        public dynamic[] busquedaMultiple(int tipoPersona, string datoDeBusqueda)
        {
            /*TipoPersona explicacion:
            * Variable que determina si la busqueda se enfoca en un docente o                      
            * tipoPersona==0 -> docente
            * tipoPersona==1 -> alumno
            */

            bool retorno = false;
            string consulta;
            DataTable datosPersonasParaRetornar = new DataTable();
            dynamic[] datosParaRetornar = new dynamic[2];

            if (tipoPersona == 0)
            {//Si la persona es un docente
                consulta = "SELECT cedula_docente,nombre, apellido FROM DOCENTE WHERE CONCAT(nombre, ' ', apellido) LIKE '%" + datoDeBusqueda + "%';";
            }else
            {//Si es un alumno
                consulta = "SELECT cedula_alumno,nombre1, apellido1 FROM ALUMNO WHERE CONCAT(nombre1, ' ', apellido1) LIKE '%" + datoDeBusqueda + "%';";
            }
            try
            {
                MySqlDataAdapter datos = objetoConexion.consultarDatos(consulta);
                datos.Fill(datosPersonasParaRetornar);
                if (datosPersonasParaRetornar.Rows.Count > 0)
                {
                    retorno = true;
                    datosParaRetornar[0] = retorno;
                    datosParaRetornar[1] = datosPersonasParaRetornar;
                }else
                {
                    retorno = false;
                    datosParaRetornar[0] = retorno;
                }
            }
            catch(Exception e){
                retorno = false;
                testing.MostrarMessageBox(e.Message);
                datosParaRetornar[0] = retorno;
            }
            

            return datosParaRetornar;
        }

        public string[] ListarCursos()
        {

            string query = "SELECT nombre_curso FROM curso WHERE nombre_curso !='Pendientes' GROUP BY nombre_curso";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int contador = dataTable.Rows.Count;
            int i = 0;
            string[] cursos = new string[contador];                                                    
            if (contador > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                       cursos[i] = row[column].ToString();
                    }
                    i++;
                }
               
            }
            return cursos;
        }

        public string[] ListarMaterias()
        {
            string query = "SELECT nombre_materia FROM materia where nombre_materia != 'nuevo' GROUP BY nombre_materia";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int contador = dataTable.Rows.Count;
            int i = 0;
            string[] materias = new string[contador];
            if (contador > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {                        
                            materias[i] = row[column].ToString();                                             
                    }
                    i++;
                }
               
            }
            return materias;
        }

        public string[] ListarDocentes()
        {
            string query = "SELECT  CONCAT(nombre,' ',apellido) FROM docente";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int contador = dataTable.Rows.Count;
            int i = 0;
            string[] docentes = new string[contador];
            if (contador > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        docentes[i] = row[column].ToString();
                    }
                    i++;
                }
               
            }
            return docentes;
        }
    
    }
}
