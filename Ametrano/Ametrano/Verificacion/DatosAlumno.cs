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
        private string[] datosCurso = new string[2];//
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

            /*Explicacion del array datosPersonalesRecividos
             * datosPersonalesRecividos[0] = -> cedula_alumno
             * datosPersonalesRecividos[1] = -> nombre1
             * datosPersonalesRecividos[2] = -> nombre2
             * datosPersonalesRecividos[3] = -> apellido1
             * datosPersonalesRecividos[4] = -> apellido2
             * datosPersonalesRecividos[5] = -> fecha_nac
             * datosPersonalesRecividos[6] = -> edad
             * datosPersonalesRecividos[7] = -> sexo
             * datosPersonalesRecividos[8] = -> estado_civil
             */

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

            datosCurso[0] = datosCursoRecibidos[0];
            datosCurso[1] = datosCursoRecibidos[1];
            

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
            /*Explicacion del array datosPersonalesRecividos
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
             * personas_a_cargo[1] = -> De 0 a 17
             * personas_a_cargo[2] = -> De 0 a 17
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
