using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Boss
{
    public interface IBoss : IUser
    {
        void BossPhrase();
    }
}
