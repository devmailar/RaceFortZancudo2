using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace RaceFortZancudo2.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from RaceFortZancudo2.Client!");
        }

        private Racer Mike;
        private Racer Franklin;
        private Racer Trevor;

        [Command("fortzancudo")]
        public void FortZancudo()
        {
            // Game is going to crash because Vector3 spawn is 0f, 0f, 0f in new Racer()

            Franklin = new Racer("Franklin", PedHash.Franklin, VehicleHash.Banshee, new Vector3(0f, 0f, 0f), new Vector3(-2705.81f, 2356.26f, 16.18f));
            Mike = new Racer("Michael", PedHash.Michael, VehicleHash.Kuruma, new Vector3(0f, 0f, 0f), new Vector3(-2699.49f, 2356.26f, 16.18f));
            Trevor = new Racer("Trevor", PedHash.Trevor, VehicleHash.Sultan, new Vector3(0f, 0f, 0f), new Vector3(-2690.20f, 2356.26f, 16.18f));
        }

        [Tick]
        public Task OnTick()
        {
            DrawRect(0.5f, 0.5f, 0.5f, 0.5f, 255, 255, 255, 150);

            return Task.FromResult(0);
        }
    }
}