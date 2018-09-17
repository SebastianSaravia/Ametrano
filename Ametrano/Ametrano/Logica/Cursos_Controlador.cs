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
        
        public dynamic[] AlumnosCurso(string curso, out DataTable dataTable)
        {
            try
            {
                string query = "SELECT a.cedula_alumno, a.nombre1 , a.apellido1 FROM alumno a JOIN asiste asis ON a.cedula_alumno=asis.cedula_alumno JOIN grupo g on g.id_grupo=asis.id_grupo WHERE asis.nombre_curso='"+curso+"' AND curdate() BETWEEN g.fecha_inicio AND g.fecha_fin";
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

        public string[] DatosViaticos(string cedula)
        {
            string query = "SELECT nombre1, apellido1, monto_viatico_por_dia FROM alumno WHERE cedula_alumno='"+cedula+"'";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);

            int count = dataTable.Columns.Count;
            string[] datos = new string[count];
            int i = 0;
            if (count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        datos[i] = row[column].ToString();
                        i++;
                    }
                   
                }
            }
            return datos;
        }

        public bool AñadirSemanaViatico(string cedula)
        {
            
            string sql = "select count(cedula_alumno) from recive where cedula_alumno='"+cedula+"'";
            MySqlDataAdapter datosCons = objetoConexion.consultarDatos(sql);
            DataTable dataT = new DataTable();
            datosCons.Fill(dataT);

            int op = dataT.Columns.Count;
            int p = 0;
            if (op > 0)
            {
                foreach (DataRow row in dataT.Rows)
                {
                    foreach (DataColumn column in dataT.Columns)
                    {
                        int.TryParse(row[column].ToString(), out p);
                        p = -p;
                    }
                }
            }


            int num=0;
            if (p==0)
            {
                num = 7;
            }else
            {//compueva que hayan pasado 7 dias desde el ultimo pago de viatico
                string query = "SELECT MAX(DATEDIFF(v.fecha, curdate())) from viatico v JOIN recive r ON r.id_viatico=v.id_viatico JOIN asiste a ON a.cedula_alumno=r.cedula_alumno JOIN grupo g ON g.id_grupo=a.id_grupo WHERE curdate() BETWEEN g.fecha_inicio AND g.fecha_fin and a.cedula_alumno='"+cedula+"'";
                MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
                DataTable dataTable = new DataTable();
                datosConsulta.Fill(dataTable);

                int count = dataTable.Columns.Count;

                if (count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            int.TryParse(row[column].ToString(), out num);
                            num = -num;
                        }
                    }
                }
            }
                        
            if (num >=7)//cuenta cuantas semanas sin cobrar viatico tiene el alumno
            {
                string query2 = "SELECT count(abonado) FROM viatico v JOIN recive r ON r.id_viatico=v.id_viatico where abonado = false and r.cedula_alumno='"+cedula+"'";
                MySqlDataAdapter datosConsulta2 = objetoConexion.consultarDatos(query2);
                DataTable dataTable2 = new DataTable();
                datosConsulta2.Fill(dataTable2);
                int ct = dataTable2.Columns.Count;
                int nm = 0;
                if (ct > 0)
                {
                    foreach (DataRow row in dataTable2.Rows)
                    {
                        foreach (DataColumn column in dataTable2.Columns)
                        {
                            int.TryParse(row[column].ToString(), out nm);
                        }

                    }
                }
                //Busca el monto de viatico por dia del alumno seleccionado
                int monto = 0;
                string query3 = "SELECT monto_viatico_por_dia FROM alumno WHERE cedula_alumno='"+cedula+"';";
                MySqlDataAdapter datosConsulta3 = objetoConexion.consultarDatos(query3);
                DataTable dataTable3 = new DataTable();
                datosConsulta3.Fill(dataTable3);
                int contador = dataTable3.Columns.Count;
               
                if (contador > 0)
                {
                    foreach (DataRow row in dataTable3.Rows)
                    {
                        foreach (DataColumn column in dataTable3.Columns)
                        {
                            int.TryParse(row[column].ToString(), out monto);
                        }

                    }
                }
                //-------------------------------------------Calculo de viatico



                int val1=0;// valor que se pagara teniendo en cuenta que no tiene pagos atrasados
                int val2=0;// valor que se pagara al tener pagos atrasados (pago actual + pagoatrasado1 + pagoatrasado2 + ...)



                //-------------------------------------------Fin calculo de viatico
                if (nm==0)//si no tiene pagos atrasados
                {
                    string query4 = "INSERT INTO viatico (fecha,monto,rubro,concepto,abonado) VALUES(curdate()," + val1 + ",'','',0)";
                    int datosConsulta4 = objetoConexion.sqlInsertUpdate(query4);
                }
                else//si tiene pagos atrasados
                {
                    string query4 = "INSERT INTO viatico (fecha,monto,rubro,concepto,abonado) VALUES(curdate()," + val2 +",'','',0)";
                    int datosConsulta4 = objetoConexion.sqlInsertUpdate(query4);
                }
                //selecciona la id de viatico de la operacion actual
                string query5 = "select max(id_viatico) from viatico where fecha = curdate()";
                MySqlDataAdapter datosConsulta5 = objetoConexion.consultarDatos(query5);
                DataTable dataTable5 = new DataTable();
                datosConsulta5.Fill(dataTable5);
                int contar = dataTable5.Columns.Count;
                int id=0;
                if (contar > 0)
                {
                    foreach (DataRow row in dataTable5.Rows)
                    {
                        foreach (DataColumn column in dataTable5.Columns)
                        {
                            int.TryParse(row[column].ToString(), out id);
                        }

                    }
                }
                //Se incertan los datos del viatico pagado en la tabla recive
                string query6 = "INSERT INTO recive VALUES('"+id+"','"+cedula+"')";
               int datosConsulta6 = objetoConexion.sqlInsertUpdate(query6);
                return true;
            } else
            {
                return false;
            }
            
        }
        
        public dynamic[] AñadirViatico(string cedula)
        {
                        
            string sql = "SELECT fecha, monto, rubro, concepto, abonado FROM viatico v JOIN recive r ON v.id_viatico=r.id_viatico WHERE r.cedula_alumno='"+cedula+"' and v.fecha= curdate()";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(sql);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);            
            int cont = dataTable.Columns.Count;
            dynamic[] semanas = new dynamic[cont];
                        
            int i = 0;
            if (cont > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                       semanas[i]=row[column].ToString();
                       i++; 
                    }
                    
                }
            }
            return semanas;
        }

        public DataTable ListarViatico(string cedula)
        {
            
            string sql = "select v.fecha as Fecha, v.monto as Monto, v.rubro as Rubro, v.concepto as Concepto, v.abonado as Abonado from viatico v join recive r ON v.id_viatico=r.id_viatico where r.cedula_alumno = '"+cedula+"'";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(sql);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
                       
             return dataTable;
        }

        public DataTable ListarLista(string curso) {
            
            string sql = "select concat(nombre1,' ',apellido1) as Nombre from alumno a join asiste asi on a.cedula_alumno=asi.cedula_alumno join grupo g on g.id_grupo=asi.id_grupo where curdate() between g.fecha_inicio and g.fecha_fin and g.nombre_curso='"+curso+"'";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(sql);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);

            return dataTable;
            
        }

        public int AgregarCurso(string nombre, string tipo)
        {
            string sql = "insert into curso values('"+nombre+"','"+tipo+"');";
            int datosCons = objetoConexion.sqlInsertUpdate(sql);





            return datosCons;
        }
    }

}
