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
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlCommand cmd = new SqlCommand("Usp_ListaPedidos", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        Console.WriteLine("######## DATA ROWS ########");
                        DataRow[] rows = dt.Rows.Cast<DataRow>().ToArray();
                        Console.WriteLine(rows);

                        for (int i = 0; i < rows.Length; i++)
                        {
                            pedidos.Add(new Pedido() {
                                IdPedido = rows[i]["idPedido"].ToString(), 
                                IdCliente = rows[i]["idCliente"].ToString(),
                                FechaPedido = rows[i]["fechaPedido"].ToString(),
                                FechaEntrega = rows[i]["fechaEntrega"].ToString(),
                                FechaEnvio = rows[i]["fechaEnvio"].ToString(),
                                Cargo = rows[i]["cargo"].ToString(),
                                Destinatario = rows[i]["destinatario"].ToString(),
                                DireccionDestinatario = rows[i]["direccionDestinatario"].ToString(),
                                CiudadDestinatario = rows[i]["ciudadDestinatario"].ToString(),
                                RegionDestinatario = rows[i]["regionDestinatario"].ToString(),
                                CodPostalDestinatario = rows[i]["codPostalDestinatario"].ToString(),
                                PaisDestinatario = rows[i]["paisDestinatario"].ToString(),
                                IdEmpleado = rows[i]["idEmpleado"].ToString(),
                                FormaEnvio = rows[i]["formaEnvio"].ToString()
                            });

                        }

                        DgPedidos.ItemsSource = pedidos;

                    }
                }
            }



        }
    }
}
