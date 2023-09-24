using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QB_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string dbPath = "/data.db";
            string root = FileRoot.Root;
            string dbPath = root + "\\Data\\data.db";
            //string connectionString = $"Data Source={dbPath}";

            QueryBuilder qb = new QueryBuilder(dbPath);
            
            //note: i hate this i hate htis i hate this tehusiagudsb
            Console.WriteLine("Which database would you like to work with?\n");
            Console.WriteLine("1. Pokemon\n2. Banned Games\n3. Exit");
            int userInput = Convert.ToInt32(Console.ReadLine());

            while (userInput != 3)
            {
                

                switch (userInput)
                {
                    case 1:

                        Pokemon pkmn = new Pokemon();   

                        Console.WriteLine("Would you like to purge the current database before we begin? Y/N");
                        char purge = Console.ReadLine().ToUpper()[0];
                        if (purge == 'Y')
                        {                           
                            qb.DeleteAll(pkmn);
                            Console.WriteLine("=============== Succesfully deleted all records ===============");
                        }

                        Console.WriteLine("Would you like to populate the current database? Y/N");
                        char popPokemon = Console.ReadLine().ToUpper()[0];

                        if (popPokemon == 'Y')
                        {


                            List<Pokemon> pokeFromCSV = new List<Pokemon>();

                            var pkmnFilePath = root + "./Data/AllPokemon.csv";

                            //var filePath = "\\data\\AllPokemon.csv";
                            using (var sr = new StreamReader(pkmnFilePath))
                            {
                                while (!sr.EndOfStream)
                                {
                                    var line = sr.ReadLine();
                                    var data = line.Split(',');

                                    var p = new Pokemon()
                                    {
                                        DexNumber = Convert.ToInt32(data[0]),
                                        Name = data[1],
                                        Form = data[2],
                                        Type1 = data[3],
                                        Type2 = data[4],
                                        Total = Convert.ToInt32(data[5]),
                                        HP = Convert.ToInt32(data[6]),
                                        Attack = Convert.ToInt32(data[7]),
                                        Defense = Convert.ToInt32(data[8]),
                                        SpecialAttack = Convert.ToInt32(data[9]),
                                        SpecialDefense = Convert.ToInt32(data[10]),
                                        Speed = Convert.ToInt32(data[11]),
                                        Generation = Convert.ToInt32(data[12])

                                    };

                                    pokeFromCSV.Add(p);

                                }

                            }

                            int x = 0;
                            foreach (var p in pokeFromCSV)
                            {
                                qb.Create(p);
                                x++;
                            }

                            Console.WriteLine($"=============== Successfully Added {x} Pokemon ===============");
                        }

                        Console.WriteLine("Would you like to add a Pokemon to the dex? Y/N");
                        char addOnePkmn = Console.ReadLine().ToUpper()[0];
                        if (addOnePkmn == 'Y')
                        {
                            Console.WriteLine("What's the pokemons's ID?");
                            int id= Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the pokemons's Dex Number?");
                            int dexNumber = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the pokemon's name?");
                            string name = Console.ReadLine();

                            Console.WriteLine("What's the form?");
                            string form = Console.ReadLine();

                            Console.WriteLine("What's its primary type?");
                            string type1 = Console.ReadLine();

                            Console.WriteLine("What's its secondary type??");
                            string type2 = Console.ReadLine();

                            Console.WriteLine("What's it's HP?");
                            int hp = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the Attack?");
                            int attack = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the Defense?");
                            int defense = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the Special Attack?");
                            int specialAttack = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the Special Defense?");
                            int specialDefense = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the Speed?");
                            int speed = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What generation is it from?");
                            int generation = Convert.ToInt32(Console.ReadLine());

                            int total = hp + attack + defense + specialAttack + specialDefense + speed;

                            Pokemon newPkmn = new Pokemon()
                            {
                                Id = id,
                                DexNumber = dexNumber,
                                Name = name,
                                Form = form,
                                Type1 = type1,
                                Type2 = type2,
                                Total = total,
                                HP = hp,
                                Attack = attack,
                                Defense = defense,
                                SpecialAttack = specialAttack,
                                SpecialDefense = specialDefense,
                                Speed = speed,
                                Generation = generation,
                            };

                            qb.Create(newPkmn);
                            Console.WriteLine($"=============== Successfully added {name} to your Pokedex ===============");
                        }


                        break; //end of the pokemon database

                    case 2:

                        BannedGame BG = new BannedGame();

                        Console.WriteLine("Would you like to purge the current database before we begin? Y/N");
                        char purge2 = Console.ReadLine().ToUpper()[0];
                        if (purge2 == 'Y')
                        {
                            qb.DeleteAll(BG);
                            Console.WriteLine("=============== Succesfully deleted all records ===============");
                        }

                        Console.WriteLine("Would you like to populate the current database? Y/N");
                        char popGames = Console.ReadLine().ToUpper()[0];

                        if (popGames == 'Y')
                        {


                            List<BannedGame> gameFromCSV = new List<BannedGame>();

                            var gameFilePath = root + "./Data/BannedGames.csv";

                            //var filePath = "\\data\\AllPokemon.csv";
                            using (var sr = new StreamReader(gameFilePath))
                            {
                                while (!sr.EndOfStream)
                                {
                                    var line = sr.ReadLine();
                                    var data = line.Split(',');

                                    var g = new BannedGame()
                                    {
                                        Title = data[0],
                                        Series = data[1],
                                        Country = data[2],
                                        Details = data[3]

                                    };

                                    gameFromCSV.Add(g);

                                }

                            }

                            int i = 0;
                            foreach (var g in gameFromCSV)
                            {
                                qb.Create(g);
                                i++;
                            }

                            Console.WriteLine($"=============== Successfully Added {i} Banned Games ===============");


                        }//end of the creation

                        Console.WriteLine("Would you like to add one game? Y/N");
                        char addOneGame = Console.ReadLine().ToUpper()[0];
                        if(addOneGame == 'Y')
                        {
                            Console.WriteLine("What's the game's ID?");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("What's the game's title?");
                            string title = Console.ReadLine();

                            Console.WriteLine("What's the game's series?");
                            string series = Console.ReadLine();

                            Console.WriteLine("What's the country it's banned in?");
                            string country = Console.ReadLine();

                            Console.WriteLine("Why is the game banned?");
                            string details = Console.ReadLine();

                            BannedGame newGame = new BannedGame()
                            {
                                Id = id,
                                Title = title,
                                Series = series,
                                Country = country,
                                Details = details
                            };

                            qb.Create(newGame);
                            Console.WriteLine($"=============== Successfully added {title} to the banned games list ===============");
                        }


                        break; //end of the banned game database

                    default:
                        Console.WriteLine("Try again please.");
                        userInput = Convert.ToInt32(Console.ReadLine());
                        break;

                }
               
                break;
            }

            Console.WriteLine("\nThanks for the info bestie.");

        }

        

        
    }
}