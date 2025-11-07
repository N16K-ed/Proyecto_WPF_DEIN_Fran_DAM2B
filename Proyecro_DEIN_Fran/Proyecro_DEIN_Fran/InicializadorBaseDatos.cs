using MySql.Data.MySqlClient;
using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecro_DEIN_Fran
{
    public static class InicializadorBaseDatos
    {
        public static void Inicializar()
        {
            string nombreDB = "ProyectoInterfacesFran";

            // Conectarse al servidor sin base de datos para crearla si no existe
            var builderServidor = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                UserID = "root",
                Password = "root"
            };

            try
            {
                using (var conn = new MySqlConnection(builderServidor.ConnectionString))
                {
                    conn.Open();
                    string crearDB = $"CREATE DATABASE IF NOT EXISTS {nombreDB};";
                    new MySqlCommand(crearDB, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la base de datos: {ex.Message}");
                return;
            }

            // Conectarse a la base recién creada
            var builderDB = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                UserID = "root",
                Password = "root",
                Database = nombreDB
            };

            try
            {
                using (var conn = new MySqlConnection(builderDB.ConnectionString))
                {
                    conn.Open();

                    // Crear tabla usuarios
                    string crearTablaUsuarios = @"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            usuario VARCHAR(50),
                            contraseña VARCHAR(100),
                            email VARCHAR(100) NULL
                        );";
                    new MySqlCommand(crearTablaUsuarios, conn).ExecuteNonQuery();

                    // Insertar usuario admin solo si no existe
                    string insertarAdmin = @"
                        INSERT INTO usuarios (usuario, contraseña, email)
                        SELECT 'admin', 'admin', NULL
                        WHERE NOT EXISTS (SELECT 1 FROM usuarios WHERE usuario='admin');";
                    new MySqlCommand(insertarAdmin, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar tabla y admin: {ex.Message}");
            }
        }
    }
}
