using Ametrano.Persistencia;
using Ametrano.Presentacion;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ametrano.Logica;

namespace Ametrano.Logica
{
    class Login_Controlador
    {
        ConexionBD objetoConexion = new ConexionBD(true);
        TestingClass testing = new TestingClass();
        public bool loginbtn_function(String usuario, String contraseña)
        {//Funcion que verifica que el usuario y la contraseña existan y sean correctos
            bool variableParaRetornar = false;
            DataTable datosRetornados = new DataTable(); //Datatable que guardara la informacion de la base de datos

            string[] informacionDeUsuario = new string[2];//Array que almacena la informacion obtenida del usuario desde la base de datos

            //Se verifican usuario y contraseña
            string consultaUsuario = "SELECT usuario,rol from cuenta_usuario where usuario = '" + usuario + "' and contraseña = '" + contraseña + "';";

            

           try
            {
                MySqlDataAdapter datos = objetoConexion.consultarDatos(consultaUsuario);//Obtengo los datos de la base de datos
                datos.Fill(datosRetornados);//Paso los datos al datatable
                byte count = 0;
                foreach (DataRow fila in datosRetornados.Rows)
                {//Bucle for que me permite recorrer el datatable para obtener los datos
                    foreach (DataColumn columna in datosRetornados.Columns)
                    {
                        if (count == 0)
                        {
                            informacionDeUsuario[0] = fila[columna].ToString();//agrego el usuario a el array
                            count++;
                        }
                        else{
                            informacionDeUsuario[1] = fila[columna].ToString(); //agrego el rol al array
                        }
                       
                        
                    }
                }
            }
            catch(Exception e)
            {
                testing.MostrarMessageBox("Error de loginControlador.Loginbtn" + e.Message);
            }
       
            if(informacionDeUsuario[0] == usuario)
            {//Si el usuario obtenido desde la base de datos coincide con el usuario ingresado entonces se muestra el mensaje
                Properties.Settings.Default.user_usuario = "root";
                Properties.Settings.Default.user_contraseña = "";
                Properties.Settings.Default.user_rol = informacionDeUsuario[1];
                Principal ventanaPrincipal = new Principal();//Creo nueva ventana principal
                ventanaPrincipal.Show();//muestro la ventana
                variableParaRetornar = true;
            }
            else
            {
                variableParaRetornar = false;
            }
                return variableParaRetornar;
        }




    }
}
