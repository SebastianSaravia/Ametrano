using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ametrano.Persistencia
{

    class ConexionBD
    {
       
        public void obtenerConfiguracion()
        {
            dynamic hostname = ConfigurationSettings.AppSettings.Get(0).ToString();
            MessageBox.Show(hostname);
        }

    }


}
