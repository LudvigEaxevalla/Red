using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

//Console


//Player var

Random rnd = new Random();
int playerHealth = 100;
int pMinDamage = 1;
int pMaxDamage = 3;
int playerDamage = rnd.Next(pMinDamage,pMaxDamage);
int playerCrit = rnd.Next(10,15);
double playerSpeed = 20;
double playerWeight = 0;
int playerAccuracy = 70;
string[] currentWeapon = {"Knife", "Axe", "Dads Rifle", "Butcher Knife", "AK47"};
string selectedWeapon = "";

//Wolf var

int wolfHealth = 500;
int wMinDmg = 20;
int wMaxDmg = 40;
int wolfDamage = rnd.Next(wMinDmg,wMaxDmg);
// int wolfSpeed = 50;
int wolfAccuracy = rnd.Next(10,30);
bool wolfDeath = false;

//Game
int dice= rnd.Next(1,100);
bool showTips = false;
string choice = "";
bool hasChosenTip = false;
// bool godMode = false;

//Grandma var

int grandmaHealth = 3;

//Weapon damage
int knifeDamage = 5;
int axeDamage = 12;
int rifleDamage = 8;
int ak47Damage = 1000;

//Weapon Choices
bool hasChosenbeginningWeapon = false;
int beginningWeaponChoice;
int endgameWeaponChoice;

//Food Choices
int foodChoice;
bool hasChosenFoodFirst = false;

//Weigth stuff
double knifeWeight = 2;
double axeWeight = 5;
double rifleWeight = 15;
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

//Deep forest
//int direction;
bool deepForest = false;



bool startPoint = false;
bool southArea = false;
bool northArea = false;
bool eastArea = false;
bool westArea = false;
bool southWestArea = false;
bool southEastArea = false;
bool northEastArea = false;
bool northWestArea = false;
bool pathArea = false;
bool foundPath = false;


int x = 0;
int y = 0;
int position = x+y;

int takeRifle = 0;
bool tookRifle = false;


//Maps     //Arrows - → ↑ ← ↓


string mapStart = @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        -                          -                            
        < West                East >
        -                          -
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";
    //East
string mapEast =  @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        -                          §
                                   §
        < West                     §
        -                          §
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";
string mapSouthEast =  @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        -                          §                                   
        < West                     §
        -                          §
        §                          §
        §                          §
        §                          §
         ~~~~~~~~~~~~~~~~~~~~~~~~~~";
string mapNorthEast =   @"
         ~~~~~~~~~~~~~~~~~~~~~~~~~~
        §                          §
        §                          §
        §                          §
        -                          §                           
        < West                     §
        -                          §
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";
    //West
string mapWest = @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        §                          -                        
        §                     East >
        §                          -
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";
string mapSouthWest = @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        §                          -
        §                     East >
        §                          -
        §                          §
        §                          §
        §                          §
         ~~~~~~~~~~~~~~~~~~~~~~~~~~";
string mapNorthWest = @"
         ~~~~~~~~~~~~~~~~~~~~~~~~~~
        §                          §
        §                          §
        §                          §
        -                          -                            
        < West                East >
        -                          -
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";
    //South
string mapSouth = @"
         ~~~~~~~~~~| ^ |~~~~~~~~~~
        §                          §
        §          North           §
        §                          §
        -                          -                            
        < West                East >
        -                          -
        §                          §
        §                          §
        §                          §
         ~~~~~~~~~~~~~~~~~~~~~~~~~~";
    //North
string mapNorth = @"
         ~~~~~~~~~~~~~~~~~~~~~~~~~~
        §                          §
        §                          §
        §                          §
        -                          -                            
        < West                East >
        -                          -
        §                          §
        §           South          §
        §                          §
         ~~~~~~~~~~| \/ |~~~~~~~~~~";

string currentMap = mapStart;

//Areas

/* 

1. Home
2. Forest part 1
3. Forest part 2 (wolf)
4. Forest part 3 (rest)
5. Grandmas house

*/

ConsoleKeyInfo keyInfo;
keyInfo = Console.ReadKey(true);


void PlayerDeath() 
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Game Over");
    Console.ReadKey();
    Environment.Exit(0);
}



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
    Console.WriteLine("\n\nBefore we begin: ");
    Console.WriteLine("\nWould you like explanations on how the game works from time to time?");
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
            Console.WriteLine("Explanations and stats will NOT be shown");
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

Console.WriteLine(@"It's the end of the week, early morning, when your mother calls out to you from the kitchen. 
You take a break from tending to the flames to go see what she wants.");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Write(@"“Be a dear and take that basket to grandmother's place.”");
Console.ResetColor();
Console.WriteLine(" your mother instructs without turning her attention away from the sink,");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("“There's heavy snowfall coming and I don't want her to run out of food out there.“");
Console.ResetColor();
Console.ReadKey();
Console.WriteLine("");
Console.Write(@"You look to where your mother points, a basket filled with bread, and a couple of pies rests on the table. 
As you take the basket with a small huff, it's heavier than you are used to.");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(" “Okay.” ");
Console.ResetColor();
Console.Write("you say as you move to the front door.");
Console.WriteLine("");
Console.WriteLine("");
Console.BackgroundColor = ConsoleColor.Red;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(@"“And be careful out there! Stay in the path, stay out of danger.“");
Console.ResetColor();
Console.WriteLine("");
Console.WriteLine("You hum and nod to yourself, you should grab yourself a weapon before heading off.");
Console.ReadKey();
isCarryingGrandmasFood = true;

if (isCarryingGrandmasFood)
{
    playerWeight += grandmaFoodWeight;
}

/*
else
{
    playerWeight -= grandmaFoodWeight;
} */

runningOdds -= playerWeight;

//--START OF GAME -- CHOOSE STARTING WEAPON--//

while (!hasChosenbeginningWeapon)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(@"Taking a knife with you sounds good, you think as you shrug your red winter cloak on, but then you glance at the door. 
On the side of it, where the shoes usually go, is the");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.Write(" axe ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("your father used to chop wood with yesterday.");
    Console.ResetColor();
    Console.WriteLine("");
    Console.WriteLine("(1) “Yeah, I'll grab a knife.”");
    Console.WriteLine("(2) “I'll take dad's axe instead.”");

    beginningWeaponChoice = int.Parse(Console.ReadLine()!);


if (beginningWeaponChoice == 1337)
    {
        selectedWeapon = currentWeapon[3];
        pMinDamage += ak47Damage;
        pMaxDamage += ak47Damage;
        playerAccuracy = 100;
        hasChosenbeginningWeapon = true;
        runningOdds = 101;
    }
    

else if (beginningWeaponChoice <1 || beginningWeaponChoice > 2 && beginningWeaponChoice != 1337) 
    {
        Console.WriteLine("You can only choose between (1) and (2). Try again");
    }  

else if (beginningWeaponChoice == 1)
{
    selectedWeapon = currentWeapon[0];
    pMinDamage += knifeDamage;
    pMaxDamage += knifeDamage;
    playerWeight += knifeWeight;
    playerAccuracy += 10;
    //playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
    Console.WriteLine("As you come to a decision, the knife feels secure in your hand");
    Console.ReadKey();
}

else if (beginningWeaponChoice == 2)
{
    selectedWeapon = currentWeapon[1];
    pMinDamage += axeDamage;
    pMaxDamage += axeDamage;
    playerWeight += axeWeight;
    playerAccuracy -= 5;
    //playerSpeed -= playerWeight;
    hasChosenbeginningWeapon = true;
    Console.WriteLine("As you come to a decision, the axe is heavy but sturdy in your grip, though you have to use both hands for it.");
    Console.ReadKey();
}

}

/*Console.WriteLine(playerDamage);
Console.WriteLine(playerWeight);
Console.WriteLine(playerSpeed);
Console.WriteLine(playerHealth);
Console.ReadKey(); */ 

Console.Clear();
Console.WriteLine(@"Your eyes slide over to the fireplace. On top of the mantle, resting easy, is your father's old hunting rifle.

You could grab that instead.
");



Console.WriteLine("(1) “Bullets are better than a blade, I'll take it.”");
Console.Write("(2). “No, I will stick with my ”");
Console.WriteLine(selectedWeapon + "”");
takeRifle = int.Parse(Console.ReadLine()!);

if (takeRifle < 1 || takeRifle > 2)
{
    Console.WriteLine("Invalid option, try again");
} 

else if (takeRifle == 1)
{
    tookRifle = true;
    if (selectedWeapon == currentWeapon[0])
    {
        playerWeight -= knifeWeight;
        playerDamage -= knifeDamage;
    }
    else if (selectedWeapon == currentWeapon[1])
    {
        playerWeight -= axeWeight;
        playerDamage -= knifeDamage;
    }
    selectedWeapon = currentWeapon[2];
    playerWeight += rifleWeight;
    playerDamage += rifleDamage;
}

else if (takeRifle == 2)
{
    tookRifle = false;
}
runningOdds -= playerWeight;

Console.Clear();
//--FOREST PART 1--//
Console.ForegroundColor = ConsoleColor.Green;
 Console.WriteLine(" _______ _    _ ______   ______ ____  _____  ______  _____ _______");
 Console.WriteLine("|__   __| |  | |  ____| |  ____/ __ \\|  __ \\|  ____|/ ____|__   __|");
 Console.WriteLine("   | |  | |__| | |__    | |__ | |  | | |__) | |__  | (___    | | ");  
 Console.WriteLine("   | |  |  __  |  __|   |  __|| |  | |  _  /|  __|  \\___ \\   | | ");  
 Console.WriteLine("   | |  | |  | | |____  | |   | |__| | | \\ \\| |____ ____) |  | |  ");  
 Console.WriteLine("   |_|  |_|  |_|______| |_|    \\____/|_|  \\_\\______|_____/   |_| ");   
                                                                    

Console.ResetColor();
Console.WriteLine(@"

The forest is dense and dark even in the light of day. 
The trees are old and tall enough that they stop any light from penetrating through. 
Not that there would be a lot of light to use as is, the day is gloomy and cold, but it's still visible 
enough for you to navigate the path that cuts through the densely populated woods.
The path is something your father cleared when your grandmother first moved into the woods. 
It has obvious markers to make it easy to stay in it and to keep wildlife from easily crossing into it.
");
Console.ReadKey();
Console.Write(@"On the edges of the dirt road there’s wild grass and bushes growing. 
You travel down a good bit of the path now nearing the middle of the forest, everything around you sounds alive, 
from twigs snapping to leaves rustling as deer and other forest creeters scamper around. 

You are starting to get winded, and even worse you are starting to get bored when your eye catches 
onto a");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write(" blueberry bush");
Console.ResetColor();
Console.Write(" in a ring of ");
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.Write("mysterious red mushrooms ");
Console.ResetColor();
Console.WriteLine("resting by a broken part of the path.");
Console.WriteLine(@"Your grandmother always says to be careful of mushrooms forming a ring for…some reason.

But the blueberries look so delicious and like just the thing that would help you get rid of the dreaded boredom. 
In fact, the mushrooms also look like they could be a good bite. You do have to head to grandmother’s place though, 
and it is starting to get dark…
");

Console.ReadKey();


while (!hasChosenFoodFirst)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("(1) Eat a handful of blueberries.");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("(2) Take a cautious bite of one of the mushrooms, breaking the circle.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("(3) Continue on the way.");
    foodChoice = int.Parse(Console.ReadLine()!);    
    Console.Clear();
    Console.ResetColor();
    switch (foodChoice)
{
    case 1:
    playerHealth += 15;
    playerSpeed += 5;
    playerAccuracy += 5;
    Console.WriteLine(@"
    You reach a hand out and grab a cluster of berries off the bush. 
    You eat them all in one bite, juices and deliciousness bursting in your mouth.

    Refreshing, you feel rejuvenated and ready for the road ahead once more. 
    Another handful couldn’t hurt right?

    But as you reach for another cluster, eager to taste them again, the bush rustles and 
    you feel a heavy footfall land in front of you just outside your field of view.
");
    Console.ReadKey();
    Console.Clear();
    hasChosenFoodFirst = true;
    break;

    case 2:
    playerHealth -= 15;
    playerSpeed -= 5;
    playerAccuracy -= 7;
    Console.WriteLine(@"
    Not letting yourself think too hard about it you pluck out one of the mushrooms off the rong and pop it in your mouth.

    The taste is…nothing of note, pretty bland actually.

    Before you can be too disappointed though, you feel an immense wave of dizziness hit you, 
    your head swims and you have to fight with yourself to stay upright.

    Eating unknown mysterious red mushrooms, you can almost hear your mother sighing in 
    exasperation. Not the smartest idea you’ve ever had.
");
    hadMushroomsBefore = true;
    Console.ReadKey();
    Console.Clear();
    hasChosenFoodFirst = true;
    break;

    case 3:
    Console.WriteLine(@"
    Your mother’s stern voice plays in your head, no straying from the path. 
    You need to get the food to your grandmother before it gets too dark to head back home after.

    With your mind made up and your motivation renewed you turn to continue on your way 
    only for you to freeze as movement becomes obvious behind you.
");
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
        Console.WriteLine("There is always a chance that you will miss the wolf when attacking in Which case it will be the wolfs turn");
        Console.WriteLine("If you hit the wolf, the wolf will become a bit slower and your chances of running away increses \n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("2. You can try to run away from the wolf.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("At first you will have no chanses of running from the wolf. It only increases when you succesfully hit the wolf");
        Console.WriteLine("When you try to run, a number will show how long you have to go. This number always changes");
        Console.WriteLine("After - your distance is shown. If your distance more or the same as the first number, you will successfully run from the wolf");
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
      


        while (wolfsTurn && !wolfDeath) 
        {

        if (wolfHealth <= 0)
        {
            unlikelyEnding = true;
            wolfDeath = true;
            battle = false;
        }

        else
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

            if (wolfAccuracy > dice)
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


    }

    if (canRun || wolfDeath || playerDeath)
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
            Console.WriteLine("The wolf has killed you");
            PlayerDeath();
            Console.ReadKey();

        }

else if (unlikelyEnding)
{
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You somehow against all odds, managed to kill the wolf.");
        Console.ReadKey();
}

else
{
    //Next Chapter - Everything will be in this else statement, its just how its gonna be
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkGreen;

        //I was today years old when I found out I could've done this the whole time
        Console.WriteLine(@"
     _____  ______ ______ _____    ______ ____  _____  ______  _____ _______ 
    |  __ \|  ____|  ____|  __ \  |  ____/ __ \|  __ \|  ____|/ ____|__   __|
    | |  | | |__  | |__  | |__) | | |__ | |  | | |__) | |__  | (___    | |   
    | |  | |  __| |  __| |  ___/  |  __|| |  | |  _  /|  __|  \___ \   | |   
    | |__| | |____| |____| |      | |   | |__| | | \ \| |____ ____) |  | |   
    |_____/|______|______|_|      |_|    \____/|_|  \_\______|_____/   |_|   
    ");
    Console.ResetColor();
    Console.WriteLine("\n\n");
    Console.WriteLine(@"
    When running you completely lost your sense of direction and the path you followed 
    is no longer in sight. You rest for a while and altough you feel better after it, your're still
    not fully yourself. You now find yourself hungry, hurt and lost. If you only find the path again,
    you will know where to go from there.

    ");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("[Enter→]");
    Console.ResetColor();

    playerHealth += 30;
    Console.ReadKey();
    startPoint = true;
    deepForest = true;
    bool mushroomDecision = false;
    bool blueberryDecision = false;
    bool appleDecision = false;
    int healthDecay = 6;
    int appleDecay = 15;
    int appleChance = 25;
    int mushroomChance = 50;
    int blueberryChance = 50;

    void Apples()
    {
        int applesOption;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (appleDecay >= 5)
        {
            Console.WriteLine(@"
            You find some fallen apples. They look fresh enough you think");
        }
        else if (appleDecay < 5)
        {
            Console.WriteLine(@"
            You find some fallen apples. It looks like they've been here a while");
        }

        Console.WriteLine("1.Eat the apples 2. Keep moving");
        applesOption = int.Parse(Console.ReadLine()!);

        switch (applesOption)
        {
 
            case 1:
                int goodApple = 4;
                int appleDice = rnd.Next(0,6);
                Console.Clear();
                if (appleDecay >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You eat the apples and feel much better than before");
                    playerHealth += 50;    
                }

                else if (appleDecay < 5 && appleDice >= goodApple)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Even though the apples aren't fresh, they were good enough to eat and you feel better");
                    playerHealth += 30;    
                }

                else if (appleDecay < 5 && appleDice < goodApple)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Theese apples must've been on the ground for too long. You dont feel so good about eating them");
                    playerHealth -= 10;
                }
                appleDecision = true;
                Console.ReadKey();

            break;

            case 2:
                Console.Clear();
                Console.WriteLine("You leave the apples behind");
                appleDecision = true;
                Console.ReadKey();
            break;

            default:
                Console.WriteLine("Try again...");
                Console.ReadKey();
            break;
        }

    }

   
    void BlueBerries()
    {
        int blueBerryOption;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"
        You found blueberries!
        Do you eat them?");
        Console.WriteLine("1. Eat the blueberries\n2. Keep moving");
        blueBerryOption = int.Parse(Console.ReadLine()!);

        switch(blueBerryOption)
        {
            case 1:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You eat the blueberries and feel somewhat than before");
                playerHealth += 10;
                blueberryDecision = true;
                Console.ReadKey();

            break;

            case 2:
                Console.Clear();
                Console.WriteLine("You leave the blueberries behind");
                blueberryDecision = true;
                Console.ReadKey();
            break;

            default:
                Console.WriteLine("Try again...");
                Console.ReadKey();
            break;
        }
    }


void Mushrooms()
    {
        int mushroomOption;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if (hadMushroomsBefore)
        {
            Console.WriteLine(@"
            You find the same Red Mushrooms you ate earlier, maybe it won't be so bad this time?");
            Console.WriteLine("1. Eat the mushrooms\n2. Use common sense");
            mushroomOption = int.Parse(Console.ReadLine()!);         
        }
        else
        {
            Console.WriteLine(@"
            You find the same Red Mushrooms you saw before, will you try them now?");
            Console.WriteLine("1. Eat the mushrooms\n2. Leave them");
            mushroomOption = int.Parse(Console.ReadLine()!);     
        }

        switch(mushroomOption)
        {
            case 1:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (hadMushroomsBefore)
                {
                    Console.WriteLine("You feel so much worse now... Why would you think it would be a good idea a second time?");
                    
                }
                else
                {
                    Console.WriteLine("That wasn't a good idea... You feel worse than before");
                }
                playerHealth -= 10;
                mushroomDecision = true;
                Console.ReadKey();

            break;

            case 2:
                Console.Clear();
                Console.WriteLine("You leave the mushrooms behind");
                mushroomDecision = true;
                Console.ReadKey();
            break;

            default:
                Console.WriteLine("Try again...");
                Console.ReadKey();
            break;
        }
    }

    while (deepForest && !pathArea && !playerDeath)
    {
        if (playerHealth <= 0 )
        {
            playerDeath = true;
        }

        Console.ResetColor();
        Console.Clear();
        if (showTips)
        {
            Console.WriteLine("Health: " + playerHealth); 
           // Console.WriteLine("Apple Decay: " + appleDecay);
        }
        Console.WriteLine(currentMap + "\n\n");
        if (startPoint)
        {

            Console.WriteLine("Which way do you go?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n(Use the arrows on your keyboard to move around)");
            Console.ResetColor();

            //Console.WriteLine("1. West | 2. North | 3. South | 4. East");
            //direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            startPoint = false;


            switch(keyInfo.Key)
            {
                //Go West
                case ConsoleKey.LeftArrow:
                    westArea = true;
                    currentMap = mapWest;
                    playerHealth -= healthDecay;
                    appleDecay--;
                break;
                
                //Go North
                case ConsoleKey.UpArrow:          
                    northArea = true;
                    currentMap = mapNorth;
                    playerHealth -= healthDecay;
                    appleDecay--;

                break;

                //Go South
                case ConsoleKey.DownArrow:
                    southArea = true;
                    currentMap = mapSouth;
                    playerHealth -= healthDecay;
                    appleDecay--;

                break;

                //Go East
                case ConsoleKey.RightArrow:
                    eastArea = true;
                    currentMap = mapEast;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                default:
                    Console.WriteLine("try again");
                    startPoint = true;
                break;


            }

        }

        else if (northArea)
        {
            dice = rnd.Next(1,100);
            if (!mushroomDecision && dice < mushroomChance)
            {
                Mushrooms();
            }
    else
        {
                
            Console.WriteLine("Which way do you go?");
            //Console.WriteLine("1. West | 2. South | 3. East");
            //direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            northArea = false;

            switch(keyInfo.Key)
            {

                //Go West
                case ConsoleKey.LeftArrow:
                    northWestArea = true;
                    currentMap = mapNorthWest;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go South
                case ConsoleKey.DownArrow:
                    startPoint = true;
                    currentMap = mapStart;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go East
                case ConsoleKey.UpArrow:
                    northEastArea = true;
                    currentMap = mapNorthEast;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                default:
                    Console.WriteLine("try again");
                    northArea = true;
                break;


            }
            
        }
        
        }
        else if (southArea)
        {
            dice = rnd.Next(1,100);

            if (!mushroomDecision && dice < mushroomChance)
            {
                Mushrooms();
            }
        else
        {
                
            Console.WriteLine("Which way do you go?");
            //Console.WriteLine("1. West | 2. North | 3. East");
            //direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            southArea = false;

            switch(keyInfo.Key)
            {

                //Go West
                case ConsoleKey.LeftArrow:
                    southWestArea = true;
                    currentMap = mapSouthWest;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go North
                case ConsoleKey.UpArrow:
                    startPoint = true;
                    currentMap = mapStart;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go East
                case ConsoleKey.RightArrow:
                    southEastArea = true;
                    currentMap = mapSouthEast;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                default:
                    Console.WriteLine("try again");
                    southArea = true;
                break;


            }
            
        }
        }
        
        else if (eastArea)
        {
            Console.WriteLine("Which way do you go?");
            //Console.WriteLine("1. West | 2. North | 3. South");
            //direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            eastArea = false;

            switch(keyInfo.Key)
            {

                //Go West
                case ConsoleKey.LeftArrow:
                    startPoint = true;
                    currentMap = mapStart;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go North
                case ConsoleKey.UpArrow:
                    northEastArea = true;
                    currentMap = mapNorthEast;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go South
                case ConsoleKey.DownArrow:
                    southEastArea = true;
                    currentMap = mapSouthEast;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                default:
                    Console.WriteLine("try again");
                    eastArea = true;
                break;


            }
            
        }
            
        else if (westArea)
        {
            Console.WriteLine("Which way do you go?");
           // Console.WriteLine("1. North | 2. South | 3. East");
           // direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            westArea = false;

            switch(keyInfo.Key)
            {

                //Go North
                case ConsoleKey.UpArrow:
                    northWestArea = true;
                    currentMap = mapNorthWest;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go South
                case ConsoleKey.DownArrow:
                    southWestArea = true;
                    currentMap = mapSouthWest;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go East
                case ConsoleKey.RightArrow:
                    startPoint = true;
                    currentMap = mapStart;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                default:
                    Console.WriteLine("try again");
                    westArea = true;
                break;


            }
            
        }

        else if (northEastArea)
        {
            dice = rnd.Next(0,100);
            if (!blueberryDecision && dice < blueberryChance)
            {
                BlueBerries();
            }
                else
                {
                    
                    Console.WriteLine("Which way do you go?");
                   // Console.WriteLine("1. West | 2. South");
                   // direction = int.Parse(Console.ReadLine()!);
                    keyInfo = Console.ReadKey();
                    northEastArea = false;

                    switch(keyInfo.Key)
                    {

                        //Go West
                        case ConsoleKey.LeftArrow:
                            northArea = true;
                            currentMap = mapNorth;
                            playerHealth -= healthDecay;
                            appleDecay--;


                        break;

                        //Go South
                        case ConsoleKey.DownArrow:
                            eastArea = true;
                            currentMap = mapEast;
                            playerHealth -= healthDecay;
                            appleDecay--;


                        break;

                        default:
                            Console.WriteLine("try again");
                            northEastArea = true;
                        break;


                    }
                }
            
        }

        else if (northWestArea)
        {
            dice = rnd.Next(0,100);
            if (!appleDecision && dice < appleChance)
            {
                Apples();
            } 
                else
                {
                    
                    Console.WriteLine("Which way do you go?");
                  //  Console.WriteLine("1. West | 2. South | 3. East");
                  //  direction = int.Parse(Console.ReadLine()!);
                    keyInfo = Console.ReadKey();
                    northWestArea = false;

                    switch(keyInfo.Key)
                    {

                        //Go West
                        case ConsoleKey.LeftArrow:
                            pathArea = true;
                            foundPath = true;
                        break;

                        //Go South
                        case ConsoleKey.DownArrow:
                            westArea = true;
                            currentMap = mapWest;
                            playerHealth -= healthDecay;
                            appleDecay--;


                        break;

                        //Go East
                        case ConsoleKey.RightArrow:
                            northArea = true;
                            currentMap = mapNorth;
                            playerHealth -= healthDecay;
                            appleDecay--;


                        break;

                        default:
                            Console.WriteLine("try again");
                            northWestArea = true;
                        break;


                    }
                }
            
        }

        else if (southWestArea)
        {
            dice = rnd.Next(0,100);
            if (!appleDecision && dice < appleChance)
            {
                Apples();
            }

            else
            {
                
            Console.WriteLine("Which way do you go?");
           // Console.WriteLine("1. North | 2. East");
           // direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            southWestArea = false;

            switch(keyInfo.Key)
            {

                //Go North
                case ConsoleKey.UpArrow:
                    westArea = true;
                    currentMap = mapWest;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;

                //Go East
                case ConsoleKey.RightArrow:
                    southArea = true;
                    currentMap = mapSouth;
                    playerHealth -= healthDecay;
                    appleDecay--;


                break;


                default:
                    Console.WriteLine("try again");
                    southWestArea = true;
                break;


            }
        }
            
        }

        else if (southEastArea)
        {
            dice = rnd.Next(0,100);
            if (!blueberryDecision && dice < blueberryChance)
            {
                BlueBerries();
            }
    else
    {
                
            Console.WriteLine("Which way do you go?");
           // Console.WriteLine("1. West | 2. North");
           // direction = int.Parse(Console.ReadLine()!);
            keyInfo = Console.ReadKey();
            southEastArea = false;

            switch(keyInfo.Key)
            {

                //Go West
                case ConsoleKey.LeftArrow:
                    southArea = true;
                    currentMap = mapSouth;
                    playerHealth -= healthDecay;
                    appleDecay--;

                break;

                //Go North
                case ConsoleKey.UpArrow:
                    eastArea = true;
                    currentMap = mapEast;
                    playerHealth -= healthDecay;
                    appleDecay--;

                break;


                default:
                    Console.WriteLine("try again");
                    southEastArea = true;
                break;


            }
            
        }
    }

    } 



    if (playerDeath)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You wandered for too long and died");
        Console.ReadKey();
        PlayerDeath();
    }

    
    if (foundPath)
    {
        Console.Clear();
        Console.WriteLine("You found the path!");
        Console.ReadKey();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"

  _____ ___ _   _    _    _       ____  _   _  _____        ______   _____        ___   _ 
 |  ___|_ _| \ | |  / \  | |     / ___|| | | |/ _ \ \      / /  _ \ / _ \ \      / / \ | |
 | |_   | ||  \| | / _ \ | |     \___ \| |_| | | | \ \ /\ / /| | | | | | \ \ /\ / /|  \| |
 |  _|  | || |\  |/ ___ \| |___   ___) |  _  | |_| |\ V  V / | |_| | |_| |\ V  V / | |\  |
 |_|   |___|_| \_/_/   \_\_____| |____/|_| |_|\___/  \_/\_/  |____/ \___/  \_/\_/  |_| \_|


        ");
        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Blah blah blah REVENGE! blah blah");


    }

    



}

