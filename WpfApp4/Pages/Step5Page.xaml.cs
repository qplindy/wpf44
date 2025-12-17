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

namespace WpfApp4.Pages
{
    public partial class Step5Page : Page
    {
        private CarConfiguration _config;

        public Step5Page(CarConfiguration config)
        {
            InitializeComponent();
            _config = config;
            ShowSummary(); // для показа итоговой инфы
        }
        private void ShowSummary()
        {
            StringBuilder sb = new StringBuilder(); //StringBuilder используется для удобного формирования многострочного текста

            sb.AppendLine($"Модель: {_config.Model}");
            sb.AppendLine($"Двигатель: {_config.Engine}");
            sb.AppendLine($"Цвет: {_config.Color}");
            sb.AppendLine($"Цена: {_config.TotalPrice:N0} ₽");
            sb.AppendLine($"Платёж: {_config.MonthlyPayment:N0} ₽ / мес");

            SummaryText.Text = sb.ToString(); // сам вывод на экран
        }
        private void Validate(object sender, TextChangedEventArgs e) // валидация, будет вызываться каждый раз, при изменении полей
        {
            bool isValid =
                NameTextBox.Text.Length >= 2 &&
                IsDigitsOnly(PhoneTextBox.Text) && // это проверки на заполненность полей
                EmailTextBox.Text.Contains("@");

            SubmitButton.IsEnabled = isValid;// только если данные заполнены, кнопка активна
        }
        private bool IsDigitsOnly(string text) // для валидации номера телефона
        {
            foreach (char c in text)
                if (!char.IsDigit(c))
                    return false;
            return text.Length >= 5;
        }
        private void PhoneOnlyDigits(object sender, TextCompositionEventArgs e) // а это ораничение ввода букв
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }
        private void ValidateForm(object sender, TextChangedEventArgs e) // более строгая проверка, например точка в почте
        {
            bool isNameValid = !string.IsNullOrWhiteSpace(NameTextBox.Text);
            bool isPhoneValid = PhoneTextBox.Text.All(char.IsDigit) && PhoneTextBox.Text.Length >= 6;
            bool isEmailValid = EmailTextBox.Text.Contains("@") && EmailTextBox.Text.Contains(".");

            SubmitButton.IsEnabled = isNameValid && isPhoneValid && isEmailValid;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            bool hasData =
                !string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                !string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                !string.IsNullOrWhiteSpace(EmailTextBox.Text);

            if (hasData)
            {
                var result = MessageBox.Show(
                    "Введённые данные будут потеряны. Продолжить?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    NavigationService.GoBack();
                }
            }
            else
            {
                NavigationService.GoBack();
            }
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Заявка успешно оформлена!\nНаш менеджер свяжется с вами.",
                "Готово",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            Application.Current.Shutdown();
        }

    }

}