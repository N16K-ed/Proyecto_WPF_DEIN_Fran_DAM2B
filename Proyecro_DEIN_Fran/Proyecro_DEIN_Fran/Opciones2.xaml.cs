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
    /// Lógica de interacción para Opciones2.xaml
    /// </summary>
    public partial class Opciones2 : Window
    {
        public Opciones2()
        {
            InitializeComponent();
        }

        private void BotonReturn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Opciones opciones = new Opciones();
            opciones.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Opciones2 opciones2 = new Opciones2();
            opciones2.Show();            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Opciones2 opciones2 = new Opciones2();
            opciones2.Show();            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Opciones2 opciones2 = new Opciones2();
            opciones2.Show();            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Opciones2 opciones2 = new Opciones2();
            opciones2.Show();
            
        }
    }
}
