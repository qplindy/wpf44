using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

using WpfApp4.Models;
using WpfApp4.Pages;



namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public CarConfiguration Config { get; set; } //хранение
        public MainWindow()
        {
            InitializeComponent();
            Config = new CarConfiguration(); //это конфигурация, которая в последствие будет заполняться
            MainFrame.Navigate(new Step1Page(Config)); // запуск мастера с первой страницы
        }
    }
}