using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul.src
{
     class Console
    {

        public Console()
        {

        }
        public void changeConsoleColor(string color)
        {
            if (color == "blue")
            {
                System.Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (color == "red")
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "white")
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color == "cyan")
            {
                System.Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (color == "green")
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public void nextline()
        {
            System.Console.WriteLine();
        }
        public void WriteDouble(string text, string text2, string color, string color2, string methode)
        {
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "-")
            {
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            changeConsoleColor(color);
            System.Console.Write(text);
            changeConsoleColor(color2);
            System.Console.Write(text2);
            changeConsoleColor("red");
            System.Console.WriteLine();
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "_")
            {
                System.Console.WriteLine();
            }
        }
        public void WriteTriple(string text, string text2, string text3, string color, string color2, string color3, string methode)
        {
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "-")
            {
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            changeConsoleColor(color);
            System.Console.Write(text);
            changeConsoleColor(color2);
            System.Console.Write(text2);
            changeConsoleColor(color3);
            System.Console.Write(text3);
            changeConsoleColor("red");
            System.Console.WriteLine();
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "_")
            {
                System.Console.WriteLine();
            }
        }
        public void Writeline(string text, string color, string methode)
        {
            if (methode == "=")
            {
                System.Console.WriteLine();
            } else if (methode == "-")
            {
                System.Console.WriteLine();
            }
            changeConsoleColor(color);
            System.Console.WriteLine(text);
            changeConsoleColor("red");
            if (methode == "=")
            {
                System.Console.WriteLine();
            } else if (methode == "_")
            {
                System.Console.WriteLine();
            }
        }
        public void WriteCharacter(string type, string color, string methode)
        {
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "-")
            {
                System.Console.WriteLine();
            }
            changeConsoleColor(color);
            if (type == "fullLine")
            {
                System.Console.WriteLine("______________________________________________________________________________________________");
            }
            else if (type == "logo")
            {
                System.Console.WriteLine("                             _____           _ ");
                System.Console.WriteLine("                            |__  /   _ _   _| |");
                System.Console.WriteLine("                              / / | | | | | | |");
                System.Console.WriteLine("                             / /| |_| | |_| | |");
                System.Console.WriteLine("                            /____\\__,_|\\__,_|_|");
            }
            else if (type == "halfLine")
            {
                System.Console.WriteLine("___________________________________________");
            }
            else if (type == "lose")
            {
                System.Console.WriteLine("__   __               _                     _  ");
                System.Console.WriteLine("\\ \\ / /__  _   _     | |    ___  ___  ___  | | ");
                System.Console.WriteLine(" \\ V / _ \\| | | |    | |   / _ \\/ __|/ _ \\ | | ");
                System.Console.WriteLine("  | | (_) | |_| |    | |__| (_) \\__ \\  __/ |_| ");
                System.Console.WriteLine("  |_|\\___/ \\__,_|    |_____\\___/|___/\\___| (_) ");
            }
            else if (type == "endboss")
            {
                System.Console.WriteLine("");
                System.Console.WriteLine(" _____           _   ____                ");
                System.Console.WriteLine("| ____|_ __   __| | | __ )  ___  ___ ___ ");
                System.Console.WriteLine("|  _| | '_ \\ / _` | |  _ \\ / _ \\/ __/ __|");
                System.Console.WriteLine("| |___| | | | (_| | | |_) | (_) \\__ \\__ \\");
                System.Console.WriteLine("|_____|_| |_|\\__,_| |____/ \\___/|___/___/");
                System.Console.WriteLine("");
            }
            else if (type == "endFight")
            {

                WriteCharacter("fullLine", "blue", "=");
                System.Console.WriteLine(" ____                     _   _   _             _    ");
                System.Console.WriteLine("| __ )  ___  ___ ___     / \\ | |_| |_ __ _  ___| | __");
                System.Console.WriteLine("|  _ \\ / _ \\/ __/ __|   / _ \\| __| __/ _` |/ __| |/ /");
                System.Console.WriteLine("| |_) | (_) \\__ \\__ \\  / ___ \\ |_| || (_| | (__|   < ");
                System.Console.WriteLine("|____/ \\___/|___/___/ /_/   \\_\\__|\\__\\__,_|\\___|_|\\_\\");
                WriteCharacter("fullLine", "blue", "=");
            } else if (type == "finished")
            {
                System.Console.WriteLine("__   __                                _ ");
                System.Console.WriteLine("\\ \\ / /__  _   _  __      _____  _ __ | |");
                System.Console.WriteLine(" \\ V / _ \\| | | | \\ \\ /\\ / / _ \\| '_ \\| |");
                System.Console.WriteLine("  | | (_) | |_| |  \\ V  V / (_) | | | |_|");
                System.Console.WriteLine("  |_|\\___/ \\__,_|   \\_/\\_/ \\___/|_| |_(_)");
            }
            changeConsoleColor("red");
            if (methode == "=")
            {
                System.Console.WriteLine();
            }
            else if (methode == "_")
            {
                System.Console.WriteLine();
            }
        }
        public void await()
        {
            System.Console.ReadLine();
        }
    }
}
