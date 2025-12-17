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
    public partial class Step4Page : Page
    {
        private CarConfiguration _config;
        private const decimal AnnualRate = 0.12m; // 12% - фиксированная процентная ставка

        public Step4Page(CarConfiguration config) // передача конфы
        {
            InitializeComponent();
            _config = config;// сохраняем конфигурацию в поле класса
        }

        private void Recalculate(object sender, SelectionChangedEventArgs e) // вызов когда пользователь меняет процент или срок
        {
            if (_config == null) // проверка на передачу конфы
            {
                MessageBox.Show("_config == null");
                return;
            }

            if (DownPaymentComboBox.SelectedItem == null ||
                TermComboBox.SelectedItem == null)
                return; // проверка на выбор

            int downPercent =
                int.Parse(((ComboBoxItem)DownPaymentComboBox.SelectedItem).Content.ToString()); // получение процентов, превращаем в число

            int months =
                int.Parse(((ComboBoxItem)TermComboBox.SelectedItem).Content.ToString()); // получение срока

            decimal downPayment = _config.TotalPrice * downPercent / 100m; // рассчет первон взноса
            decimal creditSum = _config.TotalPrice - downPayment; // это наша итоговая сумма кредита

            decimal monthlyRate = AnnualRate / 12m; // месячная процентная ставка
            decimal monthlyPayment = // ну и сам рассчет ежемесяного платежа
                creditSum *
                (monthlyRate * (decimal)System.Math.Pow((double)(1 + monthlyRate), months)) /
                ((decimal)System.Math.Pow((double)(1 + monthlyRate), months) - 1);

            DownPaymentText.Text = $"Первоначальный взнос: {downPayment:N0} ₽"; // вывод результатов на экран
            CreditSumText.Text = $"Сумма кредита: {creditSum:N0} ₽";
            MonthlyPaymentText.Text = $"Ежемесячный платёж: {monthlyPayment:N0} ₽";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Step5Page(_config));
        }
    }
}