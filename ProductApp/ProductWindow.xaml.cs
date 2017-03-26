using System;
using System.Windows;
using ProductApp.Models;

namespace ProductApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public ProductModel Product { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Product != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Product = new ProductModel();
                Product.CreatedDate = DateTime.Now;
            }
            uxGrid.DataContext = Product;
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Product = new ProductModel();

           // Product.Number = int.Parse(uxNumber.Text);
           // Product.Description = uxDescription.Text;
           // Product.Price = double.Parse(uxPrice.Text);
            //Product.Quantity = int.Parse(uxQuantity.Text);
              Product.Value = double.Parse(uxPrice.Text)* int.Parse(uxQuantity.Text);
           // Product.Cost = double.Parse(uxCost.Text);
           // Product.CreatedDate = DateTime.Now;

            DialogResult = true;
            Close();
        }

        private void uxPrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(uxPrice.Text)&&!string.IsNullOrEmpty(uxQuantity.Text))
            {
                this.uxValue.Text = (double.Parse(uxPrice.Text) * int.Parse(uxQuantity.Text)).ToString();
            }
            
        }

        private void uxQuantity_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(uxPrice.Text) && !string.IsNullOrEmpty(uxQuantity.Text))
            {
                this.uxValue.Text = (double.Parse(uxPrice.Text) * int.Parse(uxQuantity.Text)).ToString();
            }
                
        }
    }
}
