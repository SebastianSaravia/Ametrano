﻿using Ametrano.Logica;
using Ametrano.Verificacion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ametrano.Presentacion
{
    public partial class Principal : Form

    {
        private Principal_Controlador controlador = new Principal_Controlador();

        private dynamic[] eventoClickBuscarBajaDocente = new dynamic[2];
        private dynamic[] eventoClickBuscarConsultaDocente = new dynamic[2];


        public Principal()
        {
            InitializeComponent();
            eventoClickBuscarBajaDocente[0] = false;
            eventoClickBuscarConsultaDocente[0] = false;
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 0;
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 1;
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 2;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            boxSexoAlumno.SelectedIndex = 0;
            boxUsaInternetAlumno.SelectedIndex = 0;
            boxNivelEducativo.SelectedIndex = 0;
            boxJefeHogarAlumno.SelectedIndex = 0;
            boxCantidadHijosAlumno.SelectedIndex = 0;
            boxCuentaConApoyoAlumno.SelectedIndex = 0;
            boxCursoAlumno.SelectedIndex = 0;
            boxDepartamentoAlumno.SelectedIndex = 0;
            boxEspecialidades.SelectedIndex = 0;
            boxEstadoAlumno.SelectedIndex = 0;
            boxEstadoCivilAlumno.SelectedIndex = 0;
            boxFacilAccesoInternetAlumno.SelectedIndex = 0;
            boxJefeHogarAlumno.SelectedIndex = 0;
            boxNivelEducativo.SelectedIndex = 0;
            boxPersonaDiscapacidadAlumno.SelectedIndex = 0;
            boxSexoAlumno.SelectedIndex = 0;
            boxTrabajaActualmenteAlumno.SelectedIndex = 0;
            boxTrabajoAlgunaVezAlumno.SelectedIndex = 0;
            boxTrabajoCuidandoAlumno.SelectedIndex = 0;
            boxLocalidadAlumno.SelectedIndex = 0;
            boxBuscar.SelectedIndex = 0;
            boxBuscar_2.SelectedIndex = 0;

            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoFinalizar);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosFinalizar);
            foreach (Control control in this.Controls)
            {
                PlaceholderRec(control);
            }

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosPersonales);
            tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }

        private void btnSiguinete2_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoFinalizar);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoDatosPersonales);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoFinalizar);
            tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }

        private void TimePickerFechaNac_ValueChanged(object sender, EventArgs e)
        {//Evento de click en el timepickerfechanacalumnonuevo

            maskedTxtFechaNacimientoAlumnoNuevo.Mask = "00/00/0000";//Asigno maskara a la fecha

            string mes, dia;

            mes = TimePickerFechaNacAlumnoNuevo.Value.Month.ToString();
            dia = TimePickerFechaNacAlumnoNuevo.Value.Day.ToString();
            if (int.Parse(dia) < 10)
            {//si el dia es menor a 10, le agrego un cero delante
                dia = "0" + dia;
            }
            if (int.Parse(mes) < 10)
            {//Lo mismo que con dia
                mes = "0" + mes;
            }
            //Muestro la fecha en el masked box

            maskedTxtFechaNacimientoAlumnoNuevo.Text = dia + "/" + mes + "/" + TimePickerFechaNacAlumnoNuevo.Value.Year;

            maskedTxtFechaNacimientoAlumnoNuevo.ForeColor = Color.Black;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador.abrirConfiguracion();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.user_rol = "";
            Properties.Settings.Default.user_usuario = "";
            Properties.Settings.Default.user_contraseña = "";
            Login.ActiveForm.Show();
        }

        private void placeholderEventEnter(object sender, EventArgs e)
        {
            if (sender.GetType().Name.Equals("TextBox"))//Si el componente es un textbox
            {
                placeholder((TextBox)sender, "enter");
            }
            else//si es cualquier otra cosa
            {
                dynamic maskedBox = (MaskedTextBox)sender;
                if (maskedBox.Text.Equals("Fecha de nacimiento") || maskedBox.Text.Equals(""))//Si el campo esta vacio
                {
                    maskedBox.Mask = "00/00/0000";
                    maskedBox.ForeColor = Color.Black;
                }

            }

        }

        private void placeholderEventLeave(object sender, EventArgs e)
        {
            if (sender.GetType().Name.Equals("TextBox"))//Si el componente es un textbox
            {
                placeholder((TextBox)sender, "leave");
            }
            else//si es cualquier otra cosa
            {
                dynamic maskedBox = (MaskedTextBox)sender;
                if (maskedBox.Text.Equals("  /  /") || maskedBox.Text.Equals(""))
                {


                    maskedBox.Mask = "";
                    maskedBox.Text = "Fecha de nacimiento";
                    maskedBox.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }

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
                    componente.ForeColor = Color.FromArgb(64, 64, 64);
                }


            }

            return null;
        }

        public void PlaceholderRec(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {

                if (contHijo.GetType().Name.Equals("TextBox"))
                {
                    controlador.mapTextBox.Add(contHijo.GetHashCode().ToString(), contHijo.Text);

                }
                else
                {
                    if (contHijo.HasChildren)
                    {
                        this.PlaceholderRec(contHijo);
                    }
                }

            }
        }

        private void btnAñadirEspecialidad_Click(object sender, EventArgs e)
        {
            if (boxEspecialidades.SelectedIndex != -1)
            {//Evento añadir especialidad
                if (listEspecialidades.Items.IndexOf(boxEspecialidades.SelectedItem) == -1)
                {
                    listEspecialidades.Items.Add(boxEspecialidades.SelectedItem);
                }
            }

        }

        private void btnQuitarEspecialidad_Click(object sender, EventArgs e)
        {//Evento quitar especialidad
            if (listEspecialidades.SelectedIndex != -1)
            {
                listEspecialidades.Items.RemoveAt(listEspecialidades.SelectedIndex);
            }
        }

        private void btnIngresarDocente_Click(object sender, EventArgs e)
        {//Evento click del boton ingresar docente
            //Datos personales
            DatosDocente infoDocente = new DatosDocente();

            string cedula = txtCedulaDocente.Text;
            string apellido1 = txtApellido1Docente.Text;
            string nombre1 = txtNombre1Docente.Text;
            string direccion = txtDireccionDocente.Text;
            string telefono = txtTelefonoDocente.Text;
            string email = txtEmailDocente.Text;

            dynamic[] verificacion = infoDocente.setDatosDocente(new string[] { cedula, nombre1, apellido1, direccion, telefono, email });

            if (!verificacion[0])
            {
                if (listEspecialidades.Items.Count == 0)
                {
                    MessageBox.Show("El docente tiene que tener al menos una especialidad");
                }
                else
                {
                    string[] especialidades = new string[listEspecialidades.Items.Count];//array que guarda especialidades de el docente

                    for (int i = 0; i < listEspecialidades.Items.Count; i++)
                    {
                        especialidades[i] = listEspecialidades.Items[i].ToString();
                    }


                    dynamic[] insert = controlador.ingresarDocente(infoDocente, especialidades);
                    if (insert[0])
                    {
                        MessageBox.Show(insert[1]);
                        limpiarFormulario(tabPageDocentesNuevo);

                    }
                    else
                    {
                        MessageBox.Show(insert[1]);
                    }
                }

            }
            else
            {
                MessageBox.Show(verificacion[1]);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosDeInteres);
            tabControlIngresarAlumno.SelectedIndex = 2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosFinalizar);
            tabControlIngresarAlumno.SelectedIndex = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosPersonales);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosFinalizar);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosDeInteres);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosInformacion);
            tabControlIngresarAlumno.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosInformacion);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosPersonales);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }

        public void limpiarFormulario(Control contenedor)
        {//metodo que recorre el tabpage pasado y limpia todos los componentes a su estado original
            {
                foreach (Control contHijo in contenedor.Controls)
                {

                    if (contHijo.GetType().Name.Equals("TextBox"))
                    {
                        string textoCuandoEstaVacio = "";
                        controlador.mapTextBox.TryGetValue(contHijo.GetHashCode().ToString(), out textoCuandoEstaVacio);
                        contHijo.Text = textoCuandoEstaVacio;
                    }
                    else if (contHijo.GetType().Name.Equals("ListBox"))
                    {
                        clearListBox((ListBox)contHijo);

                    }
                    else if (contHijo.GetType().Name.Equals("ComboBox"))
                    {
                        clearComboBox((ComboBox)contHijo);
                    }
                    else
                    {
                        if (contHijo.HasChildren)
                        {
                            this.limpiarFormulario(contHijo);
                        }
                    }

                }
            }
        }

        public void clearListBox(ListBox lista)
        {
            lista.Items.Clear();
        }

        public void clearComboBox(ComboBox box)
        {
            if (box.Items.Count > 0)
            {
                box.SelectedIndex = 0;
            }
        }

        private void btnBuscar_2_Click(object sender, EventArgs e)
        {//Evento del boton buscar docente para dar de baja
            if (boxBuscar_2.SelectedIndex == 0)
            {//Si el tipo de busqueda es el placeholder
                MessageBox.Show("Debe seleccionar un metodo de busqueda");
            }
            else if (boxBuscar_2.SelectedIndex != 0 && txtBuscar_2.Text.Equals("Texto de busqueda"))
            {//Si el campo de busqueda es cedula o nombre pero el campo de busqueda esta vacio
                MessageBox.Show("Se debe ingresar un texto de busqueda");
            }
            else
            {//Si se selecciona nombre y apellido y se escribio un dato de busqueda
                int tipoBusqueda = -1;//Variable que almacena el tipo de busqueda seleccionado
                bool datoCorrecto = false;//Variable que se usa para verificar si el dato esta ingresado correctamente
                string datoDeBusqueda = txtBuscar_2.Text; //Dato de busqueda que se ingreso en el textbox


                if (boxBuscar_2.SelectedIndex == 1)
                {//Si se selecciona cedula
                    tipoBusqueda = 0;

                }
                else if (boxBuscar_2.SelectedIndex == 2)
                {//Si se selecciona nombre
                    tipoBusqueda = 1;
                }

                datoCorrecto = verificarDatoCorrecto(tipoBusqueda, datoDeBusqueda);

                if (datoCorrecto)
                {
                    dynamic[] datosRecividos = controlador.consultarPersona(0, tipoBusqueda, datoDeBusqueda);

                    if (datosRecividos[0])
                    {
                        IDictionary<string, string> datosRecividosDocente = datosRecividos[1];
                        string cedula, nombre, apellido, email,estado;
                        //obtengo los datos guardados en el diccionario
                        datosRecividosDocente.TryGetValue("cedula_docente", out cedula);
                        datosRecividosDocente.TryGetValue("nombre", out nombre);
                        datosRecividosDocente.TryGetValue("apellido", out apellido);
                        datosRecividosDocente.TryGetValue("email", out email);
                        datosRecividosDocente.TryGetValue("estado", out estado);

                        lblCedulaDocente.Text = "Cedula: " + cedula;
                        lblNombreDocente.Text = "Nombre: " + nombre;
                        lblApellidoDocente.Text = "Apellido: " + apellido;
                        lblEmailDocente.Text = "Email: " + email;
                        if (estado.Equals("True"))
                        {
                            lblEstadoDocenteBaja.Text = "Estado: Activo";
                            lblEstadoDocenteBaja.ForeColor = Color.Green;
                            btnDarDeBaja.Enabled = true;

                        }
                        else
                        {
                            lblEstadoDocenteBaja.Text = "Estado: Inactivo";
                            lblEstadoDocenteBaja.ForeColor = Color.IndianRed;
                            btnDarDeBaja.Enabled = false;
                        }

                        eventoClickBuscarBajaDocente[0] = true;
                        eventoClickBuscarBajaDocente[1] = cedula;

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado a la persona");
                    }
                }







            }




        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {//Evento de click en el boton de busqueda de consulta y modificacion
            if (boxBuscar.SelectedIndex == 0)
            {//Si el tipo de busqueda es el placeholder
                MessageBox.Show("Debe seleccionar un metodo de busqueda");
            }
            else if (boxBuscar.SelectedIndex != 0 && txtBuscar.Text.Equals("Texto de busqueda"))
            {//Si el campo de busqueda es cedula o nombre pero el campo de busqueda esta vacio
                MessageBox.Show("Se debe ingresar un texto de busqueda");
            }
            else
            {//Si se selecciona nombre y apellido/cedula y se escribio un dato de busqueda
                //Variables
                int tipoBusqueda = -1;//Variable que almacena el tipo de busqueda seleccionado
                bool datoCorrecto = false;//Variable que se usa para verificar si el dato esta ingresado correctamente
                string datoDeBusqueda = txtBuscar.Text; //Dato de busqueda que se ingreso en el textbox


                if (boxBuscar.SelectedIndex == 1)
                {//Si se selecciona cedula
                    tipoBusqueda = 0;

                }
                else if (boxBuscar.SelectedIndex == 2)
                {//Si se selecciona nombre
                    tipoBusqueda = 1;
                }

                datoCorrecto = verificarDatoCorrecto(tipoBusqueda, datoDeBusqueda);

                if (datoCorrecto)
                {//Si el texto de busqueda supero todas las validaciones
                    dynamic[] dato = controlador.consultarPersona(0, tipoBusqueda, datoDeBusqueda);

                    if (dato[0] == true)
                    {//Si se encontro a la persona
                        limpiarFormulario(tabPageDocentesConsultarModificar);
                        string cedula, nombre, apellido, direccion, telefono, email, estado;
                        dato[1].TryGetValue("cedula_docente", out cedula);
                        dato[1].TryGetValue("nombre", out nombre);
                        dato[1].TryGetValue("apellido", out apellido);
                        dato[1].TryGetValue("direccion", out direccion);
                        dato[1].TryGetValue("telefono", out telefono);
                        dato[1].TryGetValue("email", out email);
                        dato[1].TryGetValue("estado", out estado);
                        if (estado=="True")
                        {
                            btnCambiarEstadoDocente.Visible = false;
                        }
                        else
                        {
                            btnCambiarEstadoDocente.Visible = true;
                        }

                        txtCedulaDocente_2.Text = cedula;
                        txtNombre1Docente_2.Text = nombre;
                        txtApellido1Docente_2.Text = apellido;
                        txtDireccionDocente_2.Text = direccion;
                        txtTelefonoDocente_2.Text = telefono;
                        txtEmailDocente_2.Text = email;
                        if (estado.Equals("False"))
                        {
                            estado = "Inactivo";
                        }
                        else
                        {
                            estado = "Activo";
                        }
                        lblEstadoDocente.Text = "Estado: " + estado;

                        eventoClickBuscarConsultaDocente[0] = true;
                        eventoClickBuscarConsultaDocente[1] = cedula;

                        string[] especialidades = dato[2];
                        for (int i = 0; i < especialidades.Length; i++)
                        {
                            listEspecialidades_2.Items.Add(especialidades[i]);
                        }
                    }
                    else
                    {//Si no se encontro a la persona
                        MessageBox.Show("No se ha encontrado a la persona");
                    }
                }


            }

        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {//Evento del click en el boton de dar de baja

            if (eventoClickBuscarBajaDocente[0] == null || eventoClickBuscarBajaDocente[0])
            {//Si se habilito el borrado de un docente
                if (controlador.cambiarEstadoPersona(0, 0, eventoClickBuscarBajaDocente[1]))
                {
                    eventoClickBuscarBajaDocente[0] = false;//Se vacian variables de evento de busqueda con exito
                    eventoClickBuscarBajaDocente[1] = "";
                    MessageBox.Show("Se ha dado de baja el docente con exito");//Se avisa al usuario
                    limpiarFormulario(tabPageDocentesBaja);//Limpieza del formulario
                    lblNombreDocente.Text = "Nombre: ";
                    lblCedulaDocente.Text = "Cedula: ";
                    lblApellidoDocente.Text = "Apellido: ";
                    lblEmailDocente.Text = "Email: ";
                    lblEstadoDocenteBaja.Text = "Estado: ";
                    lblEstadoDocenteBaja.ForeColor = Color.Black;


                }
            }

        }

        private void btnCambiarEstadoDocente_Click(object sender, EventArgs e)
        {
            if (eventoClickBuscarConsultaDocente[0])
            {//Si se realizo la busqueda de una persona:

                if (lblEstadoDocente.Text.Equals("Estado: Inactivo"))
                {//Si el estado actual es de inactivo
                    bool baja = controlador.cambiarEstadoPersona(1, 0, eventoClickBuscarConsultaDocente[1]);
                    if (baja)
                    {
                        btnCambiarEstadoDocente.Visible = false;
                        lblEstadoDocente.Text = "Estado: Activo";
                        MessageBox.Show("Se ha cambiado el estado de la persona a Activo");
                       
                    }
                }

            }

        }




        public bool esInt(string numero)
        {//Metodo que retorna true si es unicamente numero
            int numero_convertido;
            if (int.TryParse(numero, out numero_convertido))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool esSoloString(string texto)
        {//Metodo que verifica si hay int en un texto, retorna true si es solo string
            bool retorno = true;
            int v1;
            for (int i = 0; i < texto.Length; i++)
            {
                if (int.TryParse(texto[i].ToString(), out v1))
                {
                    retorno = false;
                }
            }
            return retorno;
        }



        public bool verificarDatoCorrecto(int tipoBusqueda, string datoDeBusqueda)
        {
            bool datoCorrecto = false;


            if (tipoBusqueda == 0)
            {//Si la busqueda es por cedula
                bool ci_numerica = esInt(datoDeBusqueda);
                if (ci_numerica)
                {//Se verifica que la cedula no contenga texto
                    if (tipoBusqueda == 0 && datoDeBusqueda.Length < 8)
                    {//Si la busqueda es por cedula y es menor a 8 caracteres se evita la busqueda
                        MessageBox.Show("La cedula debe ser de 8 caracteres");
                        datoCorrecto = false;
                    }
                    else
                    {
                        datoCorrecto = true;
                    }

                }
                else
                {//Si contiene texto
                    datoCorrecto = false;
                    MessageBox.Show("No se pueden buscar cedulas que contengan caracteres no permitidos");
                }
            }
            else
            {//Si la busqueda es por nombre y apellido
                bool nombre_sin_numeros = esSoloString(datoDeBusqueda);
                if (nombre_sin_numeros)
                {//Se verifica que no contenga numeros
                    datoCorrecto = true;
                }
                else
                {//Si contiene numeros
                    datoCorrecto = false;
                    MessageBox.Show("No se pueden buscar nombres que contengan numeros");
                }
            }

            return datoCorrecto;
        }

        private void boxBuscar_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxBuscar_2.SelectedIndex == 1)
            {//Si se selecciona cedula se ajusta el largo maximo a 8
                txtBuscar_2.MaxLength = 8;
            }
            else
            {
                txtBuscar_2.MaxLength = 255;
            }
        }
        private void boxBuscar_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (boxBuscar.SelectedIndex == 1)
            {//Si se selecciona cedula se ajusta el largo maximo a 8
                txtBuscar.MaxLength = 8;
            }
            else
            {
                txtBuscar.MaxLength = 255;
            }
        }

        private void btnAñadirSemanaViaticos_Click(object sender, EventArgs e)
        {
            dataGridViaticos.Rows.Add();
        }

        private void btnActualizarDocente_Click(object sender, EventArgs e)
        {//Evento de click en el boton modificar docente
            //Datos personales
            DatosDocente infoDocente = new DatosDocente();

            if (eventoClickBuscarConsultaDocente[0])
            {
                string cedula = txtCedulaDocente_2.Text;
                string apellido1 = txtApellido1Docente_2.Text;
                string nombre1 = txtNombre1Docente_2.Text;
                string direccion = txtDireccionDocente_2.Text;
                string telefono = txtTelefonoDocente_2.Text;
                string email = txtEmailDocente_2.Text;

                dynamic[] verificacion = infoDocente.setDatosDocente(new string[] { cedula, nombre1, apellido1, direccion, telefono, email });

                if (!verificacion[0])
                {
                    if (listEspecialidades_2.Items.Count == 0)
                    {
                        MessageBox.Show("El docente tiene que tener al menos una especialidad");
                    }
                    else
                    {
                        string[] especialidades = new string[listEspecialidades_2.Items.Count];//array que guarda especialidades de el docente

                        for (int i = 0; i < listEspecialidades_2.Items.Count; i++)
                        {
                            especialidades[i] = listEspecialidades_2.Items[i].ToString();
                        }


                        dynamic[] update = controlador.updateDocente(infoDocente, especialidades,eventoClickBuscarConsultaDocente[1]);
                        if (update[0])
                        {
                            MessageBox.Show(update[1]);
                            limpiarFormulario(tabPageDocentesConsultarModificar);

                        }
                        else
                        {
                            MessageBox.Show(update[1]);
                        }
                    }

                }
                else
                {
                    MessageBox.Show(verificacion[1]);
                }
            }else
            {
                MessageBox.Show("Primero debes buscar un docente");
            }
        }

        private void btnAñadir_2_Click(object sender, EventArgs e)
        {
            if (eventoClickBuscarConsultaDocente[0])
            {
                if (boxEspecialidades_2.SelectedIndex != -1)
                {//Evento añadir especialidad
                    if (listEspecialidades_2.Items.IndexOf(boxEspecialidades_2.SelectedItem) == -1)
                    {
                        listEspecialidades_2.Items.Add(boxEspecialidades_2.SelectedItem);
                    }
                }
            }
            else{
                MessageBox.Show("Primero debes buscar un docente");
            }
        }

        private void btnQuitar_2_Click(object sender, EventArgs e)
        {
            if (eventoClickBuscarConsultaDocente[0])
            {
                if (listEspecialidades_2.SelectedIndex != -1)
                {
                    listEspecialidades_2.Items.RemoveAt(listEspecialidades_2.SelectedIndex);
                }
            }else
            {
                MessageBox.Show("Primero debes buscar un docente");
            }
        }
    }
}
