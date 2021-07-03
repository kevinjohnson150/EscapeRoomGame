using EscapeRoom.Boss;
using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Room 
    {
        public Room()
        {

        }

        public Room(string riddle, List<string> exits, List<Items> items)
        {
            this.Riddle = riddle;
            this.Exits = exits;
            this.Items = items;
        }

        public Room(string riddle, List<string> exits, List<Items> items, IBoss boss)
        {
            this.Riddle = riddle;
            this.Exits = exits;
            this.Items = items;
            this.Boss = boss;
        }

        public Room(string riddle, List<string> exits, List<Items> items, string secretPassage)
        {
            this.Riddle = riddle;
            this.Exits = exits;
            this.Items = items;
            this.SecretPassage = secretPassage;
        }

        public string Riddle { get; set; }

        public List<string> Exits { get; set; }

        public List<Items> Items { get; set; }

        public string SecretPassage { get; set; }

        public IBoss Boss { get; set; }

        public void RemoveItem(Items item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
            
    }
}
