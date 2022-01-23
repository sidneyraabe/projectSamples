using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int percent = 100, breeds = 5;
            int selector;
                
            int[] breedPercent = new int[breeds];
            string[] breedName = new string[] {"Labrador Retriever", "German Shepherd", "French Bulldog", "Poodle", "Beagle", "Dachshund",
            "Pembroke Welsh Corgi", "Yorkshire Terrier", "Siberian Husky", "Miniature Schnauzer", "Shih Tzu", "Boston Terrier", "Cocker Spaniel",
            "Border Collie", "Maltese", "Shiba Inu", "Chow Chow", "Rat Terrier", "Foxhound", "Greyhound", "Chihuahua", "West Highland White Terrier",
            "Scottish Terrier", "Pug", "Shetland Sheepdog", "Dalmatian", "Bloodhound", "Mastiff", "Boxer", "Pomeranian"};


            Console.Write("What is your dog's name? ");
            name = Console.ReadLine();
            Console.WriteLine("Alright, I obtained some info on " + name + "'s background on whatismydog.com. " +
                "I think it might be of interest to you...\n\n-------------------------------------\n" +
                " DNA REPORT FOR " + name.ToUpper() + ":\n-------------------------------------\n");                                    
            for (int i = 0; i < (breeds - 1); i++)
            {
                Random rnd = new Random();
                breedPercent[i] = rnd.Next(0, (percent / 2));                
                percent -= breedPercent[i];
            }
            breedPercent[breeds - 1] = percent; 

            for (int i = 0; i < breeds; i++)
            {
                while(true)
                {
                    Random rnd = new Random();
                    selector = rnd.Next(0, breedName.Length);
                    if (breedName[selector] != "used")
                        break;
                }
                Console.WriteLine("- " + breedPercent[i] + "% "+ breedName[selector]);
                breedName[selector] = "used";
            }            
        }
    }
}
