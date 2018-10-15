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
using System.Windows.Forms;

namespace Ametrano.Logica
{
    class Login_Controlador
    {
        ConexionBD objetoConexion = new ConexionBD(true);
        TestingClass testing = new TestingClass();
        public bool loginbtn_function(String usuario, String contraseña,out string mensaje)
        {//Funcion que verifica que el usuario y la contraseña existan y sean correctos
            bool variableParaRetornar = false;
            mensaje = "";
            DataTable datosRetornados = new DataTable(); //Datatable que guardara la informacion de la base de datos

            string[] informacionDeUsuario = new string[3];//Array que almacena la informacion obtenida del usuario desde la base de datos

            //Se verifican usuario y contraseña
            string consultaUsuario = "SELECT usuario,rol,notas  from cuenta_usuario where usuario = '" + usuario + "' and contraseña = '" + contraseña + "' and estado = 1;";

            
            try
            {
                MySqlDataAdapter datos = objetoConexion.consultarDatos(consultaUsuario);//Obtengo los datos de la base de datos
                datos.Fill(datosRetornados);//Paso los datos al datatable
                
                byte count = 0;
                foreach (DataRow fila in datosRetornados.Rows)
                {//Bucle for que me permite recorrer el datatable para obtener los datos
                    foreach (DataColumn columna in datosRetornados.Columns)
                    {
                        
                            informacionDeUsuario[count] = fila[count].ToString();//agrego el usuario a el array
                            count++;
                       
                        }
                                              
                    
                }
            }
            catch(Exception e)
            {
                mensaje = "Error al conectar con el servidor";
            }

       
            if(informacionDeUsuario[0] == usuario)
            {//Si el usuario obtenido desde la base de datos coincide con el usuario ingresado entonces se muestra el mensaje
                Properties.Settings.Default.user_usuario = "user";
                Properties.Settings.Default.user_contraseña = "arekushizu";
                Properties.Settings.Default.user_rol = informacionDeUsuario[1];
                mensaje = "Sin errores";
                Principal ventanaPrincipal = new Principal();//Creo nueva ventana principal
                NotasVersion nv = new NotasVersion();
                ventanaPrincipal.Show();//muestro la ventana
                bool val = false;
                if (informacionDeUsuario[2]=="1")
                {
                    val = true;
                }
                if (val==true)
                {
                    nv.ShowDialog();
                    objetoConexion = new ConexionBD();
                    string query="update cuenta_usuario SET notas='0' WHERE usuario='"+informacionDeUsuario[0]+"'";
                    int datos2 = objetoConexion.sqlInsertUpdate(query);



                }



                

                variableParaRetornar = true;
            }
            else
            {
                variableParaRetornar = false;
                if (!mensaje.Equals("Error al conectar con el servidor"))
                {
                    mensaje = "Usuario o contraseña incorrectos\nVuelva a intentarlo";
                }
                
            }
                return variableParaRetornar;
        }




    }
}
