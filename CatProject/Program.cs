using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatProject
{
    class Cat
    {
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public int Energy { get; set; } = 100;
        public decimal Price { get; set; } = 0;
        public decimal MealQuantity { get; set; } = 250;


        public Cat(string nickname, string gender, int energy, decimal price, decimal quantity)
        {
            Nickname = nickname;
            Gender = gender;
            Energy = energy;
            Price = price;
            MealQuantity = quantity;
        }

        public void ShowData()
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("~~~~~~~~~~~~~~~DATA~~~~~~~~~~~~~~\n");
            // Console.ResetColor();
            //  Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" Nickname : {Nickname}");
            Console.WriteLine($" Gender : {Gender}");
            Console.WriteLine($" Energy : {Energy} %");
            Console.WriteLine($" Price : {Price} $");
            Console.WriteLine($" Meal Quantity : {MealQuantity}.Gr");
            Console.WriteLine();
            Console.ResetColor();
        }

        /*
         oynadiqca enerji itirirler ,yatdiqda ve ya yemek yedikde 
         enerjileri artir,amma pishikler elediki
         enerjileri 0 olan kimi yatmaga getmelidirler
         ve pishikler yemek yedikce her defe chox az 
         boyuyub deyerlerinirler ,(yeni price lari qalxir)
         */

        public void GoEating()
        {
            MealQuantity += 50;
            Price += 20;

            if (Energy == 100)
            {
                Console.WriteLine("Eating...");
                System.Threading.Thread.Sleep(1999);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Energy is already Full");
                Console.ResetColor();
            }
            else
            {
                Energy += 50;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n ~~ After Eating - Current Data\n");
            Console.ForegroundColor = ConsoleColor.Red;
            ShowData();
            Console.ResetColor();

        }

        public void GoSleeping()
        {
            Console.WriteLine("Sleeping...");
            System.Threading.Thread.Sleep(1999);
            MealQuantity -= 30;

            if (Energy == 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Cat cannot Sleep when Energy is Full");
                Console.ResetColor();
            }
            else
            {
                Energy += 50;

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n ~~ After Sleeping - Current Data\n");
            Console.ForegroundColor = ConsoleColor.Red;
            ShowData();
            Console.ResetColor();
        }

        public void GoPlaying()
        {
            if (MealQuantity < 30)
            {
                GoEating();
            }
            else
            {
                MealQuantity -= 30;
            }

            if (Energy < 50)
            {
                GoSleeping();
            }
            else
            {
                Energy -= 50;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n ~~ After Playing - Current Data\n");
            Console.ForegroundColor = ConsoleColor.Red;
            ShowData();
            Console.ResetColor();
        }

    }

    class CatHouse
    {
        public string HouseName { get; set; }
        public Cat[] Cats { get; set; }
        public int CatCount { get; set; } = default;
        //public bool IsHealthy { get; set; }

        public CatHouse(string name)
        {
            HouseName = name;
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("========CAT HOUSE========");
            Console.WriteLine($" House Name : {HouseName}");
            Console.WriteLine();
            //var isHealthy = (IsHealthy) ? "Yes" : "No";
        }

        public void AddCat(ref Cat cat)
        {
            Console.WriteLine("Adding...");
            System.Threading.Thread.Sleep(999);

            Cat[] temp = new Cat[++CatCount];
            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = cat;
            Cats = temp;


        }

        public decimal GetHousePrice()
        {
            decimal val = 0;
            foreach (var cat in Cats)
            {
                val += cat.Price;
            }
            return val;
        }

        public void ShowCats()
        {
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    cat.ShowData();
                    Console.WriteLine();
                }
            }
        }
    }

    class PetShop
    {
        public CatHouse[] Houses { get; set; }

        public int CatHouseCount { get; set; }

        public void AddCatHouse(ref CatHouse house)
        {

            System.Threading.Thread.Sleep(999);

            CatHouse[] temp = new CatHouse[++CatHouseCount];
            if (Houses != null)
            {
                Houses.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = house;
            Houses = temp;
        }
        public void ShowHouses()
        {
            foreach (var house in Houses)
            {
                house.Show();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat(" Leo", "Male", 30, 100, 75);
            Cat cat2 = new Cat(" Gracie", "Female", 40, 110, 90);
            Cat cat3 = new Cat(" Stella", "Female", 50, 90, 60);
            cat1.ShowData();
            cat2.ShowData();
            cat3.ShowData();
            CatHouse house1 = new CatHouse(" Happy Cats House");
            CatHouse house2 = new CatHouse(" Leo's Place");
            CatHouse house3 = new CatHouse(" Haunted House of Cats");


            //////////////////////////ADDING//////////////////////
            house1.AddCat(ref cat1);
            house2.AddCat(ref cat2);
            house3.AddCat(ref cat3);
            /////////////////////////////////////////////////////
            house1.Show();
            house2.Show();
            house3.Show();
            //////////////////////////CATS///////////////////////
            house1.ShowCats();
            house2.ShowCats();
            house3.ShowCats();

            PetShop shop = new PetShop();
            ///////////////////////PETSHOP///////////////////////

            shop.AddCatHouse(ref house1);
            shop.AddCatHouse(ref house2);
            shop.AddCatHouse(ref house3);
            /////////////////////////////////////////////////////


            shop.ShowHouses();

            ////////////////////////ACTIONS//////////////////////
            cat1.GoEating();
            cat1.GoPlaying();
            cat1.GoSleeping();

            //-------------------//

            cat2.GoPlaying();
            cat2.GoEating();
            cat2.GoSleeping();

            //-------------------//

            cat3.GoSleeping();
            cat3.GoPlaying();
            cat3.GoEating();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////


        }
    }
}
