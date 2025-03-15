using System.Threading.Tasks;
using CitizenFX.Core;

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

        private FlagGirl Riley;

        [Command("fortzancudo")]
        public async Task FortZancudoAsync()
        {
            foreach (var entity in World.GetAllProps())
            {
                entity.Delete();
            }

            foreach (var entity in World.GetAllVehicles())
            {
                entity.Delete();
            }

            foreach (var entity in World.GetAllPeds())
            {
                entity.Delete();
            }

            Debug.WriteLine("^3[WARNING] All entities deleted.");

            var light1 = await World.CreateProp("tr_prop_tr_worklight_03b", new Vector3(-2696.55f, 2357.54f, 18.84f), new Vector3(0f, 0f, 70f), false, true);
            var light2 = await World.CreateProp("tr_prop_tr_worklight_03b", new Vector3(-2697.84f, 2350.56f, 16.90f), new Vector3(0f, 0f, 120f), false, true);
            var cone1 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.50f, 2356.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);
            var cone2 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.60f, 2355.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);
            var cone3 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.85f, 2354.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);

            Franklin = new Racer("Franklin", PedHash.Franklin, VehicleHash.Banshee, new Vector3(0f, 0f, 0f), new Vector3(-2696.06f, 2349.94f, 16.49f));
            Mike = new Racer("Michael", PedHash.Michael, VehicleHash.Kuruma, new Vector3(0f, 0f, 0f), new Vector3(-2692.86f, 2349.38f, 16.66f));
            Trevor = new Racer("Trevor", PedHash.Trevor, VehicleHash.Sultan, new Vector3(0f, 0f, 0f), new Vector3(-2689.76f, 2348.87f, 16.32f));

            await Franklin.SetIntoVehicle();
            await Mike.SetIntoVehicle();
            await Trevor.SetIntoVehicle();

            Franklin.RevEngine();
            Mike.RevEngine();
            Trevor.RevEngine();

            Riley = new FlagGirl("Riley", PedHash.Stripper02Cutscene, new Vector3(-2686.47f, 2357.84f, 16.83f));

            await Riley.WalkToAsync(new Vector3(-2696.60f, 2353.20f, 16.86f));
            await Delay(6000);
            Riley.Dance();
            await Delay(400);

            Franklin.StartBurningTires();
            Mike.StartBurningTires();
            Trevor.StartBurningTires();
        }
    }
}