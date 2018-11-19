//A simple text based adventure game, tested on both Ubuntu Linux 18.04 and Windows 10.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame {
    class Program {
        static bool isRunning = true;
        static int[] choice = new int[3];
        static string[] narration = new string[19];
        static int currentRoom = 0;
        static int playerGold = 0;
        

        static void Main(string[] args) {
            menu();
            Console.ReadLine();
            }

        static void play() {
            while(isRunning) {
                //string currentRoomNarration = narration[currentRoom];
                narration[0] = "You are at the beginning of the dungeon.";
                narration[1] = "You are in the center room, with 3 rooms off to the east, west and north.";
                narration[2] = "You move to the west room, and you find some gold! It's been added to your inventory.";
                narration[3] = "You are in a room to the east room. It is empty.";
                narration[4] = "You move to the north room, only to be surprised by an enemy! \nYou run down the stairs into the next level of the dungeon.";
                narration[5] = "As you go down the stairs, you find yourself in another part of the dungeon. \nThere is a room to the north, and a room to the east.";
                narration[6] = "As you make your way to the east room, you notice a chest. \nAs you rush towards it, you don't notice the trap inside the room. You take 2 damage.";
                narration[7] = "You make your way to the north room, and notice more wealth! \nAs you walk towards it, you also notice a crack in the wall to the east. It looks like you can fit through the crack in the wall - it's a miracle this part of the dungeon is still standing!";
                narration[8] = "You squeeze your way through the crack in the wall, and you find 150 gold in the room!";
                narration[9] = "After grabbing the gold in the hidden room, you walk down yet another set of stairs, \nto the third level of the dungeon.";
                narration[10] = "You're in another center room, similar to the first room. There is a room to the east and west.";
                narration[11] = "You go into the west room, and notice even more gold! You grab it and exit the room. \n50 gold has been added to your inventory!";
                narration[12] = "You make your way into the east room, and you notice a note. \nIt has a rubbing of some runes, and a translation. It has been added to your inventory.";
                narration[13] = "You make your way down the stairs and into a strange room. \nThe door at the end of the room has the same runes as the rubbing on the note, and in the room you notice 6 braziers.";
                narration[14] = "The note says \"To go forward, you must return; to glow brightly, the sky must burn!\"";
                narration[15] = "You light the braziers with a nearby torch - the ground rumbles, and the door opens. \nThis has obviously been sealed for a very long time.";
                narration[16] = "With the door opened, you make your way into the final room! \nIn the final room, atop a pedestal, sits the object you have been searching for: the Exalted Eye, \na mystical ring that will grant its wearer god-like abilites.";
                narration[17] = "You go forward to grab the Exalted Eye. \nPutting it on your finger reveals to you that the wearer doesn't gain god-like abilities - you BECOME a god!";
                narration[18] = "Thank you for playing my game! \nIt took me a while to create, and any constructive criticism is appreciated! \nCreated by Jacob Seadorf.";

                if(currentRoom == 18) {
                    Console.Clear();
                    Console.WriteLine(narration[currentRoom]);
                    Console.Write("\n\nPress any key to quit...");
                    break;
                }

            updateGold:
                Console.Clear();
                Console.WriteLine(narration[currentRoom]);
                Console.WriteLine();
                Console.WriteLine("Current Room: {0}", currentRoom);
                Console.WriteLine("Gold: {0}", playerGold);
                Console.WriteLine(" 1. Move to next room.\n 2.Leave the room\n");
                Console.Write("Your choice (1/2): ");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch(userChoice) {
                    case 1:
                        currentRoom++;
                        break;
                    case 2:
                        if(currentRoom != 0) {
                            currentRoom--;
                        } else {
                            Console.WriteLine("You are already at the beginning!");
                            Console.WriteLine("Do you want to quit? (Y/n)");
                            char userChar = Convert.ToChar(Console.ReadLine());
                            if(userChar == 'Y')
                                Console.WriteLine("The door is sealed with a magical barrier. You're trapped.");
                            break;
                        }
                        break;
                }
                if(currentRoom == 2) {
                    playerGold += 15;
                    goto updateGold;
                }
                if(currentRoom == 8) {
                    playerGold += 150;
                    goto updateGold;
                }
                if(currentRoom == 11) {
                    playerGold += 50;
                    goto updateGold;
                }
            }
        }

        static void menu() {
            Console.WriteLine("=======================");
            Console.WriteLine("** DUNGEON MAIN MENU **");
            Console.WriteLine("=======================");
            Console.WriteLine("1: Play");
            Console.WriteLine("2: Quit");
            Console.WriteLine("3: About");
            Console.Write("> ");
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            switch(menuChoice) {
                case 1:
                    Console.Clear();
                    play();
                    break;
                case 2:
                    char answer;
                    Console.Write("Are you sure? (Y/n): ");
                    answer = Convert.ToChar(Console.ReadLine());
                    if(answer == 'Y') {
                        Console.Write("Press any key to quit...");
                        break;
                    } else {
                        Console.Clear();
                        menu();
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Dungeon was programmed by Jacob Seadorf, \nand created as an assignment in Mrs. Fernandez's Programming class in November of 2018.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadLine();
                    Console.Clear();
                    menu();
                    break;
                default:
                    Console.Clear();
                    menu();
                    break;
                }
            }
        }
    }
