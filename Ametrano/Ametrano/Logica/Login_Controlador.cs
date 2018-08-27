using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
    class Login_Controlador
    {
        public bool loginbtn_function(String usuario, String contrasenia)
        {   //Metodo que verifica que el usuario y la contraseña existan y sean correctos
            bool variableParaRetornar = false;//C
            if(usuario.Equals("admin") && contrasenia.Equals("admin"))
            {
                variableParaRetornar = true;
            }
            else{
                variableParaRetornar = false;
            }



            return variableParaRetornar;
        }




    }
}
