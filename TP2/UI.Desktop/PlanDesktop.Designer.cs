namespace UI.Desktop
{
    partial class PlanDesktop
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
            this.tlpPlan = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cbbEspecialidades = new System.Windows.Forms.ComboBox();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.lbMaterias = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.tlpPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPlan
            // 
            this.tlpPlan.ColumnCount = 5;
            this.tlpPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tlpPlan.Controls.Add(this.lblID, 0, 0);
            this.tlpPlan.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlpPlan.Controls.Add(this.txtID, 1, 0);
            this.tlpPlan.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlpPlan.Controls.Add(this.lblEspecialidad, 0, 2);
            this.tlpPlan.Controls.Add(this.cbbEspecialidades, 1, 2);
            this.tlpPlan.Controls.Add(this.lbMaterias, 2, 1);
            this.tlpPlan.Controls.Add(this.btnCancelar, 3, 6);
            this.tlpPlan.Controls.Add(this.btnAceptar, 2, 6);
            this.tlpPlan.Controls.Add(this.lblSeparador, 0, 5);
            this.tlpPlan.Controls.Add(this.btnAgregar, 2, 4);
            this.tlpPlan.Controls.Add(this.btnQuitar, 3, 4);
            this.tlpPlan.Controls.Add(this.lblMaterias, 2, 0);
            this.tlpPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlan.Location = new System.Drawing.Point(0, 0);
            this.tlpPlan.Name = "tlpPlan";
            this.tlpPlan.RowCount = 7;
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPlan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPlan.Size = new System.Drawing.Size(553, 300);
            this.tlpPlan.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(27, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 32);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(60, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descipción";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtID.Location = new System.Drawing.Point(76, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(107, 20);
            this.txtID.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDescripcion.Location = new System.Drawing.Point(76, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(107, 20);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(3, 59);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 2;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // cbbEspecialidades
            // 
            this.cbbEspecialidades.DisplayMember = "descripcion";
            this.cbbEspecialidades.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEspecialidades.FormattingEnabled = true;
            this.cbbEspecialidades.Location = new System.Drawing.Point(76, 55);
            this.cbbEspecialidades.Name = "cbbEspecialidades";
            this.cbbEspecialidades.Size = new System.Drawing.Size(107, 21);
            this.cbbEspecialidades.TabIndex = 5;
            this.cbbEspecialidades.ValueMember = "ID";
            // 
            // lblMaterias
            // 
            this.lblMaterias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaterias.AutoSize = true;
            this.tlpPlan.SetColumnSpan(this.lblMaterias, 2);
            this.lblMaterias.Location = new System.Drawing.Point(242, 6);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(50, 13);
            this.lblMaterias.TabIndex = 8;
            this.lblMaterias.Text = "Materias:";
            // 
            // lbMaterias
            // 
            this.tlpPlan.SetColumnSpan(this.lbMaterias, 2);
            this.lbMaterias.FormattingEnabled = true;
            this.lbMaterias.Location = new System.Drawing.Point(189, 29);
            this.lbMaterias.Name = "lbMaterias";
            this.tlpPlan.SetRowSpan(this.lbMaterias, 3);
            this.lbMaterias.Size = new System.Drawing.Size(153, 121);
            this.lbMaterias.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 196);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(67, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(189, 196);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(67, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblSeparador
            // 
            this.lblSeparador.AutoSize = true;
            this.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tlpPlan.SetColumnSpan(this.lblSeparador, 5);
            this.lblSeparador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeparador.Location = new System.Drawing.Point(3, 173);
            this.lblSeparador.MaximumSize = new System.Drawing.Size(0, 20);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(550, 20);
            this.lblSeparador.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(189, 156);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 14);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(270, 156);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 14);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // PlanDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 300);
            this.Controls.Add(this.tlpPlan);
            this.Name = "PlanDesktop";
            this.Text = "PlanDesktop";
            this.Activated += new System.EventHandler(this.PlanDesktop_Activated);
            this.tlpPlan.ResumeLayout(false);
            this.tlpPlan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPlan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cbbEspecialidades;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ListBox lbMaterias;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
    }
}