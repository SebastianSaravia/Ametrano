using Ametrano.Encapsulado;
using Ametrano.Logica;
using Ametrano.Verificacion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        Cursos_Controlador CurContr = new Cursos_Controlador();
        private dynamic[] eventoClickBuscarBajaDocente = new dynamic[2];
        private dynamic[] eventoClickBuscarConsultaDocente = new dynamic[2];
        private dynamic[] eventoClickListaAlumnos = new dynamic[2];
        private dynamic[] eventoClickGenerarListaAsistencias = new dynamic[2];
        private DatosAlumno datosAlumno = new DatosAlumno();
        bool diaViatico = false;


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
            btnAñadirSemanaViaticos.Enabled = false;
            boxCursoViaticos.SelectedIndex = 0;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
            dataGridGruposActivos.DataSource = CurContr.GruposActivos();
            dataGridGruposActivos.ReadOnly = true;
            boxSexoAlumno.SelectedIndex = 0;
            boxUsaInternetAlumno.SelectedIndex = 0;
            boxNivelEducativo.SelectedIndex = 0;
            boxJefeHogarAlumno.SelectedIndex = 0;
            boxCantidadHijosAlumno.SelectedIndex = 0;
            boxCuentaConApoyoAlumno.SelectedIndex = 0;
            boxCursoAlumno.SelectedIndex = 0;
            boxDepartamentoAlumno.SelectedIndex = 0;
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
            boxBuscar.SelectedIndex = 0;
            boxBuscar_2.SelectedIndex = 0;
            boxCursoViaticos.SelectedIndex = 0;
            boxCursoGrupo.SelectedIndex = 0;           
            boxTipoCurso.SelectedIndex = 0;
            boxCursoAsistencia.SelectedIndex = 0;
            boxCursoAsistencia_2.SelectedIndex = 0;
            boxMateriaAsisencia.SelectedIndex = 0;
            boxMateriaAsistencia_2.SelectedIndex = 0;
            boxTurnoAsistencia.SelectedIndex = 0;
            boxCursoViaticos.SelectedIndex = 0;
            boxPeriodoAlumno.SelectedIndex = 0;
            boxPeriodoAlumno_2.SelectedIndex = 0;
            boxSexoAlumno_2.SelectedIndex = 0;
            boxTrabajaActualmenteAlumno_2.SelectedIndex = 0;
            boxTrabajoAnteriormenteCuidandoAlumno_2.SelectedIndex = 0;
            boxUsaInternetAlumno_2.SelectedIndex = 0;
            boxPersonaConDiscapacidadAlumno_2.SelectedIndex = 0;
            boxNivelAcademicoAlumno_2.SelectedIndex = 0;
            boxLocalidadAlumno_2.SelectedIndex = 0;
            boxJefeHogarAlumno_2.SelectedIndex = 0;
            boxFacilAccesoInternetAlumno_2.SelectedIndex = 0;
            boxEstadoCivilAlumno_2.SelectedIndex = 0;
            boxEstadoAlumno_2.SelectedIndex = 0;
            boxDepartamentoAlumno_2.SelectedIndex = 0;
            boxCursoAlumno_2.SelectedIndex = 0;
            boxCuentaConApoyoAlumno_2.SelectedIndex = 0;
            boxCantidadHijosAlumno_2.SelectedIndex = 0;
            boxTrabajoAlgunaVezAlumno_2.SelectedIndex = 0;
            boxTurnoViaticos.SelectedIndex = 0;
            dateTimeFechaAsistencia.MaxDate = DateTime.Now;


            foreach (Control control in this.Controls)
            {
                PlaceholderRec(control);
            }

            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
            tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoFinalizar);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosFinalizar);
            
           
            string[] cursos = controlador.ListarCursos();
            string[] materias = controlador.ListarMaterias();
            string[] docentes = controlador.ListarDocentes();
            

            for (int i = 0; i < cursos.Length; i++)
            {
                                
                boxCursoAsistencia_2.Items.Add(cursos[i]);
                boxCursoGrupo.Items.Add(cursos[i]);
                boxCursoAlumno_2.Items.Add(cursos[i]);
                boxCursoAlumno.Items.Add(cursos[i]);               
            }

            for (int i = 0; i < materias.Length; i++)
            {
                boxMateriaAsisencia.Items.Add(materias[i]);
                boxMateriaAsistencia_2.Items.Add(materias[i]);
                boxMateriasCurso.Items.Add(materias[i]);
                boxEspecialidades.Items.Add(materias[i]);
                boxEspecialidades_2.Items.Add(materias[i]);
                
            }

            

            DateTime fecha = DateTime.Now;

            string nombreDia = fecha.DayOfWeek.ToString();

            if(nombreDia.Equals("Thursday") || nombreDia.Equals("Friday"))
            {//Si es un jueves o viernes
                btnAñadirSemanaViaticos.Enabled = true;
                diaViatico = true;
            }else
            {
                btnAñadirSemanaViaticos.Enabled = false;
                lblBlockViaticos.Visible = true;
                diaViatico = false;
            }






        }

        /// <summary>
        /// Comienza verificaciones de la primera parte de agregar alumno
        /// </summary>
        /// <returns></returns>
        private dynamic[] setDatosPersonalesAlumno()
        {//metodo que verifica y almacena los datos personales del alumno

            string[] datosPersonales = new string[9];//Array que almacena los datos personales de alumno

            //Lleno array de datos personales para luego realizar la verificacion
            datosPersonales[0] = txtCedulaAlumno.Text;
            datosPersonales[1] = txtNombre1Alumno.Text;
            datosPersonales[2] = txtNombre2Alumno.Text;
            datosPersonales[3] = txtApellido1Alumno.Text;
            datosPersonales[4] = txtApellido2Alumno.Text;
            datosPersonales[5] = maskedTxtFechaNacimientoAlumnoNuevo.Text;
            datosPersonales[6] = txtEdadAlumno.Text;
            datosPersonales[7] = boxSexoAlumno.SelectedItem.ToString();
            datosPersonales[8] = boxEstadoCivilAlumno.SelectedItem.ToString();

           dynamic[] retorno =  datosAlumno.setDatosPersonales(datosPersonales);//Verifico datos personales
            return retorno;
        }
        
        private dynamic[] setDatosCursoAlumno()
        {//metodo que verifica y almacena los datos del curso en datosalumno
            string[] curso = new string[4];//Array que almacena los datos de contacto del alumno
            
            //Lleno el array del curso
            curso[0] = boxCursoAlumno.SelectedItem.ToString();
            curso[1] = boxEstadoAlumno.SelectedItem.ToString();
            curso[2] = boxPeriodoAlumno.SelectedItem.ToString();
            curso[3] = txtMontoViatico.Text;

            dynamic[] retorno = datosAlumno.setCurso(curso); //Verifico los datos
            return retorno;
        }
        private dynamic[] setDatosContactoAlumno()
        {
            string[] contacto = new string[3]; //Array que almacena la informacion del curso

            //Lleno el array con los datos de contacto
            contacto[0] = txtTelefono.Text;
            contacto[1] = txtCelularAlumno.Text;
            contacto[2] = txtEmailAlumno.Text;

            dynamic[] retorno = datosAlumno.setContacto(contacto);//verifico los datos
            return retorno;

        }
        private dynamic[] setDatosDireccionAlumno()
        {
            string[] direccion = new string[6];//array que almacena los datos de direccion del alumno

            //Lleno array de direccion
            direccion[0] = boxDepartamentoAlumno.SelectedItem.ToString();
            direccion[1] = txtLocalidadAlumno.Text;
            direccion[2] = txtCalleAlumno.Text;
            direccion[3] = txtReferenciaAlumno.Text;
            direccion[4] = txtNumeroPuertaAlumno.Text;
            direccion[5] = txtNumeroApartamentoAlumno.Text;

            dynamic[] retorno = datosAlumno.setDireccion(direccion);//verifico los datos

            return retorno;
        }
        private dynamic[] setDatosFormacionAcademicaAlumno()
        {
            string[] formacionAcademica = new string[2];//Array que almacena los datos de la formacion academica del alumno

            //Lleno los datos del array
            formacionAcademica[0] = boxNivelEducativo.SelectedItem.ToString();
            formacionAcademica[1] = txtUltAñoAprobado.Text;

            dynamic[] retorno = datosAlumno.setFormacionAcademica(formacionAcademica);//verifico los datos
            return retorno;
        }

        /// <summary>
        /// Termina primera parte de ingreso de alumno y comienza segunda parte
        /// </summary>
        /// <returns></returns>
        private dynamic[] setDatosTrabajoAlumno()
        {//Metodo que verifica la parte del trabajo
            string[] trabajo = new string[5]; //Array que almacena los datos del trabajo del alumno
            trabajo[0] = boxTrabajoAlgunaVezAlumno.SelectedItem.ToString();
            trabajo[1] = boxTrabajaActualmenteAlumno.SelectedItem.ToString();
            trabajo[2] = txtTiempoDesempleadoAlumno.Text;
            trabajo[3] = txtHorasJornadaAlumno.Text;
            trabajo[4] = txtIngresoMensualAlumno.Text;

            dynamic[] retorno = datosAlumno.setTrabajo(trabajo);
            return retorno;
        }
        private dynamic[] setDatosAccessoInternet()
        {//Metodo que verifica la parte del acceso a internet
            string[] accesso_a_internet = new string[3];
            accesso_a_internet[0] = boxUsaInternetAlumno.SelectedItem.ToString();
            accesso_a_internet[1] = boxFacilAccesoInternetAlumno.SelectedItem.ToString();
            accesso_a_internet[2] = txtMedioAccesoInternetAlumno.Text;
            dynamic[] retorno = datosAlumno.setAccessoInternet(accesso_a_internet);
            return retorno;
        }
        private dynamic[] setDatosJefeHogar()
        {//Metodo que verifica los datos de jefe de hogar
            string[] jefe_hogar = new string[2];
            jefe_hogar[0] = boxJefeHogarAlumno.SelectedItem.ToString();
            jefe_hogar[1] = boxCantidadHijosAlumno.SelectedItem.ToString();

            dynamic[] retorno = datosAlumno.setHogar(jefe_hogar);

            return retorno;
        }
        private dynamic[] setDatosCoberturaSalud()
        {//Metodo que verifica la cobertura de salud
            string cobertura = txtCoberuraSaludAlumno.Text;
            dynamic[] retorno = datosAlumno.setCobertura(cobertura);
            return retorno;
        }
        private dynamic[] setDatosPersonasACargo()
        {
            string[] personasCargo = new string[8];

            personasCargo[0] = txt0a17Alumno.Text;
            personasCargo[1] = txt18a59Alumno.Text;
            personasCargo[2] = txt60oMasAlumno.Text;
            personasCargo[3] = boxPersonaDiscapacidadAlumno.SelectedItem.ToString();
            personasCargo[4] = boxCuentaConApoyoAlumno.SelectedItem.ToString();
            personasCargo[5] = txtCargaSemanalCuidadoAlumno.Text;
            personasCargo[6] = boxTrabajoCuidandoAlumno.SelectedItem.ToString();
            personasCargo[7] = txtExperienciaInstitucionesCuidadoAlumno.Text;

            dynamic[] retorno = datosAlumno.setPersonasACargo(personasCargo);
            return retorno;

        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {//Boton que verificara que todos los datos esten correctos
            dynamic[] setDatosPersonalesAlumnoResultado = this.setDatosPersonalesAlumno();//objeto que guarda el estado y el mensaje 
            dynamic[] setDatosCursoAlumnoResultado = this.setDatosCursoAlumno();
            dynamic[] setDatosContactoAlumnoResultado = this.setDatosContactoAlumno();
            dynamic[] setDatosDireccionAlumnoResultado = this.setDatosDireccionAlumno();
            dynamic[] setDatosFormacionAcademicaAlumnoResultado = this.setDatosFormacionAcademicaAlumno();

            if(!setDatosPersonalesAlumnoResultado[0] && !setDatosCursoAlumnoResultado[0] &&
                !setDatosContactoAlumnoResultado[0] && !setDatosDireccionAlumnoResultado[0] && !setDatosFormacionAcademicaAlumnoResultado[0])
            {//Se verifican que todos los datos sean correctos
                
                //Si todos los datos son correctos permito al pasaje a la segunda parte del formulario 

                tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosPersonales);
                tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoDatosInteres);
                tabControlIngresarAlumno.SelectedIndex = 1;
            }
            else
            {
               
                //Si hay errores
            }


           
        }
        private void btnSiguinete2_Click(object sender, EventArgs e)
        {
            dynamic[] setDatosTrabajoAlumno = this.setDatosTrabajoAlumno();
            dynamic[] setDatosAccesoInternetAlumno = this.setDatosAccessoInternet();
            dynamic[] setDatosJefeHogarAlumno = this.setDatosJefeHogar();
            dynamic[] setDatosPersonasACargoAlumno = this.setDatosPersonasACargo();//Depende del tipo del curso
            dynamic[] setDatosCoberturaSaludAlumno = this.setDatosCoberturaSalud();

            if(!setDatosTrabajoAlumno[0] && !setDatosAccesoInternetAlumno[0] && 
                !setDatosJefeHogarAlumno[0] && !setDatosPersonasACargoAlumno[0] //Depende del tipo de curso
                && !setDatosCoberturaSaludAlumno[0])
            {//Si todo es correcto
               
                //Se pasa a la finalizacion
                IDictionary<string, string> diccionarioDeAlumno = datosAlumno.getDatosPersona();
                //Datos personales
                lblCedulaAlumno.Text = "Cedula: " + diccionarioDeAlumno["cedula_alumno"];
                lblNombre1Alumno.Text = "Primer nombre: " + diccionarioDeAlumno["nombre1"];
                lblNombre2Alumno.Text = "Segundo nombre: " + diccionarioDeAlumno["nombre2"];
                lblApellido1Alumno.Text = "Primer apellido: " + diccionarioDeAlumno["apellido1"];
                lblApellido2Alumno.Text = "Segundo apelldio: " + diccionarioDeAlumno["apellido2"];
                lblFechaNacimientoAlumno.Text = "Fecha de nacimiento: " + diccionarioDeAlumno["fecha_nac"];
                lblEdadAlumno.Text = "Edad: " + diccionarioDeAlumno["edad"];
                lblSexoAlumno.Text = "Sexo: " + diccionarioDeAlumno["sexo"];
                lblEstadoCivilAlumno.Text = "Estado civil: " + diccionarioDeAlumno["estado_civil"];
                //datos de curso

                lblCursoAlumno.Text = "Curso: " + diccionarioDeAlumno["curso_alumno"];
                lblEstadoAlumno.Text = "Estado: " + diccionarioDeAlumno["curso_estado"];
                //Se deben agregar los dos campos

                //Formacion academica

                lblNivelEducativoAlumno.Text = "Nivel educativo: " + diccionarioDeAlumno["formacion_nivel"];
                lblUltimoAñoAprobadoAlumno.Text = "Ultimo año aprovado: " + diccionarioDeAlumno["formacion_ultimo_año_aprovado"];

                //Direccion

                lblDepartamentoAlumno.Text = "Departamento: " + diccionarioDeAlumno["direccion_departamento"];
                lblLocalidadAlumno.Text = "Localidad: " + diccionarioDeAlumno["direccion_localidad"];
                lblCalleAlumno.Text = "Calle: " + diccionarioDeAlumno["direccion_calle"];
                lblReferenciaAlumno.Text = "Referencia: " + diccionarioDeAlumno["direccion_referencia"];
                lblNPuertaAlumno.Text = "Nº puerta: " + diccionarioDeAlumno["direccion_numero_puerta"];
                lblNApartamentoAlumno.Text = "Nº apartamento: " + diccionarioDeAlumno["direccion_apartamento"];

                //Contacto

                lblTelefonoAlumno.Text = "Telefono: " + diccionarioDeAlumno["contacto_telefono"];
                lblCelularAlumno.Text = "Celular: " + diccionarioDeAlumno["contacto_celular"];
                lblEmailAlumno.Text = "Email: " + diccionarioDeAlumno["contacto_email"];

                //Cobertura

                lblCoberturaSaludAlumno.Text = "Cobertura de salud: " + diccionarioDeAlumno["cobertura_salud"];

                //Hogar

                lblJefeHogarAlumno.Text = "Jefe de hogar: " + diccionarioDeAlumno["hogar_jefe"];
                lblCantidadHijosAlumno.Text = "Cantidad de hijos: " + diccionarioDeAlumno["hogar_cantidad_hijos"];

                //Trabajo

                lblTrabajoAlgunaVezAlumno.Text = "Trabajo aluna vez: " + diccionarioDeAlumno["trabajo_trabajo_alguna_vez"];
                lblTrabajaActualmenteAlumno.Text = "Trabaja actualmente: " + diccionarioDeAlumno["trabajo_trabaja_actualmente"];
                lblTiempoDesempleadoAlumno.Text = "Tiempo desempleado: " + diccionarioDeAlumno["trabajo_tiempo_desempleado"];
                lblHorasJornadaLaboralAlumno.Text = "Horas de jornada laboral: " + diccionarioDeAlumno["trabajo_horas_jornada"];
                lblIngresoMensualAlumno.Text = "Ingreso mensual: " + diccionarioDeAlumno["trabajo_ingreso_mensual"];

                //Personas a cargo

                lbl0a17Alumno.Text = "De 0 a 17 años: " + diccionarioDeAlumno["personas_cargo_0_17"];
                lbl18a59Alumno.Text = "De 18 a 59 años: " + diccionarioDeAlumno["personas_cargo_18_59"];
                lbl60oMasAlumno.Text = "De 60 años o mas: " + diccionarioDeAlumno["personas_cargo_60_mas"];
                lblPersonaConDiscapacidadAlumno.Text = "Persona con discapacidad: " + diccionarioDeAlumno["personas_cargo_con_discapacidad"];
                lblCuentaConApoyoAlumno.Text = "Cuenta con apoyo: " + diccionarioDeAlumno["personas_cargo_cuenta_con_apoyo"];
                lblCargaSemanalCuidadoAlumno.Text = "Carga semanal de cuidado: " + diccionarioDeAlumno["personas_cargo_carga_semanal_cuidado"];
                lblTrabajoAnteriormenteCuidandoAlumno.Text = "Trabajo anteriormente cuidando: " + diccionarioDeAlumno["personas_cargo_trabajo_cuidando"];
                lblExperienciaInstitucionesCuidadoAlumno.Text = "Experiencia en instituciones de cuidado: " + diccionarioDeAlumno["personas_cargo_experiencia_instituciones_cuidado"];

                //Accesso a internet

                lblUsaInternetAlumno.Text = "Usa internet: " + diccionarioDeAlumno["internet_usa_internet"];
                lblFacilAccesoInternetAlumno.Text = "Facil acceso a internet: " + diccionarioDeAlumno["internet_facil_acceso"];
                lblMedioAccesoInternetAlumno.Text = "Medio de acceso a internet: " + diccionarioDeAlumno["internet_medio_acceso"];


                tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
                tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoFinalizar);
                tabControlIngresarAlumno.SelectedIndex = 2;

            }




           
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

            maskedTxtFechaNacimientoAlumnoNuevo.Mask = "0000-00-00";//Asigno maskara a la fecha

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

            maskedTxtFechaNacimientoAlumnoNuevo.Text =  TimePickerFechaNacAlumnoNuevo.Value.Year + "/" + mes + "/" + dia ;

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
                    maskedBox.Mask = "0000-00-00";
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
                if (maskedBox.Text.Equals("    -  -") || maskedBox.Text.Equals(""))
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
                buscarDocente(tipoBusqueda, datoDeBusqueda, datoCorrecto,false);


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

        public void buscarDocente(int tipoBusqueda, string datoDeBusqueda, bool datoCorrecto, bool busquedaBaja)
        {
            if (busquedaBaja)
            {//Si es una busqueda de baja
                if (datoCorrecto)
                {
                    dynamic[] datosRecividos = controlador.consultarPersona(0, tipoBusqueda, datoDeBusqueda);

                    if (datosRecividos[0])
                    {
                        limpiarFormulario(tabPageDocentesBaja);
                        IDictionary<string, string> datosRecividosDocente = datosRecividos[1];
                        string cedula, nombre, apellido, email, estado;
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


            }else
            {//Si se busca una persona para consulta o modificacion
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
                        if (estado == "True")
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
            //if (listAlumnosViaticos.SelectedIndex>=0)
            //{
            DataTable listaAlumnos = eventoClickListaAlumnos[1];
            if (boxCursoViaticos.SelectedIndex != 0)
            {
                foreach (DataRow row in listaAlumnos.Rows)
                {
                    string ci = "";
                    foreach (DataColumn column in listaAlumnos.Columns)
                    {

                        if (column.ColumnName.Equals("cedula_alumno"))
                        {
                            ci = row[column].ToString();
                        }
                    }


                    if (CurContr.AñadirSemanaViatico(ci))
                    {
                        try
                        {
                            //dataGridViaticos.Columns.Clear();
                            //dataGridViaticos.DataSource = CurContr.ListarViatico(ci);
                            //dataGridViaticos.Columns[0].ReadOnly = true;
                            //dataGridViaticos.Columns[1].ReadOnly = true;
                            //dataGridViaticos.Columns[5].Visible = false;
                            
                        }
                        catch (Exception ew)
                        {
                            MessageBox.Show("error " + ew);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error al generar nueva semana de pago de viaticos, aún no ha pasado una semana desde el ultimo pago", "No es posible agregar otra semana de pago");
                        break;
                    }
                }

            }




            //}


        }

        public void actualizarMontoTotal()
        {
            double montoTotal = 0;
            DataTable datos = eventoClickListaAlumnos[1];
            string ci = datos.Rows[listAlumnosViaticos.SelectedIndex][datos.Columns[0]].ToString();
            montoTotal = CurContr.calcularMontoTotal(ci);
            lblMontoTotalViaticos.Text = "Monto total a pagar: $" + montoTotal ;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarResultados(txtBuscar, boxBuscar, listResultadosDocentes);
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            //Accessos directos globales
            //Agregar al manual

            if (!e.Control) return;
            if (!e.Shift) return;
            switch (e.KeyCode)
            {
                case Keys.A:
                    tabControlPrincipal.SelectedIndex = 1;
                    
                    break;
                case Keys.D:
                    tabControlPrincipal.SelectedIndex = 0;
                    

                    break;
                case Keys.C:
                    tabControlPrincipal.SelectedIndex = 2;
                    

                    break;
                    /* (etc.) */
            }
        
    }

        private void listBoxResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listResultadosDocentes.SelectedIndex != -1)
            {
                string ci = listResultadosDocentes.SelectedItem.ToString().Substring(0, 8);
                buscarDocente(0, ci, true, false);
            }
            
        }

        private void txtBuscar_2_TextChanged(object sender, EventArgs e)
        {
            mostrarResultados(txtBuscar_2, boxBuscar_2, listResultadosDocentes_2);
        }

        public void mostrarResultados(TextBox textbox,ComboBox box, ListBox lista)
        {
            if (textbox.Text.Length >= 3 && box.SelectedIndex == 2)
            {
                dynamic[] datosRecibidos = controlador.busquedaMultiple(0, textbox.Text);
                DataTable datos = datosRecibidos[1];
                if (datosRecibidos[0])
                {
                    lista.Items.Clear();
                    lista.Visible = true;
                    foreach (DataRow row in datos.Rows)
                    {
                        string persona = "";
                        foreach (DataColumn column in datos.Columns)
                        {
                            if (column.ColumnName.Equals("cedula_docente"))
                            {
                                persona += row[column].ToString() + " - ";
                            }
                            else
                            {
                                persona += row[column].ToString() + " ";
                            }

                        }
                        lista.Items.Add(persona);
                    }
                }
                else
                {
                    lista.Items.Clear();
                    lista.Visible = false;
                }
            }
            else
            {
                lista.Items.Clear();
                lista.Visible = false;
            }
        }

        private void listResultadosDocentes_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listResultadosDocentes_2.SelectedIndex != -1)
            {
                string ci = listResultadosDocentes_2.SelectedItem.ToString().Substring(0, 8);
                buscarDocente(0, ci, true, true);
            }
        }

        private void boxCursoViaticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTurnoViaticos.SelectedIndex != 0)
            {//Si hay un turno seleccionado
                if (boxCursoViaticos.SelectedIndex != 0 && diaViatico)
                {
                    btnAñadirSemanaViaticos.Enabled = true;
                }
                else
                {
                    btnAñadirSemanaViaticos.Enabled = false;
                }

                dataGridViaticos.DataSource = null;
                dataGridViaticos.Columns.Clear();
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn col3 = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn col4 = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn col5 = new DataGridViewCheckBoxColumn();
                col.HeaderText = "Fecha";
                col2.HeaderText = "Monto";
                col3.HeaderText = "Rubro";
                col4.HeaderText = "Concepto";
                col5.HeaderText = "Abonado";
                dataGridViaticos.Columns.Add(col);
                dataGridViaticos.Columns.Add(col2);
                dataGridViaticos.Columns.Add(col3);
                dataGridViaticos.Columns.Add(col4);
                dataGridViaticos.Columns.Add(col5);


                DataTable dt;
                string curso = boxCursoViaticos.SelectedItem.ToString();
                string turno = "";
                if (boxTurnoViaticos.SelectedItem != null)
                {
                   turno = boxTurnoViaticos.SelectedItem.ToString();
                }

                dynamic[] alumn = CurContr.AlumnosCurso(curso,turno, out dt);
                listAlumnosViaticos.Items.Clear();
                for (int i = 0; i < alumn.Length; i++)
                {
                    listAlumnosViaticos.Items.Add(alumn[i]);
                }
                if (alumn.Length > 0)
                {
                    eventoClickListaAlumnos[0] = true;
                    eventoClickListaAlumnos[1] = dt;

                    btnAñadirSemanaViaticos.Enabled = true;


                }else
                {
                    btnAñadirSemanaViaticos.Enabled = false;
                }
            }

            

        }

        private void listAlumnosViaticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventoClickListaAlumnos[0])
            {
               
                DataTable listaAlumnos = eventoClickListaAlumnos[1];
                int val = listAlumnosViaticos.SelectedIndex;
                if (listAlumnosViaticos.SelectedIndex != -1)
                {
                    string ci = listaAlumnos.Rows[val][listaAlumnos.Columns[0]].ToString();
                    string[] datosAlumno = CurContr.DatosViaticos(ci);
                    lblCedulaViaticos.Text = "Cedula: " + ci;
                    lblNombreViaticos.Text = "Nombre: " + datosAlumno[0] + " " + datosAlumno[1];
                    lblMontoDiaViaticos.Text = "Monto por día asistido: " + datosAlumno[2];

                    try
                    {
                        dataGridViaticos.Columns.Clear();
                        dataGridViaticos.DataSource = CurContr.ListarViatico(ci);
                        dataGridViaticos.Columns[0].ReadOnly = true;
                        dataGridViaticos.Columns[1].ReadOnly = true;
                        dataGridViaticos.Columns[5].Visible = false;
                        actualizarMontoTotal();
                    }
                    catch (Exception ew)
                    {
                        MessageBox.Show("error " + ew);
                    }
                }
            }

        }

        private void btnGenerarLista_Click(object sender, EventArgs e)
        {
            string curso = boxCursoAsistencia.SelectedItem.ToString();
            string turno = boxTurnoAsistencia.SelectedItem.ToString();
           
            dataGridListaAsistencias.Rows.Clear();

            if (boxCursoAsistencia.SelectedIndex==0)
            {
                MessageBox.Show("Debe seleccionar un curso primero.");
            }else
            {
                DataTable datosAlumnos = new DataTable();
                string[] alumnos = CurContr.ListarAlumnosGrupo(curso,turno,out datosAlumnos);

                for (int i = 0; i < alumnos.Length; i++)
                {
                    dataGridListaAsistencias.Rows.Add(alumnos[i]);
                }
                btnGuardarLista.Enabled = true;
                dateTimeFechaAsistencia.Enabled = true;
                boxMateriaAsisencia.Enabled = true;
                eventoClickGenerarListaAsistencias[0] = true;
                eventoClickGenerarListaAsistencias[1] = datosAlumnos;
            }

           
        }

        private void dataGridViaticos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViaticos.SelectedRows.Count > 0)
            {
               
                int rowIndex = dataGridViaticos.SelectedRows[0].Index;
                DataTable listaAlumnos = eventoClickListaAlumnos[1];

                DataGridViewRow alumnoSeleccionado = dataGridViaticos.Rows[rowIndex];

                bool estadoNuevo;

                if (alumnoSeleccionado.Cells[4].FormattedValue.Equals(true))
                {
                    estadoNuevo = true;
                }else
                {
                    estadoNuevo = false;
                }

                string fecha = alumnoSeleccionado.Cells[0].FormattedValue.ToString();
                string semana = alumnoSeleccionado.Cells[5].FormattedValue.ToString();

                DateTime formatFecha;

                DateTime.TryParse(fecha,out formatFecha);

                fecha = formatFecha.ToString("yyyy-MM-dd");
                
                
                int val = listAlumnosViaticos.SelectedIndex;
                string ci = listaAlumnos.Rows[val][listaAlumnos.Columns[0]].ToString();
                
                bool resultado = CurContr.updatePago(ci, fecha,semana,estadoNuevo);

                if (resultado)
                {
                    actualizarMontoTotal();
                }
                else
                {
                    MessageBox.Show("Error actualizando el pago del viatico");
                }

            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Alumnos_Controlador al = new Alumnos_Controlador();
                   
                al.insertarAlumno(datosAlumno);
            
            
            
            
        }

        private void boxCursoAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViaticos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViaticos.IsCurrentCellDirty)
            {
                dataGridViaticos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridListaAsistencias_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridListaAsistencias.IsCurrentCellDirty)
            {
                dataGridListaAsistencias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridListaAsistencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridListaAsistencias.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridListaAsistencias.SelectedRows[0];




            }
        }

        private void boxTurnoViaticos_SelectedIndexChanged(object sender, EventArgs e)
        {//Seleccion de turno
            if(boxTurnoViaticos.SelectedIndex != 0)
            {
                boxCursoViaticos.Items.Clear();
                boxCursoViaticos.Items.Add("Curso...");
                boxCursoViaticos.SelectedIndex = 0;
                string[] cursos = CurContr.listarCursoPorTurno(boxTurnoViaticos.SelectedItem.ToString());

                for (int i = 0; i < cursos.Length; i++)
                {
                    boxCursoViaticos.Items.Add(cursos[i]);
                }


                boxCursoViaticos.Enabled = true;
            }
            else{
                boxCursoViaticos.Enabled = false;
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {

            if (boxTurnoGrupo.SelectedIndex !=0 && boxCursoGrupo.SelectedIndex != 0)
            {
                string turno = boxTurnoGrupo.SelectedItem.ToString();
                string curso = boxCursoGrupo.SelectedItem.ToString();
                string inicio = dateTimeInicioGrupo.Value.ToString();
                string fin = dateTimeFinalizacionGrupo.Value.ToString();

                DateTime fechaInicio = DateTime.Parse(inicio);
                DateTime fechaFin = DateTime.Parse(fin);
                string formattedFechaInicio = fechaInicio.ToString("yyyy-MM-dd");
                string formattedFechaFin = fechaFin.ToString("yyyy-MM-dd");

                if (CurContr.AgregarGrupo(curso, formattedFechaInicio, formattedFechaFin, turno))
                {
                    dataGridGruposActivos.DataSource = CurContr.GruposActivos();
                    MessageBox.Show("El grupo ha sido creado con exito!", "Operacion exitosa.");
                }
            }else 
            {
                MessageBox.Show("Error, comprueve que todos los campos son correctos.");
            }

           
        }

        private void boxTurnoAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTurnoAsistencia.SelectedIndex != 0)
            {
                boxCursoAsistencia.Items.Clear();
                boxCursoAsistencia.Items.Add("Curso...");
                boxCursoAsistencia.SelectedIndex = 0;
                string[] cursos = CurContr.listarCursoPorTurno(boxTurnoAsistencia.SelectedItem.ToString());

                for (int i = 0; i < cursos.Length; i++)
                {
                    boxCursoAsistencia.Items.Add(cursos[i]);
                }


                boxCursoAsistencia.Enabled = true;
               
                boxMateriaAsisencia.Enabled = true;
                btnGuardarLista.Enabled = true;
                dateTimeFechaAsistencia.Enabled = true;
            }
            else
            {
                boxCursoAsistencia.Enabled = false;
                boxMateriaAsisencia.Enabled = false;
                btnGuardarLista.Enabled = false;
                dateTimeFechaAsistencia.Enabled = false;

            }
        }

        private void boxCursoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCursoAlumno.SelectedIndex != 0)
            {
                boxPeriodoAlumno.Enabled = true;
            }else
            {
                boxPeriodoAlumno.Enabled = false;
            }
            string curso = boxCursoAlumno.SelectedItem.ToString();
            string turno = "";
            if (boxTurnoAlumno.SelectedItem != null)
            {
             turno = boxTurnoAlumno.SelectedItem.ToString();
            }
            

            string[] periodos = CurContr.ListarPeriodos(curso,turno);
            boxPeriodoAlumno.Items.Clear();
            boxPeriodoAlumno.Items.Add("Periodo...");
            boxPeriodoAlumno.Items.Add("Pendiente");
            boxPeriodoAlumno.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno.Items.Add(periodos[i]);
            }


        }

        private void boxTurnoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTurnoAlumno.SelectedIndex != 0)
            {
                boxCursoAlumno.Enabled = true;
            }
            else
            {
                boxCursoAlumno.Enabled = false;
            }
            string curso = boxCursoAlumno.SelectedItem.ToString();
            string turno = "";
            if (boxTurnoAlumno.SelectedItem != null)
            {
                turno = boxTurnoAlumno.SelectedItem.ToString();
            }


            string[] periodos = CurContr.ListarPeriodos(curso, turno);
            boxPeriodoAlumno.Items.Clear();
            boxPeriodoAlumno.Items.Add("Periodo...");
            boxPeriodoAlumno.Items.Add("Pendiente");
            boxPeriodoAlumno.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno.Items.Add(periodos[i]);
            }

        }

        private void btnGuardarLista_Click(object sender, EventArgs e)
        {//evento que sube la lista a asistencias
            
            if (eventoClickGenerarListaAsistencias[0])
            {
                string materia = "";
                string fecha_asistencia = "";
                string cedula = "";
                int asistencia = 0;


                if (boxMateriaAsisencia.SelectedIndex != 0)
                {
                    materia = boxMateriaAsisencia.SelectedItem.ToString();
                }
                fecha_asistencia = dateTimeFechaAsistencia.Value.ToString("%Y-%m-%d");

                DataTable listaAlumnos = eventoClickGenerarListaAsistencias[1];

                

                if (dataGridListaAsistencias.SelectedRows[0].Cells[1].FormattedValue.ToString().Equals("True"))
                {
                    asistencia = 1;
                }else
                {
                    asistencia = 0;
                }

                cedula = listaAlumnos.Rows[indiceRowSelected][listaAlumnos.Columns[1]].ToString();



            }
            


        }
    }
}
