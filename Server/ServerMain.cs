using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace RaceFortZancudo2.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from RaceFortZancudo2.Server!");
            SetRoutingBucketEntityLockdownMode(0, "inactive");
            SetRoutingBucketPopulationEnabled(0, false);
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }
    }
}