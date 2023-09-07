using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN2
{
    public partial class Form1 : Form
    {
        private string conexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog=LOGINBD;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnINICIO_Click(object sender, EventArgs e)
        {
            string usuario = textUsuario.Text;
            string contraseña = textContraseña.Text;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string entrada = "SELECT COUNT (*) FROM USUARIO WHERE usuario = @usuario and contraseña = @contraseña";
                SqlCommand comando = new SqlCommand(entrada,conn);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);


                int mostrar = (int)comando.ExecuteScalar();

                if (mostrar > 0 )
                {
                    MessageBox.Show("INICIÓ SESIÓN");
                }else
                {
                    MessageBox.Show("INVÁLIDO");
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            registro registroForm = new registro();
            registroForm.ShowDialog();
            
        }
    }
}
