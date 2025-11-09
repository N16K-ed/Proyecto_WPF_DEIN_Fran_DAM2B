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
            if (Register.Visibility == Visibility.Visible)
            {
                Register.Visibility = Visibility.Collapsed;
                LoginMenu.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void IniSesion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string usuarioInput = user.Text.Trim().ToLower();
            string contraseñaInput = password.Password.Trim().ToLower();

            try
            {
                string connStr = "server=localhost;port=3309;uid=acda;pwd=masacda;database=ProyectoInterfacesFran;";

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

        private void AbrirRegistro_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoginMenu.Visibility = Visibility.Collapsed;
            Register.Visibility = Visibility.Visible;
        }

        private void Register_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            string usuario = user1.Text.Trim();
            string correo = email.Text.Trim();
            string contraseña = password1.Password.Trim();

            
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, introduce un usuario y una contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            var builderDB = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3309,
                UserID = "acda",
                Password = "masacda",
                Database = InicializadorBaseDatos.nombreDB 
            };

            try
            {
                using (var conn = new MySqlConnection(builderDB.ConnectionString))
                {
                    conn.Open();
                    
                    string comprobarUsuario = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario";
                    using (var cmd = new MySqlCommand(comprobarUsuario, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        int existe = Convert.ToInt32(cmd.ExecuteScalar());
                        if (existe > 0)
                        {
                            MessageBox.Show("El usuario ya existe. Elige otro nombre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    
                    string insertarUsuario = "INSERT INTO usuarios (usuario, contraseña, email) VALUES (@usuario, @contraseña, @correo)";
                    using (var cmd = new MySqlCommand(insertarUsuario, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña); 
                        cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(correo) ? DBNull.Value : (object)correo);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registro completado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoginMenu.Visibility = Visibility.Visible;
                    Register.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
