using TekgemApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekgemApp
{
    public class CitiesReturn : ICityResult
    {
        private ICollection<string> nextletters = new List<string>();
        public ICollection<string> NextLetters 
        { 
        get { return nextletters; } 
        set { nextletters = value; } 
        }

        private ICollection<string> nextcities = new List<string>();
        public ICollection<string> NextCities
        {
            get { return nextcities; }
            set { nextcities = value; }
        }

        public void addCity(string city)
        {
            NextCities.Add(city);
        }

        public void addNextLetter(string nextLetter)
        {
            NextLetters.Add(nextLetter);
        }

    }

    public class MyCitySearch : ICityFinder
    {
		private List<string> Cities = new List<string>();

        public void SetCities(List<string> cities)
        {
            Cities = cities;
        }

        public ICityResult Search(string searchString)
        {
            CitiesReturn ret = new CitiesReturn();

            foreach (string city in Cities)
            {
                bool bCityFound = true;
                for (int i  = 0; i < searchString.Count(); i++)
                {
                    if (city[i] != searchString[i])
                    {
                        bCityFound = false;
                        break;
                    }
                }

                if(bCityFound)
                {
                    ret.addCity(city);
                    try
                    {
                        ret.addNextLetter("" + city[searchString.Length]);
                    }
                    catch  (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.ToString()); 
                    }
                }
            }
            return ret;
        }
    }

    public class Program
    {
        static List<string> Cities = new List<string>();
        public static MyCitySearch se = new MyCitySearch();

        public static void Init()///test list
        {
            Cities.Add("London");
            Cities.Add("Berlin");
            Cities.Add("Paris");
            Cities.Add("Oslo");
            Cities.Add("Sydney");
            Cities.Add("Atlanta");
            Cities.Add("Bangkok");
            Cities.Add("Bangalore");
            Cities.Add("Krakow");
            Cities.Add("Manchester");
            Cities.Add("Glasgow");
            Cities.Add("New York");
            Cities.Add("Prague");
            Cities.Add("Cairo");
            Cities.Add("Beijing");
            Cities.Add("Tokyo");
            Cities.Add("Mexico City");
            Cities.Add("Moscow");
            Cities.Add("Athens");
            Cities.Add("Rome");
            Cities.Add("Madrid");
            Cities.Add("Cape Town");
            Cities.Add("Delhi");
            Cities.Add("Baghdad");
            Cities.Add("Istanbul");
            Cities.Add("Venice");
            Cities.Add("Rotterdam");
            Cities.Add("Chester");
            Cities.Add("Washington");
            Cities.Add("Amsterdam");
            Cities.Add("Brussels");
            Cities.Add("Turin");
            Cities.Add("Lisbon");
            Cities.Add("Bangui");
            Cities.Add("Bandung");
            Cities.Add("La Paz");
            Cities.Add("La Plata");
            Cities.Add("Lagos");
            Cities.Add("Leeds");
            Cities.Add("Zaria");
            Cities.Add("Zhugai");
            Cities.Add("Zibo");
			Cities.Add("Rome");
			Cities.Add("Bucharest");
			Cities.Add("Vienna");
			Cities.Add("Hamburg");
			Cities.Add("Warsaw");
			Cities.Add("Budapest");
						

			for (int i = 0; i < Cities.Count(); i++)
            {
                Cities[i] = Cities[i].ToUpper();
            }

            se.SetCities(Cities);
        }

        static void Main(string[] args)
		{
            Init();

            Console.WriteLine("Insert Search Text Here");

            while (true)
            {
                string searchstr = Console.ReadLine().ToUpper();
              

                CitiesReturn results = (CitiesReturn)se.Search(searchstr);

                ICollection<string> resultLetters = results.NextLetters;
                ICollection<string> resultCities = results.NextCities;



                foreach (string res in resultCities)
                {
                    Console.WriteLine(res);
                }


                foreach (string res in resultLetters)
                {
                    Console.WriteLine(res);
                }


            }


           
        }



	}
}
