using EscapeRoom.Boss;
using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class ProgramUI
    {
        // Change anything you want. Just throwing down ideas I had.

        public List<Items> Inventory = new List<Items>();

        Dictionary<string, Room> Rooms = new Dictionary<string, Room>
        {
            {"coffee shop", coffeeShop }, // Coffee Boss
            {"deli shop", deliShop }, // Sandwich Boss 
            {"family reunion", familyReunion }, // Evil Aunt
            {"dunkin donuts", dunkinDonuts }, // Fat Cat Boss 
            {"pet store", petStore }, // Bunny Boss
            {"street", street },
            {"coffee", coffeeShop }
        };

        Dictionary<string, Items> AttackItems = new Dictionary<string, Items>
        {
            {"ice", Items.Ice},
            {"snowcone", Items.Snowcone },
            {"donuts", Items.Donuts },
            {"catnip", Items.CatNip },
            {"baby carrots", Items.BabyCarrots },
            {"hounds", Items.Hounds },
            {"saran wrap", Items.SaranWrap },
            {"eat sandwich", Items.EatSandwich },
            {"whiskey", Items.Whiskey },
            {"rehab", Items.Rehab }
        };

        public static Room street = new Room(
            "You are walking down the street.\n" +
            "What should we do now?\n" +
            "Your options are:  coffee shop, deli shop, family reunion, dunkin donuts, or pet store",
            new List<string> { "coffee shop", "deli shop", "family reunion", "dunkin donuts", "pet store" },
            new List<Items> { }
            );

        public static Room coffeeShop = new Room(
            "\n\nYou walk by your normal coffee shop with the brand new espresso machine you just bought. The manager rushes out to ask you \n--- Do you not love us anymore?---\n" +
            "\nYou reply\n --- I have found something better than your dirt coffee!!---\n " +
            "\nThe manager unleashes the beast of the coffee shop, a HOT CUP OF COFFEE!\n\n",
            new List<string> { "ice", "snowcone" },
            new List<Items> { Items.Ice, Items.Snowcone },
            new Coffee { }

            );

        public static Room deliShop = new Room("\n\nYou arrive at the deli shop.\n\n" +
            "\n The deli shop manager offers you a free sandwich.\n" +
            "You accept the sandwich but something does not feel right.......\n\n\n" +
            "OH NO IT'S A TRAP!! The sandwich is out to get you!\n",
            new List<string> { "saran wrap", "eat" },
            new List<Items> { Items.SaranWrap, Items.EatSandwich },
            new Sandwich { }
            );

        public static Room familyReunion = new Room("\nSWOOOooooSSSSssHHHHH\n" +
            "You wake up five years in the past sitting at your family reunion listening to your Aunt give a speech. She's congratulating you on how great you are at coding in C#. Little does she know that you're about " +
            "to ruin her day. \n\nYou are called up to the podium to accept your award for being a beast at coding. You rip the award in half and inform the audience your Aunt is a no good, lying, piece of garbage.....\n" +
            "\n\n OH NO! There's a freight train headed your way!\n\n",
            new List<string> { "whiskey", "rehab" },
            new List<Items> { Items.Whiskey, Items.Rehab },
            new EvilAunt { }
            );

        public static Room dunkinDonuts = new Room("\n\nYou magically teleport ten years ahead in time and find yourself across the street from a deli shop." +
            " You walk into a newly established donut shop and see a super fat cat munchin on the donuts!\n",
            new List<string> { "catnip", "donuts" },
            new List<Items> { Items.CatNip, Items.Donuts },
            new FatCat { }
            );

        public static Room petStore = new Room("You have the sudden urge to buy a bunny rabbit. They are just so cute and fluffy!!!!\n" +
            "You arrive at your local pet store and find the perfect bunny. You pick up the bunny and everything seems to be going well until.....\n\n" +
            "The bunny uses its happy feet attack and begins to uppercut your jaw into next week!\n",
            new List<string> { "baby carrots", "hounds" },
            new List<Items> { Items.BabyCarrots, Items.Hounds },
            new Bunny { }
            );

        //new instance of User

        public void Run()
        {
            int bossCounter = 0;

            User user = new User();

            Room room = street;

            Console.Clear();

            Console.WriteLine("BEEP BEEP BEEP BEEP... 7:30AM.\n" +
                "Time to wake up.  The sun is shining and you have a lot to do today.\n" +
                "Your to do list for the day includes:\n" +
                "Coffee, Donuts, Deli, Pet Store, and a Family Reunion\n " +
                "Do you think you can make it through a normal day in the neighborhood?\n\n" +
                "Press any key to continue.");

            Console.ReadLine();

            bool alive = true;
            while (alive)
            {
                Console.Clear();

                Console.WriteLine($"Health: {user.Health}\n" +                              //now displays users health
                    $"----------------\n");

                if (room == street)
                {
                    Console.WriteLine(room.Riddle);

                    string streetCommand = Console.ReadLine().ToLower();

                    if (streetCommand.Contains("go"))
                    {
                        bool moveTo = false;
                        foreach (string move in room.Exits)
                        {
                            if (streetCommand.Contains(move) && Rooms.ContainsKey(move))
                            {
                                room = Rooms[move];
                                moveTo = true;
                                break;
                            }
                            if (!moveTo)
                            {
                                Console.WriteLine("I don't think you have time to go there today.");

                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(room.Riddle);

                    Console.WriteLine("\nThis is messed up what are you going to do?\n" +
                        "Your options are: RUN, FIND ITEM, or FIGHT");

                    string command = Console.ReadLine().ToLower();

                    //run away from boss.  was thinking we could add a central "room" called street that would be a default go between other locations. any boss that was ran away from would need to be dealt with later.
                    if (command.StartsWith("run") || command.StartsWith("exit"))
                    {
                        Console.Clear();

                        Console.WriteLine("You ran away and acted like nothing weird just happened. Hope you don't regret this decision later.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.WriteLine("You lose 50 health for your cowardice!\n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        user.Health = user.Health - 50;                                                             //lower health total
                        room = street;
                    }
                    else if (command.StartsWith("find") || command.StartsWith("look"))
                    {
                        Console.WriteLine("\nYou stumble across a cache of items.\n" +
                            "Maybe something here will help you defeat this monstrosity.\n" +
                            "your options are:\n");
                        foreach (Items roomItems in room.Items)
                        {
                            Console.WriteLine(roomItems);
                        }

                        Console.WriteLine("\nEnter the name of the item you wish to pick up.");
                        string itemCommand = Console.ReadLine().ToLower();

                        bool pickItem = false;
                        foreach (Items item in room.Items)
                        {
                            if (!pickItem && itemCommand.Contains(item.ToString().ToLower()))
                            {
                                Console.WriteLine("Hope it helps. Press any key to continue.");
                                room.RemoveItem(item);
                                Inventory.Add(item);
                                pickItem = true;
                                Console.ReadKey();
                                break;
                            }

                        }
                        if (!pickItem)
                            Console.WriteLine("Sorry that's not a valid item choice.  Please try again.");
                    }
                    else if (command.Contains("fight"))
                    {
                        if (Inventory.Count == 0)
                        {
                            Console.WriteLine("\nYou don't have an item to fight the boss. Go back and get one so you dont get REKT!\n" +
                                "Press any key to continue.");
                            Console.ReadKey();
                            room = street;
                        }
                        else
                        {
                            Console.WriteLine("No turning back now!\n");





                            while (user.Health > 0 && room.Boss.Health > 0)
                            {

                                Console.WriteLine($"Boss Health: {room.Boss.Health}\n\n");
                                Console.WriteLine($"Your Health: {user.Health}\n\n");

                                Console.WriteLine("Choose an item from your inventory to use against this boss.\n");
                                

                                foreach (Items items in Inventory)
                                {
                                    Console.WriteLine(items);
                                    string attackCommand = Console.ReadLine().ToLower();
                                }

                                Attack userAttack = user.Attack();
                                room.Boss.Damage(userAttack);
                                Console.WriteLine("You attacked the boss!\n");
                                Console.ReadKey();

                                Attack bossAttack = room.Boss.Attack();
                                user.Damage(bossAttack);
                                Console.WriteLine("\nOh no you got hit!");
                                Console.ReadKey();
                                Console.Clear();
                            }

                            if (room.Boss.Health <= 0)
                            {
                                Console.WriteLine("\nYou defeated the boss!!!");
                                room = street;
                                Console.ReadKey();
                                bossCounter++;

                            }

                            if (user.Health <= 0)
                            {
                                Console.WriteLine("\nThe boss just destroyed you!! Need a bandaid for that that scratch?");
                                room = street;
                                Console.ReadKey();
                                alive = false;
                            }

                            if (bossCounter == 5)
                            {
                                Console.WriteLine("\n************\n" +
                                    "*YOU WON THE GAME!*\n" +
                                    "*************");
                                Console.ReadKey();
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Sorry try again");
                    }
                }
            }
        }
    }
}