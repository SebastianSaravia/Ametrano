using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Encapsulado
{
    class DatosAlumno
    {
        private string[] datosPersonales = new string[9];//
        private string[] datosCurso = new string[4];//
        private string[] formacionAcademica = new string[2];//
        private string[] direccion = new string[6];//
        private string[] contacto = new string[3];
        private string coberturaSalud = "";
        private string[] hogar = new string[2];
        private string[] trabajo = new string[5];
        private string[] personas_a_cargo = new string[8];
        private string[] acceso_a_internet = new string[3];
        




        public dynamic[] setDatosPersonales(string[] datosPersonalesRecividos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            dynamic[] datosParaRetornar = new dynamic[2];

           

            //Se deben realizar verificaciones
            datosPersonales[0] = datosPersonalesRecividos[0];
            datosPersonales[1] = datosPersonalesRecividos[1];
            datosPersonales[2] = datosPersonalesRecividos[2];
            datosPersonales[3] = datosPersonalesRecividos[3];
            datosPersonales[4] = datosPersonalesRecividos[4];
            datosPersonales[5] = datosPersonalesRecividos[5];
            datosPersonales[6] = datosPersonalesRecividos[6];
            datosPersonales[7] = datosPersonalesRecividos[7];
            datosPersonales[8] = datosPersonalesRecividos[8];

           

            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;

            return datosParaRetornar;
        }
        public dynamic[] setCurso(string[] datosCursoRecibidos)
        {//metodo que guarda los datos del curso
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion de datosCursos
             * datosCurso[0] = -> curso
             * datosCurso[1] = -> estado
             * datosCurso[2] = -> periodo
             * datosCurso[3] = -> viatico por dia asistido
             */

            datosCurso[0] = datosCursoRecibidos[0];
            datosCurso[1] = datosCursoRecibidos[1];
            datosCurso[2] = datosCursoRecibidos[2];
            datosCurso[3] = datosCursoRecibidos[3];


            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            datosCurso[0] = datosCursoRecibidos[0];
            datosCurso[1] = datosCursoRecibidos[1];

            return datosParaRetornar;
        }
        public dynamic[] setFormacionAcademica(string[] datosFormacionAcademicaRecibidos)
        {//metodo que guarda los datos de formacion academica
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            formacionAcademica[0] = datosFormacionAcademicaRecibidos[0];
            formacionAcademica[1] = datosFormacionAcademicaRecibidos[1];





            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setDireccion(string[] datosDireccionRecibidos)
        {//Metodo que almacena la direccion 
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosDireccionrecividos
             * direccion[0] = -> Departamento
             * direccion[1] = -> Localidad
             * direccion[2] = -> Calle
             * direccion[3] = -> Referencia
             * direccion[4] = -> Numero de puerta
             * direccion[5] = -> Apartamento
             */

            //Guardo los datos
            direccion[0] = datosDireccionRecibidos[0];
            direccion[1] = datosDireccionRecibidos[1];
            direccion[2] = datosDireccionRecibidos[2];
            direccion[3] = datosDireccionRecibidos[3];
            direccion[4] = datosDireccionRecibidos[4];
            direccion[5] = datosDireccionRecibidos[5];

            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setContacto(string[] datosContactoRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosPersonalesRecividos
             * contacto[0] = -> Telefono
             * contacto[1] = -> Celular
             * contacto[2] = -> Email
             */

            //Guardo los datos
            contacto[0] = datosContactoRecibidos[0];
            contacto[1] = datosContactoRecibidos[1];
            contacto[2] = datosContactoRecibidos[2];
            
            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setCobertura(string datosCoberturaRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

     
            //Guardo los datos
            coberturaSalud = datosCoberturaRecibidos;

            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setHogar(string[] datosHogarRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosPersonalesRecividos
             * hogar[0] = -> JefeHogar
             * hogar[1] = -> Cantidad de hijos

             */

            //Guardo los datos
            hogar[0] = datosHogarRecibidos[0];
            hogar[1] = datosHogarRecibidos[1];
          

            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setTrabajo(string[] datosTrabajoRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosPersonalesRecividos
             * trabajo[0] = -> Trabajo alguna vez
             * trabajo[1] = -> Trabaja actualmente
             * trabajo[2] = -> Tiempo desempleado
             * trabajo[3] = -> Horas de jornada
             * trabajo[4] = -> Ingreso mensual
             */

            //Guardo los datos
            trabajo[0] = datosTrabajoRecibidos[0];
            trabajo[1] = datosTrabajoRecibidos[1];
            trabajo[2] = datosTrabajoRecibidos[2];
            trabajo[3] = datosTrabajoRecibidos[3];
            trabajo[4] = datosTrabajoRecibidos[4];


            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setPersonasACargo(string[] DatosPersonas_A_CargoRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosPersonalesRecividos
             * personas_a_cargo[0] = -> De 0 a 17
             * personas_a_cargo[1] = -> De 18 a 59
             * personas_a_cargo[2] = -> De 60 o mas
             * personas_a_cargo[3] = -> Persona con discapacidad
             * personas_a_cargo[4] = -> Cuenta con apoyo
             * personas_a_cargo[5] = -> Carga semanal de cuidado
             * personas_a_cargo[6] = -> Trabajo cuidando
             * personas_a_cargo[7] = -> Experiencia en instituciones de cuidado 
             */

            //Guardo los datos
            personas_a_cargo[0] = DatosPersonas_A_CargoRecibidos[0];
            personas_a_cargo[1] = DatosPersonas_A_CargoRecibidos[1];
            personas_a_cargo[2] = DatosPersonas_A_CargoRecibidos[2];
            personas_a_cargo[3] = DatosPersonas_A_CargoRecibidos[3];
            personas_a_cargo[4] = DatosPersonas_A_CargoRecibidos[4];
            personas_a_cargo[5] = DatosPersonas_A_CargoRecibidos[5];
            personas_a_cargo[6] = DatosPersonas_A_CargoRecibidos[6];
            personas_a_cargo[7] = DatosPersonas_A_CargoRecibidos[7];
         

            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }
        public dynamic[] setAccessoInternet(string[] datosAccessoInternetRecibidos)
        {
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;
            /*Explicacion del array datosPersonalesRecividos
             * acceso_a_internet[0] = -> Usa internet
             * acceso_a_internet[1] = -> Facil accesso internet
             * acceso_a_internet[2] = -> Medio accesso internet
             */

            //Guardo los datos
            acceso_a_internet[0] = datosAccessoInternetRecibidos[0];
            acceso_a_internet[1] = datosAccessoInternetRecibidos[1];
            acceso_a_internet[2] = datosAccessoInternetRecibidos[2];
           


            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }

        public IDictionary<string,string> getDatosPersona()
        {
            //Diccionario que almacena los datos de la persona
            IDictionary<string, string> diccionarioPersona = new Dictionary<string, string>();

        //Datos personales
        diccionarioPersona.Add("cedula_alumno", datosPersonales[0]);
            diccionarioPersona.Add("nombre1", datosPersonales[1]);
            diccionarioPersona.Add("nombre2", datosPersonales[2]);
            diccionarioPersona.Add("apellido1", datosPersonales[3]);
            diccionarioPersona.Add("apellido2", datosPersonales[4]);
            diccionarioPersona.Add("fecha_nac", datosPersonales[5]);
            diccionarioPersona.Add("edad", datosPersonales[6]);
            diccionarioPersona.Add("sexo", datosPersonales[7]);
            diccionarioPersona.Add("estado_civil", datosPersonales[8]);

            //Datos de curso
           
            diccionarioPersona.Add("curso_alumno", datosCurso[0]);
            diccionarioPersona.Add("curso_estado", datosCurso[1]);
            diccionarioPersona.Add("curso_periodo", datosCurso[2]);
            diccionarioPersona.Add("curso_monto_viatico", datosCurso[3]);

            //Formacion academica

            diccionarioPersona.Add("formacion_nivel", formacionAcademica[0]);
            diccionarioPersona.Add("formacion_ultimo_año_aprovado", formacionAcademica[1]);

            //Direccion

            diccionarioPersona.Add("direccion_departamento", direccion[0]);
            diccionarioPersona.Add("direccion_localidad", direccion[1]);
            diccionarioPersona.Add("direccion_calle", direccion[2]);
            diccionarioPersona.Add("direccion_referencia", direccion[3]);
            diccionarioPersona.Add("direccion_numero_puerta", direccion[4]);
            diccionarioPersona.Add("direccion_apartamento", direccion[5]);

            //Contacto

            diccionarioPersona.Add("contacto_telefono", contacto[0]);
            diccionarioPersona.Add("contacto_celular", contacto[1]);
            diccionarioPersona.Add("contacto_email", contacto[2]);

            //Cobertura

            diccionarioPersona.Add("cobertura_salud",coberturaSalud);

            //Hogar

            diccionarioPersona.Add("hogar_jefe", hogar[0]);
            diccionarioPersona.Add("hogar_cantidad_hijos", hogar[1]);

            //Trabajo

            diccionarioPersona.Add("trabajo_trabajo_alguna_vez", trabajo[0]);
            diccionarioPersona.Add("trabajo_trabaja_actualmente", trabajo[1]);
            diccionarioPersona.Add("trabajo_tiempo_desempleado", trabajo[2]);
            diccionarioPersona.Add("trabajo_horas_jornada", trabajo[3]);
            diccionarioPersona.Add("trabajo_ingreso_mensual", trabajo[4]);

            //Personas a cargo

            diccionarioPersona.Add("personas_cargo_0_17", personas_a_cargo[0]);
            diccionarioPersona.Add("personas_cargo_18_59", personas_a_cargo[1]);
            diccionarioPersona.Add("personas_cargo_60_mas", personas_a_cargo[2]);
            diccionarioPersona.Add("personas_cargo_con_discapacidad", personas_a_cargo[3]);
            diccionarioPersona.Add("personas_cargo_cuenta_con_apoyo", personas_a_cargo[4]);
            diccionarioPersona.Add("personas_cargo_carga_semanal_cuidado", personas_a_cargo[5]);
            diccionarioPersona.Add("personas_cargo_trabajo_cuidando", personas_a_cargo[6]);
            diccionarioPersona.Add("personas_cargo_experiencia_instituciones_cuidado", personas_a_cargo[7]);

            //Acceso a internet

            diccionarioPersona.Add("internet_usa_internet", acceso_a_internet[0]);
            diccionarioPersona.Add("internet_facil_acceso", acceso_a_internet[1]);
            diccionarioPersona.Add("internet_medio_acceso", acceso_a_internet[2]);


            return diccionarioPersona;
        }

        public dynamic[] rellenarDesdeDiccionario(IDictionary<string,string> diccionario)
        {//Este metodo toma un diccionario que fue devuelto desde la bd y rellena el objeto devolviendo bool de exito y mensaje de estado
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            string[] datosPersonales_paraInsertar = new string[9];
            string[] datosCurso_paraInsertar = new string[4];
            string[] formacionAcademica_paraInsertar = new string[2];
            string[] direccion_paraInsertar = new string[6];
            string[] contacto_paraInsertar = new string[3];
            string coberturaSalud_paraInsertar = "";
            string[] hogar_paraInsertar = new string[2];
            string[] trabajo_paraInsertar = new string[5];
            string[] personas_a_cargo_paraInsertar = new string[8];
            string[] acceso_a_internet_paraInsertar = new string[3];

            //Comienza creacion de string de datosPersonales

            diccionario.TryGetValue("cedula_alumno", out datosPersonales_paraInsertar[0]);
            diccionario.TryGetValue("nombre1", out datosPersonales_paraInsertar[1]);
            diccionario.TryGetValue("nombre2", out datosPersonales_paraInsertar[2]);
            diccionario.TryGetValue("apellido1", out datosPersonales_paraInsertar[3]);
            diccionario.TryGetValue("apellido2", out datosPersonales_paraInsertar[4]);
            diccionario.TryGetValue("fecha_nac", out datosPersonales_paraInsertar[5]);
            DateTime fechaNacimiento = DateTime.Parse(datosPersonales_paraInsertar[5]);
            datosPersonales_paraInsertar[5] = fechaNacimiento.ToString("yyyy-MM-dd");
            diccionario.TryGetValue("edad", out datosPersonales_paraInsertar[6]);
            diccionario.TryGetValue("sexo", out datosPersonales_paraInsertar[7]);
            diccionario.TryGetValue("estado_civil", out datosPersonales_paraInsertar[8]);

            dynamic[] datosPersonalesFeedback = setDatosPersonales(datosPersonales_paraInsertar);

            if (datosPersonalesFeedback[0])
            {
                mensajeParaRetornar += datosPersonalesFeedback[1];
            }

            //Ahora se realizara la insercion de datos de curso

            //agregar nombre curso despues
            diccionario.TryGetValue("nombre_curso", out datosCurso_paraInsertar[0]);
            diccionario.TryGetValue("estado", out datosCurso_paraInsertar[1]);
            diccionario.TryGetValue("monto_viatico_por_dia", out datosCurso_paraInsertar[3]);
            datosCurso_paraInsertar[2] = "Periodo proximamente a implementar";

            dynamic[] datosCursoFeedback = setCurso(datosCurso_paraInsertar);

            if (datosCursoFeedback[0])
            {
                mensajeParaRetornar += datosCursoFeedback[1];
            }

            //comienza nivel educativo

            diccionario.TryGetValue("nivel_educativo", out formacionAcademica_paraInsertar[0]);
            diccionario.TryGetValue("ultimo_anio_aprobado", out formacionAcademica_paraInsertar[1]);

            dynamic[] datosFormacionAcademicaFeedback = setFormacionAcademica(formacionAcademica_paraInsertar);

            if (datosFormacionAcademicaFeedback[0])
            {
                mensajeParaRetornar += datosFormacionAcademicaFeedback[1];
            }

            //Comienza direccion

            diccionario.TryGetValue("departamento", out direccion_paraInsertar[0]);
            diccionario.TryGetValue("localidad", out direccion_paraInsertar[1]);
            diccionario.TryGetValue("calle", out direccion_paraInsertar[2]);
            diccionario.TryGetValue("referencia", out direccion_paraInsertar[3]);
            diccionario.TryGetValue("numero_puerta", out direccion_paraInsertar[4]);
            diccionario.TryGetValue("apartamento", out direccion_paraInsertar[5]);

            dynamic[] datosDiireccionFeedback = setDireccion(direccion_paraInsertar);

            if (datosDiireccionFeedback[0])
            {
                mensajeParaRetornar += datosDiireccionFeedback[1];
            }

            //Comienza contacto


            diccionario.TryGetValue("telefono_fijo", out contacto_paraInsertar[0]);
            diccionario.TryGetValue("celular", out contacto_paraInsertar[1]);
            diccionario.TryGetValue("email", out contacto_paraInsertar[2]);


            dynamic[] datosContactoFeedback = setContacto(contacto_paraInsertar);

            if (datosContactoFeedback[0])
            {
                mensajeParaRetornar += datosContactoFeedback[1];
            }

            //Comienza coberturna


            diccionario.TryGetValue("cobertura_salud", out coberturaSalud_paraInsertar);

            dynamic[] datosCoberturaFeedback = setCobertura(coberturaSalud_paraInsertar);

            if (datosCoberturaFeedback[0])
            {
                mensajeParaRetornar += datosCoberturaFeedback[1];
            }

            //Comienza hogar

            diccionario.TryGetValue("jefe_hogar", out hogar_paraInsertar[0]);

            if (hogar_paraInsertar[0].Equals("True"))
            {
                hogar_paraInsertar[0] = "SI";
            }else
            {
                hogar_paraInsertar[0] = "NO";
            }

            diccionario.TryGetValue("cant_hijos", out hogar_paraInsertar[1]);

            dynamic[] datosHogarFeedback = setHogar(hogar_paraInsertar);

            if (datosHogarFeedback[0])
            {
                mensajeParaRetornar += datosHogarFeedback[1];
            }

            //Comienza trabajo

            diccionario.TryGetValue("trabajo_alguna_vez", out trabajo_paraInsertar[0]);

            if (trabajo_paraInsertar[0].Equals("True"))
            {
                trabajo_paraInsertar[0] = "SI";
            }
            else
            {
                trabajo_paraInsertar[0] = "NO";
            }

            diccionario.TryGetValue("trabaja_actualmente", out trabajo_paraInsertar[1]);
            if (trabajo_paraInsertar[1].Equals("True"))
            {
                trabajo_paraInsertar[1] = "SI";
            }
            else
            {
                trabajo_paraInsertar[1] = "NO";
            }

            diccionario.TryGetValue("tiempo_sin_trabajo", out trabajo_paraInsertar[2]);
            diccionario.TryGetValue("horas_trabajo", out trabajo_paraInsertar[3]);
            diccionario.TryGetValue("ingreso_mensual", out trabajo_paraInsertar[4]);

            dynamic[] datosTrabajoFeedback = setTrabajo(trabajo_paraInsertar);

            if (datosTrabajoFeedback[0])
            {
                mensajeParaRetornar += datosTrabajoFeedback[1];
            }

            //Comienza personas a cargo

            diccionario.TryGetValue("cant_personas_cargo_17", out personas_a_cargo_paraInsertar[0]);
            diccionario.TryGetValue("cant_personas_cargo_18_59", out personas_a_cargo_paraInsertar[1]);
            diccionario.TryGetValue("cant_personas_cargo_60", out personas_a_cargo_paraInsertar[2]);
            diccionario.TryGetValue("persona_tiene_discapacidad", out personas_a_cargo_paraInsertar[3]);
            if (personas_a_cargo_paraInsertar[3].Equals("True"))
            {
                personas_a_cargo_paraInsertar[3] = "SI";
            }else
            {
                personas_a_cargo_paraInsertar[3] = "NO";
            }

            diccionario.TryGetValue("cuenta_con_apoyo", out personas_a_cargo_paraInsertar[4]);
            if (personas_a_cargo_paraInsertar[4].Equals("True"))
            {
                personas_a_cargo_paraInsertar[4] = "SI";
            }
            else
            {
                personas_a_cargo_paraInsertar[4] = "NO";
            }
            diccionario.TryGetValue("carga_semanal_cuidado", out personas_a_cargo_paraInsertar[5]);
            diccionario.TryGetValue("trabajo_anteriormente_cuidando", out personas_a_cargo_paraInsertar[6]);
            if (personas_a_cargo_paraInsertar[6].Equals("True"))
            {
                personas_a_cargo_paraInsertar[6] = "SI";
            }
            else
            {
                personas_a_cargo_paraInsertar[6] = "NO";
            }

            diccionario.TryGetValue("experiencia_instituciones_cuidado", out personas_a_cargo_paraInsertar[7]);

            dynamic[] datosPersonasACargoFeedback = setPersonasACargo(personas_a_cargo_paraInsertar);

            if (datosPersonasACargoFeedback[0])
            {
                mensajeParaRetornar += datosPersonasACargoFeedback[1];
            }


            //Comienza acceso a internet

            diccionario.TryGetValue("usa_internet", out acceso_a_internet_paraInsertar[0]);
            if (acceso_a_internet_paraInsertar[0].Equals("True"))
            {
                acceso_a_internet_paraInsertar[0] = "SI";
            }
            else
            {
                acceso_a_internet_paraInsertar[0] = "NO";
            }
            diccionario.TryGetValue("facil_acceso_internet", out acceso_a_internet_paraInsertar[1]);
            if (acceso_a_internet_paraInsertar[1].Equals("True"))
            {
                acceso_a_internet_paraInsertar[1] = "SI";
            }
            else
            {
                acceso_a_internet_paraInsertar[1] = "NO";
            }
            diccionario.TryGetValue("medio_acceso_internet", out acceso_a_internet_paraInsertar[2]);

            dynamic[] datosAccesoInternetFeedback = setAccessoInternet(acceso_a_internet_paraInsertar);

            if (datosAccesoInternetFeedback[0])
            {
                mensajeParaRetornar += datosAccesoInternetFeedback[1];
            }






            if (!datosPersonalesFeedback[0] && !datosCursoFeedback[0] && !datosFormacionAcademicaFeedback[0] && !datosDiireccionFeedback[0] && !datosContactoFeedback[0] && !datosCoberturaFeedback[0] && !datosHogarFeedback[0] && !datosTrabajoFeedback[0] && !datosPersonasACargoFeedback[0] && !datosAccesoInternetFeedback[0])
            {
                errores = false;
            }
            else
            {
                errores = true;
            }


            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
            return datosParaRetornar;
        }


        public bool isNumeric(string str)
        {
            int numParsed;
            if(int.TryParse(str, out numParsed)){
                return true;
            }else
            {
                return false;
            }
        }

        public bool intInString(string str)
        {
            int varAux;
            char[] textArray = str.ToArray();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (int.TryParse(""+textArray[i], out varAux)){
                    return true;
                }
            }

            return false;
        }

    }
}
