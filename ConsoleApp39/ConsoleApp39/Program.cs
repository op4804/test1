using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    class Program
    {
        enum Weapontype
        {
            Sword,
            Bow,
            Staff,
        }

        static void ChooseWeapon(Weapontype weapon)
        {
            // Console.WriteLine($"{weapon}을 선택했습니다.");
            if(weapon == Weapontype.Sword)
            {
                Console.WriteLine("검을 선택했습니다.");

            }
            else if(weapon == Weapontype.Bow)
            {
                Console.WriteLine("활을 선택했습니다.");

            }
            else if(weapon == Weapontype.Staff)
            {
                Console.WriteLine("지팡이를 선택했습니다.");

            }

            else
            {
                Console.WriteLine("잘못된 무기입니다.");
            }
        }
        static void Main(string[] args)
        {

            //문제
            //열거형과 함수를 이용해서 풀어주세요.

            //Weapontype.Sword   검을 선택했습니다.
            //Weapontype.Bow    활을 선택했습니다.
            //Weapontype.Staff  지팡이를 선택했습니다.


            Weapontype myWeapon = Weapontype.Sword;

            ChooseWeapon(Weapontype.Bow);
            ChooseWeapon(myWeapon);


        }
    }
}
