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
    public partial class Step2Page : Page
    {
        private CarConfiguration _config;

        public Step2Page(CarConfiguration config)
        {
            InitializeComponent();

            _config = config;

            ColorComboBox.Items.Add("Белый (+0 ₽)");
            ColorComboBox.Items.Add("Чёрный (+20 000 ₽)");
            ColorComboBox.Items.Add("Серебрянный (+30 000 ₽)");

            // Восстановление выбора
            if (!string.IsNullOrEmpty(_config.Color))
                ColorComboBox.SelectedItem = _config.Color;

            OptionClimate.IsChecked = _config.HasClimateControl;
            OptionNavigation.IsChecked = _config.HasNavigation;
            OptionParking.IsChecked = _config.HasParking;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение выбора
            _config.Color = ColorComboBox.SelectedItem as string;
            _config.HasClimateControl = OptionClimate.IsChecked == true;
            _config.HasNavigation = OptionNavigation.IsChecked == true;
            _config.HasParking = OptionParking.IsChecked == true;

            NavigationService.Navigate(new Step3Page(_config));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}