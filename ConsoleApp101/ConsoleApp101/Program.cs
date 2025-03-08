using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp101
{
    class MainGame
    {
        UIManager ui;
        InputManager inputManager;
        Character myCharacter;
        Monster currentMonster;

        string scene;

        public void Initialize()
        {
            ui = new UIManager();
            inputManager = new InputManager();
            scene = "start";
        }

        public void Play()
        {
            while (true)
            {
                switch (scene)
                {
                    case "start":
                        ui.Clear();
                        SelectClass();
                        break;
                    case "main":
                        ui.Clear();
                        ui.DrawCurrentPlayer(myCharacter);
                        SelectMain();
                        break;
                    case "field":
                        ui.Clear();
                        SelectDifficulty();
                        break;
                    case "fight":
                        ui.Clear();
                        ui.DrawCurrentMonster(currentMonster);
                        ui.DrawCurrentPlayer(myCharacter);
                        SelectFightAction();
                        inputManager.GetEmptyInput();
                        break;
                    case "exit":
                        goto Exit;
                }
            }
        Exit:;
        }

        public void SelectClass()
        {
            Console.WriteLine("직업을 골라주세요.");
            int input = inputManager.GetIntInput("1.전사 / 2.마법사 / 3.도적", 1, 3);
            Console.WriteLine("========================================"); // 40
            switch (input)
            {
                case 1:
                    myCharacter = new Warrior();
                    scene = "main";
                    break;
                case 2:
                    myCharacter = new Wizard();
                    scene = "main";
                    break;
                case 3:
                    myCharacter = new Theif();
                    scene = "main";
                    break;
            }
        }


        public void SelectMain()
        {
            int input = 0;
            Console.WriteLine("어디로 갈까?");
            input = inputManager.GetIntInput("1. 사냥터 2. 종료", 1, 2);
            Console.WriteLine("========================================"); // 40
            switch (input)
            {
                case 1:
                    scene = "field";
                    break;
                case 2:
                    scene = "exit";
                    break;
            }
        }

        public void SelectDifficulty()
        {
            int input = 0;
            Console.WriteLine("난이도를 선택해주세요");
            input = inputManager.GetIntInput("1.쉬움 | 2.보통 | 3.어려움 | 4.돌아가기", 1, 4);
            Console.WriteLine("========================================"); // 40
            switch (input)
            {
                case 1:
                    scene = "fight";
                    currentMonster = new Monster(1);
                    break;
                case 2:
                    scene = "fight";
                    currentMonster = new Monster(2);
                    break;
                case 3:
                    scene = "fight";
                    currentMonster = new Monster(3);
                    break;
                case 4:
                    scene = "main";
                    break;
            }
        }

        public void SelectFightAction()
        {
            Console.WriteLine("행동을 선택해주세요");
            int input = inputManager.GetIntInput("1.기본 공격 | 2.특수 공격 | 3.도망가기", 1, 3);
            Console.WriteLine("========================================"); // 40
            switch (input)
            {
                case 1:
                    myCharacter.NormalAttack(currentMonster);
                    break;
                case 2:
                    myCharacter.SpecialAttack(currentMonster);
                    break;
                case 3:
                    scene = "field";
                    break;
            }
        }

    }


    class UIManager
    {
        public void Clear()
        {
            Console.Clear();
            Console.WriteLine("========================================"); // 40
        }
        public void DrawStart()
        {
            Console.WriteLine("starting");
        }

        public void DrawField()
        {

        }

        internal void DrawCurrentPlayer(Character myCharacter)
        {
            Console.WriteLine($"직업:{myCharacter.name} | 체력:{myCharacter.hp}/{myCharacter.maxHp} | 공격력:{myCharacter.attack}");
            Console.WriteLine("========================================"); // 40
        }

        internal void DrawCurrentMonster(Monster currentMonster)
        {
            Console.WriteLine($"몬스터 이름:{currentMonster.name} | 체력:{currentMonster.hp}/{currentMonster.maxHp} | 공격력:{currentMonster.attack}");
            Console.WriteLine("========================================"); // 40
        }
    }

    class InputManager
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        string input = "";
        public void GetEmptyInput()
        {
            Console.ReadLine();
        }
        public int GetIntInput(string words, int start, int end)
        {
        REQ:
            Console.WriteLine(words);
            Console.Write($"입력해 주세요({start} ~ {end}): ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int intInput))
            {
                if (intInput > end || intInput < start)
                {
                    Console.WriteLine("잘못된 번호입니다. 다시 입력해 주세요.");
                    goto REQ;
                }
                else
                {
                    return intInput;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요.");
                goto REQ;
            }
        }
    }

    interface IUnit
    {
        string name { get; set; }
        int attack { get; set; }
        int maxHp { get; set; }
        int hp { get; set; }

        void GetDamage(int damage);
    }

    interface Character : IUnit
    {
        void NormalAttack(IUnit target);
        void SpecialAttack(IUnit target);
    }

    class Warrior : Character
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int maxHp { get; set; }
        public int hp { get; set; }


        public Warrior()
        {
            name = "전사";
            attack = 100;
            maxHp = 100;
            hp = 100;
        }

        public void GetDamage(int damage)
        {
            this.hp -= damage;
            Console.WriteLine($"{this.name}이(가) {damage}의 피해를 입었습니다. 남은 체력{this.hp} ");
        }

        public void NormalAttack(IUnit target)
        {
            target.hp -= attack;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 무기를 휘둘렀습니다. {attack}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }

        public void SpecialAttack(IUnit target)
        {
            target.hp -= attack * 2;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 달려들어 강한 타격을 했습니다!" +
                $" {attack * 2}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }
    }
    class Wizard : Character
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int maxHp { get; set; }
        public int hp { get; set; }


        public Wizard()
        {
            name = "마법사";
            attack = 120;
            maxHp = 80;
            hp = 80;
        }

        public void GetDamage(int damage)
        {
            this.hp -= damage;
            Console.WriteLine($"{this.name}이(가) {damage}의 피해를 입었습니다. 남은 체력{this.hp} ");
        }

        public void NormalAttack(IUnit target)
        {
            target.hp -= attack;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 파이어볼을 사용했습니다." +
                $" {attack}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }

        public void SpecialAttack(IUnit target)
        {
            target.hp -= attack * 2;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 메테오를 시전했습니다!" +
                $" {attack * 2}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }
    }
    class Theif : Character
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int maxHp { get; set; }
        public int hp { get; set; }


        public Theif()
        {
            name = "도적";
            attack = 110;
            maxHp = 90;
            hp = 90;
        }

        public void GetDamage(int damage)
        {
            this.hp -= damage;
            Console.WriteLine($"{this.name}이(가) {damage}의 피해를 입었습니다. 남은 체력{this.hp} ");
        }

        public void NormalAttack(IUnit target)
        {
            target.hp -= attack;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 단검을 던졌습니다." +
                $" {attack}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }

        public void SpecialAttack(IUnit target)
        {
            target.hp -= attack * 2;
            Console.WriteLine($"{this.name}이(가) {target.name}에게 몰래 접근해 기습했습니다!" +
                $" {attack * 2}의 피해를 입혔습니다. {target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }
    }

    class Monster : IUnit
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int maxHp { get; set; }
        public int hp { get; set; }

        public Monster(int diff)
        {
            switch (diff)
            {
                case 1:
                    name = "하급 몬스터";
                    attack = 10;
                    maxHp = 200;
                    hp = 200;
                    break;
                case 2:
                    name = "중급 몬스터";
                    attack = 20;
                    maxHp = 500;
                    hp = 500;
                    break;
                case 3:
                    name = "상급 몬스터";
                    attack = 30;
                    maxHp = 1000;
                    hp = 1000;
                    break;
            }
        }
        public void GetDamage(int damage)
        {
            this.hp -= damage;
            Console.WriteLine($"{this.name}이(가) {damage}의 피해를 입었습니다. 남은 체력{this.hp} ");
        }

        public void MonsterAttack(IUnit target)
        {            
            Console.WriteLine($"{this.name}이(가) {target.name}에게 돌진했습니다!" +
                $" {attack}의 피해를 입혔습니다.");
            target.GetDamage(attack);
            Console.WriteLine($"{target.name}의 남은 체력: {target.hp} / {target.maxHp} ");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MainGame gm = new MainGame();

            gm.Initialize();
            gm.Play();
        }
    }
}
