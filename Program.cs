using System;

//Console
Console.ForegroundColor = ConsoleColor.Red;

//Player var

Random rnd = new Random();
int playerHealth = 100;
int playerDamage = rnd.Next(1,5);
int playerCrit = rnd.Next(10,15);
double playerSpeed = 20;
double playerWeight = 0;
int playerAccuracy = 80;

//Wolf var

int wolfHealth = 500;
int wolfDamage = rnd.Next(20,40);
int wolfSpeed = 50;
int wolfAccuracy = 20;

//Game
int hitCheck= rnd.Next(1,100);

//Grandma var

int grandmaHealth = 3;

//Weapon damage
int pocketKnifeDamage = 2;
int hammerDamage = 5;
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
double pocketKnifeWeight = 1.5;
double hammerWeight = 5;
double grandmaFoodWeight = 5;


//Checking things
bool playerDeath = false;
bool hadMushroomsBefore = false;
bool isCarryingGrandmasFood = false;
bool unlikelyEnding = false;
bool goodEnding = false;
bool sadEnding = false;




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


//--START OF GAME -- CHOOSE STARTING WEAPON--//

while (!hasChosenbeginningWeapon)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n   What do you choose? \n1. Pocket Knife\n2. Hammer");
    isCarryingGrandmasFood = true;

beginningWeaponChoice = int.Parse(Console.ReadLine());

if (beginningWeaponChoice <1 || beginningWeaponChoice > 2)
    {
        Console.WriteLine("You can only choose between 1 and 2. Try again");
    }

else if (beginningWeaponChoice == 1)
{
    playerDamage += pocketKnifeDamage;
    playerWeight += pocketKnifeWeight;
    playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
}

else if (beginningWeaponChoice == 2)
{
    playerDamage += hammerDamage;
    playerWeight += hammerWeight;
    playerSpeed -= playerWeight;
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

//BRANCH BALANCE//

