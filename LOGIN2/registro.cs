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
    public partial class registro : Form
    {
        private string conexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog=LOGINBD;Integrated Security=True";
        public registro()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string nombre = textNom.Text;
            string usuario = textUsu.Text;
            string email = textEmail.Text;
            string contraseña = textContraseña.Text;

            //CONDICIÓN PARA LLENAR TODOS LOS CAMPOS
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("COMPLETAR TODOS LOS CAMPOS");
                return;
            }
            //abriendo conexion
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                //PARA SABER SI EL USUARIO YA EXISTE
                string consultar = "SELECT COUNT(*) FROM USUARIOS WHERE usuario = @usuario";
                using (SqlCommand comando = new SqlCommand(consultar, conn))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                  

                    int existe = (int)comando.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("EL USUARIO YA ES EXISTENTE, PRUEBE OTRO");
                        conn.Close();
                        return;
                    }
                    //cerrar conexion
                    conn.Close();
                }

                //para registrar
                string mostrar = "INSERT INTO USUARIOS (nombre, usuario, email, contraseña) VALUES (@nombre, @usuario, @email, @contraseña)";
                using (SqlCommand comando = new SqlCommand(mostrar, conn))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    conn.Open();
                    int rowsAffect = comando.ExecuteNonQuery();
                    if (rowsAffect > 0)
                    {
                        MessageBox.Show("REGISTRO CORRECTO");
                        Form1 registroForm = new Form1();
                        registroForm.Show();
                        this.Hide();
                    }

                }
            }
            MessageBox.Show("Registro exitoso");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
