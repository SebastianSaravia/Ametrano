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
        public void abrirConfiguracion()
        {
            Configuracion ventanaConfiguracion = new Configuracion();
            ventanaConfiguracion.Show();
        }

        private void placeholderEventEnter(object sender, EventArgs e)
        {

            placeholder((TextBox)sender, "enter");
        }
        private void placeholderEventLeave(object sender, EventArgs e)
        {
            placeholder((TextBox)sender, "leave");
        }

        public TextBox placeholder(TextBox componente, string evento)
        {
            string textoCuandoEstaVacio = "";
            controlador.mapTextBox.TryGetValue(componente.GetHashCode().ToString(), out textoCuandoEstaVacio);

            if (evento.Equals("enter"))
            {
                if (componente.Text.Equals(textoCuandoEstaVacio))
                {
                    componente.Text = "";
                    componente.ForeColor = Color.Black;
                }

            }
            else
            {

                if (componente.Text.Equals(""))
                {

                    componente.Text = textoCuandoEstaVacio;
                    componente.ForeColor = Color.Gray;
                }


            }

            return null;
        }








    }
}
