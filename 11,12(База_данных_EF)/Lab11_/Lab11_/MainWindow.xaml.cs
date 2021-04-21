using Lab11_.Contexts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Data;
using Lab11_.Classes;
using System;
using System.Text.RegularExpressions;
using Lab11_.Repository;

namespace Lab11_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string lastChoosen;
        public bool addingNew = false;
        public int lastChoosenItem;
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
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                DGTables.ItemsSource = db.Users.ToList();
                                Add.IsEnabled = true;
                            }
                            break;
                        }
                    case "Products":
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                DGTables.ItemsSource = db.Products.ToList(); Add.IsEnabled = false;

                            }
                            break;
                        }
                    case "Reports":
                        {
                            DGTables.ItemsSource = db.Reports.ToList(); Add.IsEnabled = false;

                            break;
                        }
                    case "UsersData":
                        {
                            DGTables.ItemsSource = db.UsersData.ToList(); Add.IsEnabled = false;

                            break;
                        }
                    case "UsersParams":
                        {
                            DGTables.ItemsSource = db.UsersParams.ToList(); Add.IsEnabled = false;

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
                                case "Users":
                                    {
                                        UnitOfWork context = new UnitOfWork();
                                        context.Users.Delete(Convert.ToInt32(((Users)obj).Id));
                                        context.Save() ; 
                                        break; 
                                    }
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
                switch (lastChoosen)
                {
                    case "Users": 
                {
                    AddingNewUser.IsOpen = true;       
                    break; 
                }
                           
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

    

        public  void UpdateDB<TEntity>(TEntity entity) where TEntity : class
        {
            // Настройки контекста
            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            db.Entry<TEntity>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (DGTables.SelectedItems.Count != 0)
            {
                object obj = DGTables.SelectedItems[0];
                switch (lastChoosen)
                {
                    case "Users":
                        {
                            ChangePOPUPUser.IsOpen = true;
                            LoginTextBox.Text = ((Users)obj).UserLogin;
                            PasswordTextBox.Text = ((Users)obj).UserPassword;
                            break;
                        }
                    case "Products":
                        {
                            ChangePOPUProduct.IsOpen = true;
                            NameProduct.Text = ((Products)obj).ProductName;
                            CalPR.Text = ((Products)obj).CaloriesGram.ToString();
                            PRPR.Text = ((Products)obj).ProteinsGram.ToString();
                            CRBHPR.Text = ((Products)obj).CarbohydratesGram.ToString();
                            FATSPR.Text = ((Products)obj).FatsGram.ToString();

                            break;
                        }
                }
            }
        }

        private void OKEditUsers_Click(object sender, RoutedEventArgs e)
        {
            UnitOfWork context = new UnitOfWork();
            Users users = context.Users.GetItem(lastChoosenItem);
            if (LoginTextBox.Text != null && LoginTextBox.Text != "")
                users.UserLogin = LoginTextBox.Text;
            if (PasswordTextBox.Text != null && PasswordTextBox.Text != "")
                users.UserPassword = PasswordTextBox.Text;

            context.Users.Update(users);
            context.Save();

            ChangePOPUPUser.IsOpen = false;
            UpdateDB();


        }

        private void OKEditProducts_Click(object sender, RoutedEventArgs e)
        {
            UnitOfWork context = new UnitOfWork();
            Products product = context.Products.GetItem(lastChoosenItem);
            if (CalPR.Text != null && CalPR.Text != "")
                product.CaloriesGram = decimal.Parse(CalPR.Text);
            if (CRBHPR.Text != null && CRBHPR.Text != "")
                product.CarbohydratesGram = decimal.Parse(CRBHPR.Text);
            if (FATSPR.Text != null && FATSPR.Text != "")
                product.FatsGram = decimal.Parse(FATSPR.Text);
            if (PRPR.Text != null && PRPR.Text != "")
                product.ProteinsGram = decimal.Parse(PRPR.Text);
            if (NameProduct.Text != null && NameProduct.Text != "")
                product.ProductName = NameProduct.Text;


            context.Products.Update(product);
            context.Save();

            ChangePOPUProduct.IsOpen = false;
            UpdateDB();

        }

        private void DGTables_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            UnitOfWork context = new UnitOfWork();
            if (DGTables.SelectedItems.Count != 0)
            {
                object obj = DGTables.SelectedItems[0];
                switch (lastChoosen)
                {
                    case "Users":
                        {
                            lastChoosenItem = ((Users)obj).Id;
                            Change.IsEnabled = true;
                            break;
                        }
                    case "Products":
                        {
                            lastChoosenItem = ((Products)obj).IdAdded;
                            Change.IsEnabled = true;
                            break;
                        }
                    case "Reports":
                        {
                            lastChoosenItem = ((Reports)obj).IdReport;
                            Change.IsEnabled = false;

                            break;
                        }
                    case "UsersData":
                        {
                            lastChoosenItem = ((UsersData)obj).IdData;
                            Change.IsEnabled = false;
                            break;
                        }
                    case "UsersParams":
                        {
                            lastChoosenItem = ((UsersParams)obj).IdParams;
                            Change.IsEnabled = false;
                            break;
                        }
                }
            }

        }

        private void OKAddUser_Click(object sender, RoutedEventArgs e)
        {
            UnitOfWork context = new UnitOfWork();
            try
            {
                Users user = new Users();
                user.IsAdmin = false;
                user.UserLogin = LoginAddUser.Text;
                user.UserPassword = PasswordAddUser.Text;

                context.Users.Create(user);
                context.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AddingNewUser.IsOpen = false;
            UpdateDB();

        }
    }
}
