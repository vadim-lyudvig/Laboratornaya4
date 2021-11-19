using System;
using System.Drawing;

namespace Vehicle
{
    //Супер-класс (Родительский)
    class Vehicle
    {
        public int WheelCount = 4;
        public virtual string GetInfo()
        {
            return ("Количество колес: " + WheelCount); 
        }
        public virtual Image GetImage()
        {
            return Properties.Resources.mountain;
        }
        public static Random rnd = new Random();
    }
    //Перечисление для велосипеда
    public enum Bicycle
    {
        //Горный
        mountain, 
        //Городской
        urban,
        //Детский
        childlike
    }
    //Класс для велосипеда
    class Bike : Vehicle
    {
        public string name = "Велосипед";
        public Bicycle type = Bicycle.mountain;
        public int WheelRadius = 15;
        //Переопределяем метод GetInfo
        public override string GetInfo()
        {
            var str = name;
            str += "\n"+base.GetInfo();
            switch (type)
            {
                case Bicycle.mountain:
                    str += "\nТип: Горый";
                    break;
                case Bicycle.urban:
                    str += "\nТип: Городской";
                    break;
                case Bicycle.childlike:
                    str += "\nТип: Детский";
                    break;
            }
            str += "\nРадиус колес: " + WheelRadius;
            return str;
        }
        //Переопределяем метод выдачи изображения велосипеда
        public override Image GetImage()
        {
            switch (type)
            {
                case Bicycle.mountain:
                    return Properties.Resources.mountain as Bitmap;
                case Bicycle.urban:
                    return Properties.Resources.urban as Bitmap;
                default:
                    return Properties.Resources.childlike as Bitmap;
            }
        }
        //Метод для генерации велосипедов
        public static Bike Generate()
        {
            int WheelCount;
            var type = (Bicycle)rnd.Next(3);
            if(type == Bicycle.childlike)
            {
                WheelCount = 4;
            }
            else
            {
                WheelCount = 2;
            }
            var WheelRadius = rnd.Next(10, 20);
            return new Bike
            {
                WheelCount = WheelCount,
                type = type,
                WheelRadius = WheelRadius
            };
        }
    }
    //Тип автомобиля
    public enum CarType
    {
        //Автобус
        Bus, 
        //Грузовик
        Truck,
        //Внедорожник
        Suv,
        //Легковая
        Car
    }
    class Car : Vehicle
    {
        public string name = "Автомобиль";
        //Тип автомобиля
        public CarType type = CarType.Car;
        //Объем двигателя
        public int engineVolume = 10;
        //Кол-во дверей
        public int doorCount = 5;
        public override string GetInfo()
        {
            var str = name;
            str += "\n" + base.GetInfo();
            switch (type)
            {
                case CarType.Bus:
                    str += "\nТип: Автобус";
                    break;
                case CarType.Truck:
                    str += "\nТип: Грузовик";
                    break;
                case CarType.Suv:
                    str += "\nТип: Внедорожник";
                    break;
                case CarType.Car:
                    str += "\nТип: Легковая";
                    break;
            }
            str += "\nКоличество дверей: " + doorCount;
            str += "\nМощность двигателя: " + engineVolume;
            return str;
        }
        public override Image GetImage()
        {
            switch (type)
            {
                case CarType.Bus:
                    return Properties.Resources.Bus as Bitmap;
                case CarType.Truck:
                    return Properties.Resources.Truck as Bitmap;
                case CarType.Suv:
                    return Properties.Resources.Suv as Bitmap;
                default:
                    return Properties.Resources.Car as Bitmap;
            }
        }
        public static Car Generate()
        {
            int doorCount;
            var type = (CarType)rnd.Next(4);
            if(type == CarType.Car || type == CarType.Bus)
            {
                doorCount = 3;
            }
            else if (type == CarType.Truck)
            {
                doorCount = 2;
            }
            else
            {
                doorCount = 5;
            }
            return new Car
            {
                WheelCount = 4,
                type = type,
                engineVolume = rnd.Next(10, 250),
                doorCount = doorCount
            };
        }
    }
    //Тип двигателя самолета
    enum EngineType
    {
        //Поршневой
        piston,
        //Турбовинтовой
        turboprop,
        //Реактивный
        reactive
    }
    class Jet : Vehicle
    {
        public string name = "Самолет";
        public EngineType type = EngineType.piston;
        public int maxWight = 10;
        public override string GetInfo()
        {
            var str = name;
            str += "\n" + base.GetInfo();
            switch (type)
            {
                case EngineType.piston:
                    str += "\nТип двигателя: Поршневой";
                    break;
                case EngineType.turboprop:
                    str += "\nТип двигателя: Турбовинтовой";
                    break;
                case EngineType.reactive:
                    str += "\nТип двигателя: Реактивный";
                    break;
            }
            str += "\nВысота полета: " + maxWight;
            return str;
        }
        public override Image GetImage()
        {
            switch (type)
            {
                case EngineType.piston:
                    return Properties.Resources.piston as Bitmap;
                case EngineType.turboprop:
                    return Properties.Resources.turboprop as Bitmap;
                default:
                    return Properties.Resources.reactive as Bitmap;
            }
        }
        public static Jet Generate()
        {
            return new Jet
            {
                WheelCount = 3,
                type = (EngineType)rnd.Next(3),
                maxWight = rnd.Next(8000, 15000)
            };
        }
    }
}