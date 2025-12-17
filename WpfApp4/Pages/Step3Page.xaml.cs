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
    public partial class Step3Page : Page
    {
        private CarConfiguration _config;

        public Step3Page(CarConfiguration config)
        {
            InitializeComponent();
            _config = config;

            ShowData();
        }
        private void ShowData()
        {
            ModelText.Text = $"Модель: {_config.Model}";
            EngineText.Text = $"Двигатель: {_config.Engine}"; // вывод текста
            ColorText.Text = $"Цвет: {_config.Color}";

            StringBuilder options = new StringBuilder();  // список опций

            if (_config.HasClimateControl)
                options.AppendLine("• Климат-контроль");
            if (_config.HasNavigation)
                options.AppendLine("• Навигация"); // отображает выбранные опции
            if (_config.HasParking)
                options.AppendLine("• Парктроник");

            OptionsText.Text = options.Length > 0 // если ничего не выбрано, то выводит нет
                ? options.ToString()
                : "Нет";

            TotalPriceText.Text = $"{_config.TotalPrice:N0} ₽"; // подсчет итоговой цены, а считает она в классе
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Step4Page(_config));
        }
    }

}