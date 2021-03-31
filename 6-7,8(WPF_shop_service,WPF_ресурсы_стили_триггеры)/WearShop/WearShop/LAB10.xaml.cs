using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WearShop
{
    /// <summary>
    /// Логика взаимодействия для LAB10.xaml
    /// </summary>
    public partial class LAB10 : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        private SqlCommandBuilder commandBuilder;
        DataTable clothesTable;
        string IMG;
        string sn;
        string fn;
        string dscrptn;
        string color;
        int cost;
        int size;
        int rate;


        public LAB10()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void UpdateDB()
        {
            try
            {
                SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
                adapter.Update(clothesTable);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Clothes_grid.SelectedItems != null)
            {
                for (int i = 0; i < Clothes_grid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = Clothes_grid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM CLOTHES";
            clothesTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter = new SqlDataAdapter(sql, connection);
                //commandBuilder = new SqlCommandBuilder(adapter);
                //adapter.InsertCommand = new SqlCommand("INSERT_PRODUCT", connection);
                //adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@sn", SqlDbType.NVarChar, 255, "SHORT_NAME"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@fn", SqlDbType.NVarChar, 255, "FULL_NAME"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@dc", SqlDbType.NVarChar, 1028, "DESCRIPTION_CLOTH"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@ia", SqlDbType.Image, 0, "IMAGE_ADRESS"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@ctgr", SqlDbType.NVarChar, 50, "CATEGORY"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@rate", SqlDbType.Int, 0, "RATE"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@cost", SqlDbType.Money, 0, "COST"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@clr", SqlDbType.NVarChar, 255, "COLOR"));
                //adapter.InsertCommand.Parameters.Add(new SqlParameter("@size", SqlDbType.Int, 0, "SIZE"));

                //SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "ID");
                //parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(clothesTable);
                Clothes_grid.ItemsSource = clothesTable.DefaultView;
                for (int iter = 8; iter < 18; iter++)
                {
                    Clothes_grid.Columns[iter].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ChangeValuesPopup.IsOpen = true;
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (Clothes_grid.SelectedIndex == -1)
            {
                Clothes_grid.SelectedIndex = 0;
                ChangeValuesPopup2.IsOpen = false;
            }
            else
            {
                Clothes_grid.SelectedIndex--;
                ChangeValuesPopup2.IsOpen = false;
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (Clothes_grid.SelectedIndex == -1)
            {
                Clothes_grid.SelectedIndex = 0;
                ChangeValuesPopup2.IsOpen = false;
            }
            else
            {
                Clothes_grid.SelectedIndex++;
                ChangeValuesPopup2.IsOpen = false;
            }
            
        }

        private void Clothes_grid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (Clothes_grid.SelectedItems.Count != 0)
            {
                DataRowView datarowView = Clothes_grid.SelectedItems[0] as DataRowView;
                ShortNameEditTB.Text = (string)datarowView.Row[0];
                FullNameEditTB.Text = (string)datarowView.Row[1];
                DescriptionEditTB.Text = (string)datarowView.Row[2];
                byte[] imageBytes = (byte[]) datarowView.Row[3];
                CategoryEditCB.Text = (string)datarowView.Row[4];
                RateEditSLDR.Value = (int)datarowView.Row[5];
                CostEditTB.Text = Convert.ToInt32(datarowView.Row[6]).ToString();
                ColorEditCB.Text = (string)datarowView.Row[7];
                SizeEditTB.Text = datarowView.Row[8].ToString();
                ChangeValuesPopup2.IsOpen = true;

            }
        }
          

        private void AddPictureBTTN_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".jpg|.jfif|.jpg"))
            {
                IMG = filename;
            }
            else
            {
                System.Windows.MessageBox.Show("Неверный формат файла!");
            }
        }
        private void OkEditItemBTTN_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = clothesTable.NewRow();
            byte[] imageBytes = File.ReadAllBytes(IMG);
            row.ItemArray = new object[] { ShortNameEditTB.Text, FullNameEditTB.Text,DescriptionEditTB.Text, imageBytes, CategoryEditCB.Text,Convert.ToInt32(RateEditSLDR.Value),int.Parse(CostEditTB.Text), ColorEditCB.Text, int.Parse(SizeEditTB.Text)};
            clothesTable.Rows.Add(row);
            ChangeValuesPopup.IsOpen = false;
            UpdateDB();
        }

        private void CloseEditPUP_Click(object sender, RoutedEventArgs e)
        {
            ChangeValuesPopup.IsOpen = false;
        }

        private void CloseEditPUP2_Click(object sender, RoutedEventArgs e)
        {
            ChangeValuesPopup2.IsOpen = false;
        }

        private void OkEditItemBTTN2_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageBytes = File.ReadAllBytes(IMG);
            ((DataRowView)Clothes_grid.SelectedItems[0]).Row.ItemArray = new object[] { ShortNameEditTB.Text, FullNameEditTB.Text, DescriptionEditTB.Text, imageBytes, CategoryEditCB.Text, Convert.ToInt32(RateEditSLDR.Value), int.Parse(CostEditTB.Text), ColorEditCB.Text, int.Parse(SizeEditTB.Text) };
        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            QueryPopUp.IsOpen = true;
        }

        private void OkQuery_Click(object sender, RoutedEventArgs e)
        {
            string sql = QTB.Text;
            clothesTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter(sql, connection);
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
                adapter = new SqlDataAdapter(command);

                Console.WriteLine("Затронуто строк: {0}", number);
                adapter.Fill(clothesTable);
                UpdateDB();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void CloseQuery_Click(object sender, RoutedEventArgs e)
        {
            QueryPopUp.IsOpen = false;

        }
    }
       
}

