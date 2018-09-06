using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Verificacion
{
    
    class datosDocente
    {//Clase que almacena y valida los datos del docente
        private string[] datosPersonales;
        public datosDocente()
        {
            datosPersonales = new string[6];
        }
       public dynamic[] setDatosDocente(string[] datosDocenteRecibidos)
        {//Metodo que verifica los datos personales pasados 

            /*Explicacion del array datosPersonalesRecividos
             * datosPersonalesRecividos[0] = -> Cedula_docente
             * datosPersonalesRecividos[1] = -> Nombre
             * datosPersonalesRecividos[2] = -> Apellido
             * datosPersonalesRecividos[3] = -> Direccion
             * datosPersonalesRecividos[4] = -> Telefono
             * datosPersonalesRecividos[5] = -> Email
             */
            bool[] verificaciones = new bool[4];
            /* verificaciones[0] = -> cedula
             * verificaciones[1] = -> nombre
             * verificaciones[2] = -> apellido
             * verificaciones[3] = -> telefono
             */

            //Vendecidos if en una linea los cuales analizan y si es true es que no hubieron errores

            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            if (isNumeric(datosDocenteRecibidos[0]))
            {//Verificacion de la cedula
                verificaciones[0] = true;
            }
            else{
                mensajeParaRetornar += "\n La cedula contiene caracteres no permitidos";
                verificaciones[0] = false;
            }

            if (!intInString(datosDocenteRecibidos[1]))
            {//Verificacion del nombre
                verificaciones[1] = true;
            }
            else
            {
                mensajeParaRetornar += "\n El nombre contiene caracteres no permitidos";
                verificaciones[1] = false;
            }
            if (!intInString(datosDocenteRecibidos[2]))
            {//Verificacion del apellido
                verificaciones[2] = true;
            }
            else
            {
                mensajeParaRetornar += "\n El apellido contiene caracteres no permitidos";
                verificaciones[2] = false;
            }
            if (isNumeric(datosDocenteRecibidos[4]))
            {//Verificacion del numero telefonico
                verificaciones[3] = true;
            }
            else
            {
                mensajeParaRetornar += "\n El numero telefonico contiene caracteres no permitidos";
                verificaciones[3] = false;
            }

            
            if (verificaciones[0] && verificaciones[1] && verificaciones[2] && verificaciones[3])
            {//Si todos estan correctos
                this.datosPersonales[0] = datosDocenteRecibidos[0];
                this.datosPersonales[1] = datosDocenteRecibidos[1];
                this.datosPersonales[2] = datosDocenteRecibidos[2];
                this.datosPersonales[3] = datosDocenteRecibidos[3];
                this.datosPersonales[4] = datosDocenteRecibidos[4];
                this.datosPersonales[5] = datosDocenteRecibidos[5];
                errores = false;
            }else
            {
                errores = true;
            }


            dynamic[] datosParaRetornar = new dynamic[2]{ errores, mensajeParaRetornar };

            return datosParaRetornar;
        }

        public bool isNumeric(string str)
        {
            int numParsed;
            if (int.TryParse(str, out numParsed))
            {
                return true;
            }
            else
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
                if (int.TryParse("" + textArray[i], out varAux))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
