using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.Windows.Shapes.Path;

namespace Proyecro_DEIN_Fran
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Boton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == BotonJugar)
            {
                MessageBox.Show("Has clickeado Jugar");
            }
            else if (sender == BotonOpciones)
            {
                //MessageBox.Show("Has clickeado Opciones");
                Opciones opciones = new Opciones();
                opciones.Show();
                this.Close();
            }
            else if (sender == BotonCreditos)
            {
                //MessageBox.Show("Has clickeado Créditos");
                Creditos creditos = new Creditos();
                creditos.Show();
                this.Close();
            }
        }
    }
}
