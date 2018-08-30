using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Ametrano.Logica;

namespace Ametrano.Persistencia
{

    class ConexionBD
    {
        TestingClass testing = new TestingClass();

        private MySqlConnection objetoDeConexion = new MySqlConnection();//Objeto de conexion sql
        private MySqlCommand comando = new MySqlCommand();
        private string[] serverConfiguracion = new string[5]; //array que guarda la configuracion de conexion
        /* Explicacion de los campos almacenados en el array
         * serverConfiguracion[0] : direccion del servidor de base de datos
         * serverConfiguracion[1] : nombre de la base de datos que se va a usar
         * serverConfiguracion[2] : usuario para ingresar
         * serverConfiguracion[3] : contraseña para ingresar
         * serverConfiguracion[4] : especifica si se va a usar ssl
         * */


        public ConexionBD()
        {
            obtenerConfiguracion();
            string stringConexion =
                "Server=" + serverConfiguracion[0] +
                ";Database=" + serverConfiguracion[1] +
                ";Uid=" + serverConfiguracion[2] +
                ";Pwd=" + serverConfiguracion[3] +
                ";sslMode=" + serverConfiguracion[4] +
                ";";
            objetoDeConexion.ConnectionString = stringConexion;
            dynamic[] datosRetornados = intentarConexion();
            if (datosRetornados[0])
            {
                comando.Connection = objetoDeConexion;
                
            } else
            {
                testing.MostrarMessageBox(datosRetornados[1]);
            }

           

        }
        private void obtenerConfiguracion()
        {//Metodo que obtiene la configuracion del servidor
            this.serverConfiguracion[0] = Properties.Settings.Default.direccion;
            this.serverConfiguracion[1] = Properties.Settings.Default.bd;
            this.serverConfiguracion[2] = Properties.Settings.Default.usuario;
            this.serverConfiguracion[3] = Properties.Settings.Default.contraseña;
            this.serverConfiguracion[4] = Properties.Settings.Default.ssl;

        }
        public dynamic[] intentarConexion()
        {//Este metodo intenta crear una conexion con el servidor

            dynamic[] datosParaRetornar = new dynamic[2];
            /*--Explicacion del array datosParaRetornar
             * 
             * datosParaRetornar[0]: Booleano dependiendo de si la conexion tuvo exito
             * datosParaRetornar[1]: Mensaje retornado
             */

            try
            {//se intenta abrir la conexion
                objetoDeConexion.Open();

                if (objetoDeConexion.State == System.Data.ConnectionState.Open)
                {//Verifico si la conexion esta abierta
                    datosParaRetornar[0] = true;
                    datosParaRetornar[1] = "Conexion abierta con exito el:" + DateTime.Now;
                }
                objetoDeConexion.Close();
            }
            catch (Exception e)
            {//Si se falla al crear la 
                datosParaRetornar[0] = false;
                datosParaRetornar[1] = "Error al abrir la conexion el: " + DateTime.Now + "\n Mensaje devuelto por MYSQL: \n" + e.Message;
            }
            return datosParaRetornar;
        }

        public MySqlConnection obtenerConexion()
        {//Geter de la conexion
            return objetoDeConexion;
        }
        public int insertarDatos(string comandoSQL)
        {//Metodo que inserta datos en la base de datos
            int filasAfectadas= 0;//Variable que guarda las filas afectadas
            comando.CommandText = comandoSQL;
            try
            {
                objetoDeConexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();//ejecuto la operacion
                objetoDeConexion.Close();

                testing.MostrarMessageBox("Filas Afectadas: " + filasAfectadas);
            }
            catch (MySqlException e)
            {
                if(objetoDeConexion.State == System.Data.ConnectionState.Open)
                {//Cierro la conexion si esta abierta
                    objetoDeConexion.Close();
                }
                testing.MostrarMessageBox(e.Message);
            }

            return filasAfectadas;
        }
        public MySqlDataAdapter consultarDatos(string comandoSQL)
        {//Metodo que realiza consultas a la base de datos y devuelve un datatable con los resultados
            MySqlDataAdapter datos = new MySqlDataAdapter();
            try
            {
                comando.CommandText = comandoSQL;
                datos.SelectCommand = comando;//Obtengo los datos de la base de datos
                return datos;
                
            }
            catch (MySqlException e)
            {
                if (objetoDeConexion.State == System.Data.ConnectionState.Open)
                {//Cierro la conexion si esta abierta
                    objetoDeConexion.Close();
                }
                testing.MostrarMessageBox(e.Message);
            }


            return null;
        }

        



    }
}
