using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Verificacion
{
    
    class DatosDocente
    {//Clase que almacena y valida los datos del docente
        private string[] datosPersonales;
        /*Explicacion de datosPersonales
         * datosPersonales[0] = -> Cedula
         * datosPersonales[1] = -> Nombre
         * datosPersonales[2] = -> Apellido
         * datosPersonales[3] = -> Direccion
         * datosPersonales[4] = -> Telefono
         * datosPersonales[5] = -> Email
         */

        private bool todosLosDatosCorrectos = false;

        public DatosDocente()
        {
            datosPersonales = new string[6];
        }
        public dynamic[] setDatosDocente(string[] datosDocenteRecibidos)
        { //Metodo que verifica los datos y los guarda en el array de la clase
            bool retorno = false;
            string mensajeParaRetornar = "Error encontrado en los siguientes campos";

            dynamic[] datosParaRetornar = new dynamic[2];//Variable que sera retornada por el metodo que contendra todos los datos


            if (isNumeric(datosDocenteRecibidos[0]))
            {//Se verifica la validez de la cedula
                retorno = true;
                todosLosDatosCorrectos = true;
                datosPersonales[0] = datosDocenteRecibidos[0];
            }else
            {
                retorno = false;
                todosLosDatosCorrectos = false;
                mensajeParaRetornar += "\n La cedula contiene caracteres no permitidos";
            }

            if (intInString(datosDocenteRecibidos[1]))
            {//Se verifica la validez del nombre
                retorno = true;
                todosLosDatosCorrectos = true;
                datosPersonales[1] = datosDocenteRecibidos[1];

            }
            else
            {
                retorno = false;
                todosLosDatosCorrectos = false;

                mensajeParaRetornar += "\n El nombre contiene caracteres no permitidos";
            }

            if (isNumeric(datosDocenteRecibidos[2]))
            {//Se verifica la validez del apellido
                retorno = true;
                todosLosDatosCorrectos = true;
                datosPersonales[2] = datosDocenteRecibidos[2];

            }
            else
            {
                retorno = false;
                todosLosDatosCorrectos = false;

                mensajeParaRetornar += "\n El apellido contiene caracteres no permitidos";
            }
            if (isNumeric(datosDocenteRecibidos[4]))
            {//Se verifica la validez del numero telefonico
                retorno = true;
                todosLosDatosCorrectos = true;
                datosPersonales[4] = datosDocenteRecibidos[4];

            }
            else
            {
                retorno = false;
                todosLosDatosCorrectos = false;
                mensajeParaRetornar += "\n El telefono contiene caracteres no permitidos";
            }

            datosPersonales[3] = datosDocenteRecibidos[3];
            datosPersonales[5] = datosDocenteRecibidos[5];



            datosParaRetornar[0] = retorno;
            datosParaRetornar[1] = mensajeParaRetornar;


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
        public bool obtenerDatos(out string[] datosPersonales)
        {
            
            if (todosLosDatosCorrectos)
            {
                datosPersonales = this.datosPersonales;
                return true;
            }else
            {
                datosPersonales = new string[1];
                return false;
            }
        }
        



    }
}
