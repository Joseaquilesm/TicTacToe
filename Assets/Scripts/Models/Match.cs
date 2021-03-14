using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scripts.Networking;

namespace Scripts.Models
{
    class Match
    {
        public readonly ushort id;
        public static Match currentMatch; 

        public Match(ushort id)
        {
            this.id = id;
        }
        
        public void SendSpaceClicked(ushort spaceClicked)
        {
            NetworkManager.Instance.MessageSpaceTaken(spaceClicked, id);
        }
    }
}
