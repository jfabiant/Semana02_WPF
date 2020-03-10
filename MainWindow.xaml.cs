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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EjercicioFinal2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListaProductos();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Jfabiant"].ConnectionString);

        private void ListaProductos()
        {

            using (SqlCommand cmd = new SqlCommand("Usp_ListaPedidos", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        //DgPedidos.DataSource = df.Tables["ListaAnios"];
                        //CboAnios.DisplayMember = "Anios";
                        //CboAnios.ValueMember = "Anios";

                        //DgPedidos.ItemsSource = df.Tables["ListaPedidos"];

                        Console.WriteLine("Hello Im the console");
                        DataRow[] rows = dt.Rows.Cast<DataRow>().ToArray();

                        List<string[]> results =
                        dt.Select()
                            .Select(dr =>
                                rows
                                    .Select(x => x.ToString())
                                    .ToArray())
                            .ToList();


                        Console.WriteLine(results);

                    }
                }
            }


            
            //users.Add(new Pedido() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            //users.Add(new Pedido() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            //users.Add(new Pedido() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            //dgUsers.ItemsSource = users;


        }

        public class Pedido
        {
            public string IdPedido { get; set; }
            public string IdCliente { get; set; }
            public string IdEmpleado { get; set; }
            public string FechaPedido { get; set; }
            public string FechaEntrega { get; set; }
            public string FechaEnvio { get; set; }
            public string FormaEnvio { get; set; }
            public string Cargo { get; set; }
            public string Destinatario { get; set; }
            public string DireccionDestinatario { get; set; }
            public string CiudadDestinatario { get; set; }
            public string RegionDestinatario { get; set; }
            public string CodPostalDestinatario { get; set; }
            public string PaisDestinatario { get; set; }
        }   

    }
}
