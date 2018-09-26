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

        public dynamic[] AlumnosCurso(string curso, string turno, out DataTable dataTable)
        {
            try
            {
                string query = "SELECT a.cedula_alumno, a.nombre1 , a.apellido1 FROM alumno a JOIN asiste asis ON a.cedula_alumno=asis.cedula_alumno JOIN grupo g on g.id_grupo=asis.id_grupo WHERE asis.nombre_curso='"+curso+"' AND curdate() BETWEEN g.fecha_inicio AND g.fecha_fin and g.turno = '"+turno+"' group by a.cedula_alumno";
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

        public string[] ListarAlumnosGrupo(string curso,string turno,out DataTable dataTable)
        {
            

            string query = "SELECT CONCAT(a.nombre1,' ',a.apellido1), a.cedula_alumno FROM alumno a JOIN asiste asi ON asi.cedula_alumno=a.cedula_alumno JOIN grupo g ON g.id_grupo=asi.id_grupo where curdate() BETWEEN g.fecha_inicio AND g.fecha_fin and g.turno = '"+turno+"' and g.nombre_curso = '"+curso+ "' and asi.fecha = '0001-01-01' GROUP BY a.cedula_alumno;";
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
                double monto = 0;
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
                            double.TryParse(row[column].ToString(), out monto);
                        }
                    }
                }



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

                    double montoTotal = calcularMonto(fechaInicioNueva, fechaFinNueva, cedula, monto);

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
                    string fechaFinConsulta = "set lc_time_names = es_ES;select max(DATE_FORMAT(v.fecha_fin,'%Y-%m-%d')) as fecha, dayname(v.fecha) as nombreDia from viatico v join recive r on r.id_viatico = v.id_viatico where r.cedula_alumno = '" + cedula + "';";
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

                    if (nombreDiaUltimoViatico2.Equals("jueves"))
                    {//Si es jueves agrego 4 dias para llegar a lunes
                        fechaDT = fechaDT.AddDays(4);

                    }
                    else if (nombreDiaUltimoViatico2.Equals("viernes"))
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

                        

                        double montoTotal = calcularMonto(fechaInicioNueva, fechaFinNueva, cedula, monto);

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
        public double calcularMonto(string fecha_inicio, string fecha_fin,string cedula,double montoDia)
        {
            int diasAsistidosEnSemana = 0;

            string consultarAsistencias = "select cedula_alumno from asiste a where cedula_alumno = '"+cedula+"' and fecha between '"+fecha_inicio+"' and '"+fecha_fin+"' and a.asistencia = 1 group by (fecha)";
            MySqlDataAdapter consultarAsistencias_resultado = objetoConexion.consultarDatos(consultarAsistencias);

            DataTable consultarAsistencias_table = new DataTable();

            consultarAsistencias_resultado.Fill(consultarAsistencias_table);

            diasAsistidosEnSemana = consultarAsistencias_table.Rows.Count;

            double montoTotal = montoDia * diasAsistidosEnSemana; //Calculo el monto

            return montoTotal;
        }
        public double calcularMontoTotal(string cedula)
        {
            string consulta = "select sum(monto) from viatico v join recive r on r.id_viatico = v.id_viatico where v.abonado = 0 and r.cedula_alumno = '" + cedula + "';";
            MySqlDataAdapter consulta_resultados = objetoConexion.consultarDatos(consulta);
            DataTable consulta_table = new DataTable();
            consulta_resultados.Fill(consulta_table);

            double monto = 0;

            double.TryParse(consulta_table.Rows[0][consulta_table.Columns[0]].ToString(), out monto);

            return monto;
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

        public string[] listarCursoPorTurno(string turno)
        {
            string query = "SELECT nombre_curso FROM grupo where turno = '"+turno+"' and curdate() between fecha_inicio and fecha_fin;";
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
        
        public bool AgregarGrupo(string curso, string inicio, string fin, string turno)
        {
            string query = "INSERT INTO grupo(nombre_curso, fecha_inicio, fecha_fin,turno) VALUES('{0}','{1}','{2}','{3}')";
            query = string.Format(query, curso, inicio, fin, turno);
            int datosCons = objetoConexion.sqlInsertUpdate(query);
            bool resultado = false;
            if (datosCons == 1)
            {
                resultado = true;
            }
            return resultado;
        }

        public DataTable GruposActivos()
        {
            string query = "SELECT nombre_curso as 'Nombre', fecha_inicio as 'Fecha de inicio', fecha_fin as 'Fecha de finalizacion', turno as 'Turno' FROM grupo WHERE curdate() BETWEEN fecha_inicio AND fecha_fin OR fecha_inicio>=curdate()";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datosConsulta.Fill(dataTable);

            return dataTable;

        }

        public string[] ListarPeriodos(string curso,string turno,out DataTable dataTable)
        {
            
            string query = "SET lc_time_names=es_ES;SELECT CONCAT(monthname(fecha_inicio),' ',year(fecha_inicio),' - ',monthname(fecha_fin),' ',year(fecha_fin)), id_grupo  from grupo WHERE nombre_curso = '" + curso+ "' AND fecha_inicio>=curdate() AND turno='"+turno+"'";
            MySqlDataAdapter datosConsulta = objetoConexion.consultarDatos(query);
            dataTable = new DataTable();
            datosConsulta.Fill(dataTable);
            int filas = dataTable.Rows.Count;            
            string[] periodo = new string[filas];            
            int i = 0;
            
            if (filas > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    
                       periodo[i] = row[0].ToString();
                       i++;
                                       
                }

            }
                        
            return periodo;
                        
        }
        
        public bool agregarAsistencia(string cedula, string curso, string turno, string materia, string fecha, int asistencia)
        {//metodo que agrega asistencia de alumno
            string query1_buscar_curso = "select id_grupo from grupo g where g.nombre_curso = '" + curso + "' and g.turno = '" + turno + "' and curdate() between g.fecha_inicio and g.fecha_fin;";
            MySqlDataAdapter query1_buscar_curso_resultados = objetoConexion.consultarDatos(query1_buscar_curso);
            DataTable query1_buscar_curso_table = new DataTable();
            query1_buscar_curso_resultados.Fill(query1_buscar_curso_table);
            
            int id_grupo = 0;

            int.TryParse(query1_buscar_curso_table.Rows[0][0].ToString(),out id_grupo);

            //busco si ya esta el registro

            string query2_buscar_asistencia = "select cedula_alumno from asiste a where a.nombre_curso = '"+curso+"' and id_grupo = "+id_grupo+" and cedula_alumno = '" + cedula + "' and nombre_materia = '"+materia+"' and fecha = '" + fecha + "'";

            MySqlDataAdapter query2_buscar_asistencia_resultados = objetoConexion.consultarDatos(query2_buscar_asistencia);

            DataTable query2_buscar_asistencia_table = new DataTable();

            query2_buscar_asistencia_resultados.Fill(query2_buscar_asistencia_table);



            bool retorno = false;

            if (query2_buscar_asistencia_table.Rows.Count == 0)
            {
                string query3_insertar_asistencia = "insert into asiste values('" + curso + "'," + id_grupo + ",'" + cedula + "','" + materia + "','" + fecha + "'," + asistencia + ");";

                int filasAfectadas = objetoConexion.sqlInsertUpdate(query3_insertar_asistencia);

                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
            }else
            {
                string query3_insertar_asistencia = "update asiste set asistencia = "+asistencia+" where nombre_curso = '"+curso+"' and id_grupo = "+id_grupo+" and cedula_alumno = '" + cedula + "' and nombre_materia = '"+materia+"' and fecha = '" + fecha + "'";

                int filasAfectadas = objetoConexion.sqlInsertUpdate(query3_insertar_asistencia);

                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
            }



            return retorno;
        }

        public DataTable listarAsistencias(string turno,string curso,string fecha,string materia)
        {
            //Busco el id de grupo
            string query1_buscar_curso = "select id_grupo from grupo g where g.nombre_curso = '" + curso + "' and g.turno = '" + turno + "' and curdate() between g.fecha_inicio and g.fecha_fin;";
            MySqlDataAdapter query1_buscar_curso_resultados = objetoConexion.consultarDatos(query1_buscar_curso);
            DataTable query1_buscar_curso_table = new DataTable();
            query1_buscar_curso_resultados.Fill(query1_buscar_curso_table);

            int id_grupo = 0;

            int.TryParse(query1_buscar_curso_table.Rows[0][0].ToString(), out id_grupo);

            string query2_buscar_Asistencia_Alumnos = "SELECT CONCAT(a.nombre1,' ',a.apellido1) as Nombre, asi.asistencia as Asistencias FROM alumno a JOIN asiste asi ON asi.cedula_alumno=a.cedula_alumno where asi.id_grupo = '"+id_grupo+"' and asi.nombre_curso = '"+curso+"' and asi.nombre_materia = '"+materia+"' and asi.fecha = '"+fecha+"'";

            MySqlDataAdapter query2_buscar_Asistencia_Alumnos_resultados = objetoConexion.consultarDatos(query2_buscar_Asistencia_Alumnos);

            DataTable query2_buscar_Asistencia_Alumnos_table = new DataTable();

            query2_buscar_Asistencia_Alumnos_resultados.Fill(query2_buscar_Asistencia_Alumnos_table);

            return query2_buscar_Asistencia_Alumnos_table;

        }

        public bool AgregarCurso(string curso, string tipo, string[] materias)
        {
            bool resultado = false;

            string query = "insert into curso values('" + curso + "','" + tipo + "');insert into grupo (nombre_curso,fecha_inicio,fecha_fin,turno) values('" + curso + "','0001-01-01','0001-01-01','null');";
            int datosCons1 = objetoConexion.sqlInsertUpdate(query);
            MySqlDataAdapter id_grupo_resultado = objetoConexion.consultarDatos("select max(id_grupo) from grupo");
            DataTable dt = new DataTable();
            id_grupo_resultado.Fill(dt);
            int datosCons2 = 0;
            if (dt.Rows.Count > 0)
            {
                string id_grupo = dt.Rows[0][0].ToString();
                string update_id_grupo = "update grupo set id_grupo = 0 where id_grupo = " + id_grupo;
                datosCons2 = objetoConexion.sqlInsertUpdate(update_id_grupo);
            }

            if (datosCons2>0)
            {
                int[] val = new int[materias.Length];
                for (int i = 0; i < materias.Length; i++)
                {
                    string query2 = "insert into materia(nombre_curso, nombre_materia) values('" + curso + "','" + materias[i] + "');";
                    int datosCons3 = objetoConexion.sqlInsertUpdate(query2);
                    val[i] = datosCons3;
                }

                for (int i = 0; i < val.Length; i++)
                {
                    if (val[i]==1)
                    {
                        resultado = true;
                    }else
                    {
                        resultado = false;
                        break;
                    }
                }
                
            }
            return resultado;
        }

    }

}
