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
        
        public dynamic[] AlumnosCurso(string curso, dynamic fecha)
        {
            
            string query = "";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int count = dataTable.Rows.Count;

            dynamic[] alumnos = new dynamic[count];

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn colum in dataTable.Columns)
                {

                }




            }




            for (int i = 0; i < count; i++)
            {
                alumnos[i]=
            }




            return alumnos;



        }



    }
}
