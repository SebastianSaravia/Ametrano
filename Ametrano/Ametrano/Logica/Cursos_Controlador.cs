using Ametrano.Persistencia;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
   
    class Cursos_Controlador
    {
        ConexionBD objetoConexion = new ConexionBD();
        
        public dynamic[] AlumnosCurso(out DataTable dataTable)
        {


            try
            {
                string query = "select cedula_alumno, nombre1, apellido1 from alumno";
                MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
                dataTable = new DataTable();
                datosConsulta.Fill(dataTable);
                int count = dataTable.Rows.Count;

                string[] alumnos = new string[count];
                int i = 0;
                if (count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string alumno = "";
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            if (!column.ColumnName.Equals("cedula_alumno"))
                            {
                               alumno += row[column].ToString() + " ";
                            }
                           
                        }

                        alumnos[i] = alumno;
                        i++;
                    }
                }

                return alumnos;
            }
            catch (Exception)
            {
                dataTable = null;
                return null;
                throw;
            }
            
            

        }



    }
}
