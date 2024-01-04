using System;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.Serialization;

namespace WizardCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string wizSchool = "";
            int spellcraftMod = 0;
            
            List<Spell> spellList = new List<Spell>();

            Console.WriteLine("Welcome to the Wizard Calculator!");
            Console.WriteLine("What is your Wizard school?");
            Console.WriteLine("1.) Evocation");
            Console.WriteLine("2.) Necromancy");
            Console.WriteLine("3.) Conjuration");
            Console.WriteLine("4.) Enchantment");
            Console.WriteLine("5.) Divination");
            Console.WriteLine("6.) Abjuration");
            Console.WriteLine("7.) Transmutation");
            Console.WriteLine("8.) Illusion");
            Console.WriteLine("9.) Universalist/Other");
            ;
            Console.WriteLine("Enter a number: ");
            string wizChoice = Console.ReadLine();

            switch (wizChoice)
            {
                case "1":
                    wizSchool = "evo";
                    break;
                case "2":
                    wizSchool = "nec";
                    break;
                case "3":
                    wizSchool = "con";
                    break;
                case "4":
                    wizSchool = "enc";
                    break;
                case "5":
                    wizSchool = "div";
                    break;
                case "6":
                    wizSchool = "abj";
                    break;
                case "7":
                    wizSchool = "tra";
                    break;
                case "8":
                    wizSchool = "ill";
                    break;
                case "9":
                    wizSchool = "Other";
                    break;



            }





            while (true)
            {
                Console.WriteLine("------------------Menu-----------------");
                Console.WriteLine("1.) Add Spell");
                Console.WriteLine("2.) Print All Spells");
                Console.WriteLine("3.) Roll for dechipher and, to copy spells");
                Console.WriteLine("4.) Check Spell Write Time and cost (dechiper + copy)");
                Console.WriteLine("5.) Remove Spell from list ");
                Console.WriteLine("6.) Quick Add and Calc");
                Console.WriteLine("7.) Save Spell List");
                Console.WriteLine("8.) Load Spell List");
                Console.WriteLine("9.) Exit");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Enter a number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Spell(spellList);
                        break;

                    case "2":

                        foreach (Spell spell in spellList)
                        {
                            Console.WriteLine(spell);
                            Console.WriteLine(" ");

                        }

                        break;
                    case "3":
                        Console.WriteLine("What is your Spellcraft modifer?: ");
                        spellcraftMod = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("If somehow more difficult enter a the increase in DC (enter 0 if not appicble): ");
                        int addedDC = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Do you wish to take 10 with all spells Y/N");
                        string takeTen = Console.ReadLine();
                        switch (takeTen)
                        {
                            case "y":




                                foreach (Spell spell in spellList)
                                {


                                   






                                    int spellDechipherDC = 20 + spell.SpellInfo.spellLevel + addedDC;
                                    int spellCopyDC = 15 + spell.SpellInfo.spellLevel + addedDC;
                                    int WizardTake10 = 10 + spellcraftMod;
                                    if (WizardTake10 < spellDechipherDC)
                                    {
                                        Console.WriteLine($"You cannot Dechipher {spell.SpellInfo.spellName} by taking 10");

                                    }
                                    else
                                    {
                                        Console.WriteLine("You can both copy and dechipher the spell {0} by taking 10", spell.SpellInfo.spellName);
                                    }

                                }


                                break;
                            case "n":
                               
                                
                                foreach (Spell spell in spellList)
                                {
                                    int dRoll = random.Next(1, 21);
                                    int sRoll = random.Next(1, 21);
                                    int cRoll = random.Next(1, 21);


                                    int spellDechipherDC = 20 + spell.SpellInfo.spellLevel + addedDC;
                                    int spellCopyDC = 15 + spell.SpellInfo.spellLevel + addedDC;
                                    int spellStudyDC = 15 + spell.SpellInfo.spellLevel + addedDC;
                                    int dechipherRoll = dRoll + spellcraftMod;
                                    int copyRoll = cRoll + spellcraftMod;
                                   int studyRoll = sRoll + spellcraftMod;
                                    
                                    
                                    if (dechipherRoll < spellDechipherDC)
                                    {
                                        Console.WriteLine($"\n FAIL! You failed to Dechipher {spell.SpellInfo.spellName} with a roll of {dRoll} to a total of {dechipherRoll} (DC was {spellDechipherDC} ) ", Color.Red);


                                    }
                                    else
                                    {
                                       Console.WriteLine($"\nSUCCESS! You Dechiphered {spell.SpellInfo.spellName} with a roll of {dRoll} to a total of {dechipherRoll} (DC was {spellDechipherDC} ) ", Color.Green);
                                    }

                                   string spellSchool = spell.SpellSchool.ToString();

                                    if (wizSchool == spellSchool)
                                    {
                                        spellStudyDC -= 2;
                                        Console.WriteLine($"\nYou get a +2 to study {spell.SpellInfo.spellName} because it is in your school", Color.Blue);
                                    }
                                   
                               

                                    if (studyRoll < spellStudyDC)
                                    {
                                        Console.WriteLine($"\nFAIL! You failed to study {spell.SpellInfo.spellName} with a roll of {sRoll} to a toal of {studyRoll} DC was { spellStudyDC } ", Color.Red);


                                    }
                                    else
                                    {
                                        Console.WriteLine($"\nSUCCESS! studied {spell.SpellInfo.spellName} with a roll of {sRoll} to a toal of {studyRoll} DC was { spellDechipherDC } ", Color.Green );
                                    }

                                    if (copyRoll < spellCopyDC)
                                    {
                                        Console.WriteLine($"\nFAIL! You failed to Copy {spell.SpellInfo.spellName} with a roll of {cRoll} to a total of {copyRoll} (DC was {spellCopyDC} )", Color.Red);

                                    }
                                    else
                                    {
                                        Console.WriteLine($"SUCCESS! You Copied {spell.SpellInfo.spellName} with a roll of {cRoll} to a total of {copyRoll} (DC was {spellCopyDC} )", Color.Green );
                                    }

                                    
                                }
                                

                               
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
                        break;
                        case "4":
                        double studyTime = 0;
                        double copyTime = 0;
                        double studyFromOtherWizard = 0;
                        double copyCost = 0;
                        
                        foreach (Spell spell in spellList)
                        {
                          
                           
                            switch (spell.SpellInfo.spellLevel) { 
                                case 0:
                                studyTime += 1;
                                copyTime += 0.5;
                                studyFromOtherWizard += 2.5;
                                copyCost += 5;
                                    break;
                                    case 1:
                                    studyTime += 1;
                                    copyTime += 1;
                                    studyFromOtherWizard += 5;
                                    copyCost += 10;
                                    break;
                                    
                                    case 2:
                                    studyTime += 1;
                                    copyTime += 2;
                                    studyFromOtherWizard += 20;
                                    copyCost += 40;
                                    break;
                                    case 3:
                                    studyTime += 1;
                                    copyTime += 3;
                                    studyFromOtherWizard += 45;
                                    copyCost += 90;
                                    break;
                                    case 4:
                                    studyTime += 1;
                                    copyTime += 4;
                                    studyFromOtherWizard += 80;
                                    copyCost += 160;
                                    break;
                                    case 5:
                                    studyTime += 1;
                                    copyTime += 5;
                                    studyFromOtherWizard += 125;
                                    copyCost += 250;
                                    break;
                                    case 6:
                                    studyTime += 1;
                                    copyTime += 6;
                                    studyFromOtherWizard += 180;
                                    copyCost += 360;
                                    break;
                                    case 7:
                                    studyTime += 1;
                                    copyTime += 7;
                                    studyFromOtherWizard += 245;
                                    copyCost += 490;
                                    break;
                                    case 8:
                                    studyTime += 1;
                                    copyTime += 8;
                                    studyFromOtherWizard += 320;
                                    copyCost += 640;
                                    break;
                                    case 9:
                                    studyTime += 1;
                                    copyTime += 9;
                                    studyFromOtherWizard += 405;
                                    copyCost += 810;
                                    break;

                                default:
                                    Console.WriteLine("Spell other then 0-9 exists");
                                    break;

                                }
  
                        }
                        double totalTime = studyTime + copyTime;
                        double totalCost = studyFromOtherWizard + copyCost;
                        Console.WriteLine($"It will take {totalTime} hours to study and copy all spells");
                        Console.WriteLine($"It will cost {totalCost} gold to study and copy all spells");
                        Console.WriteLine($"If you didn't Study from another wizard it would cost {copyCost} gold to copy all spells");
                        
                        Console.WriteLine("How many hours a day can you work without penalty? (8 is normal)");
                        double hoursWorked = Convert.ToDouble(Console.ReadLine());
                        double daysWorked = totalTime / hoursWorked;
                        Console.WriteLine($"It will take {daysWorked} days to study and copy all spells");
                        
                        break;


                        case "5":
                        Console.WriteLine("Enter the name of the spell you wish to remove: ");
                        string spellToRemove = Console.ReadLine();
                        spellList.RemoveAll(x => x.SpellInfo.spellName == spellToRemove);
                        break;
                        case "6":
                        quickSpell();
                        break;
                    case "7":
                        Console.WriteLine("Are you sure you want to save? Y/N");
                        string save = Console.ReadLine();
                        switch (save)
                        {
                            case "y":
                                SaveSpellList(spellList);
                                Console.WriteLine("Spell list saved successfully.");
                                break;
                            case "n":
                                Console.WriteLine("Spell list not saved.");
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        
                        break;
                    case "8":
                        Console.WriteLine("Are you sure you want to load? Y/N");
                        string load = Console.ReadLine();
                        switch (load)
                        {
                            case "y":
                                spellList = LoadSpellList();
                                Console.WriteLine("Spell list loaded successfully.");
                                break;
                            case "n":
                                Console.WriteLine("Spell list not loaded.");
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        
                        break;






                    case "9":
                        
                        Environment.Exit(0);

                        break;
                        
                        



                }
                
            }

            static void Spell(List<Spell> spellList)
            {

                SpellInfo spellInfo = new SpellInfo();
                Console.WriteLine("Enter Spell Name: ");
                spellInfo.spellName = Console.ReadLine();
                Console.WriteLine("Enter Spell Level: ");
                spellInfo.spellLevel = Convert.ToInt32(Console.ReadLine());
                SpellSchool spellSchool = new SpellSchool();
                Console.WriteLine("Enter as 3 letter abbreviation (evo, nec, tra, enc, div, abj, con, ill, uni):");
                Console.WriteLine("");
                Console.WriteLine("Enter Spell School: ");
                spellSchool = (SpellSchool)Enum.Parse(typeof(SpellSchool), Console.ReadLine());


                Spell spell = new Spell(spellInfo, spellSchool);
                spellList.Add(spell);
                Console.WriteLine(spell);
                Console.WriteLine("Spell Added!");

            }

            static void SaveSpellList(List<Spell> spells)
            {
                using (StreamWriter writer = new StreamWriter("spellList.txt"))
                {
                    foreach (Spell spell in spells)
                    {
                        writer.WriteLine($"{spell.SpellInfo.spellName},{spell.SpellInfo.spellLevel},{spell.SpellSchool}");
                    }
                }
            }

            static List<Spell> LoadSpellList()
            {
                List<Spell> loadedSpells = new List<Spell>();
                if (File.Exists("spellList.txt"))
                {
                    using (StreamReader reader = new StreamReader("spellList.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3)
                            {
                                SpellInfo spellInfo = new SpellInfo
                                {
                                    spellName = parts[0],
                                    spellLevel = int.Parse(parts[1])
                                };
                                SpellSchool spellSchool = (SpellSchool)Enum.Parse(typeof(SpellSchool), parts[2]);
                                loadedSpells.Add(new Spell(spellInfo, spellSchool));
                            }
                        }
                    }
                }
                return loadedSpells;
            }
        



    }
        static void quickSpell()
        {

            int firstLevel = 0;
            int secondLevel = 0;
            int thirdLevel = 0;
            int fourthLevel = 0;
            int fifthLevel = 0;
            int sixthLevel = 0;
            int seventhLevel = 0;
            int eighthLevel = 0;
            int ninthLevel = 0;
            int cantrips = 0;





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

            int decipherTime = cantrips + firstLevel + secondLevel + thirdLevel + fourthLevel + fifthLevel + sixthLevel + seventhLevel + eighthLevel + ninthLevel;
            Console.WriteLine($"Time to dechipher is {decipherTime} hours (assuming you succeed all)");

            double writeTime = (cantrips * 0.5) + (firstLevel * 1) + (secondLevel * 2) + (thirdLevel * 3) + (fourthLevel * 4) + (fifthLevel * 5) + (sixthLevel * 6) + (seventhLevel * 7) + (eighthLevel * 8) + (ninthLevel * 9);
            Console.WriteLine($"Time to write is {writeTime} hours (assuming you succeed all)");
            double costOfWriting = (cantrips * 5) + (firstLevel * 10) + (secondLevel * 40) + (thirdLevel * 90) + (fourthLevel * 160) + (fifthLevel * 250) + (sixthLevel * 360) + (seventhLevel * 490) + (eighthLevel * 640) + (ninthLevel * 810);
            Console.WriteLine($"Cost of writing is {costOfWriting} gp (assuming you succeed all)");

            double costOfCopy = (cantrips * 2.5) + (firstLevel * 5) + (secondLevel * 20) + (thirdLevel * 45) + (fourthLevel * 80) + (fifthLevel * 125) + (sixthLevel * 180) + (seventhLevel * 245) + (eighthLevel * 320) + (ninthLevel * 405);
            Console.WriteLine($"Cost of copying is {costOfCopy} gp (assuming you succeed all)");

            Console.WriteLine(costOfCopy + costOfWriting + "gp total cost");
            Console.WriteLine(decipherTime + writeTime + "hours total time");

            double workTime = decipherTime + writeTime;
            workTime = workTime / 8;
            Console.WriteLine(workTime + "days total time");




        }

    }
}