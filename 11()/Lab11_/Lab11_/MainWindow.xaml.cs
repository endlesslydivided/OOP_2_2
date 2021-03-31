using Lab11_.Contexts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Data;
using Lab11_.Classes;
using System;
using System.Text.RegularExpressions;

namespace Lab11_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string lastChoosen;
        public bool addingNew = false;
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        public void UpdateDB()
        {
            try 
            { 
                ComboBoxItem typeItem = (ComboBoxItem)CBTables.SelectedItem;
                lastChoosen = typeItem.Content.ToString();
                switch (lastChoosen)
                {
                    case "Users":
                        {
                            db.Users.Load();
                            var Users = db.Users.Local.ToBindingList();
                            DGTables.ItemsSource = Users;
                            break;
                        }
                    case "Products":
                        {
                            db.Products.Load();
                            var Products = db.Products.Local.ToBindingList();
                            DGTables.ItemsSource = Products;
                            break;
                        }
                    case "Reports":
                        {
                            db.Reports.Load();
                            var Reports = db.Reports.Local.ToBindingList();
                            DGTables.ItemsSource = Reports;
                            break;
                        }
                    case "UsersData":
                        {
                            db.UsersData.Load();
                            var UsersData = db.UsersData.Local.ToBindingList();
                            DGTables.ItemsSource = UsersData;
                            break;
                        }
                    case "UsersParams":
                        {
                            db.UsersParams.Load();
                            var UsersParams = db.UsersParams.Local.ToBindingList();
                            DGTables.ItemsSource = UsersParams;
                            break;
                        }
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void CBTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                UpdateDB();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGTables.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < DGTables.SelectedItems.Count; i++)
                    {
                        object obj = DGTables.SelectedItems[i];
                        if (obj != null)
                        {
                            switch (lastChoosen)
                            {
                                case "Users": { db.Users.Attach((Users)obj); db.Users.Remove((Users)obj); ; break; }
                                case "Products": { db.Products.Attach((Products)obj); db.Products.Remove((Products)obj); break; }
                                case "Reports": { db.Reports.Attach((Reports)obj); db.Reports.Remove((Reports)obj); ; break; }
                                case "UsersData": { db.UsersData.Attach((UsersData)obj); db.UsersData.Remove((UsersData)obj); ; break; }
                                case "UsersParams": { db.UsersParams.Attach((UsersParams)obj); db.UsersParams.Remove((UsersParams)obj); ; break; }
                            }

                        }
                    }
                    db.SaveChanges();
                }
                UpdateDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void DGTables_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
        
        }

        private void DGTables_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {           
            addingNew = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                    if (addingNew)
                    {
                        if (DGTables.SelectedItems != null)
                        {
                            switch (lastChoosen)
                            {
                            case "Users": { db.Users.Add((Users)DGTables.SelectedItems[0]); ; break; }
                            case "Products": { db.Products.Add((Products)DGTables.SelectedItems[0]); break; }
                            case "Reports": { db.Reports.Add((Reports)DGTables.SelectedItems[0]); break; }
                            case "UsersData": { db.UsersData.Add((UsersData)DGTables.SelectedItems[0]); break; }
                            case "UsersParams": { db.UsersParams.Add((UsersParams)DGTables.SelectedItems[0]); break; }
                            }
                        }
                    db.SaveChanges();
                    addingNew = false;
                    UpdateDB();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {        
            if (Regex.IsMatch(ID.Text, "^[0-9]*$"))
            {
                int searched = int.Parse(ID.Text);
                switch (lastChoosen)
                {                  
                    case "Users": { DGTables.ItemsSource = db.Users.Where(p => p.Id == searched).ToList(); break; }
                    case "Products": { DGTables.ItemsSource = db.Products.Where(p => p.IdAdded == searched).ToList(); break; }
                    case "Reports": {  DGTables.ItemsSource = db.Reports.Where(p => p.IdReport == searched).ToList(); break; }
                    case "UsersData": {  DGTables.ItemsSource = db.UsersData.Where(p => p.IdData == searched).ToList(); break; }
                    case "UsersParams": {  DGTables.ItemsSource = db.UsersParams.Where(p => p.IdParams == searched).ToList(); break; }
                }
            }
        }

        private void DGTables_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            object obj = DGTables.SelectedItems[0];
            switch (lastChoosen)
            {
                case "Users": 
                    {
                        db.Users.Attach(obj as Users);
                        UpdateDB(obj as Users); 
                        break; 
                    }
                case "Products": 
                    { 
                        UpdateDB(obj as Products);
                        break; 
                    }
                case "Reports": 
                    { 
                        UpdateDB(obj as Reports); 
                        break; 
                    }
                case "UsersData": 
                    { 
                        UpdateDB(obj as UsersData); 
                        break; 
                    }
                case "UsersParams": 
                    { 
                        UpdateDB(obj as UsersParams); 
                        break; 
                    }
            }
            
        }

        public  void UpdateDB<TEntity>(TEntity entity) where TEntity : class
        {
            // Настройки контекста
            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            db.Entry<TEntity>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
