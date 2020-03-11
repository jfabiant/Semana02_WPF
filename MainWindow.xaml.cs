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
                        //DgPedidos.DataSource = df.Tables["ListaAnios"];
                        //CboAnios.DisplayMember = "Anios";
                        //CboAnios.ValueMember = "Anios";

                        //DgPedidos.ItemsSource = df.Tables["ListaPedidos"];

                        Console.WriteLine("######## DATA ROWS ########");
                        DataRow[] rows = dt.Rows.Cast<DataRow>().ToArray();
                        Console.WriteLine(rows);

                        for (int i = 0; i < rows.Length; i++)
                        {
                            pedidos.Add(new Pedido() { IdPedido = rows[i]["idPedido"].ToString() });
                            pedidos.Add(new Pedido() { IdCliente = rows[i]["idCliente"].ToString() });
                            pedidos.Add(new Pedido() { IdEmpleado = rows[i]["idEmpleado"].ToString() });
                            pedidos.Add(new Pedido() { FechaPedido = rows[i]["fechaPedido"].ToString() });
                            pedidos.Add(new Pedido() { FechaEntrega = rows[i]["fechaEntrega"].ToString() });
                            pedidos.Add(new Pedido() { FechaEnvio = rows[i]["fechaEnvio"].ToString() });
                            pedidos.Add(new Pedido() { FormaEnvio = rows[i]["formaEnvio"].ToString() });
                            pedidos.Add(new Pedido() { Cargo = rows[i]["cargo"].ToString() });

                        }

                        DgPedidos.ItemsSource = pedidos;

                    }
                }
            }



        }
    }
}
