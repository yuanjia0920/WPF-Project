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
using ProductApp.Models;

namespace ProductApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private ProductModel selectedProduct;
        private void uxProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = (ProductModel)uxProductList.SelectedValue;
            buttonDelete.IsEnabled = (selectedProduct != null);
            buttonChange.IsEnabled = (selectedProduct != null);
        }

        private void LoadProducts()
        {
            var products = App.ProductRepository.GetAll();

            uxProductList.ItemsSource = products.Select(t => ProductModel.ToModel(t)).ToList();
        }
        
        private void uxFileAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductWindow();

            if(window.ShowDialog()==true)
            {
                var uiProductModel = window.Product;
                var repositoryProductModel = uiProductModel.ToRepositoryModel();
                App.ProductRepository.Add(repositoryProductModel);

                LoadProducts();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedProduct != null);
        }
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductWindow();
            window.Product = selectedProduct;

            if (window.ShowDialog() == true)
            {
                App.ProductRepository.Update(window.Product.ToRepositoryModel());
                LoadProducts();
            }
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedProduct != null);
        }
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show(this, "Delete " + selectedProduct.Description, "Confirmation", 
                MessageBoxButton.OKCancel, MessageBoxImage.Warning)==MessageBoxResult.OK)
            {
                App.ProductRepository.Remove(selectedProduct.Id);
                selectedProduct = null;
                LoadProducts();
            }
        }
        private void uxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            uxFileAdd_Click(sender, null);
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            uxFileDelete_Click(sender, null);
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            uxFileChange_Click(sender, null);
        }

        private void uxProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            uxFileChange_Click(sender, null);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            // Grab the Tag from the column header
            string sortBy = column.Tag.ToString();

            // Clear out any previous column sorting
            uxProductList.Items.SortDescriptions.Clear();

            // Sort the uxContactList by the column header tag (sortBy)
            // If you want to do Descending, look at the homework :) and SortAdorner
            var sortDescription = new System.ComponentModel.SortDescription(sortBy,
                System.ComponentModel.ListSortDirection.Ascending);

            uxProductList.Items.SortDescriptions.Add(sortDescription);
        }
    }
}
