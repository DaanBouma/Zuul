using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zuul.src
{

    public class Inventory

    {
        public List<string> items;
        public int weight {  get; set; } = 0;
        public int maxWeight { get; } = 20;
        public int energy = 100;
        public int health = 100;

        public bool hasConfirmed = false;
        public bool hasUnlockBasement = false;
        public bool hasUnlockOffice = false;
        public Inventory()
        {
            items = new List<string>();
        }

        public void removeHealth(int amount)
        {
            health -= amount;

        }
        public void removeEnergy(int amount)
        {
             energy -= amount;
        }
        public bool CheckWeight(string item)
        {
            int itemWeight = getItemWeight(item);
            if ((itemWeight + weight) < maxWeight)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public int getItemWeight(string item)
        {
            if (item == "healthpotion")
            {
                return 1;
            } else if (item == "officekey")
            {
                return 1;
            } else if (item == "basementkey")
            {
                return 1;
            } else if (item == "apple")
            {
                return 2;
            } else if (item == "banana")
            {
                return 2;
            } else if (item == "sword")
            {
                return 5;
            } else if (item == "katana")
            {
                return 6;
            } else if (item == "longsword")
            {
                return 15;
            } else if (item == "spear")
            {
                return 2;
            } else if (item == "energypil")
            {
                return 4;
            }
            return 999;
        }
        public void AddItem(string item)
        {
            AddWeight(item);
            items.Add(item);
        }
        public void AddWeight(string item)
        {
            int itemWeight = getItemWeight(item);
            weight += itemWeight;
        }
        public void RemoveWeight(string item)
        {
            int itemWeight = getItemWeight(item);
            weight -= itemWeight;

        }
        
        public void RemoveItem(string item)
        {
            RemoveWeight(item);
            items.Remove(item);
        }

        public bool HasItem(string item)
        {
            return items.Contains(item);
        }
        public void ShowItems()
        {
            if (items.Count == 0)
            {
                System.Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                System.Console.WriteLine("Your inventory contains:");
                foreach (string item in items)
                {
                    System.Console.WriteLine("- " + item);
                }
            }
        }






        public string inventoryDescription()
        {
            string str = "";
            str += GetItemString();
            return str;
        }
        private string GetItemString()
        {
            string str = "";
            if (items.Count == 0)
            {
                str = "";
                return str;
            }


            int countCommas = 0;

            foreach (string item in items)
            {
                if (countCommas != 0)
                {
                    str += ",";
                }
                str += " " + item;
                countCommas++;
            }
            return str;
        }

    }


}
