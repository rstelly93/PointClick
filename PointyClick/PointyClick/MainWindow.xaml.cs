using System;
using System.Windows;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Dapper;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace PointyClick
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            fillPostalMate();
        }

        private void fillPostalMate()
        {

            string connectionString = "User=SYSDBA; Password=3k7rur9e; Database=PCS; DataSource=localhost; Port=3050;";

            using (FbConnection con = new FbConnection(connectionString))
            {
                var Query = "SELECT rdb$relation_name AS PostalMate FROM rdb$relations WHERE rdb$view_blr is null AND (rdb$system_flag is null or rdb$system_flag = 0) ORDER BY rdb$relation_name ASC ";
                //var Query2 = "SELECT * FROM Product";
                var dataAdapter = new FbDataAdapter(Query, con);
                var commandBuilder = new FbCommandBuilder(dataAdapter);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
            }
        }

        private DataTable ReadCSV(string fileName)
        {
            DataTable dt = new DataTable("Data");
            using (OleDbConnection cn = new OleDbConnection("Provider=MIcrosoft.Jet.OLEDB.4.0;Data Source=\"" + Path.GetDirectoryName(fileName) + "\"; Extended Properties='text;HDR=yes;FMT=Delimeted(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select *from [{0}]", new FileInfo(fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private void loadCSV_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dataGrid2.ItemsSource = ReadCSV(ofd.FileName).DefaultView;
                }
            }
        }

        private void columnHeaderClick(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as DataGridColumnHeader;
            if (columnHeader != null)
            {
                dataGrid2.SelectedCells.Clear();
                foreach (var item in dataGrid2.Items)
                {
                    dataGrid2.SelectedCells.Add(new DataGridCellInfo(item, columnHeader.Column));
                }
            }
        }

        private void cellClick(object sender, RoutedEventArgs e)
        {
            var cellInfo = dataGrid2.SelectedCells[0];
            var content = cellInfo.Column.GetCellContent(cellInfo.Item);

            string myQuery = "SELECT * FROM " + content;

            string connectionString = "User=SYSDBA; Password=3k7rur9e; Database=PCS; DataSource=localhost; Port=3050;";

            dataGrid1.Columns.Clear();
            dataGrid1.Items.Clear();
            dataGrid1.Items.Refresh();

            using (FbConnection con = new FbConnection(connectionString))
            {
           
                var dataAdapter = new FbDataAdapter(myQuery, con);
                var commandBuilder = new FbCommandBuilder(dataAdapter);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
            }

        }

    }
}
