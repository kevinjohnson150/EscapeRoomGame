using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.Attack;

namespace EscapeRoom.Boss
{
   public class Bunny : IBoss
    {
        public int Health { get; set; } = 175;

        public void Damage(Attack attack)
        {
            if (attack.Items == Items.BabyCarrots || attack.Items == Items.Hounds)
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

        public Attack Attack()
        {
            return new Attack(9, 11, Items.HappyFeet, "Happy Feet");
        }

        public void BossPhrase()
        {
            Console.WriteLine("Happy Feet WOMBO COMBO!");
        }

        public Attack Attack(Items attackItems)
        {
            throw new NotImplementedException();
        }
    }
}