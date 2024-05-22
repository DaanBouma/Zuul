using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul.src
{
    class Bossbattle
    {
        Random random;
        Printer printer;
        public Bossbattle()
        {
            random = new Random();
            printer = new Printer();
        }

        public bool hasStarted = false;
        public int attacks = 0;
        public int health = 10;

        public string getHealth()
        {
            string myString = health.ToString();
            return myString;
        }
        public void removeHealth(int amount)
        {
            health -= amount;
        }
    }
}
