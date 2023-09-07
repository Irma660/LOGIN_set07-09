﻿using System;
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

            

            using (SqlConnection conexion = new SqlConnection("TConexion")) ;
            {
                string mostrar = "INSERT INTO USUARIO (nombre, usuario, email, contraseña) VALUES (@nombre, @usuario, @email, @contraseña)";
                using (SqlCommand comando = new SqlCommand(mostrar, conexion)) 
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    comando.Parameters.AddWithValue("@email", email);

                   
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
        }
    }
}
