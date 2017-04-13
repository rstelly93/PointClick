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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;


namespace PointyClick
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            fillPostalMate();
        }

        // Connects to PostalMates Database and querys all the table names
        private void fillPostalMate()
        {

            string connectionString = "User=SYSDBA; Password=3k7rur9e; Database=PCS; DataSource=localhost; Port=3050;";

            using (FbConnection con = new FbConnection(connectionString))
            {
                var Query = "SELECT rdb$relation_name AS PostalMate FROM rdb$relations WHERE rdb$view_blr is null AND (rdb$system_flag is null or rdb$system_flag = 0) ORDER BY rdb$relation_name ASC ";
                var dataAdapter = new FbDataAdapter(Query, con);
                var commandBuilder = new FbCommandBuilder(dataAdapter);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
            }
        }

        // Reads in a .csv file and stores contents in a datatable
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

        //Browse button opens a file explorer and allows user to select a .csv file
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

        //Import makes a datatable with the column of selected cell
        private void import_Click(object sender, System.EventArgs e)
        {
            // First check so that we´ve only got one clicked cell
            if (dataGrid2.SelectedCells.Count != 1)
                return;

            // Then fetch the column header
            string selectedColumnHeader = (string)dataGrid2.SelectedCells[0].Column.Header;
            
            //Make Datatable with only column
            DataTable dt = new DataTable();
            dt = ((DataView)dataGrid2.ItemsSource).ToTable();
            DataView dv = new DataView(dt);

            DataTable dt2 = dv.ToTable(false, selectedColumnHeader);
            dataGrid3.ItemsSource = dt2.AsDataView();

        }


        //Event when double clicking a column header, the whole column gets highlighted
        //Currently has a bugs, needs work.
        private void columnHeaderDoubleClick(object sender, RoutedEventArgs e)
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

        //Event to select column header when header checkbox clicked
        private void mouseDownEventHandler(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;
            if (dep is DataGridColumnHeader)
            {
                System.Windows.Forms.MessageBox.Show(((DataGridColumnHeader)dep).Content.ToString());
            }
        }

    }
}
