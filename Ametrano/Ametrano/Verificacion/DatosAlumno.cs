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

            //Creacion de variables para uso general
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            //Comienza la verificacion de cedula
            bool cedulaNumerica = isNumeric(datosPersonalesRecividos[0]);

            if (cedulaNumerica)
            {//Si se cumplen todas las condiciones
                datosPersonales[0] = datosPersonalesRecividos[0];
            }else
            {
                mensajeParaRetornar += "\n La cedula contiene caracteres no permitidos";
            }

            //Comienza la verificacion de nombre1
            bool nombre1ConInt = intInString(datosPersonalesRecividos[1]);
            if (!nombre1ConInt)
            {
                datosPersonales[1] = datosPersonalesRecividos[1];
            }else
            {
                mensajeParaRetornar += "\n El primer nombre contiene numeros o caracteres no permitidos";
            }
            //Comienza la verificacion de nombre2
            bool nombre2ConInt = intInString(datosPersonalesRecividos[2]);
            if (!nombre2ConInt)
            {
                datosPersonales[2] = datosPersonalesRecividos[2];
            }else
            {
                mensajeParaRetornar += "\n El segundo nombre contiene numeros o caracteres no permitidos";
            }
            //Comienza la verificacion de apellido1
            bool apellido1ConInt = intInString(datosPersonalesRecividos[3]);
            if (!apellido1ConInt)
            {
                datosPersonales[3] = datosPersonalesRecividos[3];
            }
            else
            {
                mensajeParaRetornar += "\n El primer aoellido contiene numeros o caracteres no permitidos";
            }
            //Comienza la verificacion de apellido2
            bool apellido2ConInt = intInString(datosPersonalesRecividos[4]);
            if (!apellido1ConInt)
            {
                datosPersonales[4] = datosPersonalesRecividos[4];
            }
            else
            {
                mensajeParaRetornar += "\n El segundo aoellido contiene numeros o caracteres no permitidos";
            }
            //Comienza la verificacion de edad
            bool intEdad = isNumeric(datosPersonalesRecividos[6]);
            if (intEdad)
            {
                datosPersonales[6] = datosPersonalesRecividos[6];
            }
            else
            {
                mensajeParaRetornar += "\n La edad contiene texto  o caracteres no permitidos";
            }

            if (datosPersonalesRecividos[7].Equals("Hombre") || datosPersonalesRecividos[7].Equals("Mujer"))
            {
                datosPersonales[7] = datosPersonalesRecividos[7];
            }else
            {
                mensajeParaRetornar += "\n El sexo debe ser hombre o mujer";
            }
            datosPersonales[5] = datosPersonalesRecividos[5];
            datosPersonales[8] = datosPersonalesRecividos[8];

            if(cedulaNumerica && !nombre1ConInt && !nombre2ConInt && !apellido1ConInt && !apellido1ConInt && intEdad && (datosPersonalesRecividos[7].Equals("Hombre") || datosPersonalesRecividos[7].Equals("Mujer")))
            {//Si todas las verificaciones son correctas
                errores = false;
            }else
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
        public dynamic[] setCurso(string[] datosCursoRecibidos)
        {//metodo que guarda los datos del curso
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            datosCurso[0] = datosCursoRecibidos[0];
            datosCurso[1] = datosCursoRecibidos[1];
            errores = false;






            dynamic[] datosParaRetornar = new dynamic[2];
            /*Explicacion del array datosParaRetornar
             * datosParaRetornar[0] = -> variable bool que determina si hay errores o no en los datos
             * datosParaRetornar[1] = -> string con mensaje de error completo
             */
            datosParaRetornar[0] = errores;
            datosParaRetornar[1] = mensajeParaRetornar;
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
