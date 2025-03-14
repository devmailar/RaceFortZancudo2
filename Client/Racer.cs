using System.Threading.Tasks;
using CitizenFX.Core;

namespace RaceFortZancudo2.Client
{
    internal class Racer
    {
        private readonly Task<Ped> Ped;
        private readonly string Name;
        private Vector3 Spawn;

        private readonly Task<Vehicle> Vehicle;

        internal Racer(string name, PedHash model, VehicleHash vehicleHash, Vector3 spawn, Vector3 vehicleSpawn)
        {
            this.Name = name;
            this.Ped = World.CreatePed(model, spawn, 0f);
            this.Spawn = spawn;
            this.Vehicle = World.CreateVehicle(vehicleHash, vehicleSpawn, 0f);

            Debug.WriteLine($"^5[INFO] Racer {this.Name} created.");

            this.Ped.ContinueWith(task =>
            {
                task.Result.SetIntoVehicle(this.Vehicle.Result, VehicleSeat.Driver);
            });
        }
    }
}