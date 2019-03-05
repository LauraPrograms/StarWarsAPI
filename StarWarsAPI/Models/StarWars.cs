using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Models
{
    public class StarWars
    {
        
        public string Name;
        public string BirthYear;
        public string Films;
        public string Vehicles;

        public StarWars(string name, string birthyear, string films, string vehicles)
        {
            Name = name;
            BirthYear = birthyear;
            Films = films;
            Vehicles = vehicles;
        }

        public StarWars() { }

    }
}