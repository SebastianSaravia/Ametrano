using Ametrano.Encapsulado;
using Ametrano.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
    class Alumnos_Controlador
    {
        ConexionBD objetoConexion = new ConexionBD();
        TestingClass testing = new TestingClass();//--------------------------------------
               
        /// <param name="datos"></param>
        public void insertarAlumno(DatosAlumno datos)
        {

           
            // query datos personales
            string datosPersonales = "'" + datos.getDatosPersona()["cedula_alumno"] + "'," +
                                     "'" + datos.getDatosPersona()["nombre1"] + "'," +
                                     "'" + datos.getDatosPersona()["nombre2"] + "'," +
                                     "'" + datos.getDatosPersona()["apellido1"] + "'," +
                                     "'" + datos.getDatosPersona()["apellido2"] + "'," +
                                     "'" + datos.getDatosPersona()["fecha_nac"] + "'," +
                                     "'" + datos.getDatosPersona()["edad"] + "'," +
                                     "'" + datos.getDatosPersona()["sexo"] + "'," +
                                     "'" + datos.getDatosPersona()["estado_civil"] + "',";
            // query datos con respeco al curso
            string datosCurso = "'" + datos.getDatosPersona()["curso_estado"] + "',";
            //query formacion academica
            string datosFormacionAcademica = "'" + datos.getDatosPersona()["formacion_nivel"] + "'," +
                                             "'" + datos.getDatosPersona()["formacion_ultimo_año_aprovado"] + "',";
            // query dirección           
            string datosDireccion = "'" + datos.getDatosPersona()["direccion_departamento"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_localidad"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_calle"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_referencia"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_numero_puerta"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_apartamento"] + "',";
            //query contacto
            string datosContacto = "'" + datos.getDatosPersona()["contacto_telefono"] + "'," +
                                   "'" + datos.getDatosPersona()["contacto_celular"] + "'," +
                                   "'" + datos.getDatosPersona()["contacto_email"] + "',";
            //query cobertura de salud
            string datosCoberura = "'" + datos.getDatosPersona()["cobertura_salud"] + "',";
            //query datos del hogar
            byte jefehogar=0;
            if (datos.getDatosPersona()["hogar_jefe"]=="SI")
            {
                jefehogar = 1;
            }
            
            string datosHogar = "'" + jefehogar + "'," +
                                "'" + datos.getDatosPersona()["hogar_cantidad_hijos"] + "',";
            //query trabajo
            byte trabajo_alguna_vez = 0, trabaja_actualmente = 0;
            
            if (datos.getDatosPersona()["trabajo_trabajo_alguna_vez"]=="SI")
            {
                trabajo_alguna_vez = 1;
            }
            if (datos.getDatosPersona()["trabajo_trabaja_actualmente"]=="SI")
            {
                trabaja_actualmente = 1;
            }
            
            string datosTrabajo = "'" + trabajo_alguna_vez + "'," +
                                  "'" + trabaja_actualmente + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_tiempo_desempleado"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_horas_jornada"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_ingreso_mensual"] + "',";
            //query personas a cargo

            byte discapacidad = 0, apoyo = 0, trabajo_cuidando = 0;
            if (datos.getDatosPersona()["personas_cargo_con_discapacidad"]=="SI")
            {
                discapacidad = 1;
            }
            if (datos.getDatosPersona()["personas_cargo_cuenta_con_apoyo"]=="SI")
            {
                apoyo = 1;
            }
            if (datos.getDatosPersona()["personas_cargo_trabajo_cuidando"]=="SI")
            {
                trabajo_cuidando = 1;
            }

            string datosPersonasCargo = "'" + datos.getDatosPersona()["personas_cargo_0_17"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_18_59"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_60_mas"] + "'," +
                                        "'" + discapacidad + "'," +
                                        "'" + apoyo + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_carga_semanal_cuidado"] + "'," +
                                        "'" + trabajo_cuidando + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_experiencia_instituciones_cuidado"] + "',";
            //query acceso a internet

            byte usa_internet = 0, facil_acceso = 0;
            if (datos.getDatosPersona()["internet_usa_internet"]=="SI")
            {
                usa_internet = 1;
            }
            if (datos.getDatosPersona()["internet_facil_acceso"]=="SI")
            {
                facil_acceso = 1;
            }
            

            string datosAccesoInternet = "'" + usa_internet + "'," +
                                         "'" + facil_acceso + "'," +
                                         "'" + datos.getDatosPersona()["internet_medio_acceso"] + "'";

            //QUERY PRINCIPAL 
            string query = "INSERT INTO alumno(cedula_alumno, nombre1, nombre2, apellido1, apellido2, fecha_nac, edad, sexo, estado_civil, estado, nivel_educativo, ultimo_año_aprobado, departamento, localidad, calle, referencia, numero_puerta, apartamento, telefono_fijo, celular, email, cobertura_salud, jefe_hogar, cant_hijos, trabajo_alguna_vez, trabaja_actualmente, tiempo_sin_trabajo, horas_trabajo, ingreso_mensual, cant_personas_cargo_17, cant_personas_cargo_18_59, cant_personas_cargo_60, persona_tiene_discapacidad, cuenta_con_apoyo, carga_semanal_cuidado, trabajo_anteriormente_cuidando, experiencia_instituciones_cuidado, usa_internet, facil_acceso_internet, medio_acceso_internet) "+
                "VALUES("+datosPersonales+datosCurso+datosFormacionAcademica+datosDireccion+datosContacto+datosCoberura+datosHogar+datosTrabajo+datosPersonasCargo+datosAccesoInternet+");";
            int datosConsulta = objetoConexion.sqlInsertUpdate(query);
                        
            string query2 = "";
            MySql.Data.MySqlClient.MySqlDataAdapter datoConsulta = objetoConexion.consultarDatos(query);
            DataTable dataTable = new DataTable();
            datoConsulta.Fill(dataTable);
            int contador = dataTable.Rows.Count;
            int i = 0;
            string id_grupo = "";
            if (contador > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    id_grupo = row[0].ToString();
                }

            }
            string cedula = datos.getDatosPersona()["cedula_alumno"];
            string curso = datos.getDatosPersona()["curso_alumno"];

            string query3 = "INSERT INTO asiste(curso, id_grupo, cedula_alumno, nombre_materia, fecha, asistencia) VALUES('{0}',{1},'{2}','{3}','{4}',{5})";
            query3 = string.Format(query2, curso, id_grupo, cedula, "nuevo", "0001-01-01",0);
            int Consulta = objetoConexion.sqlInsertUpdate(query3);

        }//Fin InsertarAlumno
        
    }//Fin class
}//Fin namespace
