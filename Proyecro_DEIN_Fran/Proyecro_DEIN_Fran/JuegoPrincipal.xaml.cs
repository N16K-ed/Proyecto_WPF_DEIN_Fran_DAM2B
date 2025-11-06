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
        private bool menuToggle = false;
        private bool menuInventarioAbierto = false;
        public JuegoPrincipal()
        {
            InitializeComponent();
            CargarRejillaVacia();
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
                if (!menuInventarioAbierto){ 
                
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
                else
                {
                    menuInventarioAbierto = false;
                    MenuInventario.Visibility = Visibility.Collapsed;
                    MenuJuego.Visibility = Visibility.Visible;
                }
            }
            
        }

        private void Inventario_MouseLeftButtonDown(Object sender, MouseButtonEventArgs e)
        {
            MenuInventario.Visibility = Visibility.Visible;
            MenuJuego.Visibility = Visibility.Collapsed;
            menuInventarioAbierto = true;

        }

        private void BotonReturnInventario_MouseLeftButtonDown(Object sender, MouseButtonEventArgs e)
        {
            menuInventarioAbierto = false;
            MenuInventario.Visibility= Visibility.Collapsed;
            MenuJuego.Visibility = Visibility.Visible;
        }

        private void CargarRejillaVacia()
        {
            InventarioGrid.Children.Clear();
            int totalSlots = 48; 

            for (int i = 0; i < totalSlots; i++)
            {
                var slot = new Border
                {
                    Style = (Style)FindResource("SlotStyle")
                };

                InventarioGrid.Children.Add(slot);
            }
        }

    }


}
