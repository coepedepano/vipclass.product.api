using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vipclass.products.Domain.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Categorie> ListAll() {

            var list = new List<Categorie>();
            var soft = new Categorie
            {
                Id = 1,
                Name = "Software"
            };
            var lBusness = new Categorie
            {
                Id = 2,
                Name = "Local Business (culinary, yoga, Photography, etc)"
            };
            var Coach = new Categorie
            {
                Id = 3,
                Name = "Coach"
            };
            var edu = new Categorie
            {
                Id = 4,
                Name = "Educação"
            };
            var hobbies = new Categorie
            {
                Id = 5,
                Name = "Hobbies"
            };
            var languages= new Categorie
            {
                Id = 6,
                Name = "languages"
            };

            var technology = new Categorie
            {
                Id = 7,
                Name = "Technology"
            };
            var games = new Categorie
            {
                Id = 8,
                Name = "Games"
            };
            var illustration = new Categorie
            {
                Id = 6,
                Name = "Illustration & Animation"
            };

            list.Add(soft);
            list.Add(lBusness);
            list.Add(Coach);
            list.Add(edu);
            list.Add(hobbies);
            list.Add(languages);
            list.Add(technology);
            list.Add(games);
            list.Add(illustration);

            return list;
        }
    }
}
