//A simple text based adventure game.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame {
    class Program {
        enum room { EXIT, HIDDEN, PUZZLE, FINAL };
        static bool isRunning = true;
        static bool playerDead = false;
        static bool hiddenRoomFound = false;
        static bool exaltedEyeCollected = false;
        static int[] choice = new int[2];
        static string[] narration = new string[14];
        static int currentRoom = 0;

        static void Main(string[] args) {
            //game loop
            while(isRunning) {
                string currentRoomNarration = narration[currentRoom];
                narration[0] = "You are at the beginning of the dungeon.";
                narration[1] = "TEST ROOM 1";
                narration[2] = "TEST ROOM 2";
                narration[3] = "You are in a room to the east room. It is empty.";
                narration[4] = "":
                Console.WriteLine(narration[currentRoom]);
                Console.WriteLine("Current Room: {0}", currentRoom);
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
                                break; //break out of while loop, exit game
                        }
                        break;
                }
            }
        }
    }
}
