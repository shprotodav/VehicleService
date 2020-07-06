using System;

namespace VehicleService
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(80, 100, 50, 10, 60);
            Van van = new Van(80, 100, 50, 10, 60);
            Bus bus = new Bus(80, 100, 50, 10, 60);
            Vehicle vehicle = null;

            Console.Write($"Введите тип ТС ({car.Type}/{van.Type}/{bus.Type}): ");
            SetType(ref car, ref van, ref bus, ref vehicle);
            vehicle.Condition();
            if (vehicle.PrintCost() != 0)
            {
                vehicle.Repair();
                vehicle.Condition();
            }


            Console.ReadLine();
        }


        public static void SetType(ref Car car, ref Van van, ref Bus bus, ref Vehicle vehicle)
        {
            string vehicleName = Console.ReadLine();
            if (vehicleName.Equals(car.Type))
                vehicle = car;
            else if (vehicleName.Equals(van.Type))
                vehicle = van;
            else if (vehicleName.Equals(bus.Type))
                vehicle = bus;
            else
            {
                Console.Write($"Неизвестный тип ТС \"{vehicleName}\". Введите ещё раз: ");
                SetType(ref car, ref van, ref bus, ref vehicle);
                return;
            }
            Console.WriteLine();
        }
    }
}
