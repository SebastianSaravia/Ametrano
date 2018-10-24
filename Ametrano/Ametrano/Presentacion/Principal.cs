using Ametrano.Encapsulado;
using Ametrano.Logica;
using Ametrano.Persistencia;
using Ametrano.Presentacion;
using Ametrano.Verificacion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Ametrano.Presentacion
{
    public partial class Principal : Form

    {
        private Principal_Controlador controlador = new Principal_Controlador();
        Cursos_Controlador CurContr = new Cursos_Controlador();
        Alumnos_Controlador controlador_alumno = new Alumnos_Controlador();
        private dynamic[] eventoClickBuscarBajaDocente = new dynamic[2];
        private dynamic[] eventoClickBuscarConsultaDocente = new dynamic[2];
        private dynamic[] eventoClickListaAlumnos = new dynamic[2];
        private dynamic[] eventoClickGenerarListaAsistencias = new dynamic[5];
        private dynamic[] eventoClickBuscarConsultaAlumno = new dynamic[2];
        private dynamic[] eventoClickModificarAlumnoCurso = new dynamic[2];
        private dynamic[] eventoClickConsultarListaAsistencias = new dynamic[2];
        private dynamic[] eventoClickAgregarAlumnoCurso = new dynamic[2];
        private dynamic[] eventoClickListarPeriodosAsistencia = new dynamic[2];
        private dynamic[] eventoClickCursoViaticos = new dynamic[2];
        private DatosAlumno datosAlumno = new DatosAlumno();
        private DatosAlumno datosAlumnoConsulta = new DatosAlumno();
        private DatosAlumno datosAlumnoModificacion = new DatosAlumno();

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
            boxNumeroGrupo.SelectedIndex = 0;
            boxTurnoGrupo.SelectedIndex = 0;            
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
            boxMateriaAsistencia.SelectedIndex = 0;
            boxCursoViaticos.SelectedIndex = 0;
            boxPeriodoAlumno.SelectedIndex = 0;
            boxPeriodoAlumno_2.SelectedIndex = 0;
            boxSexoAlumno_2.SelectedIndex = 0;
            boxTrabajaActualmenteAlumno_2.SelectedIndex = 0;
            boxTrabajoCuidandoAlumno_2.SelectedIndex = 0;
            boxUsaInternetAlumno_2.SelectedIndex = 0;
            boxPersonaDiscapacidadAlumno_2.SelectedIndex = 0;
            boxNivelAcademicoAlumno_2.SelectedIndex = 0;
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
            boxTurnoAsistencia.SelectedIndex = 0;
            boxTurnoAsistencia_2.SelectedIndex = 0;
            boxBuscarAlumno.SelectedIndex = 0;
            boxTurnoAlumno.SelectedIndex = 0;
            boxTurnoAlumno_2.SelectedIndex = 0;

            dateTimeFechaAsistencia.Value = DateTime.Now;
            dateTimeFechaAsistencia_2.Value = DateTime.Now;
            dateTimeFechaAsistencia.MaxDate = DateTime.Now;
            dateTimeFechaAsistencia_2.MaxDate = DateTime.Now;


            foreach (Control control in this.Controls)
            {
                PlaceholderRec(control);
                lblRec(control);
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
                boxCursoGrupo.Items.Add(cursos[i]);
                boxCursoAlumno_2.Items.Add(cursos[i]);
                boxCursoAlumno.Items.Add(cursos[i]);
            }

            for (int i = 0; i < materias.Length; i++)
            {

                boxMateriasCurso.Items.Add(materias[i]);
                boxEspecialidades.Items.Add(materias[i]);
                boxEspecialidades_2.Items.Add(materias[i]);

            }



            DateTime fecha = DateTime.Now;

            string nombreDia = fecha.DayOfWeek.ToString();

            if (nombreDia.Equals("Thursday") || nombreDia.Equals("Friday"))
            {//Si es un jueves o viernes
                btnAñadirSemanaViaticos.Enabled = true;
                diaViatico = true;
            }
            else
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
        private dynamic[] setDatosPersonalesAlumno(int type)
        {//metodo que verifica y almacena los datos personales del alumno
         //type=0 ->nuevo
         //type=1 ->modificacion
            string[] datosPersonales = new string[9];//Array que almacena los datos personales de alumno

            //Lleno array de datos personales para luego realizar la verificacion
            

            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                datosPersonales[0] = txtCedulaAlumno.Text;
                datosPersonales[1] = txtNombre1Alumno.Text;
                datosPersonales[2] = txtNombre2Alumno.Text;
                datosPersonales[3] = txtApellido1Alumno.Text;
                datosPersonales[4] = txtApellido2Alumno.Text;
                datosPersonales[5] = maskedTxtFechaNacimientoAlumno.Text;
                datosPersonales[6] = txtEdadAlumno.Text;
                datosPersonales[7] = boxSexoAlumno.SelectedItem.ToString();
                datosPersonales[8] = boxEstadoCivilAlumno.SelectedItem.ToString();

                retorno = datosAlumno.setDatosPersonales(datosPersonales);//Verifico datos personales

            }
            else
            {
                datosPersonales[0] = txtCedulaAlumno_2.Text;
                datosPersonales[1] = txtNombre1Alumno_2.Text;
                datosPersonales[2] = txtNombre2Alumno_2.Text;
                datosPersonales[3] = txtApellido1Alumno_2.Text;
                datosPersonales[4] = txtApellido2Alumno_2.Text;
                datosPersonales[5] = maskedTxtFechaNacimientoAlumno_2.Text;
                datosPersonales[6] = txtEdadAlumno_2.Text;
                datosPersonales[7] = boxSexoAlumno_2.SelectedItem.ToString();
                datosPersonales[8] = boxEstadoCivilAlumno_2.SelectedItem.ToString();

                retorno = datosAlumnoModificacion.setDatosPersonales(datosPersonales);//Verifico datos personales

            }
            return retorno;
        }

        private dynamic[] setDatosCursoAlumno(int type)
        {//metodo que verifica y almacena los datos del curso en datosalumno
         //type=0 ->nuevo
         //type=1 ->modificacion
            string[] curso = new string[5];//Array que almacena los datos de contacto del alumno

            //Lleno el array del curso

            


            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                int periodoSeleccionado = boxPeriodoAlumno.SelectedIndex;
                string estadoAlumno = "En espera";
                int id_grupo = 0;
                if (periodoSeleccionado == 1)
                {
                    id_grupo = 0;
                }
                else if (periodoSeleccionado > 1)
                {
                    if (eventoClickAgregarAlumnoCurso[0])
                    {
                        DataTable datosPeriodos = eventoClickAgregarAlumnoCurso[1];
                        int.TryParse(datosPeriodos.Rows[periodoSeleccionado - 2][1].ToString(), out id_grupo);
                        estadoAlumno = boxEstadoAlumno.SelectedItem.ToString();
                    }
                }
                curso[0] = boxCursoAlumno.SelectedItem.ToString();
                curso[1] = estadoAlumno;
                curso[2] = id_grupo + "";
                if (txtMontoViatico.Text == controlador.mapTextBox[txtMontoViatico.GetHashCode().ToString()])
                {
                    curso[3] = "0";
                }else
                {
                    curso[3] = txtMontoViatico.Text;
                }
                curso[4] = boxTurnoAlumno.SelectedItem.ToString();

                


                retorno = datosAlumno.setCurso(curso); //Verifico los datos
            }
            else
            {//modificacion
                int periodoSeleccionado = boxPeriodoAlumno_2.SelectedIndex;
                int id_grupo = 0;
                string estadoAlumno = "En espera";
                if (periodoSeleccionado == 1)
                {
                    id_grupo = 0;
                }
                else if (periodoSeleccionado > 1)
                {
                    if (eventoClickModificarAlumnoCurso[0])
                    {
                        DataTable datosPeriodos = eventoClickModificarAlumnoCurso[1];
                        int.TryParse(datosPeriodos.Rows[periodoSeleccionado - 2][1].ToString(), out id_grupo);
                        estadoAlumno = boxEstadoAlumno_2.SelectedItem.ToString();
                    }
                }
                curso[0] = boxCursoAlumno_2.SelectedItem.ToString();
                curso[1] = estadoAlumno;
                curso[2] = id_grupo+"";

                if (txtMontoViatico_2.Text == controlador.mapTextBox[txtMontoViatico_2.GetHashCode().ToString()])
                {
                    curso[3] = "";
                }
                else
                {
                    curso[3] = txtMontoViatico_2.Text;
                }
                
                curso[4] = boxTurnoAlumno_2.SelectedItem.ToString();

                retorno = datosAlumnoModificacion.setCurso(curso); //Verifico los datos

            }
            return retorno;
        }
        private dynamic[] setDatosContactoAlumno(int type)
        {
            //type=0 ->nuevo
            //type=1 ->modificacion
            string[] contacto = new string[3]; //Array que almacena la informacion del curso

            //Lleno el array con los datos de contacto
            

            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                if (txtTelefonoAlumno.Text.Equals("Telefono"))
                {
                    contacto[0] = "0";
                }
                else
                {
                    contacto[0] = txtTelefonoAlumno.Text;
                }
                if (txtCelularAlumno.Text.Equals("Celular"))
                {
                    contacto[1] = "0";
                }
                else
                {
                    contacto[1] = txtCelularAlumno.Text;
                }
                if (txtEmailAlumno.Text.Equals("Email"))
                {
                    contacto[2] = "";
                }else
                {
                    contacto[2] = txtEmailAlumno.Text;

                }

                retorno = datosAlumno.setContacto(contacto);//verifico los datos

            }
            else
            {//modificacion
                if (txtTelefonoAlumno_2.Text.Equals("Telefono"))
                {
                    contacto[0] = "0";

                }
                else
                {
                    contacto[0] = txtTelefonoAlumno_2.Text;

                }
                if (txtCelularAlumno_2.Text.Equals("Celular"))
                {
                    contacto[1] = "0";

                }
                else
                {
                    contacto[1] = txtCelularAlumno_2.Text;

                }

                if (txtEmailAlumno_2.Text.Equals("Email"))
                {
                    contacto[2] = "";
                }
                else
                {
                    contacto[2] = txtEmailAlumno_2.Text;
                }

                retorno = datosAlumnoModificacion.setContacto(contacto);//verifico los datos

            }
            return retorno;

        }
        private dynamic[] setDatosDireccionAlumno(int type)
        {
            //type=0 ->nuevo
            //type=1 ->modificacion
            string[] direccion = new string[6];//array que almacena los datos de direccion del alumno

            //Lleno array de direccion
            

            dynamic[] retorno;

            if (type == 0)
            {//nuevo
                direccion[0] = boxDepartamentoAlumno.SelectedItem.ToString();
                direccion[1] = txtLocalidadAlumno.Text;
                direccion[2] = txtCalleAlumno.Text;
                if (txtReferenciaAlumno.Text.Equals(controlador.mapTextBox[txtReferenciaAlumno.GetHashCode().ToString()]))
                {
                    direccion[3] = "";
                }
                else
                {
                    direccion[3] = txtReferenciaAlumno.Text;
                }

                direccion[4] = txtNumeroPuertaAlumno.Text;

                if (txtNumeroApartamentoAlumno.Text.Equals(controlador.mapTextBox[txtNumeroApartamentoAlumno.GetHashCode().ToString()]))
                {
                    direccion[5] = "0";

                }else
                {
                    direccion[5] = txtNumeroApartamentoAlumno.Text;

                }

                retorno = datosAlumno.setDireccion(direccion);//verifico los datos
            }
            else
            {//modificacion
                //verificaciones
                direccion[0] = boxDepartamentoAlumno_2.SelectedItem.ToString();
                direccion[1] = txtLocalidadAlumno_2.Text;
                direccion[2] = txtCalleAlumno_2.Text;
                if (txtReferenciaAlumno_2.Text.Equals(controlador.mapTextBox[txtReferenciaAlumno_2.GetHashCode().ToString()])){
                    direccion[3] = "";
                }else
                {
                    direccion[3] = txtReferenciaAlumno_2.Text;
                }
                
                direccion[4] = txtNPuertaAlumno_2.Text;
                if (txtNApartamentoAlumno_2.Text.Equals(controlador.mapTextBox[txtNApartamentoAlumno_2.GetHashCode().ToString()]))
                {
                    direccion[5] = "0";
                }else
                {
                    direccion[5] = txtNApartamentoAlumno_2.Text;
                }
               

                retorno = datosAlumnoModificacion.setDireccion(direccion);//verifico los datos

            }

            return retorno;
        }
        private dynamic[] setDatosFormacionAcademicaAlumno(int type)
        {
            //type=0 ->nuevo
            //type=1 ->modificacion
            string[] formacionAcademica = new string[2];//Array que almacena los datos de la formacion academica del alumno

            //Lleno los datos del array
            

            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                formacionAcademica[0] = boxNivelEducativo.SelectedItem.ToString();
                formacionAcademica[1] = txtUltAñoAprobado.Text;

                retorno = datosAlumno.setFormacionAcademica(formacionAcademica);//verifico los datos
            }
            else
            {//modificacion

                formacionAcademica[0] = boxNivelAcademicoAlumno_2.SelectedItem.ToString();
                formacionAcademica[1] = txtUltimoAñoAprobadoAlumno_2.Text;

                retorno = datosAlumnoModificacion.setFormacionAcademica(formacionAcademica);//verifico los datos

            }
            return retorno;
        }

        /// <summary>
        /// Termina primera parte de ingreso de alumno y comienza segunda parte
        /// </summary>
        /// <returns></returns>
        private dynamic[] setDatosTrabajoAlumno(int type)
        {//Metodo que verifica la parte del trabajo
         //type=0 ->nuevo
         //type=1 ->modificacion
            string[] trabajo = new string[5]; //Array que almacena los datos del trabajo del alumno
            

            dynamic[] retorno;
            if (type == 0)
            {
                trabajo[0] = boxTrabajoAlgunaVezAlumno.SelectedItem.ToString();
                trabajo[1] = boxTrabajaActualmenteAlumno.SelectedItem.ToString();
                trabajo[2] = txtTiempoDesempleadoAlumno.Text;
                trabajo[3] = txtHorasJornadaAlumno.Text;
                trabajo[4] = txtIngresoMensualAlumno.Text;

                retorno = datosAlumno.setTrabajo(trabajo);
            }
            else
            {
                trabajo[0] = boxTrabajoAlgunaVezAlumno_2.SelectedItem.ToString();
                trabajo[1] = boxTrabajaActualmenteAlumno_2.SelectedItem.ToString();
                trabajo[2] = txtTiempoDesempleadoAlumno_2.Text;
                trabajo[3] = txtHorasJornadaAlumno_2.Text;
                trabajo[4] = txtIngresoMensualAlumno_2.Text;

                retorno = datosAlumnoModificacion.setTrabajo(trabajo);

            }
            return retorno;
        }
        private dynamic[] setDatosAccessoInternet(int type)
        {//Metodo que verifica la parte del acceso a internet
         //type=0 ->nuevo
         //type=1 ->modificacion
            string[] accesso_a_internet = new string[3];
            
            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                accesso_a_internet[0] = boxUsaInternetAlumno.SelectedItem.ToString();
                accesso_a_internet[1] = boxFacilAccesoInternetAlumno.SelectedItem.ToString();
                accesso_a_internet[2] = txtMedioAccesoInternetAlumno.Text;

                retorno = datosAlumno.setAccessoInternet(accesso_a_internet);
            }
            else
            {

                accesso_a_internet[0] = boxUsaInternetAlumno_2.SelectedItem.ToString();
                accesso_a_internet[1] = boxFacilAccesoInternetAlumno_2.SelectedItem.ToString();
                accesso_a_internet[2] = txtMedioAccesoInternetAlumno_2.Text;

                retorno = datosAlumnoModificacion.setAccessoInternet(accesso_a_internet);

            }
            return retorno;
        }
        private dynamic[] setDatosJefeHogar(int type)
        {//Metodo que verifica los datos de jefe de hogar
         //type=0 ->nuevo
         //type=1 ->modificacion
            string[] jefe_hogar = new string[2];
            

            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                jefe_hogar[0] = boxJefeHogarAlumno.SelectedItem.ToString();

                if(boxCantidadHijosAlumno.SelectedIndex == 0)
                {
                    jefe_hogar[1] = "0";
                }else
                {
                    jefe_hogar[1] = boxCantidadHijosAlumno.SelectedItem.ToString();
                }

               
                retorno = datosAlumno.setHogar(jefe_hogar);
            }
            else
            {//modificacion

                jefe_hogar[0] = boxJefeHogarAlumno_2.SelectedItem.ToString();
               if (boxCantidadHijosAlumno_2.SelectedIndex == 0)
                {
                    jefe_hogar[1] = "0";
                }else
                {
                    jefe_hogar[1] = boxCantidadHijosAlumno_2.SelectedItem.ToString();
                }
                retorno = datosAlumnoModificacion.setHogar(jefe_hogar);

            }
            return retorno;
        }
        private dynamic[] setDatosCoberturaSalud(int type)
        {//Metodo que verifica la cobertura de salud 
            //type=0 ->nuevo
            //type=1 ->modificacion
            
            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                string cobertura = txtCoberuraSaludAlumno.Text;
                retorno = datosAlumno.setCobertura(cobertura);
            }
            else
            {
                string cobertura = txtCoberturaSaludAlumno_2.Text;
                retorno = datosAlumnoModificacion.setCobertura(cobertura);
            }

            return retorno;
        }
        private dynamic[] setDatosPersonasACargo(int type)
        {
            //type=0 ->nuevo
            //type=1 ->modificacion
            string[] personasCargo = new string[8];

            
            dynamic[] retorno;
            if (type == 0)
            {//nuevo
                if (txt0a17Alumno.Text.Equals(controlador.mapTextBox[txt0a17Alumno.GetHashCode().ToString()]))
                {
                    personasCargo[0] = "0";
                }
                else
                {
                    personasCargo[0] = txt0a17Alumno.Text;
                }

                if (txt18a59Alumno.Text.Equals(controlador.mapTextBox[txt18a59Alumno.GetHashCode().ToString()]))
                {
                    personasCargo[1] = "0";
                }
                else
                {
                    personasCargo[1] = txt18a59Alumno.Text;
                }

                if (txt60oMasAlumno.Text.Equals(controlador.mapTextBox[txt60oMasAlumno.GetHashCode().ToString()]))
                {
                    personasCargo[2] = "0";
                }
                else
                {
                    personasCargo[2] = txt60oMasAlumno.Text;
                }

                
                if (boxPersonaDiscapacidadAlumno.SelectedIndex == 0)
                {
                    personasCargo[3] = "0";
                }
                else
                {
                    personasCargo[3] = boxPersonaDiscapacidadAlumno.SelectedItem.ToString();
                }
               

               if(boxCuentaConApoyoAlumno.SelectedIndex == 0)
                {
                    personasCargo[4] = "0";
                }
                else
                {
                    personasCargo[4] = boxCuentaConApoyoAlumno.SelectedItem.ToString();
                }

                if (txtCargaSemanalCuidadoAlumno.Text.Equals(controlador.mapTextBox[txtCargaSemanalCuidadoAlumno.GetHashCode().ToString()]))
                {
                    personasCargo[5] = "";
                }
                else
                {
                    personasCargo[5] = txtCargaSemanalCuidadoAlumno.Text;
                }

                if (boxTrabajoCuidandoAlumno.SelectedIndex == 0)
                {
                    personasCargo[6] = "0";
                }
                else
                {
                    personasCargo[6] = boxTrabajoCuidandoAlumno.SelectedItem.ToString();
                }

                if (txtExperienciaInstitucionesCuidadoAlumno.Text.Equals(controlador.mapTextBox[txtExperienciaInstitucionesCuidadoAlumno.GetHashCode().ToString()]))
                {
                    personasCargo[7] = "";
                }
                else
                {
                    personasCargo[7] = txtExperienciaInstitucionesCuidadoAlumno.Text;
                }

                
                retorno = datosAlumno.setPersonasACargo(personasCargo);
            }
            else
            {

                if (txt0a17Alumno_2.Text.Equals(controlador.mapTextBox[txt0a17Alumno_2.GetHashCode().ToString()]))
                {
                    personasCargo[0] = "0";
                }
                else
                {
                    personasCargo[0] = txt0a17Alumno_2.Text;
                }

                if (txt18a59Alumno_2.Text.Equals(controlador.mapTextBox[txt18a59Alumno_2.GetHashCode().ToString()]))
                {
                    personasCargo[1] = "0";
                }
                else
                {
                    personasCargo[1] = txt18a59Alumno_2.Text;
                }

                if (txt60oMasAlumno_2.Text.Equals(controlador.mapTextBox[txt60oMasAlumno_2.GetHashCode().ToString()]))
                {
                    personasCargo[2] = "0";
                }
                else
                {
                    personasCargo[2] = txt60oMasAlumno_2.Text;
                }


                if (boxPersonaDiscapacidadAlumno_2.SelectedIndex == 0)
                {
                    personasCargo[3] = "0";
                }
                else
                {
                    personasCargo[3] = boxPersonaDiscapacidadAlumno_2.SelectedItem.ToString();
                }


                if (boxCuentaConApoyoAlumno_2.SelectedIndex == 0)
                {
                    personasCargo[4] = "0";
                }
                else
                {
                    personasCargo[4] = boxCuentaConApoyoAlumno_2.SelectedItem.ToString();
                }

                if (txtCargaSemanalCuidadoAlumno_2.Text.Equals(controlador.mapTextBox[txtCargaSemanalCuidadoAlumno_2.GetHashCode().ToString()]))
                {
                    personasCargo[5] = "";
                }
                else
                {
                    personasCargo[5] = txtCargaSemanalCuidadoAlumno_2.Text;
                }

                if (boxTrabajoCuidandoAlumno_2.SelectedIndex == 0)
                {
                    personasCargo[6] = "0";
                }
                else
                {
                    personasCargo[6] = boxTrabajoCuidandoAlumno_2.SelectedItem.ToString();
                }

                if (txtExperienciaInstitucionesCuidadoAlumno_2.Text.Equals(controlador.mapTextBox[txtExperienciaInstitucionesCuidadoAlumno_2.GetHashCode().ToString()]))
                {
                    personasCargo[7] = "";
                }
                else
                {
                    personasCargo[7] = txtExperienciaInstitucionesCuidadoAlumno_2.Text;
                }

                //personasCargo[0] = txt0a17Alumno_2.Text;
                //personasCargo[1] = txt18a59Alumno_2.Text;
                //personasCargo[2] = txt60oMasAlumno_2.Text;
                //personasCargo[3] = boxPersonaConDiscapacidadAlumno_2.SelectedItem.ToString();
                //personasCargo[4] = boxCuentaConApoyoAlumno_2.SelectedItem.ToString();
                //personasCargo[5] = txtCargaSemanalCuidandoAlumno_2.Text;
                //personasCargo[6] = boxTrabajoCuidandoAlumno_2.SelectedItem.ToString();
                //personasCargo[7] = txtExperienciaInstitucionesTrabajoAlumno_2.Text;

                retorno = datosAlumnoModificacion.setPersonasACargo(personasCargo);
            }

            return retorno;

        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {//Boton que verificara que todos los datos esten correctos
            dynamic[] setDatosPersonalesAlumnoResultado = this.setDatosPersonalesAlumno(0);//objeto que guarda el estado y el mensaje 
            dynamic[] setDatosCursoAlumnoResultado = this.setDatosCursoAlumno(0);
            dynamic[] setDatosContactoAlumnoResultado = this.setDatosContactoAlumno(0);
            dynamic[] setDatosDireccionAlumnoResultado = this.setDatosDireccionAlumno(0);
            dynamic[] setDatosFormacionAcademicaAlumnoResultado = this.setDatosFormacionAcademicaAlumno(0);

            string mensaje = "";
            if (setDatosPersonalesAlumnoResultado[0])
            {
                mensaje = setDatosPersonalesAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosCursoAlumnoResultado[0])
            {
                mensaje = setDatosCursoAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosContactoAlumnoResultado[0])
            {
                mensaje = setDatosContactoAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosDireccionAlumnoResultado[0])
            {
                mensaje = setDatosDireccionAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosFormacionAcademicaAlumnoResultado[0])
            {
                mensaje = setDatosFormacionAcademicaAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }

            if (!setDatosPersonalesAlumnoResultado[0] && !setDatosCursoAlumnoResultado[0] &&
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
            dynamic[] setDatosTrabajoAlumno = this.setDatosTrabajoAlumno(0);
            dynamic[] setDatosAccesoInternetAlumno = this.setDatosAccessoInternet(0);
            dynamic[] setDatosJefeHogarAlumno = this.setDatosJefeHogar(0);
            dynamic[] setDatosPersonasACargoAlumno = this.setDatosPersonasACargo(0);//Depende del tipo del curso
            dynamic[] setDatosCoberturaSaludAlumno = this.setDatosCoberturaSalud(0);

            if (!setDatosTrabajoAlumno[0] && !setDatosAccesoInternetAlumno[0] &&
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

                if (diccionarioDeAlumno["direccion_referencia"].Equals(""))
                {
                    lblReferenciaAlumno.Text = "Referencia: " + "Sin dato";
                }
                else
                {
                    lblReferenciaAlumno.Text = "Referencia: " + diccionarioDeAlumno["direccion_referencia"];
                }

                
                lblNPuertaAlumno.Text = "Nº puerta: " + diccionarioDeAlumno["direccion_numero_puerta"];
                if (diccionarioDeAlumno["direccion_apartamento"].Equals("0"))
                {
                    lblNApartamentoAlumno.Text = "Nº apartamento: " + "Sin dato";
                }else
                {
                    lblNApartamentoAlumno.Text = "Nº apartamento: " + diccionarioDeAlumno["direccion_apartamento"];
                }

                //Contacto

                if (diccionarioDeAlumno["contacto_telefono"].Equals("0"))
                {
                    lblTelefonoAlumno.Text = "Telefono: " + "Sin dato";

                }
                else
                {
                    lblTelefonoAlumno.Text = "Telefono: " + diccionarioDeAlumno["contacto_telefono"];

                }
                if (diccionarioDeAlumno["contacto_celular"].Equals("0"))
                {
                    lblCelularAlumno.Text = "Celular: " + "Sin dato";

                }else
                {
                    lblCelularAlumno.Text = "Celular: " + diccionarioDeAlumno["contacto_celular"];

                }
                if (diccionarioDeAlumno["contacto_email"].Equals(""))
                {
                    lblEmailAlumno.Text = "Email: " + "Sin dato";


                }else
                {
                    lblEmailAlumno.Text = "Email: " + diccionarioDeAlumno["contacto_email"];

                }

                //Cobertura

                lblCoberturaSaludAlumno.Text = "Cobertura de salud: " + diccionarioDeAlumno["cobertura_salud"];

                //Hogar

                lblJefeHogarAlumno.Text = "Jefe de hogar: " + diccionarioDeAlumno["hogar_jefe"];

                if (diccionarioDeAlumno["hogar_cantidad_hijos"].Equals("0"))
                {
                    lblCantidadHijosAlumno.Text = "Cantidad de hijos: " + "Sin hijos";

                }
                else
                {
                    lblCantidadHijosAlumno.Text = "Cantidad de hijos: " + diccionarioDeAlumno["hogar_cantidad_hijos"];

                }

                //Trabajo

                lblTrabajoAlgunaVezAlumno.Text = "Trabajo aluna vez: " + diccionarioDeAlumno["trabajo_trabajo_alguna_vez"];
                lblTrabajaActualmenteAlumno.Text = "Trabaja actualmente: " + diccionarioDeAlumno["trabajo_trabaja_actualmente"];
                lblTiempoDesempleadoAlumno.Text = "Tiempo desempleado: " + diccionarioDeAlumno["trabajo_tiempo_desempleado"];
                lblHorasJornadaLaboralAlumno.Text = "Horas de jornada laboral: " + diccionarioDeAlumno["trabajo_horas_jornada"];
                lblIngresoMensualAlumno.Text = "Ingreso mensual: " + diccionarioDeAlumno["trabajo_ingreso_mensual"];

                //Personas a cargo
                if (diccionarioDeAlumno["personas_cargo_0_17"].Equals("0"))
                {
                    lbl0a17Alumno.Text = "De 0 a 17 años: " + "No aplica";
                }
                else
                {
                    lbl0a17Alumno.Text = "De 0 a 17 años: " + diccionarioDeAlumno["personas_cargo_0_17"];
                }
                
                if (diccionarioDeAlumno["personas_cargo_18_59"].Equals("0"))
                {
                    lbl18a59Alumno.Text = "De 18 a 59 años: " + "No aplica";
                }
                else
                {
                    lbl18a59Alumno.Text = "De 18 a 59 años: " + diccionarioDeAlumno["personas_cargo_18_59"];
                }

                if (diccionarioDeAlumno["personas_cargo_60_mas"].Equals("0"))
                {
                    lbl60oMasAlumno.Text = "De 60 años o mas: " + "No aplica";

                }else
                {
                    lbl60oMasAlumno.Text = "De 60 años o mas: " + diccionarioDeAlumno["personas_cargo_60_mas"];

                }
                if (diccionarioDeAlumno["personas_cargo_con_discapacidad"].Equals("0"))
                {
                    lblPersonaConDiscapacidadAlumno.Text = "Persona con discapacidad: " + "No aplica";

                }
                else
                {
                    lblPersonaConDiscapacidadAlumno.Text = "Persona con discapacidad: " + diccionarioDeAlumno["personas_cargo_con_discapacidad"];

                }

                if (diccionarioDeAlumno["personas_cargo_cuenta_con_apoyo"].Equals("0"))
                {
                    lblCuentaConApoyoAlumno.Text = "Cuenta con apoyo: " + "No aplica";

                }
                else
                {
                    lblCuentaConApoyoAlumno.Text = "Cuenta con apoyo: " + diccionarioDeAlumno["personas_cargo_cuenta_con_apoyo"];

                }

                if (diccionarioDeAlumno["personas_cargo_carga_semanal_cuidado"].Equals(""))
                {
                    lblCargaSemanalCuidadoAlumno.Text = "Carga semanal de cuidado: " + "No aplica";

                }
                else
                {
                lblCargaSemanalCuidadoAlumno.Text = "Carga semanal de cuidado: " + diccionarioDeAlumno["personas_cargo_carga_semanal_cuidado"];

                }

                if (diccionarioDeAlumno["personas_cargo_trabajo_cuidando"].Equals("0"))
                {
                    lblTrabajoAnteriormenteCuidandoAlumno.Text = "Trabajo anteriormente cuidando: " + "No aplica";

                }else
                {
                    lblTrabajoAnteriormenteCuidandoAlumno.Text = "Trabajo anteriormente cuidando: " + diccionarioDeAlumno["personas_cargo_trabajo_cuidando"];

                }

                if (diccionarioDeAlumno["personas_cargo_experiencia_instituciones_cuidado"].Equals(""))
                {
                    lblExperienciaInstitucionesCuidadoAlumno.Text = "Experiencia en instituciones de cuidado: " + "No aplica";

                }else
                {
                    lblExperienciaInstitucionesCuidadoAlumno.Text = "Experiencia en instituciones de cuidado: " + diccionarioDeAlumno["personas_cargo_experiencia_instituciones_cuidado"];

                }


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

            maskedTxtFechaNacimientoAlumno.Mask = "0000-00-00";//Asigno maskara a la fecha

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

            maskedTxtFechaNacimientoAlumno.Text = TimePickerFechaNacAlumnoNuevo.Value.Year + "/" + mes + "/" + dia;

            maskedTxtFechaNacimientoAlumno.ForeColor = Color.Black;
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
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea cerrar su sesión", "Seguro que desea continuar?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            
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
        public void lblRec(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {

                if (contHijo.GetType().Name.Equals("Label"))
                {
                    controlador.mapTextBox.Add(contHijo.GetHashCode().ToString(), contHijo.Text);

                }
                else
                {
                    if (contHijo.HasChildren)
                    {
                        this.lblRec(contHijo);
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

        private void btnSiguienteConsultaAlumno_Click(object sender, EventArgs e)
        {
            dynamic[] setDatosPersonalesAlumnoResultado = this.setDatosPersonalesAlumno(1);//objeto que guarda el estado y el mensaje 
            dynamic[] setDatosCursoAlumnoResultado = this.setDatosCursoAlumno(1);
            dynamic[] setDatosContactoAlumnoResultado = this.setDatosContactoAlumno(1);
            dynamic[] setDatosDireccionAlumnoResultado = this.setDatosDireccionAlumno(1);
            dynamic[] setDatosFormacionAcademicaAlumnoResultado = this.setDatosFormacionAcademicaAlumno(1);

            string mensaje = "";
            if (setDatosPersonalesAlumnoResultado[0])
            {
                mensaje = setDatosPersonalesAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosCursoAlumnoResultado[0])
            {
                mensaje = setDatosCursoAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosContactoAlumnoResultado[0])
            {
                mensaje = setDatosContactoAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosDireccionAlumnoResultado[0])
            {
                mensaje = setDatosDireccionAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }
            if (setDatosFormacionAcademicaAlumnoResultado[0])
            {
                mensaje = setDatosFormacionAcademicaAlumnoResultado[1];
                MessageBox.Show(mensaje);
            }


            if (!setDatosPersonalesAlumnoResultado[0] && !setDatosCursoAlumnoResultado[0] &&
                !setDatosContactoAlumnoResultado[0] && !setDatosDireccionAlumnoResultado[0] && !setDatosFormacionAcademicaAlumnoResultado[0])
            {//Se verifican que todos los datos sean correctos

                //Si todos los datos son correctos permito al pasaje a la segunda parte del formulario 
                if (eventoClickBuscarConsultaAlumno[0])
                {
                    rellenarFormularioTerceraParte();
                }


                tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
                tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosDeInteres);
                tabControlIngresarAlumno.SelectedIndex = 2;
            }
            else
            {

                //Si hay errores
            }


            

        }

        private void btnSiguienteConsultaAlumno_2_Click(object sender, EventArgs e)
        {
            dynamic[] setDatosTrabajoAlumno = this.setDatosTrabajoAlumno(1);
            dynamic[] setDatosAccesoInternetAlumno = this.setDatosAccessoInternet(1);
            dynamic[] setDatosJefeHogarAlumno = this.setDatosJefeHogar(1);
            dynamic[] setDatosPersonasACargoAlumno = this.setDatosPersonasACargo(1);//Depende del tipo del curso
            dynamic[] setDatosCoberturaSaludAlumno = this.setDatosCoberturaSalud(1);

            if (!setDatosTrabajoAlumno[0] && !setDatosAccesoInternetAlumno[0] &&
                !setDatosJefeHogarAlumno[0] && !setDatosPersonasACargoAlumno[0] //Depende del tipo de curso
                && !setDatosCoberturaSaludAlumno[0])
            {//Si todo es correcto
             //Se pasa a la finalizacion
                IDictionary<string, string> diccionarioDeAlumno = datosAlumnoModificacion.getDatosPersona();

                //Datos personales
                lblCedulaAlumno_3.Text = "Cedula: " + diccionarioDeAlumno["cedula_alumno"];
                lblNombre1Alumno_3.Text = "Primer nombre: " + diccionarioDeAlumno["nombre1"];
                lblNombre2Alumno_3.Text = "Segundo nombre: " + diccionarioDeAlumno["nombre2"];
                lblApellido1Alumno_3.Text = "Primer apellido: " + diccionarioDeAlumno["apellido1"];
                lblApellido2Alumno_3.Text = "Segundo apelldio: " + diccionarioDeAlumno["apellido2"];
                lblFechaNacimientoAlumno_3.Text = "Fecha de nacimiento: " + diccionarioDeAlumno["fecha_nac"];
                lblEdadAlumno_3.Text = "Edad: " + diccionarioDeAlumno["edad"];
                lblSexoAlumno_3.Text = "Sexo: " + diccionarioDeAlumno["sexo"];
                lblEstadoCivilAlumno_3.Text = "Estado civil: " + diccionarioDeAlumno["estado_civil"];
                //datos de curso

                lblCursoAlumno_3.Text = "Curso: " + diccionarioDeAlumno["curso_alumno"];
                lblEstadoAlumno_3.Text = "Estado: " + diccionarioDeAlumno["curso_estado"];
                lblMontoViaticoAlumno_3.Text = "Monto de viatico: " + diccionarioDeAlumno["curso_monto_viatico"];
                //Se deben agregar los dos campos

                //Formacion academica

                lblNivelEducativoAlumno_3.Text = "Nivel educativo: " + diccionarioDeAlumno["formacion_nivel"];
                lblUltimoAñoAprobadoAlumno_3.Text = "Ultimo año aprovado: " + diccionarioDeAlumno["formacion_ultimo_año_aprovado"];

                //Direccion

                lblDepartamentoAlumno_3.Text = "Departamento: " + diccionarioDeAlumno["direccion_departamento"];
                lblLocalidadAlumno_3.Text = "Localidad: " + diccionarioDeAlumno["direccion_localidad"];
                lblCalleAlumno_3.Text = "Calle: " + diccionarioDeAlumno["direccion_calle"];

                if (diccionarioDeAlumno["direccion_referencia"].Equals(""))
                {
                    lblReferenciaAlumno_3.Text = "Referencia: " + "Sin dato";
                }
                else
                {
                    lblReferenciaAlumno_3.Text = "Referencia: " + diccionarioDeAlumno["direccion_referencia"];
                }


                lblNPuertaAlumno_3.Text = "Nº puerta: " + diccionarioDeAlumno["direccion_numero_puerta"];
                if (diccionarioDeAlumno["direccion_apartamento"].Equals("0"))
                {
                    lblNApartamentoAlumno_3.Text = "Nº apartamento: " + "Sin dato";
                }
                else
                {
                    lblNApartamentoAlumno_3.Text = "Nº apartamento: " + diccionarioDeAlumno["direccion_apartamento"];
                }

                //Contacto
                if (diccionarioDeAlumno["contacto_telefono"].Equals("0"))
                {
                    lblTelefonoAlumno_3.Text = "Telefono: " + "Sin dato";

                }
                else
                {
                    lblTelefonoAlumno_3.Text = "Telefono: " + diccionarioDeAlumno["contacto_telefono"];

                }
                if (diccionarioDeAlumno["contacto_celular"].Equals("0"))
                {
                    lblCelularAlumno_3.Text = "Celular: " + "Sin dato";

                }else
                {
                    lblCelularAlumno_3.Text = "Celular: " + diccionarioDeAlumno["contacto_celular"];

                }
                if (diccionarioDeAlumno["contacto_email"].Equals(""))
                {
                    lblEmailAlumno_3.Text = "Email: " + "Sin dato";
                }else
                {
                    lblEmailAlumno_3.Text = "Email: " + diccionarioDeAlumno["contacto_email"];

                }

                //Cobertura

                lblCoberturaSaludAlumno_3.Text = "Cobertura de salud: " + diccionarioDeAlumno["cobertura_salud"];

                //Hogar

                lblJefeHogarAlumno_3.Text = "Jefe de hogar: " + diccionarioDeAlumno["hogar_jefe"];

                if (diccionarioDeAlumno["hogar_cantidad_hijos"].Equals("0"))
                {
                    lblCantidadHijosAlumno_3.Text = "Cantidad de hijos: " + "Sin hijos";

                }
                else
                {
                    lblCantidadHijosAlumno_3.Text = "Cantidad de hijos: " + diccionarioDeAlumno["hogar_cantidad_hijos"];

                }

                //Trabajo

                lblTrabajoAlgunaVezAlumno_3.Text = "Trabajo aluna vez: " + diccionarioDeAlumno["trabajo_trabajo_alguna_vez"];
                lblTrabajaActualmenteAlumno_3.Text = "Trabaja actualmente: " + diccionarioDeAlumno["trabajo_trabaja_actualmente"];
                lblTiempoDesempleadoAlumno_3.Text = "Tiempo desempleado: " + diccionarioDeAlumno["trabajo_tiempo_desempleado"];
                lblHorasJornadaLaboralAlumno_3.Text = "Horas de jornada laboral: " + diccionarioDeAlumno["trabajo_horas_jornada"];
                lblIngresoMensualAlumno_3.Text = "Ingreso mensual: " + diccionarioDeAlumno["trabajo_ingreso_mensual"];

                bool c1nulo = false, c2nulo = false, c3nulo = false;
                //Personas a cargo
                if (diccionarioDeAlumno["personas_cargo_0_17"].Equals("0"))
                {
                    lbl0a17Alumno_3.Text = "De 0 a 17 años: " + "No aplica";
                    c1nulo = true;
                }
                else
                {
                    lbl0a17Alumno_3.Text = "De 0 a 17 años: " + diccionarioDeAlumno["personas_cargo_0_17"];
                }

                if (diccionarioDeAlumno["personas_cargo_18_59"].Equals("0"))
                {
                    lbl18a59Alumno_3.Text = "De 18 a 59 años: " + "No aplica";
                    c2nulo = true;
                }
                else
                {
                    lbl18a59Alumno_3.Text = "De 18 a 59 años: " + diccionarioDeAlumno["personas_cargo_18_59"];
                }

                if (diccionarioDeAlumno["personas_cargo_60_mas"].Equals("0"))
                {
                    lbl60oMasAlumno_3.Text = "De 60 años o mas: " + "No aplica";
                    c3nulo = true;
                }
                else
                {
                    lbl60oMasAlumno_3.Text = "De 60 años o mas: " + diccionarioDeAlumno["personas_cargo_60_mas"];

                }
                if(c1nulo && c2nulo && c3nulo)
                {
                    lblPersonaConDiscapacidadAlumno_3.Text = "Persona con discapacidad: " + "No aplica";
                    lblCuentaConApoyoAlumno_3.Text = "Cuenta con apoyo: " + "No aplica";
                    lblCargaSemanalCuidadoAlumno_3.Text = "Carga semanal de cuidado: " + "No aplica";
                }
                else
                {
                    if (diccionarioDeAlumno["personas_cargo_con_discapacidad"].Equals("0"))
                    {
                        lblPersonaConDiscapacidadAlumno_3.Text = "Persona con discapacidad: " + "No aplica";

                    }
                    else
                    {
                        lblPersonaConDiscapacidadAlumno_3.Text = "Persona con discapacidad: " + diccionarioDeAlumno["personas_cargo_con_discapacidad"];

                    }

                    if (diccionarioDeAlumno["personas_cargo_cuenta_con_apoyo"].Equals("0"))
                    {
                        lblCuentaConApoyoAlumno_3.Text = "Cuenta con apoyo: " + "No aplica";

                    }
                    else
                    {
                        lblCuentaConApoyoAlumno_3.Text = "Cuenta con apoyo: " + diccionarioDeAlumno["personas_cargo_cuenta_con_apoyo"];

                    }

                    if (diccionarioDeAlumno["personas_cargo_carga_semanal_cuidado"].Equals(""))
                    {
                        lblCargaSemanalCuidadoAlumno_3.Text = "Carga semanal de cuidado: " + "No aplica";

                    }
                    else
                    {
                        lblCargaSemanalCuidadoAlumno_3.Text = "Carga semanal de cuidado: " + diccionarioDeAlumno["personas_cargo_carga_semanal_cuidado"];

                    }
                }

                if (diccionarioDeAlumno["personas_cargo_trabajo_cuidando"].Equals("0"))
                {
                    lblTrabajoAnteriormenteCuidandoAlumno_3.Text = "Trabajo anteriormente cuidando: " + "No aplica";

                }
                else
                {
                    lblTrabajoAnteriormenteCuidandoAlumno_3.Text = "Trabajo anteriormente cuidando: " + diccionarioDeAlumno["personas_cargo_trabajo_cuidando"];

                }

                if (diccionarioDeAlumno["personas_cargo_experiencia_instituciones_cuidado"].Equals(""))
                {
                    lblExperienciaInstitucionesCuidadoAlumno_3.Text = "Experiencia en instituciones de cuidado: " + "No aplica";

                }
                else
                {
                    lblExperienciaInstitucionesCuidadoAlumno_3.Text = "Experiencia en instituciones de cuidado: " + diccionarioDeAlumno["personas_cargo_experiencia_instituciones_cuidado"];

                }


                //Accesso a internet

                lblUsaInternetAlumno_3.Text = "Usa internet: " + diccionarioDeAlumno["internet_usa_internet"];
                lblFacilAccesoInternetAlumno_3.Text = "Facil acceso a internet: " + diccionarioDeAlumno["internet_facil_acceso"];
                lblMedioAccesoInternetAlumno_3.Text = "Medio de acceso a internet: " + diccionarioDeAlumno["internet_medio_acceso"];





                tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
                tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosFinalizar);
                tabControlIngresarAlumno.SelectedIndex = 3;

            }
        }

        private void btnAtrasConsultaAlumno_2_Click(object sender, EventArgs e)
        {

            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosPersonales);
            tabControlIngresarAlumno.SelectedIndex = 1;
        }

        private void btnAtrasConsultaAlumno_3_Click_1(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosFinalizar);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosDeInteres);
            tabControlIngresarAlumno.SelectedIndex = 2;
        }

        private void btnAtrasConsultaAlumno_Click(object sender, EventArgs e)
        {
            tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
            tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosInformacion);
            tabControlIngresarAlumno.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (eventoClickBuscarConsultaAlumno[0])
            {
                rellenarConsultaAlumnoSegundaParte();
                
                //Muestro la proxima pagina
                tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosInformacion);
                tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosDatosPersonales);
                tabControlIngresarAlumno.SelectedIndex = 1;
            }

        }

        public void rellenarConsultaAlumnoSegundaParte()
        {
            if (eventoClickBuscarConsultaAlumno[0])
            {
                IDictionary<string, string> datosAlumnoDiccionario = datosAlumnoConsulta.getDatosPersona();

                
                boxEstadoAlumno_2.SelectedItem = datosAlumnoDiccionario["curso_estado"];
                txtMontoViatico_2.Text = datosAlumnoDiccionario["curso_monto_viatico"];
                boxTurnoAlumno_2.SelectedItem = datosAlumnoDiccionario["curso_turno"];
                boxCursoAlumno_2.SelectedItem = datosAlumnoDiccionario["curso_alumno"];
               

                

                //Falta seleccionar el periodo al que asiste el alumno

                //DatosPersonales

                txtCedulaAlumno_2.Text = datosAlumnoDiccionario["cedula_alumno"];
                txtNombre1Alumno_2.Text = datosAlumnoDiccionario["nombre1"];
                txtNombre2Alumno_2.Text = datosAlumnoDiccionario["nombre2"];
                txtApellido1Alumno_2.Text = datosAlumnoDiccionario["apellido1"];
                txtApellido2Alumno_2.Text = datosAlumnoDiccionario["apellido2"];
                maskedTxtFechaNacimientoAlumno_2.Text = datosAlumnoDiccionario["fecha_nac"];
                txtEdadAlumno_2.Text = datosAlumnoDiccionario["edad"];
                boxSexoAlumno_2.SelectedItem = datosAlumnoDiccionario["sexo"];
                boxEstadoCivilAlumno_2.SelectedItem = datosAlumnoDiccionario["estado_civil"];

                //Direccion

                boxDepartamentoAlumno_2.SelectedItem = datosAlumnoDiccionario["direccion_departamento"];
                txtLocalidadAlumno_2.Text = datosAlumnoDiccionario["direccion_localidad"];
                txtCalleAlumno_2.Text = datosAlumnoDiccionario["direccion_calle"];
                if (datosAlumnoDiccionario["direccion_referencia"].Equals(""))
                {
                    txtReferenciaAlumno_2.Text = "Referencia";
                }else
                {
                    txtReferenciaAlumno_2.Text = datosAlumnoDiccionario["direccion_referencia"];
                }

                txtNPuertaAlumno_2.Text = datosAlumnoDiccionario["direccion_numero_puerta"];

                if (datosAlumnoDiccionario["direccion_apartamento"].Equals("0"))
                {
                    txtNApartamentoAlumno_2.Text = "Número de apartamento";
                }else
                {
                    txtNApartamentoAlumno_2.Text = datosAlumnoDiccionario["direccion_apartamento"];
                }

                //Contacto
                if (datosAlumnoDiccionario["contacto_telefono"].Equals("0"))
                {
                    txtTelefonoAlumno_2.Text = controlador.mapTextBox[txtTelefonoAlumno_2.GetHashCode().ToString()];
                }
                else
                {
                    txtTelefonoAlumno_2.Text = datosAlumnoDiccionario["contacto_telefono"];
                }
                if (datosAlumnoDiccionario["contacto_celular"].Equals("0"))
                {
                    txtCelularAlumno_2.Text = controlador.mapTextBox[txtCelularAlumno_2.GetHashCode().ToString()];

                }
                else
                {
                    txtCelularAlumno_2.Text = datosAlumnoDiccionario["contacto_celular"];

                }
                if (datosAlumnoDiccionario["contacto_email"].Equals(""))
                {
                    txtEmailAlumno_2.Text = controlador.mapTextBox[txtEmailAlumno_2.GetHashCode().ToString()];

                }
                else
                {
                    txtEmailAlumno_2.Text = datosAlumnoDiccionario["contacto_email"];

                }

                //Formacion academica

                boxNivelAcademicoAlumno_2.SelectedItem = datosAlumnoDiccionario["formacion_nivel"];
                txtUltimoAñoAprobadoAlumno_2.Text = datosAlumnoDiccionario["formacion_ultimo_año_aprovado"];





            }

        }
        public void rellenarFormularioTerceraParte()
        {
            IDictionary<string, string> datosAlumnoDiccionario = datosAlumnoConsulta.getDatosPersona();

            //Cobertura de Salud

            if (eventoClickBuscarConsultaAlumno[0])
            {
                txtCoberturaSaludAlumno_2.Text = datosAlumnoDiccionario["cobertura_salud"];

                //Hogar

                boxJefeHogarAlumno_2.SelectedItem = datosAlumnoDiccionario["hogar_jefe"];
                boxCantidadHijosAlumno_2.SelectedItem = datosAlumnoDiccionario["hogar_cantidad_hijos"];

                //Trabajo

                boxTrabajoAlgunaVezAlumno_2.SelectedItem = datosAlumnoDiccionario["trabajo_trabajo_alguna_vez"];
                boxTrabajaActualmenteAlumno_2.SelectedItem = datosAlumnoDiccionario["trabajo_trabaja_actualmente"];
                txtTiempoDesempleadoAlumno_2.Text = datosAlumnoDiccionario["trabajo_tiempo_desempleado"];
                txtHorasJornadaAlumno_2.Text = datosAlumnoDiccionario["trabajo_horas_jornada"];
                txtIngresoMensualAlumno_2.Text = datosAlumnoDiccionario["trabajo_ingreso_mensual"];

                //Personas a cargo
                bool c1nulo = false, c2nulo = false, c3nulo = false;
                if (datosAlumnoDiccionario["personas_cargo_0_17"].Equals("0"))
                {
                    txt0a17Alumno_2.Text = controlador.mapTextBox[txt0a17Alumno_2.GetHashCode().ToString()];
                    c1nulo = true;
                }else
                {
                    txt0a17Alumno_2.Text = datosAlumnoDiccionario["personas_cargo_0_17"];
                }

                if (datosAlumnoDiccionario["personas_cargo_18_59"].Equals("0"))
                {
                    txt18a59Alumno_2.Text = controlador.mapTextBox[txt18a59Alumno_2.GetHashCode().ToString()];
                    c2nulo = true;
                }
                else
                {
                    txt18a59Alumno_2.Text = datosAlumnoDiccionario["personas_cargo_18_59"];
                }

                if (datosAlumnoDiccionario["personas_cargo_60_mas"].Equals("0"))
                {
                    txt60oMasAlumno_2.Text = controlador.mapTextBox[txt60oMasAlumno_2.GetHashCode().ToString()];
                    c3nulo = true;
                }else
                {
                    txt60oMasAlumno_2.Text = datosAlumnoDiccionario["personas_cargo_60_mas"];
                }

                if (c1nulo && c2nulo && c3nulo)
                {
                    boxPersonaDiscapacidadAlumno_2.SelectedIndex = 0;

                    boxCuentaConApoyoAlumno_2.SelectedIndex = 0;
                }
                else
                {
                    boxPersonaDiscapacidadAlumno_2.SelectedItem = datosAlumnoDiccionario["personas_cargo_con_discapacidad"];

                    boxCuentaConApoyoAlumno_2.SelectedItem = datosAlumnoDiccionario["personas_cargo_cuenta_con_apoyo"];
                }

               

                if (datosAlumnoDiccionario["personas_cargo_carga_semanal_cuidado"].Equals(""))
                {
                    txtCargaSemanalCuidadoAlumno_2.Text = controlador.mapTextBox[txtCargaSemanalCuidadoAlumno_2.GetHashCode().ToString()];
                }else
                {
                    txtCargaSemanalCuidadoAlumno_2.Text = datosAlumnoDiccionario["personas_cargo_carga_semanal_cuidado"];
                }

                if (datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"].Equals("") && datosAlumnoDiccionario["personas_cargo_trabajo_cuidando"].Equals("NO"))
                {
                    boxTrabajoCuidandoAlumno_2.SelectedIndex = 0;
                }
                else
                {
                    boxTrabajoCuidandoAlumno_2.SelectedItem = datosAlumnoDiccionario["personas_cargo_trabajo_cuidando"];
                }

                if (datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"].Equals(""))
                {
                    txtExperienciaInstitucionesCuidadoAlumno_2.Text = controlador.mapTextBox[txtExperienciaInstitucionesCuidadoAlumno_2.GetHashCode().ToString()];

                }else
                {
                    txtExperienciaInstitucionesCuidadoAlumno_2.Text = datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"];
                }

                //Acceso a internet

                boxUsaInternetAlumno_2.SelectedItem = datosAlumnoDiccionario["internet_usa_internet"];
                boxFacilAccesoInternetAlumno_2.SelectedItem = datosAlumnoDiccionario["internet_facil_acceso"];
                txtMedioAccesoInternetAlumno_2.Text = datosAlumnoDiccionario["internet_medio_acceso"];

            }

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
                    }else if (contHijo.GetType().Name.Equals("Label"))
                    {
                        string textoCuandoEstaVacio = "";

                        controlador.mapTextBox.TryGetValue(contHijo.GetHashCode().ToString(), out textoCuandoEstaVacio);

                        contHijo.Text = textoCuandoEstaVacio;
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
                buscarDocente(tipoBusqueda, datoDeBusqueda, datoCorrecto, false);


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


            }
            else
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
        public void buscarAlumno(int tipoBusqueda, string datoDeBusqueda, bool datoCorrecto)
        {
            if (datoCorrecto)
            {//Si el texto de busqueda supero todas las validaciones
                dynamic[] dato = controlador.consultarPersona(1, tipoBusqueda, datoDeBusqueda);
                
                if (dato[0] == true)
                {//Si se encontro a la persona
                    limpiarFormulario(tabPageModificarAlumnosDatosPersonales);
                    limpiarFormulario(tabPageIngresarAlumnoDatosInteres);
                    limpiarFormulario(tabPageAlumnosModificar);

                    IDictionary<string, string> datosAlumnoDiccionario = dato[1];
                    

                    string cedula = "";

                    datosAlumnoDiccionario.TryGetValue("cedula_alumno", out cedula);

                    //Relleno datosAlumno de consulta
                    dynamic[] datosAlumnoFeedback = datosAlumnoConsulta.rellenarDesdeDiccionario(datosAlumnoDiccionario);

                    if (datosAlumnoFeedback[0])
                    {//Si hay error
                        MessageBox.Show(datosAlumnoFeedback[1]);
                    }

                    eventoClickBuscarConsultaAlumno[0] = true;
                    eventoClickBuscarConsultaAlumno[1] = cedula;

                    rellenarConsultaAlumnoPrimeraParte();


                }
                else
                {//Si no se encontro a la persona
                    MessageBox.Show("No se ha encontrado a la persona");
                }
            }
        }

        public void rellenarConsultaAlumnoPrimeraParte()
        {
            if (eventoClickBuscarConsultaAlumno[0])
            {
                IDictionary<string, string> datosAlumnoDiccionario = datosAlumnoConsulta.getDatosPersona();

                //Primera parte
                //Curso
                lblCursoAlumno_2.Text = "Curso: " + datosAlumnoDiccionario["curso_alumno"];
                lblEstadoAlumno_2.Text = "Estado: " + datosAlumnoDiccionario["curso_estado"];
                lblMontoViaticoAlumno_2.Text = "Monto de viatico: $" + datosAlumnoDiccionario["curso_monto_viatico"];


                //Datos Personales

                lblCedulaAlumno_2.Text = "Cedula: " + datosAlumnoDiccionario["cedula_alumno"];
                lblNombe1Alumno_2.Text = "Primer nombre: " + datosAlumnoDiccionario["nombre1"];
                lblNombre2Alumno_2.Text = "Segundo nombre: " + datosAlumnoDiccionario["nombre2"];
                lblApellido1Alumno_2.Text = "Primer apellido: " + datosAlumnoDiccionario["apellido1"];
                lblApellido2Alumno_2.Text = "Segundo apellido: " + datosAlumnoDiccionario["apellido2"];
                DateTime fechaNacimiento = DateTime.Parse(datosAlumnoDiccionario["fecha_nac"]);

                lblFechaNacimientoAlumno_2.Text = "Fecha de nacimiento: " + fechaNacimiento.ToString("dd/MM/yyyy");
                lblEdadAlumno_2.Text = "Edad: " + datosAlumnoDiccionario["edad"];
                lblSexoAlumno_2.Text = "Sexo: " + datosAlumnoDiccionario["sexo"];
                lblEstadoCivilAlumno_2.Text = "Estado civil: " + datosAlumnoDiccionario["estado_civil"];

                //Formacion Academimca

                lblNivelEducativoAlumno_2.Text = "Nivel educativo: " + datosAlumnoDiccionario["formacion_nivel"];
                lblUltimoAñoAprobadoAlumno_2.Text = "Ultimo año aprovado: " + datosAlumnoDiccionario["formacion_ultimo_año_aprovado"];

                //Direccion

                lblDepartamentoAlumno_2.Text = "Departamento: " + datosAlumnoDiccionario["direccion_departamento"];
                lblLocalidadAlumno_2.Text = "Localidad: " + datosAlumnoDiccionario["direccion_localidad"];
                lblCalleAlumno_2.Text = "Calle: " + datosAlumnoDiccionario["direccion_calle"];
                if (datosAlumnoDiccionario["direccion_referencia"].Equals(""))
                {
                    lblReferenciaAlumno_2.Text = "Referencia: " + "Sin dato";
                }
                else
                {
                    lblReferenciaAlumno_2.Text = "Referencia: " + datosAlumnoDiccionario["direccion_referencia"];
                }
                lblNPuertaAlumno_2.Text = "Nº puerta: " + datosAlumnoDiccionario["direccion_numero_puerta"];

                if (datosAlumnoDiccionario["direccion_apartamento"].Equals("0"))
                {//Si el numero de apartamento esta vacio
                    lblNApartamentoAlumno_2.Text = "Nº apartamento: " + "Sin dato";
                }else
                {
                    lblNApartamentoAlumno_2.Text = "Nº apartamento: " + datosAlumnoDiccionario["direccion_apartamento"];
                }

                //Contacto
                if (datosAlumnoDiccionario["contacto_telefono"].Equals("0"))
                {
                    lblTelefonoAlumno_2.Text = "Telefono: " + "Sin dato";
                }else
                {
                    lblTelefonoAlumno_2.Text = "Telefono: " + datosAlumnoDiccionario["contacto_telefono"];
                }
                if (datosAlumnoDiccionario["contacto_celular"].Equals("0"))
                {
                    lblCelularAlumno_2.Text = "Celular: " + "Sin dato";

                }
                else
                {
                    lblCelularAlumno_2.Text = "Celular: " + datosAlumnoDiccionario["contacto_celular"];

                }
                if (datosAlumnoDiccionario["contacto_email"].Equals(""))
                {
                    lblEmailAlumno_2.Text = "Email: " + "Sin dato";

                }else
                {
                    lblEmailAlumno_2.Text = "Email: " + datosAlumnoDiccionario["contacto_email"];

                }

                //Coberturna

                lblCoberturaSaludAlumno_2.Text = "Cobertura de salud: " + datosAlumnoDiccionario["cobertura_salud"];

                //Hogar

                lblJefeHogarAlumno_2.Text = "Jefe de hogar: " + datosAlumnoDiccionario["hogar_jefe"];
                if (datosAlumnoDiccionario["hogar_cantidad_hijos"].Equals("0"))
                {
                    lblCantidadHjosAlumno_2.Text = "Cantidad de hijos: " + "Sin hijos";

                }else
                {
                    lblCantidadHjosAlumno_2.Text = "Cantidad de hijos: " + datosAlumnoDiccionario["hogar_cantidad_hijos"];

                }

                //Trabajo

                lblTrabajoAlgunaVezAlumno_2.Text = "Trabajo alguna vez: " + datosAlumnoDiccionario["trabajo_trabajo_alguna_vez"];
                lblTrabajaActualmenteAlumno_2.Text = "Trabaja Actualmente: " + datosAlumnoDiccionario["trabajo_trabaja_actualmente"];
                lblTiempoDesempleadoAlumno_2.Text = "Tiempo desempleado: " + datosAlumnoDiccionario["trabajo_tiempo_desempleado"];
                lblHorasJornadaLaboralAlumno_2.Text = "Horas de jornada laboral: " + datosAlumnoDiccionario["trabajo_horas_jornada"];
                lblIngresoMensualAlumno_2.Text = "Ingreso mensual: " + datosAlumnoDiccionario["trabajo_ingreso_mensual"];

                bool c1nulo = false, c2nulo = false, c3nulo = false;

                //Personas a Cargo
                if (datosAlumnoDiccionario["personas_cargo_0_17"].Equals("0"))
                {
                    lbl0a17Alumno_2.Text = "De 0 a 17 años: " + "No aplica";
                    c1nulo = true;
                }
                else
                {
                    lbl0a17Alumno_2.Text = "De 0 a 17 años: " + datosAlumnoDiccionario["personas_cargo_0_17"];
                    c1nulo = false;
                }
                if (datosAlumnoDiccionario["personas_cargo_18_59"].Equals("0"))
                {
                    lbl18a59Alumno_2.Text = "De 18 a 59 años: " + "No aplica";
                    c2nulo = true;

                }
                else
                {
                    lbl18a59Alumno_2.Text = "De 18 a 59 años: " + datosAlumnoDiccionario["personas_cargo_18_59"];
                    c2nulo = false;

                }


                if (datosAlumnoDiccionario["personas_cargo_60_mas"].Equals("0"))
                {
                    lbl60oMasAlumno_2.Text = "De 60 años o mas: " + "No aplica";
                    c3nulo = true;

                }
                else
                {
                    lbl60oMasAlumno_2.Text = "De 60 años o mas: " + datosAlumnoDiccionario["personas_cargo_60_mas"];
                    c3nulo = false;

                }

                if(c1nulo && c2nulo && c3nulo)
                {
                    lblPersonaConDiscapacidadAlumno_2.Text = "Persona con discapacidad: " + "No aplica";
                    lblCuentaApoyoAlumno_2.Text = "Cuenta con apoyo: " + "No aplica";
                    lblCargaSemanalCuidadoAlumno_2.Text = "Carga mensual de cuidado: " + "No aplica";
                }else
                {
                    lblPersonaConDiscapacidadAlumno_2.Text = "Persona con discapacidad: " + datosAlumnoDiccionario["personas_cargo_con_discapacidad"];
                    lblCuentaApoyoAlumno_2.Text = "Cuenta con apoyo: " + datosAlumnoDiccionario["personas_cargo_cuenta_con_apoyo"];
                    lblCargaSemanalCuidadoAlumno_2.Text = "Carga mensual de cuidado: " + datosAlumnoDiccionario["personas_cargo_carga_semanal_cuidado"];
                }

                if (datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"].Equals(""))
                {
                    lblExperienciaInstitucionesCuidadoAlumno_2.Text = "Experiencia en instituciones de cuidado: " + "No aplica";
                }else
                {
                    lblExperienciaInstitucionesCuidadoAlumno_2.Text = "Experiencia en instituciones de cuidado: " + datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"];
                }

                if (datosAlumnoDiccionario["personas_cargo_trabajo_cuidando"].Equals("NO") && datosAlumnoDiccionario["personas_cargo_experiencia_instituciones_cuidado"].Equals(""))
                {
                    lblTrabajoAnteriormenteCuidandoAlumno_2.Text = "Trabajo anteriormente cuidando: " + "No aplica";
                }else
                {
                    lblTrabajoAnteriormenteCuidandoAlumno_2.Text = "Trabajo anteriormente cuidando: " + datosAlumnoDiccionario["personas_cargo_trabajo_cuidando"];
                }

                //Acceso a Internet

                lblUsaInternetAlumno_2.Text = "Usa internet: " + datosAlumnoDiccionario["internet_usa_internet"];
                lblFacilAccesoInternetAlumno_2.Text = "Facil acceso a internet: " + datosAlumnoDiccionario["internet_facil_acceso"];
                lblMedioAccesoInternetAlumno_2.Text = "Medio de acceso a internet: " + datosAlumnoDiccionario["internet_medio_acceso"];

                btnModificarAlumno.Enabled = true;

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
            if (boxBuscar_2.SelectedIndex == 0)
            {
                txtBuscar_2.Enabled = false;
                btnBuscar_2.Enabled = false;
            }
            else
            {
                txtBuscar_2.Enabled = true;
                btnBuscar_2.Enabled = true;
            }

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

            if (boxBuscar.SelectedIndex == 0)
            {
                txtBuscar.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                txtBuscar.Enabled = true;
                btnBuscar.Enabled = true;
            }
            if (boxBuscar.SelectedIndex == 1)
            {//Si se selecciona cedula se ajusta el largo maximo a 8
                txtBuscar.MaxLength = 8;
            }
            else
            {
                txtBuscar.MaxLength = 255;
            }
        }
        private void MostrarCuadroInicio()
        {
            try
            {
                ///Ver como hacer con procesos
                ///Loading ld = new Loading
                ///ld.ShowDialog();
            }
            catch (System.Threading.ThreadAbortException e)
            {

            }catch(Exception e)
            {

            }
        }
        private void btnAñadirSemanaViaticos_Click(object sender, EventArgs e)
        {
            bool viaticoExitoso = true;
            DataTable listaAlumnos = eventoClickListaAlumnos[1];
            
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);
            
            if (boxCursoViaticos.SelectedIndex != 0)
            {

                if (hilo.ThreadState == System.Threading.ThreadState.Unstarted)
                {
                    hilo.Start();
                }


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


                    if (!CurContr.AñadirSemanaViatico(ci))
                    {

                        if (hilo.ThreadState == System.Threading.ThreadState.Running)
                        {
                            hilo.Suspend();
                        }
                        MessageBox.Show("Error al generar nueva semana de pago de viaticos, aún no ha pasado una semana desde el ultimo pago", "No es posible agregar otra semana de pago");
                        viaticoExitoso = false;
                        break;
                    }

                }

            }

            if (viaticoExitoso)
            {

                if (hilo.ThreadState == System.Threading.ThreadState.Running)
                {
                    hilo.Suspend();
                }
                MessageBox.Show("Se ha generado el viatico correctamente", "Viatico generado con exito");
                listAlumnosViaticos.SelectedIndex = listaAlumnos.Rows.Count - 1;
                listAlumnosViaticos.SelectedIndex = 0;
            }





        }

        public void actualizarMontoTotal()
        {
            double montoTotal = 0;
            DataTable datos = eventoClickListaAlumnos[1];
            string ci = datos.Rows[listAlumnosViaticos.SelectedIndex][datos.Columns[0]].ToString();
            montoTotal = CurContr.calcularMontoTotal(ci);
            lblMontoTotalViaticos.Text = "Monto total a pagar: $" + montoTotal;
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


                        dynamic[] update = controlador.updateDocente(infoDocente, especialidades, eventoClickBuscarConsultaDocente[1]);
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
            }
            else
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
            else
            {
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
            }
            else
            {
                MessageBox.Show("Primero debes buscar un docente");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarResultados(txtBuscar, boxBuscar, listResultadosDocentes, 0);
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
            mostrarResultados(txtBuscar_2, boxBuscar_2, listResultadosDocentes_2, 0);
        }

        public void mostrarResultados(TextBox textbox, ComboBox box, ListBox lista, int type)
        {
            //type=0 -> docente
            //type=1 -> alumno
            if (type == 0)
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
            else
            {//Si es alumno

                if (textbox.Text.Length >= 3 && box.SelectedIndex == 2)
                {
                    dynamic[] datosRecibidos = controlador.busquedaMultiple(1, textbox.Text);
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
                                if (column.ColumnName.Equals("cedula_alumno"))
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
            }//fin si es alumno
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
            boxNumeroGrupoViaticos.Items.Clear();
            boxNumeroGrupoViaticos.Items.Add("Grupo...");
            boxNumeroGrupoViaticos.SelectedIndex = 0;

            try
            {
                if (boxTurnoViaticos.SelectedIndex != 0)
                {
                    boxNumeroGrupo.Enabled = true;
                    DataTable data = new DataTable();

                    string turno = boxTurnoViaticos.SelectedItem.ToString();
                    string curso = boxCursoViaticos.SelectedItem.ToString();
                    string[] grupos = CurContr.ListarNumeroGrupo(curso, turno, out data);

                    for (int i = 0; i < grupos.Length; i++)
                    {

                        boxNumeroGrupoViaticos.Items.Add(grupos[i]);
                    }
                    boxNumeroGrupoViaticos.Enabled = true;
                    eventoClickCursoViaticos[0] = true;
                    eventoClickCursoViaticos[1] = data;

                }
                else
                {
                    boxNumeroGrupoViaticos.Enabled = false;
                }
            }
            catch (Exception)
            {


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
            string id_grupo = "";
            DataTable periodos = eventoClickListarPeriodosAsistencia[1];
            if (dataGridListaAsistencias.Rows.Count > 0)
            {
                dataGridListaAsistencias.Rows.Clear();
            }

            if (boxCursoAsistencia.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un curso primero.");
            }else if (boxNumeroGrupo.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un grupo primero.");
            }
            else
            {
                DataTable datosAlumnos = new DataTable();
                if (eventoClickListarPeriodosAsistencia[0])
                {
                    id_grupo = periodos.Rows[boxNumeroGrupo.SelectedIndex-1][1].ToString();
                }

                string[] alumnos = CurContr.ListarAlumnosGrupo(curso, turno, id_grupo, out datosAlumnos);

                for (int i = 0; i < alumnos.Length; i++)
                {
                    dataGridListaAsistencias.Rows.Add(alumnos[i]);
                }
                string[] materias = controlador.ListarMateriasPorCurso(curso);
                boxMateriaAsistencia.Items.Clear();
                boxMateriaAsistencia.Items.Add("Materia...");   
                for(int i = 0; i < materias.Length; i++)
                {
                    boxMateriaAsistencia.Items.Add(materias[i]);
                }


                btnGuardarLista.Enabled = true;
                dateTimeFechaAsistencia.Enabled = true;
                boxMateriaAsistencia.Enabled = true;
                boxMateriaAsistencia.SelectedIndex = 0;
                eventoClickGenerarListaAsistencias[0] = true;
                eventoClickGenerarListaAsistencias[1] = datosAlumnos;
                eventoClickGenerarListaAsistencias[2] = curso;
                eventoClickGenerarListaAsistencias[3] = turno;
                eventoClickGenerarListaAsistencias[4] = id_grupo;
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
                }
                else
                {
                    estadoNuevo = false;
                }

                string fecha = alumnoSeleccionado.Cells[0].FormattedValue.ToString();
                string semana = alumnoSeleccionado.Cells[5].FormattedValue.ToString();

                DateTime formatFecha;

                DateTime.TryParse(fecha, out formatFecha);

                fecha = formatFecha.ToString("yyyy-MM-dd");


                int val = listAlumnosViaticos.SelectedIndex;
                string ci = listaAlumnos.Rows[val][listaAlumnos.Columns[0]].ToString();



                bool resultado = CurContr.updatePago(ci, fecha, semana, estadoNuevo);

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
            int periodoSeleccionado = boxPeriodoAlumno.SelectedIndex;
            int id_grupo = 0;
            if (periodoSeleccionado == 1)
            {
                id_grupo = 0;
            }
            else if (periodoSeleccionado > 1)
            {
                if (eventoClickAgregarAlumnoCurso[0])
                {
                    DataTable datosPeriodos = eventoClickAgregarAlumnoCurso[1];
                    int.TryParse(datosPeriodos.Rows[periodoSeleccionado - 2][1].ToString(), out id_grupo);
                }
            }
            DialogResult dialogResult = MessageBox.Show("Esta seguro que todos los datos son correctos?", "Continuar?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (al.insertarAlumno(datosAlumno, id_grupo))
                {
                    MessageBox.Show("El alumno ha sido guardado con exito");

                    maskedTxtFechaNacimientoAlumno.Text = "";
            
                    limpiarFormulario(tabPageIngresarAlumnoDatosPersonales);
                    limpiarFormulario(tabPageIngresarAlumnoDatosInteres);
                    limpiarFormulario(tabPageIngresarAlumnoFinalizar);
                    tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoFinalizar);
                    tabControlIngresarAlumno.Controls.Remove(tabPageIngresarAlumnoDatosInteres);
                    tabControlIngresarAlumno.Controls.Add(tabPageIngresarAlumnoDatosPersonales);
                }
                else
                {
                    MessageBox.Show("Error al ingresar alumno, verifique que los campos contienen la informacion correcta", "Error al ingresar alumno");
                }


            }
            else if (dialogResult == DialogResult.No)
            {

            }





        }

        private void boxCursoAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxNumeroGrupo.Items.Clear();
            boxNumeroGrupo.Items.Add("Grupo...");
            boxNumeroGrupo.SelectedIndex = 0;

            try
            {
            if (boxCursoAsistencia.SelectedIndex !=0)
            {
                boxNumeroGrupo.Enabled = true;
                DataTable data = new DataTable();
               
                string turno=boxTurnoAsistencia.SelectedItem.ToString();
                string curso=boxCursoAsistencia.SelectedItem.ToString();
                string[] grupos = CurContr.ListarNumeroGrupo(curso,turno, out data);

                for (int i = 0; i < grupos.Length; i++)
                {
                       
                        boxNumeroGrupo.Items.Add(grupos[i]);
                }
                    eventoClickListarPeriodosAsistencia[0] = true;
                    eventoClickListarPeriodosAsistencia[1] = data;
            }
            else
            {
                boxNumeroGrupo.Enabled = false;
            }
            }
            catch (Exception)
            {

                
            }
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
            if (boxTurnoViaticos.SelectedIndex != 0)
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
            else
            {
                boxCursoViaticos.Enabled = false;
            }
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {

            if (boxTurnoGrupo.SelectedIndex != 0 && boxCursoGrupo.SelectedIndex != 0)
            {
                string turno = boxTurnoGrupo.SelectedItem.ToString();
                string curso = boxCursoGrupo.SelectedItem.ToString();
                string inicio = dateTimeInicioGrupo.Value.ToString();
                string fin = dateTimeFinalizacionGrupo.Value.ToString();
                string numero = txtNumeroGrupo.Text;

                DateTime fechaInicio = DateTime.Parse(inicio);
                DateTime fechaFin = DateTime.Parse(fin);
                string formattedFechaInicio = fechaInicio.ToString("yyyy-MM-dd");
                string formattedFechaFin = fechaFin.ToString("yyyy-MM-dd");

                if (CurContr.AgregarGrupo(curso, formattedFechaInicio, formattedFechaFin, turno,numero))
                {
                    dataGridGruposActivos.DataSource = CurContr.GruposActivos();
                    MessageBox.Show("El grupo ha sido creado con exito!", "Operacion exitosa.");
                }
            }
            else
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


            }
            else
            {
                boxCursoAsistencia.Enabled = false;


            }
        }

        private void boxCursoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCursoAlumno.SelectedIndex != 0)
            {
                boxPeriodoAlumno.Enabled = true;
            }
            else
            {
                boxPeriodoAlumno.Enabled = false;
            }
            string curso = boxCursoAlumno.SelectedItem.ToString();
            string turno = "";
            if (boxTurnoAlumno.SelectedItem != null)
            {
                turno = boxTurnoAlumno.SelectedItem.ToString();
            }

            DataTable datos = new DataTable();
            string[] periodos = CurContr.ListarPeriodos(curso, turno, out datos);
            boxPeriodoAlumno.Items.Clear();
            boxPeriodoAlumno.Items.Add("Periodo...");
            boxPeriodoAlumno.Items.Add("Pendiente");
            boxPeriodoAlumno.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno.Items.Add(periodos[i]);
            }
            eventoClickAgregarAlumnoCurso[0] = true;
            eventoClickAgregarAlumnoCurso[1] = datos;


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
            string curso = "";
            if (boxCursoAlumno.SelectedIndex > 0)
            {
              curso = boxCursoAlumno.SelectedItem.ToString();
            }
            string turno = "";
            if (boxTurnoAlumno.SelectedItem != null)
            {
                turno = boxTurnoAlumno.SelectedItem.ToString();
            }

            



            DataTable datos = new DataTable();
            string[] periodos = CurContr.ListarPeriodos(curso, turno, out datos);
            boxPeriodoAlumno.Items.Clear();
            boxPeriodoAlumno.Items.Add("Periodo...");
            boxPeriodoAlumno.Items.Add("Pendiente");
            boxPeriodoAlumno.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno.Items.Add(periodos[i]);
            }
            eventoClickAgregarAlumnoCurso[0] = true;
            eventoClickAgregarAlumnoCurso[1] = datos;

        }

        private void btnGuardarLista_Click(object sender, EventArgs e)
        {//evento que sube la lista a asistencias
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

            bool insertFail = false;
            if (eventoClickGenerarListaAsistencias[0])
            {
                if (boxMateriaAsistencia.SelectedIndex == 0)
                {
                    MessageBox.Show("Debes seleccionar una materia");
                }
                else
                {
                    if(hilo.ThreadState == System.Threading.ThreadState.Unstarted)
                    {
                        hilo.Start();
                    }
                    for (int i = 0; i < dataGridListaAsistencias.Rows.Count; i++)
                    {
                        string materia = "";
                        string fecha_asistencia = "";
                        string cedula = "";
                        int asistencia = 0;
                        string nombre_curso = "";
                        string turno = "";
                        string id_grupo = "";


                        if (boxMateriaAsistencia.SelectedIndex != 0)
                        {
                            materia = boxMateriaAsistencia.SelectedItem.ToString();
                        }
                        fecha_asistencia = dateTimeFechaAsistencia.Value.ToString("yyyy-MM-dd");

                        DataTable listaAlumnos = eventoClickGenerarListaAsistencias[1];

                        nombre_curso = eventoClickGenerarListaAsistencias[2];


                        turno = eventoClickGenerarListaAsistencias[3];
                        id_grupo = eventoClickGenerarListaAsistencias[4];
                        

                        if (dataGridListaAsistencias.Rows[i].Cells[1].FormattedValue.Equals(true))
                        {
                            asistencia = 1;
                        }
                        else
                        {
                            asistencia = 0;
                        }

                        cedula = listaAlumnos.Rows[i][listaAlumnos.Columns[1]].ToString();



                        if (!CurContr.agregarAsistencia(cedula, nombre_curso, turno, materia, fecha_asistencia,id_grupo, asistencia))
                        {
                            insertFail = true;
                        }

                        //cedula = listaAlumnos.Rows[indiceRowSelected][listaAlumnos.Columns[1]].ToString();

                    }

                    if (insertFail)
                    {
                        if (hilo.ThreadState == System.Threading.ThreadState.Running)
                        {
                            hilo.Abort();
                        }
                        MessageBox.Show("hubieron errores al insertar los datos");


                    }
                    else
                    {
                        if(hilo.ThreadState == System.Threading.ThreadState.Running)
                        {
                            hilo.Abort();
                        }
                        MessageBox.Show("Lista registrada correctamente");
                    }
                }
            }



        }

        private void boxTurnoAsistencia_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTurnoAsistencia_2.SelectedIndex != 0)
            {
                
                boxCursoAsistencia_2.Enabled = true;
                boxCursoAsistencia_2.Items.Clear();
                boxCursoAsistencia_2.Items.Add("Curso...");

                string turno = "";

                if (boxTurnoAsistencia_2.SelectedItem != null)
                {
                    turno = boxTurnoAsistencia_2.SelectedItem.ToString();
                }

                string[] cursos = CurContr.listarCursoPorTurno(turno);

                for (int i = 0; i < cursos.Length; i++)
                {
                    boxCursoAsistencia_2.Items.Add(cursos[i]);
                }

                boxCursoAsistencia_2.SelectedIndex = 0;


            }
            else
            {
                boxCursoAsistencia_2.Enabled = false;
                btnConsultarLista.Enabled = false;
            }





        }

        private void btnConsultarLista_Click(object sender, EventArgs e)
        {
            if (lstMateriasDelDia.SelectedIndex != -1)
            {
                if (dataGridListaAsistencias_2.Rows.Count > 0)
                {
                    dataGridListaAsistencias_2.Rows.Clear();
                }
                string turno = boxTurnoAsistencia_2.SelectedItem.ToString();
                string curso = boxCursoAsistencia_2.SelectedItem.ToString();
                string fecha = dateTimeFechaAsistencia_2.Value.ToString("yyyy-MM-dd");
                string materia = lstMateriasDelDia.SelectedItem.ToString();
                DataTable datos = eventoClickConsultarListaAsistencias[1];
                string id_grupo = "";
                
                if (eventoClickConsultarListaAsistencias[0])
                {
                    id_grupo = datos.Rows[boxNumeroGrupo_2.SelectedIndex - 1][1].ToString();
                }
                


                DataTable listaAlumnos = CurContr.listarAsistencias(turno, curso, fecha,id_grupo, materia);


                if (listaAlumnos.Rows.Count > 0)
                {
                    foreach (DataRow row in listaAlumnos.Rows)
                    {
                        string nombre = row[0].ToString();

                        dataGridListaAsistencias_2.Rows.Add(nombre);

                    }

                    for (int i = 0; i < listaAlumnos.Rows.Count; i++)
                    {
                        int asistencia_recibida = 0;
                        int.TryParse(listaAlumnos.Rows[i][1].ToString(), out asistencia_recibida);
                        bool asistencia = false;
                        if (asistencia_recibida == 1)
                        {
                            asistencia = true;
                        }
                        dataGridListaAsistencias_2.Rows[i].Cells[1].Value = asistencia;


                    }

                    dataGridListaAsistencias_2.Columns[0].ReadOnly = true;
                    dataGridListaAsistencias_2.Columns[1].ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron asistencias registradas");
                    //Si no hay ninguna asistencia ese dia para esa materia 
                }


            }
            else
            {
                MessageBox.Show("Debes seleccionar una materia");
            }

        }

        private void boxCursoAsistencia_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCursoAsistencia_2.SelectedIndex != 0)
            {
                btnConsultarLista.Enabled = false;

                string curso = boxCursoAsistencia_2.SelectedItem.ToString();
                boxNumeroGrupo_2.Items.Clear();
                boxNumeroGrupo_2.Items.Add("Grupo...");
                boxNumeroGrupo_2.SelectedIndex = 0;
                
                try
                {
                    if (boxCursoAsistencia_2.SelectedIndex != 0)
                    {
                        boxNumeroGrupo.Enabled = true;
                        DataTable data = new DataTable();

                        string turno = boxTurnoAsistencia_2.SelectedItem.ToString();

                        string[] grupos = CurContr.ListarNumeroGrupo(curso, turno, out data);

                        for (int i = 0; i < grupos.Length; i++)
                        {
                            boxNumeroGrupo_2.Items.Add(grupos[i]);
                        }
                        boxNumeroGrupo_2.Enabled = true;
                        eventoClickConsultarListaAsistencias[0] = true;
                        eventoClickConsultarListaAsistencias[1] = data;
                    }
                    else
                    {
                        boxNumeroGrupo_2.Enabled = false;
                    }
                }
                catch (Exception)
                {


                }

            }
            else
            {
                btnConsultarLista.Enabled = false;
            }
        }

        private void txtBuscarAlumno_TextChanged(object sender, EventArgs e)
        {
            mostrarResultados(txtBuscarAlumno, boxBuscarAlumno, listResultadosAlumnos, 1);
        }

        private void boxBuscarAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxBuscarAlumno.SelectedIndex == 0)
            {
                txtBuscarAlumno.Enabled = false;
                btnBuscar_3.Enabled = false;
            }
            else
            {
                txtBuscarAlumno.Enabled = true;
                btnBuscar_3.Enabled = true;
            }

            if (boxBuscarAlumno.SelectedIndex == 1)
            {//Si se selecciona cedula se ajusta el largo maximo a 8
                txtBuscarAlumno.MaxLength = 8;
            }
            else
            {
                txtBuscarAlumno.MaxLength = 255;
            }
        }

        private void listResultadosAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (listResultadosAlumnos.SelectedIndex != -1)
            {
                string ci = listResultadosAlumnos.SelectedItem.ToString().Substring(0, 8);
                buscarAlumno(0, ci, true);
                toolTip.SetToolTip(lblExperienciaInstitucionesCuidadoAlumno_2, lblExperienciaInstitucionesCuidadoAlumno_2.Text);
            }
        }

        private void btnBuscar_3_Click(object sender, EventArgs e)
        {
           
            if (boxBuscarAlumno.SelectedIndex == 0)
            {//Si el tipo de busqueda es el placeholder
                MessageBox.Show("Debe seleccionar un metodo de busqueda");
            }
            else if (boxBuscarAlumno.SelectedIndex != 0 && txtBuscarAlumno.Text.Equals("Texto de busqueda"))
            {//Si el campo de busqueda es cedula o nombre pero el campo de busqueda esta vacio
                MessageBox.Show("Se debe ingresar un texto de busqueda");
            }
            else
            {//Si se selecciona nombre y apellido/cedula y se escribio un dato de busqueda
                //Variables
                int tipoBusqueda = -1;//Variable que almacena el tipo de busqueda seleccionado
                bool datoCorrecto = false;//Variable que se usa para verificar si el dato esta ingresado correctamente
                string datoDeBusqueda = txtBuscarAlumno.Text; //Dato de busqueda que se ingreso en el textbox


                if (boxBuscarAlumno.SelectedIndex == 1)
                {//Si se selecciona cedula
                    tipoBusqueda = 0;

                }
                else if (boxBuscarAlumno.SelectedIndex == 2)
                {//Si se selecciona nombre
                    tipoBusqueda = 1;
                }

                datoCorrecto = verificarDatoCorrecto(tipoBusqueda, datoDeBusqueda);
                buscarAlumno(tipoBusqueda, datoDeBusqueda, datoCorrecto);
                toolTip.SetToolTip(lblExperienciaInstitucionesCuidadoAlumno_2, lblExperienciaInstitucionesCuidadoAlumno_2.Text);

            }
        }

        private void dateTimeFechaNacimientoAlumno_2_ValueChanged(object sender, EventArgs e)
        {
            maskedTxtFechaNacimientoAlumno_2.Mask = "0000-00-00";//Asigno maskara a la fecha

            string mes, dia;

            mes = dateTimeFechaNacimientoAlumno_2.Value.Month.ToString();
            dia = dateTimeFechaNacimientoAlumno_2.Value.Day.ToString();
            if (int.Parse(dia) < 10)
            {//si el dia es menor a 10, le agrego un cero delante
                dia = "0" + dia;
            }
            if (int.Parse(mes) < 10)
            {//Lo mismo que con dia
                mes = "0" + mes;
            }
            //Muestro la fecha en el masked box

            maskedTxtFechaNacimientoAlumno_2.Text = dateTimeFechaNacimientoAlumno_2.Value.Year + "/" + mes + "/" + dia;

            maskedTxtFechaNacimientoAlumno_2.ForeColor = Color.Black;
        }

        private void btnFinalizarConsultaAlumno_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que todos los datos son correctos?", "Continuar?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (controlador_alumno.ModificarAlumno(datosAlumnoModificacion, datosAlumnoConsulta.getDatosPersona()["cedula_alumno"], datosAlumnoConsulta.getDatosPersona()["curso_alumno"]))
                {
                    MessageBox.Show("El alumno ha sido actualizado con exito");
                    maskedTxtFechaNacimientoAlumno_2.Text = "";
                    eventoClickModificarAlumnoCurso[0] = false;
                    eventoClickBuscarConsultaAlumno[0] = false;
                    limpiarFormulario(tabPageModificarAlumnosInformacion);
                    limpiarFormulario(tabPageModificarAlumnosDatosPersonales);
                    limpiarFormulario(tabPageModificarAlumnosDatosDeInteres);
                    limpiarFormulario(tabPageModificarAlumnosFinalizar);
                    tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosPersonales);
                    tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosDatosDeInteres);
                    tabControlModificarAlumno.Controls.Remove(tabPageModificarAlumnosFinalizar);
                    tabControlModificarAlumno.Controls.Add(tabPageModificarAlumnosInformacion);
                    btnModificarAlumno.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al actualizar alumno, verifique que los campos contienen la informacion correcta", "Error al actualizar alumno");
                }


            }
        }

        

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(Application.StartupPath, "Resources\\Manual.pdf");
            Process.Start(pdfPath);


        }

        private void pruebaDeConexionConBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConexionBD con = new ConexionBD();
                      
            dynamic res = con.intentarConexion();

            if (res[0])
            {
                MessageBox.Show("La conexión con el servidor fue exitosa.");
            }else
            {
                MessageBox.Show("Conexion con el servidor fallida.");
            }


           
        }

        private void btnAñadirMateriaCurso_Click(object sender, EventArgs e)
        {

            string item = boxMateriasCurso.SelectedItem.ToString();

            if (!listMateriasCurso.Items.Contains(item))
            {
                listMateriasCurso.Items.Add(item);
            }
               

        }

        private void btnQuitarMateriaCurso_Click(object sender, EventArgs e)
        {
             
            if (listMateriasCurso.SelectedIndex > -1)
            {
                listMateriasCurso.Items.RemoveAt(listMateriasCurso.SelectedIndex);
            }
            
        }

        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            string curso = txtNombreCurso.Text;
            string tipo = boxTipoCurso.SelectedItem.ToString();
                      
            string[] materias = new string[listMateriasCurso.Items.Count+1];

            for (int i = 0; i < listMateriasCurso.Items.Count; i++)
            {
                materias[i] = listMateriasCurso.Items[i].ToString();               
            }
            

            if (materias.Length>0 && boxTipoCurso.SelectedIndex>0 && txtNombreCurso.Text != "Nombre del curso")
            {
                materias[materias.Length-1] = "nuevo";
                if (CurContr.AgregarCurso(curso, tipo, materias))
                {
                    MessageBox.Show("Curso añadido satisfactoriamente");
                    string[] listaCursos = controlador.ListarCursos();
                    boxCursoGrupo.Items.Clear();
                    boxCursoGrupo.Items.Add("Curso...");
                    for(int i = 0; i < listaCursos.Length; i++)
                    {
                        boxCursoGrupo.Items.Add(listaCursos[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Error al crear un nuevo curso");
                }
            }else
            {
                MessageBox.Show("Error al crear nuevo curso, verifique que los datos sean correctos ","Error");
            }


            
           

        }

        private void boxCursoAlumno_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxCursoAlumno_2.SelectedIndex != 0)
            {
                boxPeriodoAlumno_2.Enabled = true;
            }
            else
            {
                boxPeriodoAlumno_2.Enabled = false;
            }
            string curso = boxCursoAlumno_2.SelectedItem.ToString();
            string turno = "";
            if (boxTurnoAlumno_2.SelectedItem != null)
            {
                turno = boxTurnoAlumno_2.SelectedItem.ToString();
            }

            DataTable datos = new DataTable();
            string[] periodos = CurContr.ListarPeriodos(curso, turno, out datos);
            boxPeriodoAlumno_2.Items.Clear();
            boxPeriodoAlumno_2.Items.Add("Periodo...");
            boxPeriodoAlumno_2.Items.Add("Pendiente");
            boxPeriodoAlumno_2.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno_2.Items.Add(periodos[i]);
            }
            eventoClickModificarAlumnoCurso[0] = true;
            eventoClickModificarAlumnoCurso[1] = datos;

            string periodo = controlador_alumno.MostrarPeriodoAlumno(datosAlumnoConsulta.getDatosPersona()["cedula_alumno"], curso, turno);

            boxPeriodoAlumno_2.SelectedItem = periodo;
        }

        private void boxTurnoAlumno_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTurnoAlumno_2.SelectedIndex != 0)
            {
                boxCursoAlumno_2.Enabled = true;
            }
            else
            {
                boxCursoAlumno_2.Enabled = false;
            }
            string curso = boxCursoAlumno_2.SelectedItem.ToString();
            string turno = "";
            if (boxTurnoAlumno_2.SelectedItem != null)
            {
                turno = boxTurnoAlumno_2.SelectedItem.ToString();
            }

            DataTable datos = new DataTable();
            string[] periodos = CurContr.ListarPeriodos(curso, turno, out datos);
            boxPeriodoAlumno_2.Items.Clear();
            boxPeriodoAlumno_2.Items.Add("Periodo...");
            boxPeriodoAlumno_2.Items.Add("Pendiente");
            boxPeriodoAlumno_2.SelectedIndex = 0;
            for (int i = 0; i < periodos.Length; i++)
            {
                boxPeriodoAlumno_2.Items.Add(periodos[i]);
            }
            eventoClickModificarAlumnoCurso[0] = true;
            eventoClickModificarAlumnoCurso[1] = datos;

            string periodo = controlador_alumno.MostrarPeriodoAlumno(datosAlumnoConsulta.getDatosPersona()["cedula_alumno"], curso, turno);

            boxPeriodoAlumno_2.SelectedItem = periodo;

        }

        private void Solo_numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
                       
        }
        private void Solo_letras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void boxPeriodoAlumno_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxPeriodoAlumno_2.SelectedIndex == 1)
            {
                boxEstadoAlumno_2.SelectedIndex = boxEstadoAlumno_2.Items.Count - 1;
                boxEstadoAlumno_2.Enabled = false;
            }else if (boxPeriodoAlumno_2.SelectedIndex > 1)
            {
                boxEstadoAlumno_2.SelectedIndex = 3;
                boxEstadoAlumno_2.Enabled = true;
            }
        }

        private void boxPeriodoAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(boxPeriodoAlumno.SelectedIndex == 1)
            {
                boxEstadoAlumno.Enabled = false;
                boxEstadoAlumno.SelectedIndex = boxEstadoAlumno.Items.Count - 1;
            }else if(boxPeriodoAlumno.SelectedIndex > 1)
            {
                boxEstadoAlumno.SelectedIndex = 3;
                boxEstadoAlumno.Enabled = true;

            }
        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            ReporteErrores rep = new ReporteErrores();
            rep.ShowDialog();
        }
        
        private void reporteDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteErrores rep = new ReporteErrores();
            rep.ShowDialog();
        }

        private void maskedTxtFechaNacimientoAlumno_TextChanged(object sender, EventArgs e)
        {
            string fechaNacStr = maskedTxtFechaNacimientoAlumno.Text;

            DateTime nacimiento;
            DateTime.TryParse(maskedTxtFechaNacimientoAlumno.Text, out nacimiento);

            int edad = controlador.buscarEdad(nacimiento.ToString("yyyy-MM-dd"));

            txtEdadAlumno.Text = edad + "";
           
        }

        private void maskedTxtFechaNacimientoAlumno_2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            string fechaNacStr = maskedTxtFechaNacimientoAlumno_2.Text;

            DateTime nacimiento;
            DateTime.TryParse(maskedTxtFechaNacimientoAlumno_2.Text, out nacimiento);

            int edad = controlador.buscarEdad(nacimiento.ToString("yyyy-MM-dd"));

            txtEdadAlumno_2.Text = edad + "";
        }

        private void notasDeVersiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotasVersion nv = new NotasVersion();
            nv.ShowDialog();
        }

        private void menuPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void boxNumeroGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxMateriaAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxNumeroGrupoViaticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxNumeroGrupoViaticos.SelectedIndex != 0)
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
                string id_grupo = "";
                if (boxTurnoViaticos.SelectedItem != null)
                {
                    turno = boxTurnoViaticos.SelectedItem.ToString();
                }
                if (eventoClickCursoViaticos[0])
                {
                    DataTable datos = eventoClickCursoViaticos[1];
                    id_grupo = datos.Rows[boxNumeroGrupoViaticos.SelectedIndex - 1][1].ToString();
                }

                dynamic[] alumn = CurContr.AlumnosCurso(curso, turno,id_grupo, out dt);
                listAlumnosViaticos.Items.Clear();
                for (int i = 0; i < alumn.Length; i++)
                {
                    listAlumnosViaticos.Items.Add(alumn[i]);
                }
                if (alumn.Length > 0)
                {
                    eventoClickListaAlumnos[0] = true;
                    eventoClickListaAlumnos[1] = dt;

                    if (diaViatico)
                    {
                        btnAñadirSemanaViaticos.Enabled = true;
                    }


                }
                else
                {
                    btnAñadirSemanaViaticos.Enabled = false;
                }
            }

        }

        private void viaticos_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre1Alumno_TextChanged(object sender, EventArgs e)
        {
            txtNombre1Alumno.Text.ToUpper();
        }

        private void txtNombre2Alumno_TextChanged(object sender, EventArgs e)
        {
           txtNombre2Alumno.Text.ToUpper();
        }

        private void txtApellido1Alumno_TextChanged(object sender, EventArgs e)
        {
           txtApellido1Alumno.Text.ToUpper();
        }

        private void txtApellido2Alumno_TextChanged(object sender, EventArgs e)
        {
            txtApellido2Alumno.Text.ToUpper();
        }

        private void dateTimeFechaAsistencia_2_ValueChanged(object sender, EventArgs e)
        {
            if(boxTurnoAsistencia_2.SelectedIndex!=0 && boxCursoAsistencia_2.SelectedIndex!=0 && boxNumeroGrupo_2.SelectedIndex != 0)
            {
                btnConsultarLista.Enabled = false;
                string fecha = dateTimeFechaAsistencia_2.Value.ToString("yyyy-MM-dd");
                string turno = boxTurnoAsistencia_2.SelectedItem.ToString();
                string curso = boxCursoAsistencia_2.SelectedItem.ToString();
                DataTable numeroLista = eventoClickConsultarListaAsistencias[1];
                string numeroCurso = numeroLista.Rows[boxNumeroGrupo_2.SelectedIndex - 1][1].ToString();

                DataTable materias = CurContr.listarMateriasDeUnDia(turno, curso, numeroCurso, fecha);
                lstMateriasDelDia.Items.Clear();
                foreach (DataRow item in materias.Rows)
                {
                    lstMateriasDelDia.Items.Add(item[0].ToString());
                }

            }
        }

        private void lstMateriasDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMateriasDelDia.SelectedIndex != -1 && boxTurnoAsistencia_2.SelectedIndex!=0 && boxCursoAsistencia_2.SelectedIndex!=0 && boxNumeroGrupo_2.SelectedIndex!=0)
            {
                btnConsultarLista.Enabled = true;
            }else
            {
                btnConsultarLista.Enabled = false;
            }
        }

        private void boxNumeroGrupo_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxNumeroGrupo_2.SelectedIndex == 0)
            {
                btnConsultarLista.Enabled = false;
            }else
            {
                dateTimeFechaAsistencia_2_ValueChanged(sender, e);

            }

        }
    }
}
