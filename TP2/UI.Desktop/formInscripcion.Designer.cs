namespace UI.Desktop
{
    partial class formInscripcion
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblElijaMateria = new System.Windows.Forms.Label();
            this.lblSeleccioneComision = new System.Windows.Forms.Label();
            this.cbxMaterias = new System.Windows.Forms.ComboBox();
            this.cbxComisiones = new System.Windows.Forms.ComboBox();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblElijaMateria, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSeleccioneComision, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxMaterias, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxComisiones, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInscribirse, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblElijaMateria
            // 
            this.lblElijaMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblElijaMateria.AutoSize = true;
            this.lblElijaMateria.Location = new System.Drawing.Point(15, 7);
            this.lblElijaMateria.Name = "lblElijaMateria";
            this.lblElijaMateria.Size = new System.Drawing.Size(87, 13);
            this.lblElijaMateria.TabIndex = 0;
            this.lblElijaMateria.Text = "Elija una materia:";
            // 
            // lblSeleccioneComision
            // 
            this.lblSeleccioneComision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSeleccioneComision.AutoSize = true;
            this.lblSeleccioneComision.Location = new System.Drawing.Point(3, 34);
            this.lblSeleccioneComision.Name = "lblSeleccioneComision";
            this.lblSeleccioneComision.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccioneComision.TabIndex = 1;
            this.lblSeleccioneComision.Text = "Seleccione Comision: ";
            // 
            // cbxMaterias
            // 
            this.cbxMaterias.DisplayMember = "descripcion";
            this.cbxMaterias.FormattingEnabled = true;
            this.cbxMaterias.Location = new System.Drawing.Point(120, 3);
            this.cbxMaterias.Name = "cbxMaterias";
            this.cbxMaterias.Size = new System.Drawing.Size(121, 21);
            this.cbxMaterias.TabIndex = 3;
            this.cbxMaterias.Text = " ";
            this.cbxMaterias.ValueMember = "descripcion";
            this.cbxMaterias.SelectedIndexChanged += new System.EventHandler(this.cbxMaterias_SelectedIndexChanged);
            // 
            // cbxComisiones
            // 
            this.cbxComisiones.DisplayMember = "descripcion";
            this.cbxComisiones.FormattingEnabled = true;
            this.cbxComisiones.Location = new System.Drawing.Point(120, 30);
            this.cbxComisiones.Name = "cbxComisiones";
            this.cbxComisiones.Size = new System.Drawing.Size(121, 21);
            this.cbxComisiones.TabIndex = 4;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInscribirse.Location = new System.Drawing.Point(39, 57);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(75, 23);
            this.btnInscribirse.TabIndex = 5;
            this.btnInscribirse.Text = "Inscribir";
            this.btnInscribirse.UseVisualStyleBackColor = true;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(120, 57);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // formInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 87);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formInscripcion";
            this.Text = "formInscripcion";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblElijaMateria;
        private System.Windows.Forms.Label lblSeleccioneComision;
        private System.Windows.Forms.ComboBox cbxMaterias;
        private System.Windows.Forms.ComboBox cbxComisiones;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnCancelar;
    }
}