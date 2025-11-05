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
    /// Lógica de interacción para JuegoPrincipal.xaml
    /// </summary>
    public partial class JuegoPrincipal : Window
    {
        public bool menuToggle = false;
        public JuegoPrincipal()
        {
            InitializeComponent();
        }

        private void CerrarSesion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void BotonReturn_MouseLeftButtonDown(Object sender, MouseButtonEventArgs e)
        {
            MenuJuego.Visibility = Visibility.Collapsed;
            menuToggle = false;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (!menuToggle)
                {
                    MenuJuego.Visibility = Visibility.Visible;
                    menuToggle = true;
                }
                else
                {
                    MenuJuego.Visibility= Visibility.Collapsed;
                    menuToggle = false;
                }
            }
        }


    }


}
