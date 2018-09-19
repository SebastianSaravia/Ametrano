using Ametrano.Encapsulado;
using Ametrano.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
    class Alumnos_Controlador
    {
        ConexionBD objetoConexion = new ConexionBD();
        TestingClass testing = new TestingClass();//--------------------------------------

        /// <summary>
        /// 
        /// </summary>
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
            string datosCurso = "'" + datos.getDatosPersona()["estado_alumno"] + "',";
            //query formacion academica
            string datosFormacionAcademica = "'" + datos.getDatosPersona()["formacion_nivel"] + "'," +
                                             "'" + datos.getDatosPersona()["formacion_ultimo_año_aprovado"] + "',";
            // query dirección           
            string datosDireccion = "'" + datos.getDatosPersona()["direccion_departamento"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_localidad"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_calle"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_referencia"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_numero_puerta"] + "'," +
                                    "'" + datos.getDatosPersona()["direccion_apartaento"] + "',";
            //query contacto
            string datosContacto = "'" + datos.getDatosPersona()["contacto_telefono"] + "'," +
                                   "'" + datos.getDatosPersona()["contacto_celular"] + "'," +
                                   "'" + datos.getDatosPersona()["contacto_email"] + "',";
            //query cobertura de salud
            string datosCoberura = "'" + datos.getDatosPersona()["cobertura_salud"] + "',";
            //query datos del hogar
            string datosHogar = "'" + datos.getDatosPersona()["hogar_jefe"] + "'," +
                                "'" + datos.getDatosPersona()["hogar_cantidad_hijos"] + "',";
            //query trabajo
            string datosTrabajo = "'" + datos.getDatosPersona()["trabajo_trabajo_alguna_vez"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_trabaja_actualmente"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_tiempo_desempleado"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_horas_jornada"] + "'," +
                                  "'" + datos.getDatosPersona()["trabajo_ingreso_mensual"] + "',";
            //query personas a cargo
            string datosPersonasCargo = "'" + datos.getDatosPersona()["personas_cargo_0_17"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_18_59"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_60_mas"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_con_discapacidad"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_cuenta_con_apoyo"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_carga_semanal_cuidado"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_trabajo_cuidando"] + "'," +
                                        "'" + datos.getDatosPersona()["personas_cargo_experiencia_instituciones_cuidado"] + "',";
            //query acceso a internet
            string datosAccesoInternet = "'" + datos.getDatosPersona()["internet_usa_internet"] + "'," +
                                         "'" + datos.getDatosPersona()["internet_facil_acceso"] + "'," +
                                         "'" + datos.getDatosPersona()["internet_medio_acceso"] + "';";

            //QUERY PRINCIPAL ***Incompleta***
            string query = "INSERT INTO alumno(cedula_alumno, nombre1, nombre2, apellido1, apellido2, fecha_nac, edad, sexo, estado_civil, estado, nivel_educativo, ultimo_año_aprobado, departamento, localidad, calle, referencia, numero_puerta, apartamento)"+
                "VALUES("+datosPersonales+datosCurso+datosFormacionAcademica+datosDireccion+datosContacto+datosCoberura+datosHogar+datosTrabajo+datosPersonasCargo+datosAccesoInternet+")";



        }




    }
}
