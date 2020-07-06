using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleService
{
    class Vehicle
    {
        public string Type { get; set; }

        private Detail body;
        private Detail transmission;
        private Detail wheels;
        private Detail motor;
        protected Detail uniqueItem;

        public Vehicle (int bodyHP, int transmissionHP, int wheelsHP, int motorHP)
        {
            this.body = new Body(bodyHP);
            this.transmission = new Transmission(transmissionHP);
            this.wheels = new Wheels(wheelsHP);
            this.motor = new Motor(motorHP);
        }

        public int PrintCost ()
        {
            Console.WriteLine($"--- Цены на ремонт повреждённых деталей ---");
            int sum = 0;

            sum += body.Cost();
            sum += transmission.Cost();
            sum += wheels.Cost();
            sum += motor.Cost();
            sum += uniqueItem.Cost();

            if (sum == 0)
                Console.WriteLine($"Все детали машины целые");
            else
                Console.WriteLine($"Общая сумма ремонта: ${sum}");
            Console.WriteLine();
            return sum;
        }

        public void Repair()
        {
            Console.Write("Введите через запятую детали, которые необходимо отремонтировать: ");
            //string repairLine = Console.ReadLine();
            string[] repairList = Console.ReadLine().Split(',');
            foreach(string repairItem in repairList)
            {
                if (body.IsRepairable(repairItem))
                    body.Repair();
                else if (transmission.IsRepairable(repairItem))
                    transmission.Repair();
                else if (wheels.IsRepairable(repairItem))
                    wheels.Repair();
                else if (motor.IsRepairable(repairItem))
                    motor.Repair();
                else if (uniqueItem.IsRepairable(repairItem))
                    uniqueItem.Repair();
                else 
                    Console.WriteLine($"Отсутствует возможность починить {repairItem}");
            }
            Console.WriteLine();
        }

        public void Condition()
        {
            Console.WriteLine($"--- Состояние ТС {this.Type} ---");
            Console.WriteLine($"{this.body.Name}: {this.body.DetailHP}/100");
            Console.WriteLine($"{this.transmission.Name}: {this.transmission.DetailHP}/100");
            Console.WriteLine($"{this.wheels.Name}: {this.wheels.DetailHP}/100");
            Console.WriteLine($"{this.motor.Name}: {this.motor.DetailHP}/100");
            Console.WriteLine($"{this.uniqueItem.Name}: {this.uniqueItem.DetailHP}/100");
            Console.WriteLine();
        }
    }

    class Car : Vehicle
    {
        public Car (int bodyHP, int transmissionHP, int wheelsHP, int motorHP, int uniqueItemHP)
            : base (bodyHP, transmissionHP,  wheelsHP,  motorHP)
        {
            this.Type = "Легковой автомобиль";
            this.uniqueItem = new UniqueItem("Турбонаддув", uniqueItemHP, 2);
        }
    }

    class Van : Vehicle
    {
        public Van(int bodyHP, int transmissionHP, int wheelsHP, int motorHP, int uniqueItemHP)
            : base(bodyHP, transmissionHP, wheelsHP, motorHP)
        {
            this.Type = "Грузовик";
            this.uniqueItem = new UniqueItem("Прицеп", uniqueItemHP, 3);
        }
    }

    class Bus : Vehicle
    {
        public Bus(int bodyHP, int transmissionHP, int wheelsHP, int motorHP, int uniqueItemHP)
            : base(bodyHP, transmissionHP, wheelsHP, motorHP)
        {
            this.Type = "Автобус";
            this.uniqueItem = new UniqueItem("Салон", uniqueItemHP, 4);
        }
    }
}

