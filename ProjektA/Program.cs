using System;
//Sahar Ali Abdou
//Projekt A del A1:
namespace ProjektA
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        const int _maxNrArticles = 10;
        const int _minNrArticles = 1;
        //const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;


        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to project A.");
            Console.WriteLine("Lets print a receipt!");
            bool Continue = ReadArticles($"Please choose number of articles (1-10)! ", out nrArticles, _minNrArticles, _maxNrArticles);
            articleInput();
            Printreceipt();
        }






        public static void articleInput()
        {


            Article article = new Article();

            string[] InputArrays;
            int counter = 0;


            while (counter < nrArticles)
            {



                try
                {
                    Console.WriteLine($"Enter article {counter + 1} in the format (beer:10,21)");

                    InputArrays = Console.ReadLine().Split(':');
                    if (InputArrays.Length != 2)
                    {
                        Console.WriteLine("Wrong format, Please try again!");
                        continue;
                    }

                    if (!string.IsNullOrEmpty(InputArrays[0]) && !string.IsNullOrWhiteSpace(InputArrays[0]))
                    {
                        article.Name = InputArrays[0];
                    }

                    else
                    {
                        Console.WriteLine("name error");
                        continue;
                    }
                    bool checkValue = decimal.TryParse(InputArrays[1], out decimal price);
                    if (checkValue)
                    {
                        article.Price = price;
                    }
                    else
                    {
                        Console.WriteLine("Price error!");
                        continue;

                    }

                    articles[counter] = article; // stores the articles entered in an array


                }

                catch
                {
                    Console.WriteLine("Try again!");
                    continue;

                }
                counter++;
                continue;


            }


        }

        public static void Printreceipt()
        {


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Receipt purchased articles");
            Console.WriteLine($"{"Purchase date:",-7} {DateTime.Now}");
            Console.WriteLine();
            Console.WriteLine($"{"Number of articles purchased",-7}: {nrArticles}");
            Console.WriteLine();

            Console.WriteLine($"{"#",-7} {"Name",-20} {"Price",20}");
           




            decimal sum = 0;


            for (int k = 0; k < nrArticles; k++)// I use this forloop to sum the prices of each article
            {
                sum += articles[k].Price;
                Console.WriteLine($"{k + 1,-7} {articles[k].Name,-20} {articles[k].Price,20:C2}");


            }

            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine($"{"Total price:",-7} {sum,36:C2}");// print the total price of articles
            Console.WriteLine($"{"Includes VAT (25%) :",-7} {sum * _vat,28:C2}");// Calculates and prints the vat.




        }

        public static bool ReadArticles(string question, out int number, int minInt, int maxInt)// Use string separator.
        {
            string option;
            do
            {
                Console.WriteLine($"{question} or to quit please type Q or q!");
                option = Console.ReadLine();
                if (int.TryParse(option, out number) && number >= minInt && number <= maxInt)
                {
                    return true;
                }
                else if (option != "Q" && option != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((option != "Q" && option != "q"));
            return false;
        }
    }



}
