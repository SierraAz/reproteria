using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaReporteria
{
    public partial class menu_reporteria : Form
    {
        public menu_reporteria()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

                bool abierto = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "inicio")
                    {
                        abierto = true;
                        f.Focus();
                        break;
                    }
                }
                if (abierto == false)
                {
                    Inicio rep = new Inicio();
                    rep.MdiParent = this;
                    rep.Show();
                }
                
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "reporteria_usuario")
                {
                    abierto = true;
                    f.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                reporteria_usuario rep = new reporteria_usuario();
                rep.MdiParent = this;
                rep.Show();
            }
        }
    }
}
