    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Zuul.src;


    class Game
    {
        private Inventory playerInventory;
        private Bossbattle bossbattle;
        private Parser parser;
        private Room currentRoom;
        private Inventory inventory;
        private List<string> chests;
        private Random random;
        private Zuul.src.Console console;

        public Game()
        {
            console = new Zuul.src.Console();
            chests = new List<string>();
            bossbattle = new Bossbattle();
            playerInventory = new Inventory();
            parser = new Parser();
            inventory = new Inventory();
            random = new Random();
            CreateRooms();
        }
    public bool quiting = false;
        public bool finished = false;
    public bool wantToQuit = false;
    private void CreateRooms()
        {
            Room outside = new Room("outside the main entrance of the university");


            // Basement ( Room creation )

            Room BasementEntry = new Room("in a room with just one single door...");
            Room Basement = new Room("");

            // First Floor ( Room Creation)

            Room hallwayFF = new Room("main hallway on the first floor");
            Room Detention = new Room("at the Detention Room, This is not the right place to be. Go home!");
            Room Lab = new Room("at the Lab, There is alot of enquipment here. Maybe I can make something?");
            Room Office = new Room("at the Office. There should be some information here!");
            Room Outside = new Room("outside the horrible school!");

            // Second Floor (Room creation)

            Room hallwaySF = new Room("main hallway on the second floor");
            Room cleaningRoom = new Room("cleaning closet, it is very sticky here!");
            Room mathRoom = new Room("math room with only math stuff...");


            // First Floor (Exits)
            hallwayFF.AddExit("detention", Detention);
            hallwayFF.AddExit("lab", Lab);
            hallwayFF.AddExit("office", Office);
            hallwayFF.AddExit("exit", outside);
            hallwayFF.AddExit("upstairs", hallwaySF);
            hallwayFF.AddExit("downstairs", BasementEntry);

            Detention.AddExit("hallway", hallwayFF);
        Detention.AddObject("chest");

        Lab.AddExit("office", Office);
            Lab.AddExit("hallway", hallwayFF);
            Lab.AddItem("healthpotion");
            Lab.AddObject("chest");

            Office.AddExit("lab", Lab);
            Office.AddExit("hallway", hallwayFF);
            Office.AddItem("basementkey");

            // Second floor (exits)

            hallwaySF.AddExit("downstairs", hallwayFF);
            hallwaySF.AddExit("cleaningcloset", cleaningRoom);
            hallwaySF.AddExit("mathroom", mathRoom);

            cleaningRoom.AddExit("hallway", hallwaySF);

            cleaningRoom.AddItem("officekey");


            mathRoom.AddExit("hallway", hallwaySF);
            mathRoom.AddObject("chest");


            // Basement (exits)

            BasementEntry.AddExit("upstairs", hallwayFF);
            BasementEntry.AddExit("room", Basement);
            BasementEntry.AddObject("chest");
            currentRoom = Detention;


            // Chest Content

        chests.Add("banana");
        chests.Add("apple");
        chests.Add("energypil");
        chests.Add("sword");
        chests.Add("katana");
        chests.Add("longsword");
       chests.Add("spear");
    }


    public void count()
    {
        bossbattle.attacks++;
        if (bossbattle.attacks == 2 && bossbattle.hasStarted == true)
        {
            bossAttack();
            bossbattle.attacks = 0;
        }
    }



public void Play()

        {
        PrintWelcome();
        while (!finished)
        {
            Command command = parser.GetCommand();
            finished = ProcessCommand(command);

            if (finished == true)
           {
                break;
            }
        }

        ThanksForPlaying();
        console.await();
    }

        private void PrintWelcome()
        {
        console.WriteCharacter("logo", "blue", "=");
        console.WriteCharacter("fullLine", "blue", "_");
        console.Writeline("Welcome to the most boring game ever!", "white", "");
        console.Writeline("Use Commands such as 'Go' and 'Use' to do certain things in the game.", "white", "");
        console.Writeline("Move Rooms, Pickup Items but most of all. Escape the School by fighting its villain!", "white", "");
        console.WriteDouble("See the Commands by typing ", "'help'", "white", "blue", "");
        console.WriteCharacter("fullLine", "blue", "=");
        console.WriteDouble("You are In the", " Detention Room ", "white", "blue", "");
        console.Writeline("The Teacher said she would come back but it is already 7PM. Maybe it is time to go home.", "white", "");
        console.Writeline(currentRoom.GetLongDescription3(), "blue", "=");
        }

        private bool ProcessCommand(Command command)
        {


            if (command.IsUnknown())
            {

                IDontKnowWhatYouMean();
                return wantToQuit;
            }

            switch (command.CommandWord)
            {
                case "help":
                    PrintHelp();
                    break;
                case "go":
                    GoRoom(command);
                    break;
                case "quit":
                    wantToQuit = true;
                    break;
                case "status":
                    showStatus();
                    break;
                case "take":
                    TakeItem(command);
                    break;
                case "look":
                    roominformation();
                    break;
                case "search":
                    searchRoom();
                    break;
                case "drop":
                    DropItem(command);
                    break;
                case "use":
                    use(command);
                    break;
                case "open":
                    open(command);
                    break;
                case "attack":
                attack(command);
                    break;
                 case "stats":
                weaponstats(command);
                break;
            case "weight":
                console.WriteDouble("playerinventory: ", playerInventory.weight.ToString(), "white", "red", "-");
                console.WriteDouble("inventory: ", inventory.weight.ToString(), "white", "red", "_");
                break;


        }
        bool shouldstop = stopGameCheck();
        wantToQuit = shouldstop;
            return wantToQuit;
        }
    public bool stopGameCheck()
    {
        if (quiting == true)
        {
            return true;
        }
        return false;
    }
    public void IDontKnowWhatYouMean()
    {
        console.Writeline("I Don't know what you mean!", "blue", "=");
    }
    public void ThanksForPlaying()
    {
        console.WriteCharacter("fullLine", "blue", "=");
        console.Writeline("Thank you for playing.", "white", "");
        console.WriteTriple("Press", " [Enter] ", "to continue.", "white", "blue", "white", "");
        console.WriteCharacter("fullLine", "blue", "=");
    }
    private void attack(Command command)
    {
        if (!command.HasSecondWord())
        {
            console.Writeline("attack with what?", "blue", "=");
            return;
        }
        string itemName = command.SecondWord;
        if (playerInventory.items.Contains(itemName) == true)
        {
            if (itemName == "sword")
            {
                bossbattle.removeHealth(amount: 20);
                console.Writeline("You used a sword and attack the boss... ", "blue", "-");
                console.Writeline("He has lost 20 health.", "blue", "");
                console.WriteDouble("Remaining health: ", bossbattle.getHealth(), "blue", "white", "_");
                count();
                if (bossbattle.health <= 0)
                {
                    victory();
                }
            } else if (itemName == "katana")
            {
                bossbattle.removeHealth(amount: 35);
                console.Writeline("You used a katana and attack the boss... ", "blue", "-");
                console.Writeline("He has lost 35 health.", "blue", "");
                console.WriteDouble("Remaining health: ", bossbattle.getHealth(), "blue", "white", "_");
                count();
                if (bossbattle.health <= 0)
                {
                    victory();
                }
            } else if (itemName == "longsword"){
                bossbattle.removeHealth(amount: 80);
                console.Writeline("You used a longsword and attack the boss... ", "blue", "-");
                console.Writeline("He has lost 80 health.", "blue", "");
                console.WriteDouble("Remaining health: ", bossbattle.getHealth(), "blue", "white", "_");
                count();
                if (bossbattle.health <= 0)
                {
                    victory();
                }
            } else if (itemName == "spear")
            {
                bossbattle.removeHealth(amount: 20);
                console.Writeline("You used a spear and attack the boss... ", "blue", "-");
                console.Writeline("He has lost 20 health.", "blue", "");
                console.WriteDouble("Remaining health: ", bossbattle.getHealth(), "blue", "white", "_");
                count();
                if (bossbattle.health <= 0)
                {
                    victory();
                }
            }

        } else
        {
            console.Writeline("didnt attack...", "blue", "=");
        }
        }
    private void weaponstats(Command command)
    {
        if (!command.HasSecondWord())
        {
            console.Writeline("show what?", "blue", "=");
            return;
        }
        string itemName = command.SecondWord;
        int itemDamage = showAttackDamage(itemName);
        if (playerInventory.items.Contains(itemName) == true)
        {
            console.WriteCharacter("halfLine", "blue", "=");
            console.Writeline("this is a special item. Used to attack...", "white", "");
            console.WriteTriple("This weapon does ", itemDamage.ToString(), " Damage!", "white", "red", "white", "");
            console.WriteCharacter("halfLine", "blue", "=");
        } else
        {
            console.Writeline("Dont know that weapon...", "blue", "=");
        }
    }
    private int showAttackDamage(string item)
    {
        if (item == "sword")
        {
            return 20;
        } else if (item == "katana")
        {
            return 35;
        } else if (item == "longsword")
        {
            return 80;
        } else if (item == "spear")
        {
            return 20;
        }
        return 0;
    } 
    private void use(Command command)
    {
        if (!command.HasSecondWord())
        {
            console.Writeline("use what?", "blue", "=");
            return;
        }
        string itemName = command.SecondWord;
        if (playerInventory.items.Contains(itemName) == true)
        {
            

            if (itemName == "healthpotion")
            {
                if ((playerInventory.health + 20) <= 100)
                {
                    console.Writeline("You used a Healthpotion. You gain 20 Health.", "green", "_");
                    playerInventory.health += 20;
                    playerInventory.RemoveItem(itemName);
                    count();
                }
                else
                {
                    console.Writeline("You have to much health to use a healthpotion...", "blue", "=");
                }
            }
            else if (itemName == "officekey")
            {
                console.Writeline("You have unlocked the office!", "green", "=");
                inventory.hasUnlockOffice = true;
                playerInventory.RemoveItem(itemName);
            } 
            else if (itemName == "basementkey")
            {              
                console.Writeline("You have unlocked the basement!", "green", "=");
                inventory.hasUnlockBasement = true;
                playerInventory.RemoveItem(itemName);
            }
            else if (itemName == "apple" || itemName == "banana")
            {
                if ((playerInventory.health + 10) <= 100 && (playerInventory.energy + 10) <= 100)
                {
                    console.Writeline("You gained 10 health and Energy!", "green", "=");
                    playerInventory.health += 10;
                    playerInventory.energy += 10;
                    playerInventory.RemoveItem(itemName);
                    count();
                }
                else if ((playerInventory.health + 10) < 100)
                {
                    console.Writeline("You gained 10 health. But you are already at max energy", "green", "=");
                    playerInventory.health += 10;
                    count();
                }
                else if ((playerInventory.energy + 10) < 100)
                {
                    console.Writeline("You gained 10 energy. But you are already at max health", "green", "=");
                    count();
                }
                else
                {
                    console.Writeline("You have already everything max...", "blue", "=");
                }
            } else if (itemName == "energypil")
            {
                console.Writeline("You gained 50 energy", "green", "=");
                playerInventory.energy += 50;
                if (playerInventory.energy > 100)
                {
                    playerInventory.energy = 100;
                }
            }
            {
                {
                }
            }
          
        }
        else
        {
            console.Writeline("Not used...", "blue", "=");
        }
    }

        private string randomSelection()
        {
            int index = random.Next(chests.Count);
            string randomString = chests[index];
            return randomString;
        }
        private string openChest()
        {
            return randomSelection();
        }
        private void open(Command command)
        {
            if (!command.HasSecondWord())
            {
            console.Writeline("Open what?", "blue", "=");
                return;
            }
            string itemName = command.SecondWord;
                if (itemName == "chest" && currentRoom.contains("chest"))
                {
                     console.WriteCharacter("halfLine", "blue", "=");
                     console.Writeline("You open the chest and you find: ", "white", "");
                     string randomstring = openChest();
                     console.Writeline(randomstring, "cyan", "");
                     currentRoom.AddItem(randomstring);
                     currentRoom.removeObject("chest");
                     console.WriteCharacter("halfLine", "blue", "=");
        }
                else
                {
                    console.Writeline("Dont know how to open...", "blue", "=");
                }
        }

        private void searchRoom()
	    {
        console.WriteCharacter("halfLine", "blue", "=");
        itemInformation();
        console.nextline();
        objectInformation();
        console.WriteCharacter("halfLine", "blue", "_");
    }
        private void objectInformation()
        {
            string items = currentRoom.GetLongDescription5();
            if (items == "")
            {
                console.Writeline("There are no chests :(", "white", "=");
            }
            else
            {
                console.Writeline("in the corner of the room is a: ", "white", "");
                console.Writeline(items, "cyan", "");
            }
        }

        private void itemInformation()
	    {
		    string items = currentRoom.GetLongDescription2();
		    if (items == "")
		    {
                console.Writeline("After searching for some time you gave up. There is nothing here!", "white", "=");
            } else
		    {
                console.Writeline("after searching for quite some time you found: ", "white", "");
                console.Writeline(items, "cyan", "");
        }
        }
        private void roominformation()
	    {
        console.WriteCharacter("fullLine", "blue", "=");
        console.Writeline(currentRoom.GetLongDescription(), "white", "");
        console.Writeline(currentRoom.GetExits(), "blue", "");
        console.WriteCharacter("fullLine", "blue", "=");
        }
        private void PrintHelp()
		    {
        console.WriteCharacter("fullLine", "blue", "=");
        console.Writeline("You are lost. You are alone.", "white", "");
        console.Writeline("You wander around at the university.", "white", "");
        console.WriteCharacter("fullLine", "blue", "=");
        parser.PrintValidCommands();
        console.WriteCharacter("fullLine", "blue", "=");
    }
		    private void TakeItem(Command command)
		    {
			    if (!command.HasSecondWord())
			    {
            console.Writeline("Take what?", "blue", "=");
                return;
			    }

			    string itemName = command.SecondWord;

			    if (currentRoom.HasItem(itemName))
			    {
			    if (playerInventory.CheckWeight(itemName) == true)
			    {
                    playerInventory.AddItem(itemName);
                    currentRoom.RemoveItem(itemName);
                    console.Writeline("You took the " + itemName + ".", "blue", "");
                } else
			    {
				console.Writeline("You can't carry it. it is to heavy. Maybe drop some other items!", "blue", "");
                }
            }
			    else
			    {
                console.Writeline("There is no " + itemName + " here.", "blue", "");
            }
                console.nextline();
    }

        private void DropItem(Command command)
        {
            if (!command.HasSecondWord())
            {
                console.Writeline("Drop what?", "blue", "=");
                return;
            }

            string itemName = command.SecondWord;
            if (playerInventory.items.Contains(itemName) == true)
            {
                currentRoom.AddItem(itemName);
                playerInventory.RemoveItem(itemName);
                console.Writeline("You dropped the " + itemName + ".", "blue", "");
            }

            else
            {
                console.Writeline("You dont have a " + itemName + ".", "blue", "");

            }

        console.nextline();
    }



        private void showStatus()
        {
        console.WriteCharacter("halfLine", "blue", "=");
        console.Writeline(" Status", "white", "");
        console.WriteCharacter("halfLine", "blue", "_");
            console.Writeline("Weight: " + playerInventory.weight + "kg / " + playerInventory.maxWeight + "kg", "white", "");
		    console.Writeline("Health: " + playerInventory.health + " / 100", "white", "");
		    console.Writeline("Energy: " + playerInventory.energy + "%", "white", "");
        console.changeConsoleColor("blue");
        console.WriteCharacter("halfLine", "blue", "=");
        if (playerInventory.inventoryDescription() == "")
		    {
			    console.Writeline("You don't have any items yet!", "blue", "");
		    } else
		    {
                console.Writeline("Items: " + playerInventory.inventoryDescription(), "white", "");
            }
        console.WriteCharacter("halfLine", "blue", "=");
    }


    private void playerLose(string deathReason)
    {
        console.WriteCharacter("fullLine", "blue", "=");
        console.WriteCharacter("lose", "blue", "");
        console.WriteCharacter("fullLine", "blue", "=");

        if (deathReason == "energy")
        {
            console.WriteDouble("You couldnt go further because you didnt have enough", " energy", "white", "red", "=");
        }
        else if (deathReason == "health")
        {
            console.WriteDouble("You couldnt go further because you didnt have enough", " health", "white", "red", "=");
        }
        quiting = true;
    }
    private void GoRoom(Command command)
    {
        if (!command.HasSecondWord())
        {
            console.Writeline("go Where?", "blue", "=");
            return;
        }

        string direction = command.SecondWord;

        Room nextRoom = currentRoom.GetExit(direction);

        if (nextRoom == null)
        {
            console.Writeline("There is no door to " + direction + "!", "blue", "_");
            return;
        }
        if (direction == "room" && inventory.hasUnlockBasement == false)
        {
            console.Writeline("It seems like it is looked. Maybe there is a key...", "blue", "=");
            return;
            {

            }
        }

        if (direction == "room" && inventory.hasConfirmed == false)
        {
            console.Writeline("After this point you can't go back. Do you want to proceed?", "white", "-");
            console.WriteDouble("Write: ", "'go room'", "white", "red", "_");
            inventory.hasConfirmed = true;
            return;
        }
        if (direction == "room" && inventory.hasUnlockBasement == true && inventory.hasConfirmed == true)
        {
            bossbattle.hasStarted = true;
            bossbattle.attacks = 0;
            console.nextline();
            console.nextline();
            console.WriteCharacter("fullLine", "blue", "=");
            console.WriteCharacter("endboss", "blue", "");
            console.WriteCharacter("fullLine", "blue", "=");
            console.WriteDouble("You walk into the room. In horror you see ", "Micha", "white", "red", "_");
            console.nextline();
            console.Writeline("you wil begin with the attack. You will get 2 chances of commands. You can use the", "white", "=");
            console.WriteTriple("'use'", " and ", "attack", "red", "white", "red", "_");
            console.nextline(); 
            console.Writeline("WE FIGHT TILL SOMEONE DIES....", "red", "=");
            console.WriteCharacter("fullLine", "blue", "=");
            return;
        }
        if (direction == "office" && inventory.hasUnlockOffice == false)
        {
            console.Writeline("It seems like it is looked. Maybe there is a key...", "blue", "=");
            return;
        }
        if (playerInventory.energy > 5)
        {
            playerInventory.energy -= 5;
            currentRoom = nextRoom;
            console.nextline();
            console.WriteCharacter("fullLine", "blue", "=");
            console.Writeline(currentRoom.GetLongDescription(), "white", "");
            console.Writeline(currentRoom.GetExits(), "blue", "_");
            console.WriteCharacter("fullLine", "blue", "=");
            return;
        } else
        {
            playerLose("energy");

        }
            

    }
    
    public void victory()
    {
        console.WriteCharacter("fullLine", "blue", "=");
        console.WriteCharacter("finished", "blue", "");
        console.WriteCharacter("fullLine", "blue", "=");
        console.WriteDouble("You have defeated ", "Micha", "white", "red", "_");
        wantToQuit = true;
        finished = true;
    }
    public void bossAttack()
    {
        List<Action> attackOptions = new List<Action>
            {
                AttackOption1,
                AttackOption2,
                AttackOption3,
                AttackOption4,
                AttackOption5,
                AttackOption6,
                AttackOption7
            };

        int chosenAttack = random.Next(attackOptions.Count);
        attackOptions[chosenAttack].Invoke();
    }

    private void AttackOption1()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("The boss has felt your attacks. He Thinks for a second at trows a chair at you.", "red", "_");
        console.Writeline("you lost 20 health.", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");

        playerInventory.removeHealth(amount: 20);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        } else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption2()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("the boss felt that. He is jumping on the ground. It begins to crack. You jump. And you survive.", "red", "_");
        console.Writeline("you lost 15 Energy.", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");

        playerInventory.removeEnergy(amount: 15);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption3()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("You made the boss angry. He is now screaming 'Luister Luister Luister...'", "red", "_");
        console.Writeline("you lost 15 health and 15 Energy", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");
        playerInventory.removeHealth(amount: 15);
        playerInventory.removeEnergy(amount: 15);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption4()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("He didnt care. He start his computer and is playing roblox...", "red", "_");
        console.Writeline("you lost 20 health.", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");
        playerInventory.removeHealth(amount: 20);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption5()
    { 
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("he is lazy. He spawns his companion. Odin runs at you and steals your phone...", "red", "_");
        console.Writeline("you lost 20 health. And your Phone", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");
        playerInventory.removeHealth(amount: 20);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption6()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("He drops bootstrap on your head...", "red", "_");
        console.Writeline("you lost 80 health.", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");
        playerInventory.removeHealth(amount: 80);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }

    private void AttackOption7()
    {
        console.WriteCharacter("endFight", "blue", "");
        console.Writeline("He begins yapping... You are getting really bored", "red", "_");
        console.Writeline("you lost 50 Energy.", "white", "_");
        console.WriteCharacter("fullLine", "blue", "=");
        playerInventory.removeEnergy(amount: 50);
        if (playerInventory.health <= 0)
        {
            playerLose(deathReason: "health");
        }
        else if (playerInventory.energy <= 0)
        {
            playerLose(deathReason: "energy");
        }
    }
}