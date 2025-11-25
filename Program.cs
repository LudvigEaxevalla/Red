using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;


//Player var

Random rnd = new Random();
int playerHealth = 100;
int pMinDamage = 1;
int pMaxDamage = 3;
int playerDamage = rnd.Next(pMinDamage,pMaxDamage);
int playerCrit = rnd.Next(10,15);
double playerSpeed = 20;
double playerWeight = 0;
int playerAccuracy = 75;
string[] currentWeapon = {"Pocket Knife", "Hammer", "Kitchen Knife", "AK47"};
string selectedWeapon = "";

//Wolf var

int wolfHealth = 500;
int wMinDmg = 20;
int wMaxDmg = 40;
int wolfDamage = rnd.Next(wMinDmg,wMaxDmg);
int wolfSpeed = 50;
int wolfAccuracy = rnd.Next(10,30);

//Game
int dice= rnd.Next(1,100);
bool showTips = false;
string choice = "";
bool hasChosenTip = false;

//Grandma var

int grandmaHealth = 3;

//Weapon damage
int pocketKnifeDamage = 5;
int hammerDamage = 8;
int ak47Damage = 1000;

//Weapon Choices
bool hasChosenbeginningWeapon = false;
int beginningWeaponChoice;
int endgameWeaponChoice;

//Food Choices
int foodChoice;
bool hasChosenFoodFirst = false;
bool hasChosenFoodSecond = false;

//Weigth stuff
double pocketKnifeWeight = 2;
double hammerWeight = 5;
double grandmaFoodWeight = 5;


//Checking things
bool playerDeath = false;
bool hadMushroomsBefore = false;
bool isCarryingGrandmasFood = false;
bool unlikelyEnding = false;
bool goodEnding = false;
bool sadEnding = false;
bool deathEnding = false;

//Battle stuff
bool battle = false;
bool canRun = false;
bool playersTurn = false;
bool wolfsTurn = false;
int battleChoice = 0;

double runningOdds = 0;



//Areas

/* 

1. Home
2. Forest part 1
3. Forest part 2 (wolf)
4. Forest part 3 (rest)
5. Grandmas house

*/


Console.Clear();
Console.ForegroundColor = ConsoleColor.Red;


    Console.WriteLine(" _____  ______ _____");  
    Console.WriteLine("|  __ \\|  ____|  __ \\"); 
    Console.WriteLine("| |__) | |__  | |  | |");
    Console.WriteLine("|  _  /|  __| | |  | |");
    Console.WriteLine("| | \\ \\| |____| |__| |");
    Console.WriteLine("|_|  \\_\\______|_____/ ");

Console.WriteLine("\nA text adventure game");
Console.ForegroundColor = ConsoleColor.DarkYellow;

while (!hasChosenTip)
{        
    Console.WriteLine("\n\n Would you like explanations on how the game works from time to time?");
    Console.WriteLine("This will also include seeing stats like health in battles");
    Console.WriteLine("y/n");
    choice = Console.ReadLine()!;

        if (choice == "y" || choice == "Y")
        {
            showTips = true;
            Console.WriteLine("More information will be shown");
            Console.WriteLine("Press ENTER to continue");
            hasChosenTip = true;
            Console.ReadKey();
        }
        else if (choice == "n" || choice == "N")
        {
            Console.WriteLine("More information will NOT be shown");
            Console.WriteLine("Press ENTER to continue");
            hasChosenTip = true;
            Console.ReadKey();
            
        }
        else        
        {
            Console.WriteLine("Unvalid input - please type y or n");
        }

}

Console.Clear();
                       
Console.ResetColor();

Console.WriteLine("\n\n-- Just a bunch of text here that will welcome the player and set up the story.");
Console.WriteLine("Your grandma is sick blah blah blah bring her food blah blah look out for dangers.");
Console.WriteLine("Choose between a pocket knife and a hammer before you leave, just in case. --");


isCarryingGrandmasFood = true;

if (isCarryingGrandmasFood)
{
    playerWeight += grandmaFoodWeight;
}
else
{
    playerWeight -= grandmaFoodWeight;
}

runningOdds -= playerWeight;

//--START OF GAME -- CHOOSE STARTING WEAPON--//

while (!hasChosenbeginningWeapon)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n   What do you choose? \n1. Pocket Knife\n2. Hammer");

beginningWeaponChoice = int.Parse(Console.ReadLine()!);

if (beginningWeaponChoice <1 || beginningWeaponChoice > 2)
    {
        Console.WriteLine("You can only choose between 1 and 2. Try again");
    }

else if (beginningWeaponChoice == 1)
{
    selectedWeapon = currentWeapon[0];
    pMinDamage += pocketKnifeDamage;
    pMaxDamage += pocketKnifeDamage;
    playerWeight += pocketKnifeWeight;
    runningOdds -= playerWeight;
    //playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
}

else if (beginningWeaponChoice == 2)
{
    selectedWeapon = currentWeapon[1];
    pMinDamage += hammerDamage;
    pMaxDamage += hammerDamage;
    playerWeight += hammerWeight;
    runningOdds -= playerWeight;
    //playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
}

    
}

/*Console.WriteLine(playerDamage);
Console.WriteLine(playerWeight);
Console.WriteLine(playerSpeed);
Console.WriteLine(playerHealth);
Console.ReadKey(); */ 

Console.Clear();
Console.ForegroundColor = ConsoleColor.White;

//--FOREST PART 1--//
Console.ForegroundColor = ConsoleColor.DarkGreen;
 Console.WriteLine(" _______ _    _ ______   ______ ____  _____  ______  _____ _______");
 Console.WriteLine("|__   __| |  | |  ____| |  ____/ __ \\|  __ \\|  ____|/ ____|__   __|");
 Console.WriteLine("   | |  | |__| | |__    | |__ | |  | | |__) | |__  | (___    | | ");  
 Console.WriteLine("   | |  |  __  |  __|   |  __|| |  | |  _  /|  __|  \\___ \\   | | ");  
 Console.WriteLine("   | |  | |  | | |____  | |   | |__| | | \\ \\| |____ ____) |  | |  ");  
 Console.WriteLine("   |_|  |_|  |_|______| |_|    \\____/|_|  \\_\\______|_____/   |_| ");   
                                                                    

Console.ResetColor();
Console.Write("\n\nYou walk for a bit and stop where you know ");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write("blueberries ");
Console.ResetColor();
Console.Write("grow");
Console.Write("\nYou also notice some ");
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.Write("mysterious red mushrooms ");
Console.ResetColor();
Console.Write("ahead");

Console.WriteLine("\n\nYou know nothing about the mushrooms but they sure look yummy!");



Console.ReadKey();


while (!hasChosenFoodFirst)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Do you eat the blueberries(1), the red mushroom(2) or do you continue without eating(3)?");
    foodChoice = int.Parse(Console.ReadLine()!);    
    Console.Clear();
    switch (foodChoice)
{
    case 1:
    playerHealth += 15;
    playerSpeed += 5;
    playerAccuracy += 5;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("You feel more energiezed than before and your journey continues!");
    Console.ReadKey();
    Console.Clear();
    hasChosenFoodFirst = true;
    break;

    case 2:
    playerHealth -= 15;
    playerSpeed -= 5;
    playerAccuracy -= 7;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("You feel.... not so good... That was probably a bad idea but you continue");
    Console.ReadKey();
    Console.Clear();
    hasChosenFoodFirst = true;
    break;

    case 3:
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("You decide to not eat and continue your journey...");
    Console.ReadKey();
    Console.Clear();
    hasChosenFoodFirst = true;
    break;

    default:
    Console.WriteLine("You must choose 1, 2 or 3. Try again");
    break;
}
}

//--WOLF ENCOUNTER - FIGHT--//
                                                                    

Console.ResetColor();


Console.WriteLine("You walk without a care in the world for a while but as you get deeper into the woods,");
Console.WriteLine("you realize how dark it gets when the trees gets closer and the path narrows.");
Console.WriteLine("------ blah blah blah blah ------");
Console.WriteLine("Something approches --blah blah-- it's a wolf wondering who you are and where you're going");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("You have no choice but to fight the wolf");

Console.ReadKey();



battle = true;

while (battle)
{
    if (showTips)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You always have the first turn in battle and you have one of two options each turn. ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n1. Attack the wolf with the weapon you chose at the beginning of the game.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("There is always a chance that you will miss the wolf when attacking in wich case it will be the wolfs turn");
        Console.WriteLine("If you hit the wolf, the wolf will become a bit slower and your chances of running away increses \n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("2. You can try to run away from the wolf.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("At first you will have 0 chanses of running from the wolf. It only increases when you succesfully hit the wolf");
        Console.WriteLine("When you try to run, a number will show how long you have to go. This number always changes");
        Console.WriteLine("After - your distance is shown. If your distance is the same or more than the first number, you will successfully run from the wolf");
        Console.WriteLine("If you fail to run, it will be the wolfs turn");
        Console.WriteLine("\n");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("The wolf only has one move: Attack");
        Console.WriteLine("The wolf is less likely to hit you than you are to hit him, however:");
        Console.WriteLine("If the wolf does hit you, your chances of running away decreses and the wolfs chance of hitting you next time slightly increses.\n");
        Console.WriteLine("The wolf also has more health than you and does more damage.");
        Console.WriteLine("Winning by just attacking is possible buy very unlikely");
        Console.ReadKey();
        Console.Clear();
        
    }

    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The battle begins");
        Console.ReadKey();
        Console.Clear();
    }
    


    if (!playersTurn && !wolfsTurn)
    {
        playersTurn = true;
    }

    while (playersTurn && !playerDeath)


    {

            if (playerHealth <= 0)
        {
            playerDeath = true;
        }
        else if (playerHealth > 0)
        {
        playerDamage = rnd.Next(pMinDamage, pMaxDamage);
        dice = rnd.Next(1,100);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n");
        Console.WriteLine("Use your " + selectedWeapon + " (1)");
        Console.WriteLine("Try to run (2)");

        if (showTips)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n");
            Console.WriteLine("Your chances of running away: " + runningOdds);
            Console.WriteLine("Your Health: " + playerHealth);
            Console.WriteLine("Wolfs Health: " + wolfHealth);  
        }
        battleChoice = int.Parse(Console.ReadLine()!);


        switch(battleChoice){

            case 1:
            dice = rnd.Next(1,100);

            if (playerAccuracy >= dice)
                {
                    wolfHealth -= playerDamage;
                   // wolfSpeed -= playerDamage;
                    runningOdds += playerDamage;
                        if (wolfHealth <= 0)
                    {
                        playersTurn = false;
                        wolfsTurn = false;
                        battle = false;
                        unlikelyEnding = true;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You succesfully hit the wolf with your " + selectedWeapon);
                    Console.WriteLine("Your chances of running increses");
                    Console.ReadKey();
                    playersTurn = false;
                    wolfsTurn = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You missed!");
                    Console.ReadKey();
                    playersTurn = false;
                    wolfsTurn = true;
                }
            break;

            case 2:
            Console.Clear();
            dice = rnd.Next(1,100);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Distance to run: ");
                for (int i = 0; i <= dice; i++) 
                 {
                            
                            //Console.Write("| " + $"\r{i}");
                            Console.Write("|");
                            Thread.Sleep(50);
                            if (i == dice)
                    {
                        break;
                    }
                 } 
                 Console.WriteLine("\n" + dice);
                 Console.ReadKey();

                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Your distance: ");

                for (int i = 0; i <= runningOdds; i++)
                {
                    //Console.Write($"\r{i}");
                    Console.Write("|");
                    Thread.Sleep(50); 

                    if (i == runningOdds)
                    {
                        break;
                    }
                }
                Console.WriteLine("\n" + runningOdds); 
                Console.ReadKey();


            if (runningOdds < dice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You tried to run but the wolf is just to fast for you");
                    Console.ReadKey();
                    playersTurn = false;
                    wolfsTurn = true;
                }

                else if (runningOdds >= dice)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You succesfully ran away from the wolf");
                    Console.ReadKey();
                    battle = false;
                    playersTurn = false;
                    wolfsTurn = false;
                }
            break;

            default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Try again");
            break;
            
        }
            
        }
      


        while (wolfsTurn)
        {
            dice = rnd.Next(1,100);
            wolfDamage = rnd.Next(wMinDmg, wMaxDmg);
            wolfAccuracy = rnd.Next(10,30);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The Wolfs attack: ");
                for (int i = 0; i <= wolfAccuracy; i++) 
                 {
                            
                            //Console.Write("| " + $"\r{i}");
                            Console.Write("|");
                            Thread.Sleep(20);
                            if (i == wolfAccuracy)
                    {
                        break;
                    }
                 } 
                 Console.WriteLine("\n" + wolfAccuracy);
                 Console.ReadKey();

                 Console.ForegroundColor = ConsoleColor.Green;
                 Console.WriteLine("Your defense: ");

                for (int i = 0; i <= dice; i++)
                {
                    //Console.Write($"\r{i}");
                    Console.Write("|");
                    Thread.Sleep(20); 

                    if (i == dice)
                    {
                        break;
                    }
                }
                Console.WriteLine("\n" + dice); 
                Console.ReadKey();

            if (wolfAccuracy >= dice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                playerHealth -= wolfDamage;
                wolfAccuracy++;
                runningOdds -= rnd.Next(5,15);
                Console.WriteLine("The wolf attacked you.... it hurts");
                Console.WriteLine("Your chances of running away decreses");
                Console.ReadKey();
                wolfsTurn = false;
                playersTurn = true;

            
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You managed to dodge the wolfs attack!");
                Console.ReadKey();
                wolfsTurn = false;
                playersTurn = true;
            }
        }
    }

    if (canRun || unlikelyEnding || playerDeath)
    {
        battle = false;
    }

}

if (deathEnding)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("");
}

        if (playerDeath)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The wolf has killed you\nGame Over");
            Console.ReadKey();

        }

else
{
    Console.Clear();
    Console.ResetColor();
    Console.WriteLine("Next Level");
}
