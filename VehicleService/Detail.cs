using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleService
{
    class Detail
    {
        public string Name { get; set; }
        public int DetailHP { get; set; }
        public int CostCoef { get; set; }

        public Detail(string Name, int detailHP, int costCoef)
        {
            this.Name = Name;
            this.DetailHP = detailHP;
            this.CostCoef = costCoef;
        }

        public int Cost()
        {
            if (this.DetailHP < 100)
            {
                int sum = (100 - this.DetailHP) * CostCoef;
                Console.WriteLine($"{this.Name}: ${sum}");
                return sum;
            }
            return 0;
        }

        public void Repair()
        {
            this.DetailHP = 100;
            Console.WriteLine($"Деталь {this.Name} успешно отремонтирована");
        }

        public bool IsRepairable(string detailName)
        {
            if (detailName.Equals(this.Name) && this.DetailHP < 100)
                return true;
            else
                return false;
        }
    }

    class Body : Detail
    {
        public Body (int detailHP)
            : base("Корпус", detailHP, 1) { }
    }

    class Transmission : Detail
    {
        public Transmission(int detailHP)
            : base("Трансмиссия", detailHP, 1) { }
    }

    class Wheels : Detail
    {
        public Wheels(int detailHP)
            : base("Колёса", detailHP, 1) { }
    }

    class Motor : Detail
    {
        public Motor(int detailHP)
            : base("Мотор", detailHP, 1) { }
    }

    class UniqueItem : Detail
    {
        public UniqueItem(string Name, int detailHP, int costCoef)
            : base (Name, detailHP, costCoef) { }
    }
}
