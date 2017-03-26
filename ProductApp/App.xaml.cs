using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProductApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ProductRepository.ProductRepository productRepository;
        static App()
        {
            productRepository = new ProductRepository.ProductRepository();
        }
        public static ProductRepository.ProductRepository ProductRepository
        {
            get
            {
                return productRepository;
            }
        }
    }
}
