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
        public bool insertarAlumno(DatosAlumno datos, int id_grupo)
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
            string datosCurso = "'" + datos.getDatosPersona()["curso_estado"] + "'," + 
                                "" + datos.getDatosPersona()["curso_monto_viatico"] + ",";
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
            string query = "INSERT INTO alumno(cedula_alumno, nombre1, nombre2, apellido1, apellido2, fecha_nac, edad, sexo, estado_civil, estado,monto_viatico_por_dia, nivel_educativo, ultimo_anio_aprobado, departamento, localidad, calle, referencia, numero_puerta, apartamento, telefono_fijo, celular, email, cobertura_salud, jefe_hogar, cant_hijos, trabajo_alguna_vez, trabaja_actualmente, tiempo_sin_trabajo, horas_trabajo, ingreso_mensual, cant_personas_cargo_17, cant_personas_cargo_18_59, cant_personas_cargo_60, persona_tiene_discapacidad, cuenta_con_apoyo, carga_semanal_cuidado, trabajo_anteriormente_cuidando, experiencia_instituciones_cuidado, usa_internet, facil_acceso_internet, medio_acceso_internet) " +
                "VALUES("+datosPersonales+datosCurso+datosFormacionAcademica+datosDireccion+datosContacto+datosCoberura+datosHogar+datosTrabajo+datosPersonasCargo+datosAccesoInternet+");";
            int datosConsulta = objetoConexion.sqlInsertUpdate(query);
                        

           
            string cedula = datos.getDatosPersona()["cedula_alumno"];
            string curso = "";
            if (id_grupo == 0)
            {
                curso = "Pendientes";
            }
            else
            {
            curso = datos.getDatosPersona()["curso_alumno"];
            }
           

            string query3 = "INSERT INTO asiste(nombre_curso, id_grupo, cedula_alumno, nombre_materia, fecha, asistencia) VALUES('{0}',{1},'{2}','{3}','{4}',{5})";
            query3 = string.Format(query3, curso, id_grupo, cedula, "nuevo", "0001-01-01",0);
            int Consulta = objetoConexion.sqlInsertUpdate(query3);
            bool exito=false;

            if (Consulta>0 && datosConsulta > 0)
            {
                exito = true;
            }

            return exito;
            
        }//Fin InsertarAlumno

        public bool ModificarAlumno(DatosAlumno datos, int id_grupo)
        {
            bool resultado=false;
            IDictionary<string, string> alumno = datos.getDatosPersona();
                       
            if (alumno["hogar_jefe"] == "SI")
            {
                alumno["hogar_jefe"] = "1";
            }else
            {
                alumno["hogar_jefe"] = "0";
            }

            if (alumno["trabajo_trabajo_alguna_vez"] == "SI")
            {
                alumno["trabajo_trabajo_alguna_vez"] = "1";
            }
            else
            {
                alumno["trabajo_trabajo_alguna_vez"] = "0";
            }
            if (alumno["trabajo_trabaja_actualmente"] == "SI")
            {
                alumno["trabajo_trabaja_actualmente"] = "1";
            }
            else
            {
                alumno["trabajo_trabaja_actualmente"] = "0";
            }

            if (alumno["personas_cargo_con_discapacidad"] == "SI")
            {
                alumno["personas_cargo_con_discapacidad"] = "1";
            }
            else
            {
                alumno["personas_cargo_con_discapacidad"] = "0";
            }
            if (alumno["personas_cargo_cuenta_con_apoyo"] == "SI")
            {
                alumno["personas_cargo_cuenta_con_apoyo"] = "1";
            }
            else
            {
                alumno["personas_cargo_cuenta_con_apoyo"] = "0";
            }
            if (alumno["personas_cargo_trabajo_cuidando"] == "SI")
            {
                alumno["personas_cargo_trabajo_cuidando"] = "1";
            }
            else
            {
                alumno["personas_cargo_trabajo_cuidando"] = "0";
            }

            if (alumno["internet_usa_internet"] == "SI")
            {
                alumno["internet_usa_internet"] = "1";
            }
            else
            {
                alumno["internet_usa_internet"] = "0";
            }
            if (alumno["internet_facil_acceso"] == "SI")
            {
                alumno["internet_facil_acceso"] = "1";
            }
            else
            {
                alumno["internet_facil_acceso"] = "0";
            }
            
            string query = "UPDATE alumno SET cedula_alumno='{0}', nombre1='{1}', nombre2='{2}', apellido1='{3}', apellido2='{4}', fecha_nac='{5}', edad={6}, sexo='{7}', estado_civil='{8}', nivel_educativo='{9}', ultimo_anio_aprobado='{10}', telefono_fijo='{11}', celular='{12}', email='{13}', departamento='{14}', calle='{15}', numero_puerta='{16}', apartamento='{17}', referencia='{18}', localidad='{19}', estado='{20}', trabajo_alguna_vez={21}, trabaja_actualmente={22}, tiempo_sin_trabajo='{23}', horas_trabajo='{24}', ingreso_mensual='{25}', cobertura_salud='{26}', jefe_hogar={27}, cant_hijos={28}, usa_internet={28}, facil_acceso_internet={29}, medio_acceso_internet='{30}', cant_personas_cargo_17={31}, cant_personas_cargo_18_59={32},cant_personas_cargo_60={33}, persona_tiene_discapacidad={34},cuenta_con_apoyo={35}, carga_semanal_cuidado='{36}',trabajo_anteriormente_cuidando={37}, experiencia_instituciones_cuidado={38}, monto_viatico_por_dia={39} WHERE cedula_alumno='{40}'";
            query = string.Format(query,alumno["cedula_alumno"], alumno["nombre1"], alumno["nombre2"], alumno["apellido1"], alumno["apellido2"], alumno["fecha_nac"], alumno["edad"], alumno["sexo"], alumno["estado_civil"], alumno["formacion_nivel"], alumno["formacion_ultimo_año_aprovado"], alumno["contacto_telefono"], alumno["contacto_celular"], alumno["contacto_email"], alumno["direccion_departamento"], alumno["direccion_calle"], alumno["direccion_numero_puerta"], alumno["direccion_apartamento"], alumno["direccion_referencia"], alumno["direccion_localidad"], alumno["curso_estado"], alumno["trabajo_trabajo_alguna_vez"], alumno["trabajo_trabaja_actualmente"], alumno["trabajo_tiempo_desempleado"], alumno["trabajo_horas_jornada"], alumno["trabajo_ingreso_mensual"], alumno["cobertura_salud"], alumno["hogar_jefe"], alumno["hogar_cantidad_hijos"], alumno["internet_usa_internet"], alumno["internet_facil_acceso"], alumno["internet_medio_acceso"], alumno["personas_cargo_0_17"], alumno["personas_cargo_18_59"], alumno["personas_cargo_60_mas"], alumno["personas_cargo_con_discapacidad"], alumno["personas_cargo_cuenta_con_apoyo"], alumno["personas_cargo_carga_semanal_cuidado"], alumno["personas_cargo_trabajo_cuidando"], alumno["personas_cargo_experiencia_instituciones_cuidado"], alumno["curso_monto_viatico"], alumno["cedula_alumno"]);
            int Consulta = objetoConexion.sqlInsertUpdate(query);
            
            if (Consulta>0)
            {
                string query2 = "UPDATE asiste SET nombre_curso='{0}', id_grupo='{1}', cedula_alumno='{2}' WHERE cedula_alumno='{3}'";
                query2 = string.Format(query2, alumno["curso_alumno"], id_grupo, alumno["cedula_alumno"]);
                int Consulta2 = objetoConexion.sqlInsertUpdate(query2);
                if (Consulta2 >0)
                {
                    resultado = true;
                }                                
            }
            
            return resultado;
        }







    }//Fin class
}//Fin namespace
