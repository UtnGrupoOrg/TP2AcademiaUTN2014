namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tlMateriaDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblHorasSemanales = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.tlMateriaDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMateriaDesktop
            // 
            this.tlMateriaDesktop.ColumnCount = 4;
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateriaDesktop.Controls.Add(this.lblID, 0, 0);
            this.tlMateriaDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlMateriaDesktop.Controls.Add(this.lblHorasSemanales, 0, 2);
            this.tlMateriaDesktop.Controls.Add(this.lblPlan, 2, 1);
            this.tlMateriaDesktop.Controls.Add(this.lblHorasTotales, 2, 2);
            this.tlMateriaDesktop.Controls.Add(this.btnAceptar, 2, 3);
            this.tlMateriaDesktop.Controls.Add(this.btnCancelar, 3, 3);
            this.tlMateriaDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlMateriaDesktop.Controls.Add(this.txtHorasSemanales, 1, 2);
            this.tlMateriaDesktop.Controls.Add(this.txtID, 1, 0);
            this.tlMateriaDesktop.Controls.Add(this.txtHorasTotales, 3, 2);
            this.tlMateriaDesktop.Controls.Add(this.cbxPlan, 3, 1);
            this.tlMateriaDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMateriaDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlMateriaDesktop.Name = "tlMateriaDesktop";
            this.tlMateriaDesktop.RowCount = 4;
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateriaDesktop.Size = new System.Drawing.Size(414, 110);
            this.tlMateriaDesktop.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 26);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblHorasSemanales
            // 
            this.lblHorasSemanales.AutoSize = true;
            this.lblHorasSemanales.Location = new System.Drawing.Point(3, 53);
            this.lblHorasSemanales.Name = "lblHorasSemanales";
            this.lblHorasSemanales.Size = new System.Drawing.Size(90, 13);
            this.lblHorasSemanales.TabIndex = 2;
            this.lblHorasSemanales.Text = "Horas Semanales";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(205, 26);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 3;
            this.lblPlan.Text = "Plan";
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.Location = new System.Drawing.Point(205, 53);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(73, 13);
            this.lblHorasTotales.TabIndex = 4;
            this.lblHorasTotales.Text = "Horas Totales";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(205, 82);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(286, 82);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(99, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(99, 56);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(100, 20);
            this.txtHorasSemanales.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(99, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 9;
            this.txtID.TabStop = false;
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHorasTotales.Location = new System.Drawing.Point(286, 56);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(125, 20);
            this.txtHorasTotales.TabIndex = 3;
            // 
            // cbxPlan
            // 
            this.cbxPlan.DisplayMember = "Descripcion";
            this.cbxPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(286, 29);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(125, 21);
            this.cbxPlan.TabIndex = 1;
            this.cbxPlan.ValueMember = "ID";
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 110);
            this.Controls.Add(this.tlMateriaDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MateriaDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Materia";
            this.Activated += new System.EventHandler(this.MateriaDesktop_Activated);
            this.tlMateriaDesktop.ResumeLayout(false);
            this.tlMateriaDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMateriaDesktop;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblHorasSemanales;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblHorasTotales;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHorasSemanales;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtHorasTotales;
        private System.Windows.Forms.ComboBox cbxPlan;
    }
}