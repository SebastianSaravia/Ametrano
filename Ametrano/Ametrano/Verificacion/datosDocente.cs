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
        public DatosDocente()
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
            bool[] verificaciones = new bool[12];
            /* verificaciones[0] = -> cedula
             * verificaciones[1] = -> nombre
             * verificaciones[2] = -> apellido
             * verificaciones[3] = -> telefono
             * verificaciones[4] = -> longitud de la cedula
             * verificaciones[5] = -> longitud del numero telefonico
             * verificaciones[6] = -> cedula es igual a placeholder
             * verificaciones[7] = -> nombre es igual a placeholder
             * verificaciones[8] = -> apellido es igual a placeholder
             * verificaciones[9] = -> direccion es igual a placeholder
             * verificaciones[10] = -> telefono es igual a placeholder
             * verificaciones[11] = -> email es igual a placeholder
             * 
             */

            //Vendecidos if en una linea los cuales analizan y si es true es que no hubieron errores

            string mensajeParaRetornar = "Error encontrado en los siguientes campos";
            bool errores = false;

            if (datosDocenteRecibidos[0].Equals("Cedula"))
            { //Si la cedula es igual al placeholder
                mensajeParaRetornar += "\n La cedula esta vacia";
                verificaciones[6] = false;
            }else
            {//Si la cedula no es el placeholder
                verificaciones[6] = true;
                if (datosDocenteRecibidos[0].Length >= 8)
                {//Verificacion de la longitud de la cedula
                    verificaciones[4] = true;

                    if (isNumeric(datosDocenteRecibidos[0]))
                    {//Verificacion de la cedula
                        verificaciones[0] = true;
                    }

                    else
                    {
                        mensajeParaRetornar += "\n La cedula contiene caracteres no permitidos";
                        verificaciones[0] = false;
                    }
                }
                else
                {
                    mensajeParaRetornar += "\n La longitud de la cedula no es valida";
                    verificaciones[4] = false;
                }
            }

            
            if(datosDocenteRecibidos[1].Equals("Primer nombre"))
            {//Si el nombre es igual al placeholder
                mensajeParaRetornar += "\n el nombre esta vacio";
                verificaciones[7] = false;
            }else
            {
                verificaciones[7] = true;
                if (!intInString(datosDocenteRecibidos[1]))
                {//Verificacion del nombre
                    verificaciones[1] = true;
                }
                else
                {
                    mensajeParaRetornar += "\n El nombre contiene caracteres no permitidos";
                    verificaciones[1] = false;
                }
            }
            
           if(datosDocenteRecibidos[2].Equals("Primer apellido"))
            {//Si el apellido es igual al placeholder
                mensajeParaRetornar += "\n El apellido esta vacio";
                verificaciones[8] = false;
            }else
            {//Sino
                verificaciones[8] = true;
                if (!intInString(datosDocenteRecibidos[2]))
                {//Verificacion del apellido
                    verificaciones[2] = true;
                }
                else
                {
                    mensajeParaRetornar += "\n El apellido contiene caracteres no permitidos";
                    verificaciones[2] = false;
                }
            }
            if (datosDocenteRecibidos[4].Equals("Telefono"))
            {//Si el telefono es igual al placeholder
                mensajeParaRetornar += "\n El telefono esta vacio";
                verificaciones[10] = false;
            }
            else
            {
                verificaciones[10] = true;
                if (datosDocenteRecibidos[4].Length >= 8 && datosDocenteRecibidos[4].Length <= 12)
                {//Verificacion de la longitud del numero telefonico
                    verificaciones[5] = true;

                    if (isNumeric(datosDocenteRecibidos[4]))
                    {//Verificacion del numero telefonico
                        verificaciones[3] = true;
                    }
                    else
                    {
                        mensajeParaRetornar += "\n El numero telefonico contiene caracteres no permitidos";
                        verificaciones[3] = false;
                    }
                }
                else
                {
                    mensajeParaRetornar += "\n La longitud del numero telefonico no es valida";
                    verificaciones[5] = false;
                }
            }
            if (datosDocenteRecibidos[3].Equals("Direccion"))
            {
                mensajeParaRetornar += "\n La direccion esta vacia";
                verificaciones[9] = false;
            }else
            {
                verificaciones[9] = true;
            }
            if (datosDocenteRecibidos[5].Equals("Email"))
            {
                mensajeParaRetornar += "\n El email esta vacio";
                verificaciones[11] = false;
            }else
            {
                verificaciones[11] = true;
            }
            

            


            if (verificaciones[0] && verificaciones[1] && verificaciones[2] && verificaciones[3] && verificaciones[4] && verificaciones[5] && verificaciones[6] && verificaciones[7] && verificaciones[8] && verificaciones[9] && verificaciones[10] && verificaciones[11] )
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
            long numParsed;
            if (long.TryParse(str, out numParsed))
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
