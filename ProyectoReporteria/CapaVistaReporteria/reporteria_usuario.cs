using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CapaVistaReporteria
{
    public partial class reporteria_usuario : Form
    {
        string connectionString = @"Server=colchoneria.mysql.database.azure.com;Database=colchoneria;Uid=administrador;Pwd=Jm123456;";
        int idregistro = 0;
        public reporteria_usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("pa_registro_buscarvalor", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_valorbuscar", textBox1.Text);
                DataTable dtbregistro = new DataTable();
                sqlDa.Fill(dtbregistro);
                tabla_registro.DataSource = dtbregistro;
                tabla_registro.Columns[0].Visible = true;
            }
        }

        private void reporteria_usuario_Load(object sender, EventArgs e)
        {

        }

        private void tabla_registro_DoubleClick(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (tabla_registro.CurrentRow.Index != -1)
                textBox3.Text = tabla_registro.CurrentRow.Cells[4].Value.ToString();
            textBox1.Text = tabla_registro.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = tabla_registro.CurrentRow.Cells[1].Value.ToString();
            idregistro = Convert.ToInt32(tabla_registro.CurrentRow.Cells[0].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string disp;
            disp = Convert.ToString(textBox3.Text);
            if (disp == "Visible")
            {

                string r = textBox2.Text;
                visualizar b = new visualizar(r);
                b.Show();
            }
            else
            {
                MessageBox.Show("No esta habilitado el reporte");
            }
        }
    }
}
