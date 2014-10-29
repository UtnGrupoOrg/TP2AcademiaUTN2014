using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Desktop
{
    partial class AlumnoDesktop
    {
        private new void InitializeComponent(){
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.lblPlan = new System.Windows.Forms.Label();
            
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Controls.Add(this.lblPlan, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxPlan, 3, 4);
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(276, 104);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 8;
            this.lblPlan.Text = "Plan:";
            // 
            // cbxPlan
            // 
            this.cbxPlan.DisplayMember = "descripcion";
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(357, 107);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(121, 21);
            this.cbxPlan.TabIndex = 7;
            this.cbxPlan.ValueMember = "ID";
        }
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbxPlan;
    }
}
