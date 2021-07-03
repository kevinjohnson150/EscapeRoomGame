using EscapeRoom.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public interface IUser
    {
        int Health { get; set; }

        void Damage(Attack attack);

        Attack Attack();

        Attack Attack(Items attackItems);

    }

}
