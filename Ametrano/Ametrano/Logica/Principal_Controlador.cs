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

       








    }
}
