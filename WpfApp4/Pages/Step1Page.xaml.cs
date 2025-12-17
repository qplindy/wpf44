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
using WpfApp4.Models;
using WpfApp4.Pages;

namespace WpfApp4.Pages
{
    public partial class Step1Page : Page
    {
        private CarConfiguration _config;
        public Step1Page(CarConfiguration config) // передача конфигурации
        {

            InitializeComponent();

            _config = config;

            ModelComboBox.Items.Add("BMW");
            ModelComboBox.Items.Add("Audi"); //список
            ModelComboBox.Items.Add("Mercedes");

            EngineComboBox.Items.Add("Бензин");
            EngineComboBox.Items.Add("Дизель");
            EngineComboBox.Items.Add("Электро");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) //кнопка далее, но перед этим данные сохраняются в классе
        {
            _config.Model = ModelComboBox.SelectedItem as string;
            _config.Engine = EngineComboBox.SelectedItem as string;

            NavigationService.Navigate(new Step2Page(_config));
        }
    }
}