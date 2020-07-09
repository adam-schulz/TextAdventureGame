using AdventureGame_Library1;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_Console.UI
{

    public class AdventureGameUI
    {
        private readonly AdventureGame_Repository _adventureRepo = new AdventureGame_Repository();
        protected readonly Character newCharacter = new Character();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Welcome to the World of Schuka: a text based adventure! Please have fun and follow the prompts.\n" +
                    "When asked to select between numerous choices, \n" +
                    "please enter the number corresponding to the choice you would like to select.\n \n \n" +
                    "Enter the number of options you would like to select \n" +
                    "1. Start a New Game \n" +
                    "2. Exit");  // \n must fall within the quotation marks \n creates an newline

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Starts A New Game
                        StartNewGame();
                        break;
                    case "2":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number: either 1 or 2 \n" +
                            "Press any key to continue.....");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void StartNewGame()
        {

            Console.Clear();
            Console.WriteLine("Enter the number of the character type you would like to select: \n" +
                "1) Elf \n" +
                "2) Knight \n" +
                "3) Mage \n" +
                "4) Dwarf \n" +
                "5) Ranger");
            string number = Console.ReadLine();
            switch (number)
            {
                case "1":
                    newCharacter.CharacterType = TypeOfCharacter.Elf;
                    break;
                case "2":
                    newCharacter.CharacterType = TypeOfCharacter.Knight;
                    break;
                case "3":
                    newCharacter.CharacterType = TypeOfCharacter.Mage;
                    break;
                case "4":
                    newCharacter.CharacterType = TypeOfCharacter.Dwarf;
                    break;
                case "5":
                    newCharacter.CharacterType = TypeOfCharacter.Ranger;
                    break;
                default:
                    Console.WriteLine("The character type you have choosen is invalid. A character has been chosen for you");
                    newCharacter.CharacterType = TypeOfCharacter.Bard;
                    Console.ReadKey();
                    break;

            }
            Console.Clear();
            Console.WriteLine("Enter the number of the weapon type you would like to select: \n" +
                "1) Sword \n" +
                "2) Bow \n" +
                "3) Axe \n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newCharacter.Weapon = "sword";
                    break;
                case "2":
                    newCharacter.Weapon = "bow";
                    break;
                case "3":
                    newCharacter.Weapon = "axe";
                    break;
                default:
                    Console.WriteLine("The weapon you have selected is not a valid option. You have instead been given a Lute.");
                    newCharacter.Weapon = "Lute";
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            Console.WriteLine($"You have chosen to begin your journey with a character of {newCharacter.CharacterType}, \n" +
                $"and your weapon is a {newCharacter.Weapon}. You have {newCharacter.Health} health \n" +
                "Adventure awaits you! Press any key to continue");
            Console.ReadKey();

            _adventureRepo.AddCharacterToList(newCharacter);

            Console.Clear();
            Console.WriteLine("At some point in your journey you may come across a monster... What would you like to name this creature? \n" +
                "1) Dart \n" +
                "2) Gengar \n" +
                "3) Wendy");
            Monster newMonster = new Monster();

            int L = int.Parse(Console.ReadLine());
            switch (L)
            {
                case 1:
                    newMonster.Name = "Dart";
                    break;
                case 2:
                    newMonster.Name = "Gengar";
                    break;
                case 3:
                    newMonster.Name = "Wendy";
                    break;
                default:
                    Console.WriteLine("You foolishly have not chosen an available option. A default monster name has been chosen for you.");
                    newMonster.Name = "Steve";
                    break;

            }


            Console.WriteLine("What type of Monster would you like your creature to be? \n" +
                "1) King Black Dragon \n" +
                "2) Demigorgon \n" +
                "3) Your Arch Nemesis");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    newMonster.MonsterType = "King Black Dragon";
                    break;
                case 2:
                    newMonster.MonsterType = "Demigorgon";
                    break;
                case 3:
                    newMonster.MonsterType = "Your Arch Nemesis";
                    break;
                default:
                    Console.WriteLine("The Monster type you have choosen is unavailable at this time. A random monster has been chosen for you.");
                    newMonster.MonsterType = "Nightmare";
                    break;

            }

            _adventureRepo.AddMonsterToList(newMonster);



            Console.Clear();
            Console.WriteLine($"Your monster's name is {newMonster.Name} and is of type {newMonster.MonsterType}.\n" +
                              "Press any key to continue.");
            Console.ReadKey();

            Console.Clear();


            bool isinputCorrect = false;
            Console.WriteLine("You wake up in a dark room lit only by a small candle on the bedside table.\n" +
                 "You try to open the door but it is locked. You will need to find a key to get it.\n" +
                 "Where would you like to search? \n" +
                 "1) Under the bed \n" +
                 "2) In the closet \n" +
                 "3) In the desk drawer");
            int guess = Convert.ToInt32(Console.ReadLine());

            do
            {
                if (guess == 3)
                {
                    isinputCorrect = true; // breaks the loop
                    Console.WriteLine("You found the correct key");
                    Console.ReadKey();

                }
                else // program continues to run until program is over
                {
                    Console.WriteLine("You didn't find the key ... try again");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
            }
            while (!isinputCorrect);

            Console.Clear();
            Console.WriteLine("You unlock the door and discover a bustling village. \n" +
                "Out of the corner of your eye you spot a stranger hunched over in desperate need of help. \n" +
                "Would you like to offer your assistance? \n" +
                "1) Yes \n" +
                "2) No");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine("The man is very thankful and as such you have gained an extra health");
                newCharacter.Health++;
                Console.WriteLine($"Congrats you now have {newCharacter.Health} health.");
                Console.ReadKey();

            }
            else if (userInput == 2)
            {
                Console.WriteLine("The man has cried out for help and no has answered thus he is left in a pool of tears \n" +
                                  "You slip in the pool of tears and woefully sprain your ankle.");
                newCharacter.Health--;
                Console.WriteLine($"Sorry you now have {newCharacter.Health} health.");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("The road you are on reaches a fork. There are two paths - one to the right and one to the left. Which do you choose? \n" +
                "1) Right \n" +
                "2) Left");
            int userInput2 = int.Parse(Console.ReadLine());



            if (userInput2 == 1)
            {
                bool isinputCorrect1 = false;
                Console.WriteLine("Your path is blocked by a bear! What do you do? \n" +
                    "1) Run \n" +
                    $"2) Draw your {newCharacter.Weapon}. \n");
                int choice1 = int.Parse(Console.ReadLine());

                do
                {
                    if (choice1 == 2)
                    {
                        isinputCorrect1 = true; // breaks the loop
                        Console.WriteLine("You kill the bear after a hard battle.");
                        newCharacter.Health++;


                    }
                    else // program continues to run until program is bool inputCorrect1= true
                    {
                        Console.WriteLine("You weren't able to get away and the bear has begun clawing at you! You must press 2 to fight back!");
                        newCharacter.Health -= 2;
                        choice1 = int.Parse(Console.ReadLine());
                    }
                }
                while (!isinputCorrect1);
                Console.ReadKey();
            }

            else if (userInput2 == 2)
            {
                bool isinputCorrect2 = false;
                Console.WriteLine("Your path is blocked by a goblin! How do you react? \n" +
                    "1) Run \n" +
                    $"2) Draw your {newCharacter.Weapon}");

                int choice2 = int.Parse(Console.ReadLine());

                do
                {
                    if (choice2 == 2)
                    {
                        isinputCorrect2 = true; // breaks the loop                        
                        Console.WriteLine("You have defeated the Goblin. For you bravery you have been awarded an extra health.");
                        newCharacter.Health++;

                    }
                    else // program continues to run until program is over
                    {
                        Console.WriteLine("You weren't able to get away and the Goblin has initiated the attack. You must press 2 to fight back!");
                        newCharacter.Health -= 2;
                        choice2 = int.Parse(Console.ReadLine());
                    }
                }
                while (!isinputCorrect2);
                Console.ReadKey();
            }

            Console.WriteLine($"You now have {newCharacter.Health} health.\n" + "To continue on your adventure press any key.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("You arrive in a barbarian village, and in this village you discover a pub as well as a training ground. \n" +
                "Do you wish to go to the pub for a pint or to the training grounds to sharpen your skills? \n" +
                "1) I'm awfully parched, let's have a drink. \n" +
                "2) I'm always looking to improve myself, let's head to the training grounds.");
            int choice3 = int.Parse(Console.ReadLine());

            if (choice3 == 1)
            {
                Console.WriteLine("The pint is refreshing and restores some health");
                newCharacter.Health++;
                Console.ReadKey();
            }

            else if (choice3 == 2)
            {
                Console.WriteLine($"You are a diligent {newCharacter.CharacterType} and have been rewarded for all your hard work.");
                newCharacter.Health += 3;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You are scorned by you indecisiveness");
                newCharacter.Health--;
                Console.ReadKey();
            }
            Console.WriteLine($"You now have {newCharacter.Health} health \n" + "Press any key to continue on your adventure.");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("A worried looking man comes up to you and says that he has lost his lizard. \n" +
                "Would you like to help him find it? \n" +
                "1) Of course! I can't think of a more nobler deed. \n" +
                "2) Unfortunately I do not have time. Good luck!");

            int choice4 = int.Parse(Console.ReadLine());

            if (choice4 == 1)
            {
                Console.WriteLine("After a lengthy search, you find the lizard relaxing in the drinking fountain behind the pub. Huzzah!");
                newCharacter.Health++;
                Console.ReadKey();
            }

            else if (choice4 == 2)
            {
                Console.WriteLine("As you are walking away from the man, you are stung by a wasp. Ouch!");
                newCharacter.Health--;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You stare blankly at the man and he slowly walk away, rather confused...");
                Console.ReadKey();
            }
            Console.Clear();

            Console.WriteLine($"You now have {newCharacter.Health} health \n" + "Press any key to continue on your adventure.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("It is getting late so you turn back for home.\n" +
            $"On your way home, you are stopped by  a {newMonster.MonsterType} named {newMonster.Name}! Egads! \n" +
            $"Do you fight the monster or run away like a coward? \n" +
            "1) Fight \n" +
            "2) Run away");
            int finalChoice = int.Parse(Console.ReadLine());
            Console.ReadKey();

            Console.Clear();
            if (finalChoice == 1)
            {
                Console.WriteLine("You are brave.");
                if (newCharacter.Health >= newMonster.Health)
                {
                    Console.WriteLine($"Hurray you defeated {newMonster.Name} \n" +
                    "You make it back home safely and head straight to bed, worn out by the days' adventure");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"{newMonster.Name} has defeated you. Perhaps you should have been a better person... GAME OVER!");
                    Console.ReadKey();
                }
            }

            else
            {
                Console.WriteLine($"{newMonster.Name} caught on the in the forest on the south of the village. Perhaps you should have been a better person... GAME OVER!");
            }
            Console.ReadKey();

        }
    }

}