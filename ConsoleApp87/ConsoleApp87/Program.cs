using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp87
{
    class Character
    {
        public string characterName;

        public int characterLevel;
        public int characterHealth;
        public int characterCost;
        public int characterAttack;
        public bool isAlive;

        public Skill[] skills;

        public Character()
        {
            isAlive = true;
            characterLevel = 1;

            skills = new Skill[4];

            skills[0] = new Skill();
            skills[0].skillName = "q skill";
            skills[1] = new Skill();
            skills[1].skillName = "w skill";
            skills[2] = new Skill();
            skills[2].skillName = "e skill";
            skills[3] = new Skill();
            skills[3].skillName = "r skill";
        }
        
        public void Attack(ref Character character)
        {
            Console.WriteLine($"{character}에게 기본 공격!");
            character.characterHealth -= characterAttack;
        }
    }
    class Skill
    {
        public string skillName { get; set; }
        public int skillValue;

        public void UseSkill()
        {
            Console.WriteLine($"{skillName} 사용!");
        }
        public void UseSkill(ref Character character)
        {
            Console.WriteLine($"{character.characterName} 에게 \"{skillName}\" 사용!");
            character.characterHealth -= skillValue;
        }
        public void UseSkill(ref Character echaracter, ref Character acharacter)
        {
            Console.WriteLine($"\"{skillName}\" 사용!");
            echaracter.characterHealth -= skillValue;
            acharacter.characterHealth += skillValue;
        }
    }
    class Yasuo : Character
    {
        public Yasuo()
        {
            characterName = "야스오";
            characterHealth = 200;
            characterAttack = 10;

            skills[0].skillName = "강철 폭풍";
            skills[0].skillValue = 30;
            skills[1].skillName = "바람 장막";
            skills[1].skillValue = -10;
            skills[2].skillName = "질풍검";
            skills[2].skillValue = 15;
            skills[3].skillName = "최후의 숨결!";
            skills[3].skillValue = 50;
        }
    }
    class Yone : Character
    {
        public Yone()
        {
            characterName = "요네";
            characterHealth = 200;
            characterAttack = 10;

            skills[0].skillName = "필멸의 검";
            skills[0].skillValue = 40;
            skills[1].skillName = "영혼 가르기";
            skills[1].skillValue = 20;
            skills[2].skillName = "영혼 해방";
            skills[2].skillValue = 5;
            skills[3].skillName = "운명 봉인!";
            skills[3].skillValue = 40;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Yasuo yasuo = new Yasuo();
            Yone yone = new Yone();

            bool turn = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"이름: {yasuo.characterName} / 체력: {yasuo.characterHealth}");
                Console.WriteLine($"이름: {yone.characterName} / 체력: {yone.characterHealth}");

                if (yasuo.characterHealth < 0)
                {
                    Console.WriteLine($"{yone.characterName}의 승리!");
                    break;
                }
                if (yone.characterHealth < 0)
                {
                    Console.WriteLine($"{yasuo.characterName}의 승리!");
                    break;
                }
                Console.WriteLine();
                Random random = new Random();
                int temp;
                Character character1;
                Character character2;
                if (turn)
                {
                    temp = random.Next(0, 3);
                    Console.Write(yasuo.characterName + ", ");
                    switch (temp)
                    {
                        case 0:
                            character1 = yone; // 형변환
                            yasuo.skills[0].UseSkill(ref character1);
                            break;
                        case 1:
                            character1 = yasuo; // 형변환
                            yasuo.skills[1].UseSkill(ref character1);
                            break;
                        case 2:
                            character1 = yone; // 형변환
                            yasuo.skills[2].UseSkill(ref character1);
                            break;
                        case 3:
                            character1 = yone; // 형변환
                            yasuo.skills[3].UseSkill(ref character1);
                            break;
                    }
                    turn = false;
                }
                else
                {
                    temp = random.Next(0, 3);
                    Console.Write(yone.characterName + ", ");
                    switch (temp)
                    {
                        case 0:
                            character1 = yasuo; // 형변환
                            yone.skills[0].UseSkill(ref character1);
                            break;
                        case 1:
                            character1 = yasuo; // 형변환
                            character2 = yone; // 형변환
                            yone.skills[1].UseSkill(ref character1, ref character2);
                            break;
                        case 2:
                            character1 = yasuo; // 형변환
                            yone.skills[2].UseSkill(ref character1);
                            break;
                        case 3:
                            character1 = yasuo; // 형변환
                            yone.skills[3].UseSkill(ref character1);
                            break;
                    }
                    turn = true;
                }


                Thread.Sleep(2000);




        
            }
        }
    }
}
