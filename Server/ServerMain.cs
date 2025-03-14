using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace RaceFortZancudo2.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from RaceFortZancudo2.Server!");
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }
    }
}