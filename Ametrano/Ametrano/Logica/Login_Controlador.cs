using Ametrano.Presentacion;
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
        {//Funcion que verifica que el usuario y la contraseña existan y sean correctos
            bool variableParaRetornar = false;

            //Se verifican usuario y contraseña
            if(usuario.Equals("admin") && contrasenia.Equals("admin"))
            {//Si el usuario y la contraseña coinciden muestro la ventana y retorno true
                Principal ventanaPrincipal = new Principal();
                ventanaPrincipal.Show();
                variableParaRetornar = true;
            }else
            {//Sino retorno false
                variableParaRetornar = false;
            }

            return variableParaRetornar;
        }




    }
}
