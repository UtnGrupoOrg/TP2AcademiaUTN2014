namespace UI.Desktop
{
    partial class formPersonas
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
        protected void InitializeComponent()
        {
            this.tscPersonas = new System.Windows.Forms.ToolStripContainer();
            this.tlpPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.tsPersonas = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tscPersonas.ContentPanel.SuspendLayout();
            this.tscPersonas.TopToolStripPanel.SuspendLayout();
            this.tscPersonas.SuspendLayout();
            this.tlpPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.tsPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscPersonas
            // 
            // 
            // tscPersonas.ContentPanel
            // 
            this.tscPersonas.ContentPanel.Controls.Add(this.tlpPersonas);
            this.tscPersonas.ContentPanel.Size = new System.Drawing.Size(797, 387);
            this.tscPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscPersonas.Location = new System.Drawing.Point(0, 0);
            this.tscPersonas.Name = "tscPersonas";
            this.tscPersonas.Size = new System.Drawing.Size(797, 412);
            this.tscPersonas.TabIndex = 0;
            this.tscPersonas.Text = "toolStripContainer1";
            // 
            // tscPersonas.TopToolStripPanel
            // 
            this.tscPersonas.TopToolStripPanel.Controls.Add(this.tsPersonas);
            // 
            // tlpPersonas
            // 
            this.tlpPersonas.ColumnCount = 2;
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPersonas.Controls.Add(this.btnActualizar, 0, 1);
            this.tlpPersonas.Controls.Add(this.btnSalir, 1, 1);
            this.tlpPersonas.Controls.Add(this.dgvPersonas, 0, 0);
            this.tlpPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlpPersonas.Name = "tlpPersonas";
            this.tlpPersonas.RowCount = 2;
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPersonas.Size = new System.Drawing.Size(797, 387);
            this.tlpPersonas.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(638, 361);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(719, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.AllowUserToResizeRows = false;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpPersonas.SetColumnSpan(this.dgvPersonas, 2);
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(3, 3);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(791, 352);
            this.dgvPersonas.TabIndex = 2;
            // 
            // tsPersonas
            // 
            this.tsPersonas.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPersonas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsPersonas.Location = new System.Drawing.Point(3, 0);
            this.tsPersonas.Name = "tsPersonas";
            this.tsPersonas.Size = new System.Drawing.Size(72, 25);
            this.tsPersonas.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.Add;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.Edit;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.Delete;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // id
            // 
            this.id.Name = "id";
            // 
            // nombre
            // 
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.Name = "apellido";
            // 
            // legajo
            // 
            this.legajo.Name = "legajo";
            // 
            // telefono
            // 
            this.telefono.Name = "telefono";
            // 
            // direccion
            // 
            this.direccion.Name = "direccion";
            // 
            // email
            // 
            this.email.Name = "email";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            // 
            // formPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 412);
            this.Controls.Add(this.tscPersonas);
            this.Name = "formPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.formPersonas_Load);
            this.tscPersonas.ContentPanel.ResumeLayout(false);
            this.tscPersonas.TopToolStripPanel.ResumeLayout(false);
            this.tscPersonas.TopToolStripPanel.PerformLayout();
            this.tscPersonas.ResumeLayout(false);
            this.tscPersonas.PerformLayout();
            this.tlpPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.tsPersonas.ResumeLayout(false);
            this.tsPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolStripContainer tscPersonas;
        protected System.Windows.Forms.ToolStrip tsPersonas;
        protected System.Windows.Forms.TableLayoutPanel tlpPersonas;
        protected System.Windows.Forms.Button btnActualizar;
        protected System.Windows.Forms.Button btnSalir;
        protected System.Windows.Forms.DataGridView dgvPersonas;
        protected System.Windows.Forms.ToolStripButton tsbNuevo;
        protected System.Windows.Forms.ToolStripButton tsbEditar;
        protected System.Windows.Forms.ToolStripButton tsbEliminar;
        protected System.Windows.Forms.DataGridViewTextBoxColumn id;
        protected System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        protected System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        protected System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        protected System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        protected System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        protected System.Windows.Forms.DataGridViewTextBoxColumn email;
        protected System.Windows.Forms.DataGridViewTextBoxColumn fecha_nacimiento;
    }
}