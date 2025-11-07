using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecro_DEIN_Fran
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BotonReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void IniSesion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string usuarioInput = user.Text.Trim().ToLower();
            string contraseñaInput = password.Password.Trim().ToLower();

            try
            {
                string connStr = "server=localhost;port=3306;uid=root;pwd=root;database=ProyectoInterfacesFran;";

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Seleccionamos directamente el id del usuario que coincida
                    string sql = "SELECT id FROM usuarios WHERE LOWER(usuario)=@usuario AND LOWER(contraseña)=@contraseña LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuarioInput);
                        cmd.Parameters.AddWithValue("@contraseña", contraseñaInput);

                        object result = cmd.ExecuteScalar(); // devuelve null si no hay coincidencia

                        if (result != null)
                        {
                            // Usuario válido
                            JuegoPrincipal principal = new JuegoPrincipal();
                            principal.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar o consultar la base de datos: {ex.Message}");
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Reutiliza tu manejador existente del clic
                IniSesion_MouseLeftButtonDown(sender, null);
            }
        }

        private void Registro_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }  
    }
}
