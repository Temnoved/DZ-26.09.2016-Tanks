using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Tanks
{
    class Tanks
    {
        static Random rnd = new Random();//дял случайного заполнения
        protected String strName = "";//имя
        protected byte bArmor = 0;//броня
        protected byte bAmo = 0;//боезапас
        protected byte bMobility = 0;//мобильность

        public Tanks(String strNam = "")//конструктор с именем
        {
            this.strName = strNam;
            this.bArmor = (byte)rnd.Next(0, 101);
            this.bAmo = (byte)rnd.Next(0, 101);
            this.bMobility = (byte)rnd.Next(0, 101);
        }

        public Tanks()//конструктор без параметров
        {
            char[] chTmp = new char[5];//для генерации имени
            for (int i = 0; i < 5; i++)//созадём случайный набор из больших букв
            {
                chTmp[i] = (char)rnd.Next(65, 91);
            }
            this.strName = chTmp.ToString();
            //случайное заполнение полей
            this.bArmor = (byte)rnd.Next(0, 101);
            this.bAmo = (byte)rnd.Next(0, 101);
            this.bMobility = (byte)rnd.Next(0, 101);
        }

        static int ArmorCompare(Tanks tObj1, Tanks tObj2)//сравнение по броне
        {
            if(tObj1.bArmor > tObj2.bArmor)
            {
                return 1;
            }
            if(tObj1.bArmor < tObj2.bArmor)
            {
                return -1;
            }
            return 0;
        }

        static int AmoCompare(Tanks tObj1, Tanks tObj2)//сравнение по боезапасу
        {
            if (tObj1.bAmo > tObj2.bAmo)
            {
                return 1;
            }
            if (tObj1.bAmo < tObj2.bAmo)
            {
                return -1;
            }
            return 0;
        }

        static int MobilityCompare(Tanks tObj1, Tanks tObj2)//сравнение по мобильности
        {
            if (tObj1.bMobility > tObj2.bMobility)
            {
                return 1;
            }
            if (tObj1.bMobility < tObj2.bMobility)
            {
                return -1;
            }
            return 0;
        }
        public static short operator * (Tanks tObj1, Tanks tObj2)//определение победителя в сражении пары юнитов
        {
            short CountObj = 0;
            CountObj += (short)ArmorCompare(tObj1, tObj2);
            CountObj += (short)AmoCompare(tObj1, tObj2);
            CountObj += (short)MobilityCompare(tObj1, tObj2);
            //вернёт отрицательное значение если победил юнит 2
            //вернёт положительное значение если победил юнит 1
            //вернёт 0 если ничья
            return CountObj;
        }


        public void ShowTank()//метод показа характеристик юнита в виде строки
        {
            if(this.strName == "")//если имени нет генерируем исключение
            {
                throw new Exception("The tank has empty name(class Tanks.ShowTank)");
            }
            Console.Write("Name:" + this.strName + " Arm:" + this.bArmor.ToString() + " Amo:" + this.bAmo + " Mobi:" + this.bMobility);
        }
    }
}
