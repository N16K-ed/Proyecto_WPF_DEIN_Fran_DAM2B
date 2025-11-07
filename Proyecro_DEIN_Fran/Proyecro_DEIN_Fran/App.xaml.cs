using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecro_DEIN_Fran
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Inicializar base y tablas
            InicializadorBaseDatos.Inicializar();

            // Abrir ventana de login
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
