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

        private void DgPedidos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<Producto> productos = new List<Producto>();

            Pedido pedido = (Pedido)DgPedidos.SelectedItem;
            int idPedido = int.Parse(pedido.IdPedido);

            using (SqlCommand cmd = new SqlCommand("Usp_Detalle_Pedido", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.AddWithValue("@idpedido", idPedido);

                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);

                        Console.WriteLine("######## DATA ROWS ########");
                        DataRow[] rows = dt.Rows.Cast<DataRow>().ToArray();
                        Console.WriteLine(rows);

                        for (int i = 0; i < rows.Length; i++)
                        {
                            productos.Add(new Producto()
                            {
                                IdProducto = rows[i][0].ToString(),
                                NombreProducto = rows[i][1].ToString(),
                                IdProveedor= rows[i][2].ToString(),
                                IdCategoria= rows[i][3].ToString(),
                                CantidadPorUnidad= rows[i][4].ToString(),
                                PrecioUnidad= rows[i][5].ToString(),
                                UnidadesEnExistencia= rows[i][6].ToString(),
                                UnidadesEnPedido= rows[i][7].ToString(),
                                NivelNuevoPedido= rows[i][8].ToString(),
                                Suspendido= rows[i][9].ToString(),
                                CategoriaProducto= rows[i][10].ToString()
                            });

                        }

                        DgDetallePedido.ItemsSource = productos;

                    }
                }
            }


        }
    }
}
