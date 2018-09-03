using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Encapsulado
{
    class DatosAlumno
    {
        private string[] datosPersonales = new string[9];
        private string[] datosCurso = new string[2];
        private string[] formacionAcademica = new string[2];
        private string[] direccion = new string[6];
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
            string mensajeParaRetornar = "";
            bool errores = false;

            //Comienza la verificacion de errores
            bool cedulaNumerica = isNumeric(datosPersonalesRecividos[0]);

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
