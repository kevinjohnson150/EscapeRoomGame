using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.Attack;

namespace EscapeRoom.Boss
{
   public class EvilAunt : IBoss
    {
        public int Health { get; set; } = 200;

        public void Damage(Attack attack)
        {
            if (attack.Items == Items.Whiskey || attack.Items == Items.Rehab)
            {
                Health -= (int)Math.Floor(attack.Damage * 2.5);
            }
            else if (attack.Items == Items.Trip || attack.Items == Items.Stomp)
            {
                Health  -= (int)Math.Ceiling(attack.Damage *  0.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }

        public Attack Attack()
        {
            return new Attack(2, 8, Items.Slam, "SLAM!");
        }

        public void BossPhrase()
        {
            Console.WriteLine("Come here you little S**t!");
        }

        public Attack Attack(Items attackItems)
        {
            throw new NotImplementedException();
        }
    }
}