namespace Ametrano.Presentacion
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaConfiguracion = new System.Windows.Forms.ListBox();
            this.tabControlConfiguracion = new System.Windows.Forms.TabControl();
            this.tabPageUsuarios = new System.Windows.Forms.TabPage();
            this.tabControlConfiguracionUsuariosElementos = new System.Windows.Forms.TabControl();
            this.tabPageVerUsuarios = new System.Windows.Forms.TabPage();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnCancelarCambiosUsuarios = new System.Windows.Forms.Button();
            this.btnGuardarCambiosBD = new System.Windows.Forms.Button();
            this.tabPageBD = new System.Windows.Forms.TabPage();
            this.txtUsuarioFuncionario = new System.Windows.Forms.TextBox();
            this.lblUsuarioFuncionario = new System.Windows.Forms.Label();
            this.txtDireccionBD = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnCancelarConfiguracionBD = new System.Windows.Forms.Button();
            this.btnGuardarConfiguracionBD = new System.Windows.Forms.Button();
            this.tabControlConfiguracion.SuspendLayout();
            this.tabPageUsuarios.SuspendLayout();
            this.tabControlConfiguracionUsuariosElementos.SuspendLayout();
            this.tabPageVerUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabPageBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaConfiguracion
            // 
            this.listaConfiguracion.BackColor = System.Drawing.SystemColors.Control;
            this.listaConfiguracion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaConfiguracion.Dock = System.Windows.Forms.DockStyle.Left;
            this.listaConfiguracion.FormattingEnabled = true;
            this.listaConfiguracion.Items.AddRange(new object[] {
            "Usuarios"});
            this.listaConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.listaConfiguracion.Name = "listaConfiguracion";
            this.listaConfiguracion.Size = new System.Drawing.Size(94, 333);
            this.listaConfiguracion.TabIndex = 0;
            this.listaConfiguracion.SelectedIndexChanged += new System.EventHandler(this.listaConfiguracion_SelectedIndexChanged);
            // 
            // tabControlConfiguracion
            // 
            this.tabControlConfiguracion.Controls.Add(this.tabPageUsuarios);
            this.tabControlConfiguracion.Controls.Add(this.tabPageBD);
            this.tabControlConfiguracion.Location = new System.Drawing.Point(95, -22);
            this.tabControlConfiguracion.Name = "tabControlConfiguracion";
            this.tabControlConfiguracion.SelectedIndex = 0;
            this.tabControlConfiguracion.Size = new System.Drawing.Size(766, 359);
            this.tabControlConfiguracion.TabIndex = 1;
            // 
            // tabPageUsuarios
            // 
            this.tabPageUsuarios.Controls.Add(this.tabControlConfiguracionUsuariosElementos);
            this.tabPageUsuarios.Controls.Add(this.btnCancelarCambiosUsuarios);
            this.tabPageUsuarios.Controls.Add(this.btnGuardarCambiosBD);
            this.tabPageUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsuarios.Name = "tabPageUsuarios";
            this.tabPageUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsuarios.Size = new System.Drawing.Size(758, 333);
            this.tabPageUsuarios.TabIndex = 0;
            this.tabPageUsuarios.Text = "tabPage1";
            this.tabPageUsuarios.UseVisualStyleBackColor = true;
            // 
            // tabControlConfiguracionUsuariosElementos
            // 
            this.tabControlConfiguracionUsuariosElementos.Controls.Add(this.tabPageVerUsuarios);
            this.tabControlConfiguracionUsuariosElementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlConfiguracionUsuariosElementos.Location = new System.Drawing.Point(3, 3);
            this.tabControlConfiguracionUsuariosElementos.Name = "tabControlConfiguracionUsuariosElementos";
            this.tabControlConfiguracionUsuariosElementos.SelectedIndex = 0;
            this.tabControlConfiguracionUsuariosElementos.Size = new System.Drawing.Size(752, 327);
            this.tabControlConfiguracionUsuariosElementos.TabIndex = 4;
            // 
            // tabPageVerUsuarios
            // 
            this.tabPageVerUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.tabPageVerUsuarios.Controls.Add(this.btnModificarUsuario);
            this.tabPageVerUsuarios.Controls.Add(this.btnAgregar);
            this.tabPageVerUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabPageVerUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabPageVerUsuarios.Name = "tabPageVerUsuarios";
            this.tabPageVerUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVerUsuarios.Size = new System.Drawing.Size(744, 301);
            this.tabPageVerUsuarios.TabIndex = 0;
            this.tabPageVerUsuarios.Text = "Ver Usuarios";
            this.tabPageVerUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(629, 65);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(108, 23);
            this.btnEliminarUsuario.TabIndex = 3;
            this.btnEliminarUsuario.Text = "Eliminar usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(630, 36);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(108, 23);
            this.btnModificarUsuario.TabIndex = 2;
            this.btnModificarUsuario.Text = "Modificar usuario";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(630, 7);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar usuario";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 6);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(617, 289);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // btnCancelarCambiosUsuarios
            // 
            this.btnCancelarCambiosUsuarios.Location = new System.Drawing.Point(592, 302);
            this.btnCancelarCambiosUsuarios.Name = "btnCancelarCambiosUsuarios";
            this.btnCancelarCambiosUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCambiosUsuarios.TabIndex = 3;
            this.btnCancelarCambiosUsuarios.Text = "Cancelar";
            this.btnCancelarCambiosUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambiosBD
            // 
            this.btnGuardarCambiosBD.Location = new System.Drawing.Point(673, 302);
            this.btnGuardarCambiosBD.Name = "btnGuardarCambiosBD";
            this.btnGuardarCambiosBD.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCambiosBD.TabIndex = 2;
            this.btnGuardarCambiosBD.Text = "Guardar";
            this.btnGuardarCambiosBD.UseVisualStyleBackColor = true;
            // 
            // tabPageBD
            // 
            this.tabPageBD.Controls.Add(this.txtUsuarioFuncionario);
            this.tabPageBD.Controls.Add(this.lblUsuarioFuncionario);
            this.tabPageBD.Controls.Add(this.txtDireccionBD);
            this.tabPageBD.Controls.Add(this.lblDireccion);
            this.tabPageBD.Controls.Add(this.btnCancelarConfiguracionBD);
            this.tabPageBD.Controls.Add(this.btnGuardarConfiguracionBD);
            this.tabPageBD.Location = new System.Drawing.Point(4, 22);
            this.tabPageBD.Name = "tabPageBD";
            this.tabPageBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBD.Size = new System.Drawing.Size(758, 333);
            this.tabPageBD.TabIndex = 1;
            this.tabPageBD.Text = "Bases de datos";
            this.tabPageBD.UseVisualStyleBackColor = true;
            // 
            // txtUsuarioFuncionario
            // 
            this.txtUsuarioFuncionario.Location = new System.Drawing.Point(9, 89);
            this.txtUsuarioFuncionario.Name = "txtUsuarioFuncionario";
            this.txtUsuarioFuncionario.Size = new System.Drawing.Size(196, 20);
            this.txtUsuarioFuncionario.TabIndex = 5;
            // 
            // lblUsuarioFuncionario
            // 
            this.lblUsuarioFuncionario.AutoSize = true;
            this.lblUsuarioFuncionario.Location = new System.Drawing.Point(6, 73);
            this.lblUsuarioFuncionario.Name = "lblUsuarioFuncionario";
            this.lblUsuarioFuncionario.Size = new System.Drawing.Size(116, 13);
            this.lblUsuarioFuncionario.TabIndex = 4;
            this.lblUsuarioFuncionario.Text = "Usuario de Funcionario";
            // 
            // txtDireccionBD
            // 
            this.txtDireccionBD.Location = new System.Drawing.Point(9, 25);
            this.txtDireccionBD.Name = "txtDireccionBD";
            this.txtDireccionBD.Size = new System.Drawing.Size(196, 20);
            this.txtDireccionBD.TabIndex = 3;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 9);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(199, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Direccion del servidor de bases de datos";
            // 
            // btnCancelarConfiguracionBD
            // 
            this.btnCancelarConfiguracionBD.Location = new System.Drawing.Point(592, 302);
            this.btnCancelarConfiguracionBD.Name = "btnCancelarConfiguracionBD";
            this.btnCancelarConfiguracionBD.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarConfiguracionBD.TabIndex = 1;
            this.btnCancelarConfiguracionBD.Text = "Cancelar";
            this.btnCancelarConfiguracionBD.UseVisualStyleBackColor = true;
            // 
            // btnGuardarConfiguracionBD
            // 
            this.btnGuardarConfiguracionBD.Location = new System.Drawing.Point(673, 302);
            this.btnGuardarConfiguracionBD.Name = "btnGuardarConfiguracionBD";
            this.btnGuardarConfiguracionBD.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarConfiguracionBD.TabIndex = 0;
            this.btnGuardarConfiguracionBD.Text = "Guardar";
            this.btnGuardarConfiguracionBD.UseVisualStyleBackColor = true;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 333);
            this.Controls.Add(this.tabControlConfiguracion);
            this.Controls.Add(this.listaConfiguracion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(875, 372);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(875, 372);
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.tabControlConfiguracion.ResumeLayout(false);
            this.tabPageUsuarios.ResumeLayout(false);
            this.tabControlConfiguracionUsuariosElementos.ResumeLayout(false);
            this.tabPageVerUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabPageBD.ResumeLayout(false);
            this.tabPageBD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaConfiguracion;
        private System.Windows.Forms.TabControl tabControlConfiguracion;
        private System.Windows.Forms.TabPage tabPageUsuarios;
        private System.Windows.Forms.TabPage tabPageBD;
        private System.Windows.Forms.Button btnGuardarConfiguracionBD;
        private System.Windows.Forms.Button btnCancelarConfiguracionBD;
        private System.Windows.Forms.Button btnCancelarCambiosUsuarios;
        private System.Windows.Forms.Button btnGuardarCambiosBD;
        private System.Windows.Forms.TextBox txtDireccionBD;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TabControl tabControlConfiguracionUsuariosElementos;
        private System.Windows.Forms.TabPage tabPageVerUsuarios;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtUsuarioFuncionario;
        private System.Windows.Forms.Label lblUsuarioFuncionario;
    }
}