using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
   public class User : IUser
    {
        public int Health { get; set; } = 1500;



        public void Damage(Attack attack)



        {
            if (attack.Items == Items.Drown || attack.Items == Items.HappyFeet || attack.Items == Items.Shock)
            {
                Health -= (int)Math.Floor(attack.Damage * 2.5);
            }
            else if (attack.Items == Items.Trip || attack.Items == Items.Stomp)
            {
                Health -= (int)Math.Ceiling(attack.Damage * 0.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }

        public Attack Attack(Items attackItem)
        {
            return new Attack(5, 25, attackItem, "Get attacked!");
        }

        public Attack Attack()
        {
            return new Attack(1, 10, default, "I don't know what I used but it worked...");
        }

    }
}
