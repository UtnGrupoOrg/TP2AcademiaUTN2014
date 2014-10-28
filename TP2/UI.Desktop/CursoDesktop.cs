using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public Curso cursoActual { get; set; }
        private List<Materia> materias;
        private List<Comision> comisiones;
        public CursoDesktop()
        {
            InitializeComponent();
            cursoActual = new Curso();
            materias = new MateriaLogic().GetAll();
            this.cbxMaterias.DataSource = materias;
            comisiones = new ComisionLogic().GetAll();
            this.cbxComision.DataSource = comisiones;
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            if (this.Modo==ModoForm.Alta)
            {
              
            }

        
        }
    }
}
