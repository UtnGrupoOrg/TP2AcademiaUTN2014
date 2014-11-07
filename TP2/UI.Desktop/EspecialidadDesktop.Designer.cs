namespace UI.Desktop
{
    partial class EspecialidadDesktop
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIDEspecialidad = new System.Windows.Forms.Label();
            this.txtIDEspecialidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIDEspecialidad
            // 
            this.lblIDEspecialidad.AutoSize = true;
            this.lblIDEspecialidad.Location = new System.Drawing.Point(12, 9);
            this.lblIDEspecialidad.Name = "lblIDEspecialidad";
            this.lblIDEspecialidad.Size = new System.Drawing.Size(87, 13);
            this.lblIDEspecialidad.TabIndex = 0;
            this.lblIDEspecialidad.Text = "ID Especialidad: ";
            // 
            // txtIDEspecialidad
            // 
            this.txtIDEspecialidad.Enabled = false;
            this.txtIDEspecialidad.Location = new System.Drawing.Point(129, 6);
            this.txtIDEspecialidad.Name = "txtIDEspecialidad";
            this.txtIDEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtIDEspecialidad.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Especialidad: ";
            // 
            // txtNombreEspecialidad
            // 
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(129, 37);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtNombreEspecialidad.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(99, 63);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(180, 63);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EspecialidadDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(267, 98);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombreEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDEspecialidad);
            this.Controls.Add(this.lblIDEspecialidad);
            this.Name = "EspecialidadDesktop";
            this.Text = "Especialidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDEspecialidad;
        private System.Windows.Forms.TextBox txtIDEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
