using Ametrano.Persistencia;
using Ametrano.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ametrano.Logica
{
    class Principal_Controlador
    {
        public IDictionary<string, string> mapTextBox = new Dictionary<string, string>();
        ConexionBD objetoConexion = new ConexionBD();


        public void abrirConfiguracion()
        {
            Configuracion ventanaConfiguracion = new Configuracion();
            ventanaConfiguracion.Show();
        }
        public bool ingresarDocente(string cedula,string apellido1,string apellido2,string nombre1,string nombre2,string direccion,string telefono, string email)
        {//Metodo que ingresa datos en la base de datos
            string insert = "INSERT INTO DOCENTE VALUES('" + 
                cedula + "','" +
                nombre1 + " " +
                nombre2 + "','" + 
                apellido1 + " " + 
                apellido2 + "','" + 
                direccion + "','" + 
                telefono +"','" + 
                email + "');";
            int filasAfectadas = objetoConexion.insertarDatos(insert);


            


            return false;
        }

       








    }
}
