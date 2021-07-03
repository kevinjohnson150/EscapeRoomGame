using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.Attack;

namespace EscapeRoom.Boss
{
   public class Sandwich : IBoss
    {
        public int Health { get; set; } = 150;

        public void Damage(Attack attack)
        {
            if (attack.Items == Items.SaranWrap || attack.Items == Items.EatSandwich)
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
            return new Attack(4, 7, Items.Blinded, "Cucumber Mask");
        }

        public void BossPhrase()
        {
            Console.WriteLine("You can't handle these cucumbers!");
        }

        public Attack Attack(Items attackItems)
        {
            throw new NotImplementedException();
        }
    }
}