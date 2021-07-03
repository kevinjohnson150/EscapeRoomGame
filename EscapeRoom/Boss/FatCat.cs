using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.Attack;

namespace EscapeRoom.Boss
{
   public class FatCat : IBoss
    {
        public int Health { get; set; } = 250;

        public void Damage(Attack attack)
        {
            if (attack.Items == Items.CatNip || attack.Items == Items.Donuts)
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
            return new Attack(5, 8, Items.Scratch, "Slice n' Dice");
        }

        public void BossPhrase()
        {
            Console.WriteLine("MMMeeEEooooOOWWWww");
        }

        public Attack Attack(Items attackItems)
        {
            throw new NotImplementedException();
        }
    }
}