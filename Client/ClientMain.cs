using System.Drawing;
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

        private Racer Franklin;

        private FlagGirl Riley;

        [Command("fortzancudo")]
        private async Task FortZancudoAsync()
        {
            #region CleanUp
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
            #endregion

            #region Props
            var light1 = await World.CreateProp("tr_prop_tr_worklight_03b", new Vector3(-2696.55f, 2357.54f, 18.84f), new Vector3(0f, 0f, 70f), false, true);
            var light2 = await World.CreateProp("tr_prop_tr_worklight_03b", new Vector3(-2697.84f, 2350.56f, 16.90f), new Vector3(0f, 0f, 120f), false, true);
            var cone1 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.50f, 2356.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);
            var cone2 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.60f, 2355.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);
            var cone3 = await World.CreateProp("prop_mp_cone_02", new Vector3(-2696.85f, 2354.23f, 16.85f), new Vector3(0f, 0f, -10f), false, true);
            #endregion

            Franklin = new Racer("Franklin", PedHash.Franklin, VehicleHash.Elegy, new Vector3(0f, 0f, 0f), new Vector3(-2696.06f, 2349.94f, 16.49f));

            var vehicle = await World.CreateVehicle(VehicleHash.Elegy, new Vector3(-2692.86f, 2349.38f, 16.66f), 349.25f);
            await Franklin.SetIntoVehicle();

            Game.PlayerPed.Task.WarpIntoVehicle(vehicle, VehicleSeat.Driver);

            await Delay(1000);

            TaskVehicleTempAction(Game.PlayerPed.Handle, vehicle.Handle, 31, 18000);

            Franklin.RevEngine();

            Riley = new FlagGirl("Riley", PedHash.Stripper02Cutscene, new Vector3(-2691.46f, 2342.8f, 17.01f));

            // Play Happy Song radio station

            await Riley.WalkToAsync(new Vector3(-2691.67f, 2356.79f, 16.85f));
            await Delay(16000);
            Riley.Dance();
            await Delay(1000);

            TaskVehicleTempAction(Game.PlayerPed.Handle, vehicle.Handle, 30, 16500);

            Franklin.StartBurningTires();
            Franklin.AttachVehicleBlip();

            await Delay(16000);

            _ = Franklin.SetVehicleRacingMode();
        }

        [Tick]
        private Task DrawFinishLine()
        {
            World.DrawMarker(MarkerType.VerticalCylinder, new Vector3(-759.03f, 5492.83f, 34.11f), new Vector3(), new Vector3(), new Vector3(1.0f, 1.0f, 1.0f), Color.FromArgb(255, 107, 107), false, false, false, null, null, false);

            return Task.FromResult(0);
        }
    }
}