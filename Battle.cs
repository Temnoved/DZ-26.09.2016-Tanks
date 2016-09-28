using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Tanks
{
    enum Teamwinner { T34 = 1, Panters, Tie}//перечисление возможных исходов сражения
    class Battle
    {
        const int iTeamQuant = 5;//максимальное количество юнитов в команде
        protected Tanks [] tT34 = null;//массив для первой команды
        protected Tanks [] tPant = null;//массив для второй команды

        public Battle(Tanks[] t1 = null, Tanks[] t2 = null)//конструктор
        {
            this.tT34 = t1;
            this.tPant = t2;
        }

        public Teamwinner Winner()//определение побидителя
        {
            if(this.tPant.Length == 0 || this.tT34.Length == 0)//проверка на пустые массивы
            {
                throw new Exception("Arrey is empty(class Battle.Winner)");
            }
            int iCountT1 = 0, iCountT2 = 0;
            for(int i = 0; i < iTeamQuant; i++)
            {
                //перегруженная операция * возврощает 1 если победил перывый юнит
                //возвращает -1 если победил второй юнит
                //возвращает 0 если ничья
                if((this.tT34[i]*this.tPant[i]) > 0 )//
                {
                    iCountT1++;
                }
                if ((this.tT34[i] * this.tPant[i]) <0)
                {
                    iCountT2++;
                }
            }
            //по окончании цикла возвращаем один из возможных результатов в зависимости от состояния счетчиков
            if (iCountT1 > iCountT2)
            {
                return Teamwinner.T34;
            }
            if (iCountT1 < iCountT2)
            {
                return Teamwinner.Panters;
            }
            return Teamwinner.Tie;  
        }

        public void ShowTeams()//метод показа команд
        {
            if (this.tPant.Length == 0 || this.tT34.Length == 0)//проверка на пустые массивы
            {
                throw new Exception("Arrey is empty(class Battle.ShowTeams)");
            }
            Console.WriteLine("Team T-34:" + new String(' ', 30) + "Team Panter:");
            for(int i = 0; i < iTeamQuant; i++)
            {
                this.tT34[i].ShowTank();
                Console.Write("\t");
                this.tPant[i].ShowTank();
                Console.WriteLine();
            }
            Console.WriteLine(new String('*', 75));
        }

        public void ShowWinner(Teamwinner tWin)//метод показа результата
        {
            if ((int)tWin < 1 || (int)tWin > 3)//проверка попадания результата в допустимый диапазон
            {
                throw new Exception("Arrey is empty(class Battle.ShowTeams)");
            }

            if (tWin == Teamwinner.T34)
            {
                Console.WriteLine("Battle result: Team T-34 - Winner");
            }
            if (tWin == Teamwinner.Panters)
            {
                Console.WriteLine("Battle result: Team Panters - Winner");
            }
            if (tWin == Teamwinner.Tie)
            {
                Console.WriteLine("Battle result: Tie");
            }
        }
    }
}
