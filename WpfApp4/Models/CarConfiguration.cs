using System;
using System.Collections.Generic;

namespace WpfApp4.Models
{
    public class CarConfiguration
    {
        //Шаг 1
        public string Model { get; set; }
        public string Engine { get; set; }

        //Шаг 2
        public string Color { get; set; }
        public bool HasClimateControl { get; set; }
        public bool HasNavigation { get; set; }
        public bool HasParking { get; set; }

        //Шаг 4 (кредит)
        public int DownPaymentPercent { get; set; }
        public int CreditMonths { get; set; }
        public decimal MonthlyPayment { get; set; }

        //Расчёт цены
        public decimal BasePrice
        {
            get
            {
                if (Model == "BMW") return 2_500_000;
                if (Model == "Audi") return 2_200_000;
                if (Model == "Mercedes") return 2_800_000;
                return 0;
            }
        }
        public decimal EnginePrice
        {
            get
            {
                if (Engine == "Бензин") return 0;
                if (Engine == "Дизель") return 150_000;
                if (Engine == "Электро") return 500_000;
                return 0;
            }
        }
        public decimal ColorPrice
        {
            get
            {
                if (Color == "Белый") return 0;
                if (Color == "Чёрный") return 20_000;
                if (Color == "Серебрянный") return 30_000;
                return 0;
            }
        }
        public decimal OptionsPrice
        {
            get
            {
                decimal sum = 0;
                if (HasClimateControl) sum += 30_000;
                if (HasNavigation) sum += 20_000;
                if (HasParking) sum += 25_000;
                return sum;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return BasePrice + EnginePrice + ColorPrice + OptionsPrice;
            }
        }
    }
}