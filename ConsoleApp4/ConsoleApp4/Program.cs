using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            float skillDamage;
            float cardGauge;
            float specialAttackDamage;
            int maxMana;
            int manaRegeninBattle;
            int manaRegeninNBattel;
            float movementSpeed;
            float ridingSpeed;
            float movingSpeed;
            float coolTime;

            Console.Write("스킬 피해량을 입력하세요: ");
            skillDamage = float.Parse(Console.ReadLine());



            Console.WriteLine($"스킬 피해량은 {skillDamage}입니다. ");

        }
    }
}
