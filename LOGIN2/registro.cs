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
        private string Cconexion = "Data Source=DESKTOP-7LDGQBD;Initial Catalog = LOGINBD; Integrated Security = True";
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
            using (SqlConnection Cconexion = new SqlConnection("Conexion"))
            {
                Cconexion.Open();
                //PARA SABER SI EL USUARIO YA EXISTE
                string consultar = "SELECT COUNT(*) FROM USUARIO WHERE usuario = @usuario";
                using (SqlCommand comando = new SqlCommand(consultar, Cconexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    Cconexion.Open();

                    int existe = (int)comando.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("EL USUARIO YA ES EXISTENTE, PRUEBE OTRO");
                        Cconexion.Close();
                        return;
                    }
                    //cerrar conexion
                    Cconexion.Close();
                }


                //para registrar
                string mostrar = "INSERT INTO USUARIO (nombre, usuario, email, contraseña) VALUES (@nombre, @usuario, @email, @contraseña)";
                using (SqlCommand comando = new SqlCommand(mostrar, Cconexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    comando.Parameters.AddWithValue("@email", email);


                    Cconexion.Open();
                    comando.ExecuteNonQuery();
                    Cconexion.Close();

                }
            }
            MessageBox.Show("Registro exitoso");
        }
    }
}
