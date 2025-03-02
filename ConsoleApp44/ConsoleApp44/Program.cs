using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ConsoleApp44
{
    class Program
    {
        const int MAX_ITEMS = 10;

        public struct Item
        {
            public string itemName;
            public int amount;

            public void DeleteAmount(int del)
            {
                amount -= del;
            }
            public void AddAmount(int add)
            {
                amount += add;
            }
            public void SetItem(string name)
            {
                itemName = name;
            }
            public void ResetItem()
            {
                itemName = null;
                amount = 0;
            }
        }

        public struct Inventory
        {
            Item[] items;

            public void InitInventory(int size)
            {
                items = new Item[size];
            }
            public void AddItem(Item adding)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if(items[i].itemName == adding.itemName)
                    {
                        Console.WriteLine("기존 보유 아이템 획득!");
                        items[i].AddAmount(adding.amount);
                        return;
                    }
                }
                for(int i = 0; i < items.Length; i++)
                {
                    if (items[i].itemName == null)
                    {
                        Console.WriteLine("신규 아이템 획득!");
                        items[i].SetItem(adding.itemName);
                        items[i].AddAmount(adding.amount);
                        return;
                    }
                }
                Console.WriteLine("인벤토리가 가득 찼습니다. ");
                }

            public void RemoveItem(Item removing)
            {
                for(int i = 0; i < items.Length; i++)
                {
                    if (items[i].itemName == removing.itemName)
                    {
                        if(items[i].amount >= removing.amount)
                        {
                            items[i].DeleteAmount(removing.amount);
                            if(items[i].amount == 0)
                            {
                                items[i].ResetItem();
                            }
                            return;
                        }
                        else
                        {
                            Console.WriteLine("아이템 갯수 부족");
                        }
                    }
                }
                Console.WriteLine("해당 아이템은 인벤토리에 없습니다 다시 확인해 주세요.");
            }
            public void ShowInventory()
            {
                bool isEmpty = true;
                Console.WriteLine("현재 인벤토리");
                Console.WriteLine("-------------");
                foreach (Item item in items)
                {
                    if(item.itemName != null)
                    {                        
                        Console.WriteLine($"아이템 명: {item.itemName} x {item.amount}");
                        isEmpty = false;
                    }
                }                
                if (isEmpty)
                {
                    Console.WriteLine("인벤토리가 비어있습니다.");
                }
                Console.WriteLine("-------------");
            }
        }

        static void Main(string[] args)
        {
            Inventory myInventory = new Inventory();
            myInventory.InitInventory(MAX_ITEMS);
            myInventory.ShowInventory();

            Item item1 = new Item { itemName = "포션", amount = 3, };
            Item item2 = new Item { itemName = "칼", amount = 1, };
            Item item3 = new Item { itemName = "독 포션", amount = 2, };
            Item item4 = new Item { itemName = "포션", amount = 7, };


            myInventory.AddItem(item1);
            myInventory.ShowInventory();

            myInventory.AddItem(item2);
            myInventory.AddItem(item3);
            myInventory.AddItem(item4);
            myInventory.ShowInventory();

            myInventory.RemoveItem(new Item() { itemName = "포션", amount = 2, });
            myInventory.ShowInventory();






        }
    }
}
