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
        {
            bool variableParaRetornar = false;
            if(usuario.Equals("admin") && contrasenia.Equals("admin"))
            {
                variableParaRetornar = true;
            }else
            {
                variableParaRetornar = false;
            }



            return variableParaRetornar;
        }




    }
}
