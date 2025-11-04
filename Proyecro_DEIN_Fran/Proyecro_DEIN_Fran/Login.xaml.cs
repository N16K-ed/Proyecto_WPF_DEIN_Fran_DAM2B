using System;
using System.Collections.Generic;
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

        private void IniSesion_MouseLeftButtonDown(Object sender, MouseButtonEventArgs e)
        {
            if (user.Text.ToLower().Equals("admin") && password.Password.ToLower().Equals("admin"))
            {
                MessageBox.Show("Has Iniciado Sesión.");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
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
    }
}
