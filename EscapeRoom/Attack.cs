using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Attack
    { 

        public int Damage { get; }

        public Items Items { get; set; }

        public string Name { get; set; }

        private readonly Random random = new Random();

        public Attack ()
        {

        }

        public Attack (int minDamage, int maxDamage, Items items, string name)        
        {
            Damage = random.Next(minDamage, maxDamage + 1);
            Name = name;
            Items = items;
        }


    }
}
