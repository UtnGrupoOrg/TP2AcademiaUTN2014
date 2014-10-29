using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Desktop
{
    partial class formAlumnos
    {
        private new void InitializeComponent()
        {
            this.desc_plan = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // dgvPersonas
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.apellido,
            this.legajo,
            this.telefono,
            this.direccion,
            this.email,
            this.fecha_nacimiento,
            this.desc_plan});
            //
            // id_persona
            // 
            this.id.DataPropertyName = "id_persona";
            this.id.HeaderText = "ID";
            this.id.Name = "id_persona";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            // 
            // legajo
            // 
            this.legajo.DataPropertyName = "legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.DataPropertyName = "fecha_nacimiento";
            this.fecha_nacimiento.HeaderText = "Fecha Nacimiento";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            // 
            // desc_plan
            // 
            this.desc_plan.DataPropertyName = "desc_plan";
            this.desc_plan.HeaderText = "Plan";
            this.desc_plan.Name = "desc_plan";

            this.Load += new System.EventHandler(this.formAlumnos_Load);
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_plan;
    }
}
