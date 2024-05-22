using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zuul.src
{
    class Printer
    {
        private Parser parser;

        public Printer()
        {

            parser = new Parser();
        }
        public void notConfirmed()
        {
            System.Console.WriteLine();
            switchColor("blue");
            switchColor("white");
            System.Console.WriteLine("After this point you cant go back. Do you want to proceed?");
            System.Console.Write("Write");
            switchColor("red");
            System.Console.Write(" 'go room' ");
            System.Console.WriteLine();
            System.Console.WriteLine();
            switchColor("red");
        }
        public void notUnlocked()
        {
            System.Console.WriteLine();
            switchColor("blue");
            System.Console.WriteLine("it seems like it is locked. Maybe there is a key...");
            System.Console.WriteLine();
            switchColor("red");
        }
        public void battle()
        {
             System.Console.WriteLine();
             System.Console.WriteLine();
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            System.Console.WriteLine();
            consoleStyle("endboss");
            System.Console.WriteLine();
            consoleStyle("fullLine");
            System.Console.WriteLine();
            switchColor("white");
            System.Console.Write("You walk into the room. In horror you see ");
            switchColor("red");
            System.Console.Write("Micha");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            switchColor("white");
            System.Console.Write("you wil begin with the attack. You will get 2 chances of commands. You can use the ");
            switchColor("red");
            System.Console.Write("'use'");
            switchColor("white");
            System.Console.Write(" and ");
            switchColor("red");
            System.Console.Write("'attack'");
            switchColor("white");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("after your 2 commands the boss will atack ones. It is a random attack with a random effect.");
            System.Console.WriteLine();
            switchColor("red");
            System.Console.WriteLine("WE FIGHT TILL SOMEONE DIES....");
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            System.Console.WriteLine();
            switchColor("red");
        }
        public void lose(string deathReason)
        {
            switchColor("blue");
            consoleStyle("fullLine");
            System.Console.WriteLine();
            consoleStyle("lose");
            System.Console.WriteLine();
            consoleStyle("fullLine");
            switchColor("white");

            if (deathReason == "energy")
            {
                System.Console.WriteLine();
                switchColor("white");
                System.Console.Write("You couldnt go further because you didnt have enough");
                switchColor("blue");
                System.Console.Write(" Energy");
                switchColor("white");
                System.Console.Write("!");
                switchColor("white");
                System.Console.WriteLine();
                System.Console.WriteLine();
            }

            System.Console.WriteLine();
            switchColor("white");
            System.Console.WriteLine("Thank you for playing.");
            System.Console.Write("Press");
            switchColor("blue");
            System.Console.Write(" [Enter] ");
            switchColor("white");
            System.Console.Write("to continue.");
            System.Console.WriteLine("");
            switchColor("red");
            
        }
        public void WelcomeMessage()
        {
            switchColor("blue");
            System.Console.WriteLine();
            consoleStyle("logo");
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            System.Console.WriteLine();
            switchColor("white");
            System.Console.WriteLine("Welcome to the most boring game ever!");
            System.Console.WriteLine("Use Commands such as 'Go' and 'Use' to do certain things in the game.");
            System.Console.WriteLine("Move Rooms, Pickup Items but most of all. Escape the School by fighting its villain!");
            System.Console.Write("See the Commands by typing ");
            switchColor("blue");
            System.Console.Write("'help'");
            switchColor("white");
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            System.Console.WriteLine();
            switchColor("red");
        }
        public void FirstDirection()
        {
            switchColor("white");
            System.Console.Write("You are In the");
            switchColor("blue");
            System.Console.Write(" Detention Room ");
            switchColor("white");
            System.Console.WriteLine();
            System.Console.WriteLine("The Teacher said she would come back but it is already 7PM. Maybe it is time to go home.");
            System.Console.WriteLine();
            switchColor("blue");
        }
        public void ThanksForPlaying()
        {
            switchColor("blue");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            consoleStyle("fullLine");
            System.Console.WriteLine("");
            switchColor("white");
            System.Console.WriteLine("Thank you for playing.");
            System.Console.Write("Press");
            switchColor("blue");
            System.Console.Write(" [Enter] ");
            switchColor("white");
            System.Console.Write("to continue.");
            System.Console.WriteLine("");
            switchColor("blue");
            System.Console.WriteLine("");
            consoleStyle("fullLine");
        }
        public void IDontKnowWhatYouMean()
        {
            switchColor("blue");
            System.Console.WriteLine("");
            System.Console.WriteLine("I Don't Know what you mean!");
            System.Console.WriteLine("");
            switchColor("red");
        }
        public void HelpInformation()
        {
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            switchColor("white");
            System.Console.WriteLine();
            System.Console.WriteLine("You are lost. You are alone.                ");
            System.Console.WriteLine("You wander around at the university.        ");
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            switchColor("white");
            parser.PrintValidCommands();
            System.Console.WriteLine();
            switchColor("blue");
            consoleStyle("fullLine");
            switchColor("red");
            System.Console.WriteLine();
        }
        public void gowhere()
        {
            switchColor("blue");
            System.Console.WriteLine();
            System.Console.WriteLine("Go where?");
            switchColor("red");
            System.Console.WriteLine();
        }
        public void switchColor(string color)
        {
            if (color == "blue")
            {
                System.Console.ForegroundColor = ConsoleColor.Blue;
            } else if (color == "red")
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
            } else if (color == "white")
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            } else if (color == "cyan")
            {
                System.Console.ForegroundColor = ConsoleColor.Cyan;
            } else if (color == "green")
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public void consoleStyle(string type)
        {
            if (type == "fullLine")
            {
                System.Console.WriteLine("______________________________________________________________________________________________");
            } else if (type == "logo")
            {
                System.Console.WriteLine("                             _____           _ ");
                System.Console.WriteLine("                            |__  /   _ _   _| |");
                System.Console.WriteLine("                              / / | | | | | | |");
                System.Console.WriteLine("                             / /| |_| | |_| | |");
                System.Console.WriteLine("                            /____\\__,_|\\__,_|_|");
            } else if (type == "halfLine")
            {
                System.Console.WriteLine("___________________________________________");
            } else if (type == "lose")
            {
                System.Console.WriteLine("__   __               _                     _  ");
                System.Console.WriteLine("\\ \\ / /__  _   _     | |    ___  ___  ___  | | ");
                System.Console.WriteLine(" \\ V / _ \\| | | |    | |   / _ \\/ __|/ _ \\ | | ");
                System.Console.WriteLine("  | | (_) | |_| |    | |__| (_) \\__ \\  __/ |_| ");
                System.Console.WriteLine("  |_|\\___/ \\__,_|    |_____\\___/|___/\\___| (_) ");
            } else if (type == "endboss")
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(" _____           _   ____                ");
                System.Console.WriteLine("| ____|_ __   __| | | __ )  ___  ___ ___ ");
                System.Console.WriteLine("|  _| | '_ \\ / _` | |  _ \\ / _ \\/ __/ __|");
                System.Console.WriteLine("| |___| | | | (_| | | |_) | (_) \\__ \\__ \\");
                System.Console.WriteLine("|_____|_| |_|\\__,_| |____/ \\___/|___/___/");
                System.Console.WriteLine("");
            } else if (type == "endFight")
            {
                System.Console.WriteLine(" ____                     _   _   _             _    ");
                System.Console.WriteLine("| __ )  ___  ___ ___     / \\ | |_| |_ __ _  ___| | __");
                System.Console.WriteLine("|  _ \\ / _ \\/ __/ __|   / _ \\| __| __/ _` |/ __| |/ /");
                System.Console.WriteLine("| |_) | (_) \\__ \\__ \\  / ___ \\ |_| || (_| | (__|   < ");
                System.Console.WriteLine("|____/ \\___/|___/___/ /_/   \\_\\__|\\__\\__,_|\\___|_|\\_\\");
            }
        }
    }
}
