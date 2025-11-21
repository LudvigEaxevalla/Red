using System;
using System.Net.Http.Headers;

//Console
Console.ForegroundColor = ConsoleColor.Red;

//Player var

Random rnd = new Random();
int playerHealth = 100;
int pMinDamage = 1;
int pMaxDamage = 5;
int playerDamage = rnd.Next(pMinDamage,pMaxDamage);
int playerCrit = rnd.Next(10,15);
double playerSpeed = 20;
double playerWeight = 0;
int playerAccuracy = 80;
string[] currentWeapon = {"Pocket Knife", "Hammer", "Kitchen Knife", "AK47"};

//Wolf var

int wolfHealth = 500;
int wMinDmg = 20;
int wMaxDmg = 40;
int wolfDamage = rnd.Next(wMinDmg,wMaxDmg);
int wolfSpeed = 50;
int wolfAccuracy = 100;

//Game
int dice= rnd.Next(1,100);

//Grandma var

int grandmaHealth = 3;

//Weapon damage
int pocketKnifeDamage = 5;
int hammerDamage = 15;
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


    Console.WriteLine(" _____  ______ _____");  
    Console.WriteLine("|  __ \\|  ____|  __ \\"); 
    Console.WriteLine("| |__) | |__  | |  | |");
    Console.WriteLine("|  _  /|  __| | |  | |");
    Console.WriteLine("| | \\ \\| |____| |__| |");
    Console.WriteLine("|_|  \\_\\______|_____/ ");

Console.WriteLine("\nA text adventure game");
                       
                       
Console.ForegroundColor = ConsoleColor.White;

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


Console.WriteLine("\n\n\n\nR: " + runningOdds);
Console.WriteLine("W:" + playerWeight);


//--START OF GAME -- CHOOSE STARTING WEAPON--//

while (!hasChosenbeginningWeapon)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n   What do you choose? \n1. Pocket Knife\n2. Hammer");

beginningWeaponChoice = int.Parse(Console.ReadLine());

if (beginningWeaponChoice <1 || beginningWeaponChoice > 2)
    {
        Console.WriteLine("You can only choose between 1 and 2. Try again");
    }

else if (beginningWeaponChoice == 1)
{
    pMinDamage += pocketKnifeDamage;
    pMaxDamage += pocketKnifeDamage;
    playerWeight += pocketKnifeWeight;
    runningOdds -= playerWeight;
    //playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
}

else if (beginningWeaponChoice == 2)
{
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

Console.WriteLine("-- You are now walking in the forest and find blueberries and a red mysterious looking mushrooom --");
Console.WriteLine("\n\n\n\nR: " + runningOdds);
Console.WriteLine("W:" + playerWeight);
Console.ReadKey();


while (!hasChosenFoodFirst)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Do you eat the blueberries(1), the red mushroom(2) or do you continue without eating(3)?");
    foodChoice = int.Parse(Console.ReadLine());
    switch (foodChoice)
{
    case 1:
    playerHealth += 20;
    playerSpeed += 5;
    playerAccuracy += 10;
    Console.WriteLine("You feel more energiezed than before and your journey continues!");
    Console.ReadKey();
    hasChosenFoodFirst = true;
    break;

    case 2:
    playerHealth -= 20;
    playerSpeed -= 5;
    playerAccuracy -= 10;
    Console.WriteLine("You feel.... not so good... That probably wasn't a good idea but you continue");
    Console.ReadKey();
    hasChosenFoodFirst = true;
    break;

    case 3:
    Console.WriteLine("You decide to not eat and continue your journey...");
    Console.ReadKey();
    hasChosenFoodFirst = true;
    break;

    default:
    Console.WriteLine("You must choose 1, 2 or 3. Try again");
    break;
}
}

//--WOLF ENCOUNTER - FIGHT--//
Console.ForegroundColor = ConsoleColor.White;


Console.WriteLine("Next Level");
Console.ReadKey();



battle = true;

while (battle)
{
    Console.WriteLine("Battle");
    Console.ReadKey();

    if (!playersTurn && !wolfsTurn)
    {
        playersTurn = true;
    }

    while (playersTurn)
    {
        playerDamage = rnd.Next(pMinDamage, pMaxDamage);
        dice = rnd.Next(1,100);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Use your " + currentWeapon + " (1)");
        Console.WriteLine("Try to run (2)");
        battleChoice = int.Parse(Console.ReadLine());

        switch(battleChoice){

            case 1:
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
                    Console.WriteLine("You succesfully hit the wolf with your " + currentWeapon);
                    Console.WriteLine("Player dmg: " + playerDamage);
                    Console.WriteLine("Player min dmg: " + pMinDamage);
                    Console.WriteLine("Player max dmg: " + pMaxDamage);
                    Console.WriteLine("Running oods: " + runningOdds);
                    Console.WriteLine("Player health: " + playerHealth);
                    Console.WriteLine("Player acc: " + playerAccuracy);
                    Console.WriteLine("Dice: " + dice);
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
            if (runningOdds < dice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You tried to run but the wolf is just to fast for you");
                    Console.ReadKey();
                    playersTurn = false;
                    wolfsTurn = true;
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You succesfully ran away from the wolf");
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

        if (playerHealth <= 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The wolf has killed you");
            Console.ReadKey();
            playersTurn = false;
            wolfsTurn = false;
            battle = false;
        }

        while (wolfsTurn)
        {
            wolfDamage = rnd.Next(wMinDmg, wMaxDmg);
            dice = rnd.Next(1,100);
            if (wolfAccuracy >= dice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                playerHealth -= wolfDamage;
                Console.WriteLine("The wolf attacked you.... it hurts");
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

    if (canRun || unlikelyEnding)
    {
        battle = false;
    }

}

Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Next Level");