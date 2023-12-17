using System;

namespace WizardCalculator
{
    internal class Program
    {
        private static int cantrips = 0;
        private static int firstLevel = 0;
        private static int secondLevel = 0;
        private static int thirdLevel = 0;
        private static int fourthLevel = 0;
        private static int fifthLevel = 0;
        private static int sixthLevel = 0;
        private static int seventhLevel = 0;
        private static int eighthLevel = 0;
        private static int ninthLevel = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1.) Add Spells");
                Console.WriteLine("2.) Calculate Time and Gold");
                Console.WriteLine("3.) Exit");
                Console.WriteLine("Enter a number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Spell();
                        break;
                   
                   case "2":
                        
                       int decipherTime = cantrips + firstLevel + secondLevel + thirdLevel + fourthLevel + fifthLevel + sixthLevel + seventhLevel + eighthLevel + ninthLevel;
                        Console.WriteLine($"Time to dechipher is {decipherTime} hours (assuming you succeed all)");

                        double writeTime = (cantrips * 0.5) + (firstLevel * 1) + (secondLevel * 2) + (thirdLevel * 3) + (fourthLevel * 4) + (fifthLevel * 5) + (sixthLevel * 6) + (seventhLevel * 7) + (eighthLevel * 8) + (ninthLevel * 9) ;          
                        Console.WriteLine($"Time to write is {writeTime} hours (assuming you succeed all)");
                        double costOfWriting = (cantrips * 5) + (firstLevel * 10 ) + (secondLevel * 40) + (thirdLevel * 90) + (fourthLevel * 160) + (fifthLevel * 250) + (sixthLevel * 360) + (seventhLevel * 490) + (eighthLevel * 640) + (ninthLevel * 810);
                        Console.WriteLine($"Cost of writing is {costOfWriting} gp (assuming you succeed all)");

                        double costOfCopy = (cantrips * 2.5) + (firstLevel * 5) + (secondLevel * 20) + (thirdLevel * 45) + (fourthLevel * 80) + (fifthLevel * 125) + (sixthLevel * 180) + (seventhLevel * 245) + (eighthLevel * 320) + (ninthLevel * 405);
                        Console.WriteLine($"Cost of copying is {costOfCopy} gp (assuming you succeed all)");

                        Console.WriteLine(costOfCopy + costOfWriting + "gp total cost");
                        Console.WriteLine(decipherTime + writeTime + "hours total time");
                        
                        double workTime = decipherTime + writeTime;
                        workTime = workTime / 8;
                        Console.WriteLine(workTime + "days total time");
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;
                }
            }
        }

        static void Spell()
        {
            Console.WriteLine("How many cantrips do you want to add?");
            cantrips = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 1st level spells do you want to add?");
            firstLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 2nd level spells do you want to add?");
            secondLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 3rd level spells do you want to add?");
            thirdLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 4th level spells do you want to add?");
            fourthLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 5th level spells do you want to add?");
            fifthLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 6th level spells do you want to add?");
            sixthLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 7th level spells do you want to add?");
            seventhLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 8th level spells do you want to add?");
            eighthLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many 9th level spells do you want to add?");
            ninthLevel = Convert.ToInt32(Console.ReadLine());


         
            Console.WriteLine("Thanks! Data Saved!");
        }
    }
}