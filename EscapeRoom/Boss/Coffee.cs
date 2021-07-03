using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.Attack;

namespace EscapeRoom.Boss
{
    public class Coffee : IBoss
    {
        public int Health { get; set; } = 100;

        public void Damage(Attack attack)
        {
            if (attack.Items == Items.Ice || attack.Items == Items.Snowcone)
            {
                Health -= (int)Math.Floor(attack.Damage * 2.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }

        public Attack Attack()
        {
            return new Attack(2, 9, Items.Burn, "Burn");
        }

        public void BossPhrase()
        {
            Console.WriteLine("It's gettin' hot in here!!");
        }

        public Attack Attack(Items attackItems)
        {
            throw new NotImplementedException();
        }
    }

}
