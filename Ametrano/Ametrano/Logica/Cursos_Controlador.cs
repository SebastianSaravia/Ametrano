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
        TestingClass testing = new TestingClass();

        public dynamic[] AlumnosCurso(string curso, out DataTable dataTable)
        {
            try
            {
                string query = "SELECT a.cedula_alumno, a.nombre1 , a.apellido1 FROM alumno a JOIN asiste asis ON a.cedula_alumno=asis.cedula_alumno JOIN grupo g on g.id_grupo=asis.id_grupo WHERE asis.nombre_curso='"+curso+"' AND curdate() BETWEEN g.fecha_inicio AND g.fecha_fin group by a.cedula_alumno";
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

        public string[] ListarAlumnosGrupo(string curso)
        {
            

            string query = "SELECT CONCAT(a.nombre1,' ',a.apellido1) FROM alumno a JOIN asiste asi ON asi.cedula_alumno=a.cedula_alumno JOIN grupo g ON g.id_grupo=asi.id_grupo where curdate() BETWEEN g.fecha_inicio AND g.fecha_fin GROUP BY a.cedula_alumno;";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int count = dataTable.Rows.Count;
            string[] alumnos = new string[count];
            int i = 0;
            if (count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {                                                         
                    alumnos[i] += row[0].ToString();
                    i++;
                }
            }
            return alumnos;
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
            {//compueva que hayan pasado 7 dias desde el ultimo pago de viatico
                num = 7;
            }else
            {//Se comprueva que el viatico se genere dentro del tiempo de vida del curso actual
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
                        
            if (num >=7)//Valida que hayan pasado los 7 dias
            {
                
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
                
















                //-------------------------------------------Fin calculo de viatico


                //Calculo de fecha de inicio y fecha de fin

                string consulta_max_viatico = "select max(DATE_FORMAT(v.fecha,'%Y-%m-%d')) as fecha, dayname(v.fecha) as nombreDia from viatico v join recive r on r.id_viatico = v.id_viatico where r.cedula_alumno = '" + cedula + "';";
                MySqlDataAdapter consulta_max_viatico_resultado = objetoConexion.consultarDatos(consulta_max_viatico);

                DataTable consultaMaxViatico_Table = new DataTable();

                consulta_max_viatico_resultado.Fill(consultaMaxViatico_Table);
                string fecha_ulimo_viatico = "";    //  <----------------------------- Fecha ultimo viatico
                string nombreDiaUltimoViatico = ""; //  <----------------------------- nombre del dia que se cobro el ultimo viatico
                foreach(DataRow row in consultaMaxViatico_Table.Rows){
                    fecha_ulimo_viatico = row[consultaMaxViatico_Table.Columns[0]].ToString();
                    nombreDiaUltimoViatico = row[consultaMaxViatico_Table.Columns[1]].ToString();
                }

                
                //Variables
                DateTime fechaDT = DateTime.Now;//Datetime para agregar dias
                string fechahoy = fechaDT.ToString("yyyy - MM - dd");
                string fechaInicioNueva = ""; //Variable que guardara la fecha de inicio
                string fechaFinNueva = ""; //variable que guardara la fecha de fifn
               
                if (fecha_ulimo_viatico.Equals(""))
                {//Primer viatico generado
                    if (fechaDT.DayOfWeek == DayOfWeek.Friday)
                    {
                        fechaDT = fechaDT.AddDays(-11);
                    }else
                    {
                        fechaDT = fechaDT.AddDays(-10);
                    }
                    
                    fechaInicioNueva = fechaDT.ToString("yyyy-MM-dd");

                    fechaDT = DateTime.Parse(fechaInicioNueva);

                    fechaDT = fechaDT.AddDays(4);

                    fechaFinNueva = fechaDT.ToString("yyyy-MM-dd");

                    int montoTotal = calcularMonto(fechaInicioNueva, fechaFinNueva, cedula, monto);

                    int semana = 1;

                    //Incerta los datos del viatico en la bd
                    string query4 = "INSERT INTO viatico (fecha,monto,rubro,concepto,abonado,fecha_inicio,fecha_fin,semana) VALUES(curdate()," + montoTotal + ",'','Semana "+semana+"',0,'" + fechaInicioNueva + "','" + fechaFinNueva + "','"+semana+"')";
                    int datosConsulta4 = objetoConexion.sqlInsertUpdate(query4);

                    //selecciona la id de viatico de la operacion actual
                    string query5 = "select max(id_viatico) from viatico where fecha = curdate()";
                    MySqlDataAdapter datosConsulta5 = objetoConexion.consultarDatos(query5);
                    DataTable dataTable5 = new DataTable();
                    datosConsulta5.Fill(dataTable5);
                    int contar = dataTable5.Columns.Count;
                    int id = 0;
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
                    string query6 = "INSERT INTO recive VALUES('" + id + "','" + cedula + "')";
                    int datosConsulta6 = objetoConexion.sqlInsertUpdate(query6);

                }
                else
                {
                AgregarSemanaViatico:
                    string fecha_fin_ultimo_viatico2 = "";
                    string nombreDiaUltimoViatico2 = "";
                    fechaInicioNueva = ""; //Variable que guardara la fecha de inicio
                    fechaFinNueva = ""; //variable que guardara la fecha de fifn
                    string fechaFinConsulta = "select max(DATE_FORMAT(v.fecha_fin,'%Y-%m-%d')) as fecha, dayname(v.fecha) as nombreDia from viatico v join recive r on r.id_viatico = v.id_viatico where r.cedula_alumno = '" + cedula + "';";
                    MySqlDataAdapter fechaFin_resultado = objetoConexion.consultarDatos(fechaFinConsulta);

                    DataTable fechaFin_table = new DataTable();

                    fechaFin_resultado.Fill(fechaFin_table);

                    foreach (DataRow row in fechaFin_table.Rows)
                    {
                        fecha_fin_ultimo_viatico2 = row[fechaFin_table.Columns[0]].ToString();
                        nombreDiaUltimoViatico2 = row[fechaFin_table.Columns[1]].ToString();
                    }

                    

                    TimeSpan cantDiasDesdeUlimoViatico = DateTime.Parse(fechahoy) - DateTime.Parse(fecha_fin_ultimo_viatico2);

                   

                    fechaDT = DateTime.Parse(fecha_fin_ultimo_viatico2);

                    if (nombreDiaUltimoViatico2.Equals("Thursday"))
                    {//Si es jueves agrego 4 dias para llegar a lunes
                        fechaDT = fechaDT.AddDays(4);

                    }
                    else if (nombreDiaUltimoViatico2.Equals("Friday"))
                    {//Agrego 3 dias mas si es viernes
                        fechaDT = fechaDT.AddDays(3);
                    }

                    fechaInicioNueva = fechaDT.ToString("yyyy-MM-dd");//Obtengo la fecha del datetime con los dias agregados en formato año mes dia


                    fechaDT = DateTime.Parse(fechaInicioNueva);//Igualo el datetime para poder obtener la fecha de fin

                    fechaDT = fechaDT.AddDays(4);//Agrego 5 dias para llegar a cubrir una semana entera

                    fechaFinNueva = fechaDT.ToString("yyyy-MM-dd");//Obtengo la fecha en formato año mes dia

                    if (cantDiasDesdeUlimoViatico.Days/7>1)
                    {
                        //Calculo del monto

                        

                        int montoTotal = calcularMonto(fechaInicioNueva, fechaFinNueva, cedula, monto);

                        string consultarSemana = "Select max(semana) from viatico v join recive r on r.id_viatico = v.id_viatico where r.cedula_alumno = '" + cedula + "';";
                        MySqlDataAdapter consultarSemana_resultados = objetoConexion.consultarDatos(consultarSemana);
                        DataTable consultarSemana_table = new DataTable();
                        consultarSemana_resultados.Fill(consultarSemana_table);

                        int semana = 0;

                        int.TryParse(consultarSemana_table.Rows[0][consultarSemana_table.Columns[0]].ToString(), out semana);

                        semana++;

                        //Incerta los datos del viatico en la bd
                        string query4 = "INSERT INTO viatico (fecha,monto,rubro,concepto,abonado,fecha_inicio,fecha_fin,semana) VALUES(curdate()," + montoTotal + ",'','Semana " + semana + "',0,'" + fechaInicioNueva + "','" + fechaFinNueva + "','"+semana+"')";
                        int datosConsulta4 = objetoConexion.sqlInsertUpdate(query4);

                        //selecciona la id de viatico de la operacion actual
                        string query5 = "select max(id_viatico) from viatico where fecha = curdate()";
                        MySqlDataAdapter datosConsulta5 = objetoConexion.consultarDatos(query5);
                        DataTable dataTable5 = new DataTable();
                        datosConsulta5.Fill(dataTable5);
                        int contar = dataTable5.Columns.Count;
                        int id = 0;
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
                        string query6 = "INSERT INTO recive VALUES('" + id + "','" + cedula + "')";
                        int datosConsulta6 = objetoConexion.sqlInsertUpdate(query6);
                    }

                   

                    if(cantDiasDesdeUlimoViatico.Days / 7 >= 2)
                    {
                        goto AgregarSemanaViatico;
                    }
                    

                    
                }




               
                return true;
            } else
            {
                return false;
            }
            
        }
        public int calcularMonto(string fecha_inicio, string fecha_fin,string cedula,int montoDia)
        {
            int diasAsistidosEnSemana = 0;

            string consultarAsistencias = "select count(cedula_alumno) from asiste a where fecha between '" + fecha_inicio + "' and '" + fecha_fin + "' and cedula_alumno = '" + cedula + "';";
            MySqlDataAdapter consultarAsistencias_resultado = objetoConexion.consultarDatos(consultarAsistencias);

            DataTable consultarAsistencias_table = new DataTable();

            consultarAsistencias_resultado.Fill(consultarAsistencias_table);

           int.TryParse(consultarAsistencias_table.Rows[0][consultarAsistencias_table.Columns[0]].ToString(),out diasAsistidosEnSemana);

            int montoTotal = montoDia * diasAsistidosEnSemana; //Calculo el monto

            return montoTotal;
        }
        public int calcularMontoTotal(string cedula)
        {
            string consulta = "select sum(monto) from viatico v join recive r on r.id_viatico = v.id_viatico where v.abonado = 0 and r.cedula_alumno = '" + cedula + "';";
            MySqlDataAdapter consulta_resultados = objetoConexion.consultarDatos(consulta);
            DataTable consulta_table = new DataTable();
            consulta_resultados.Fill(consulta_table);

            int monto = 0;

            int.TryParse(consulta_table.Rows[0][consulta_table.Columns[0]].ToString(), out monto);

            return monto;

            return 0;
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
            
            string sql = "select v.fecha as Fecha, v.monto as Monto, v.rubro as Rubro, v.concepto as Concepto, v.abonado as Abonado,semana as Semana from viatico v join recive r ON v.id_viatico=r.id_viatico where r.cedula_alumno = '" + cedula+"'";
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

        public bool updatePago(string ci, string fecha,string semana,bool estado)
        {
            //Primero debo consultar el id de el viatico
            string consulta = "select v.id_viatico from viatico v join recive r on r.id_viatico = v.id_viatico where fecha = '" + fecha + "' and semana = "+semana+" and r.cedula_alumno = '" + ci + "';";
            MySqlDataAdapter datos = objetoConexion.consultarDatos(consulta);

            DataTable viaticos = new DataTable();
            try
            {

                datos.Fill(viaticos);

            }
            catch (Exception)
            {

            }
            int idViatico;

            int nuevoEstado;
            if (estado == true)
            {
                nuevoEstado = 1;
            }else
            {
                nuevoEstado = 0;
            }

            int.TryParse(viaticos.Rows[0][viaticos.Columns[0]].ToString(),out idViatico);//guardo el id del viatico en la variable

            string update = "UPDATE viatico SET abonado = " + nuevoEstado + " where id_viatico = " + idViatico + ";";

            int filasAfectadas = objetoConexion.sqlInsertUpdate(update);

            if (filasAfectadas > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool AgregarGrupo(string curso, string inicio, string fin,string turno)
        {
            string query = "INSERT INTO grupo(nombre_curso, fecha_inicio, fecha_fin,turno) VALUES('{0}','{1}','{2}','{3}')";
            query = string.Format(query, curso, inicio, fin,turno);
            int datosCons = objetoConexion.sqlInsertUpdate(query);
            bool resultado = false;
            if (datosCons==1)
            {
                resultado = true;
            }
            return resultado;
        }







    }

}
