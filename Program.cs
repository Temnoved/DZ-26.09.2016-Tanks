//Разработать программу, моделирующую танковый бой.В танковом бою участвуют 5 танков «Т-34» и 5 танков «Pantera». Каждый танк («Т-34» и «Pantera»)
//описываются параметрами: «Боекомплект»,  «Уровень брони», «Уровень маневренности». Значение данных параметров задаются случайными числами от 0 до 100.
//Каждый танк участвует в парной битве, т.е.первый танк «Т-34» сражается с первым танком «Pantera» и т.д.Победа присуждается тому танку, который превышает
//противника по двум и более параметрам из трех.  Основное требование:  сражение(проверку на победу в бою) реализовать путем перегрузки
//оператора «*» (произведение).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Tanks
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////// Блок тестирования работоспособности методов //////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //тестовые массивы объектов класса Tanks
                //Tanks[] tT34 = { new Tanks("T-34-1"), new Tanks("T-34-2"), new Tanks("T-34-3"), new Tanks("T-34-4"), new Tanks("T-34-5"), };
                //Tanks[] tPanters = { new Tanks("PzKpfwV-1"), new Tanks("PzKpfwV-2"), new Tanks("PzKpfwV-3"), new Tanks("PzKpfwV-4"), new Tanks("PzKpfwV-5"), };

                //проверка работоспособности методов
                //Battle bTestBat = new Battle(tT34, tPanters);
                //bTestBat.ShowTeams();
                //bTestBat.ShowWinner(bTestBat.Winner());

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                const int iTeamQuant = 5;//максимальное количество танков в команде
                Tanks[] tTeamT34 = new Tanks[iTeamQuant];//массив для первой команды
                Tanks[] tTeamPanter = new Tanks[iTeamQuant];//массив для второй команды

                for (int i = 0; i < iTeamQuant; i++)//цикл заполнения
                {
                    //просим ввести имена для пары танков в каждой команде
                    Console.Write("Введите имя для {0}-го танка команды Т-34:", i+1);
                    tTeamT34[i] = new Tanks(Console.ReadLine());                 
                    Console.Write("Введите имя для {0}-го танка команды Panter:", i + 1);
                    tTeamPanter[i] = new Tanks(Console.ReadLine());
                    Console.WriteLine(new String('-', 50));
                }
                Battle bBatle = new Battle (tTeamT34, tTeamPanter);//создание объекта класса Battle
                bBatle.ShowTeams();//показ состава команд и их характеристики
                bBatle.ShowWinner(bBatle.Winner());//показ итогов
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
