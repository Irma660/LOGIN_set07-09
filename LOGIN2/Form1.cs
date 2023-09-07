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
        private string conexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog = LOGINBD; Integrated Security = True";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnINICIO_Click(object sender, EventArgs e)
        {
            string usuario = textUsuario.Text;
            string nombre = textNombre.Text;
            string contraseña = textContraseña.Text;

            using(SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                string entrada = "SELECT COUNT (*) FROM USUARIO WHERE nombre = @nombre , usuario = @usuario and contraseña = @contraseña";
                SqlCommand comando = new SqlCommand(entrada,con);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
