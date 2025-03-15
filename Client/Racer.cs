using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace RaceFortZancudo2.Client
{
    internal class Racer
    {
        private readonly Task<Ped> Ped;
        private readonly string Name;
        private Vector3 Spawn;

        internal readonly Task<Vehicle> Vehicle;

        internal Racer(string name, PedHash model, VehicleHash vehicleHash, Vector3 spawn, Vector3 vehicleSpawn)
        {
            this.Name = name;
            this.Ped = World.CreatePed(model, spawn, 0f);
            this.Spawn = spawn;
            this.Vehicle = World.CreateVehicle(vehicleHash, vehicleSpawn, 349.25f);

            Debug.WriteLine($"^5[INFO] Racer {this.Name} created.");
        }

        internal async Task SetIntoVehicle()
        {
            try
            {
                var ped = await this.Ped;
                var vehicle = await this.Vehicle;
                if (ped == null || vehicle == null)
                {
                    throw new Exception($"Ped {ped} or Vehicle {vehicle}");
                }

                ped.SetIntoVehicle(vehicle, VehicleSeat.Driver);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"^1[ERROR] Exception in SetIntoVehicle: {ex.Message}");
                throw;
            }
            finally
            {
                Debug.WriteLine($"^5[INFO] Racer {this.Name} set into vehicle.");
            }
        }

        internal void RevEngine()
        {
            try
            {
                var ped = this.Ped.Result;
                var vehicle = this.Vehicle.Result;
                if (ped == null || vehicle == null)
                {
                    throw new Exception($"Ped {ped} or Vehicle {vehicle}");
                }

                TaskVehicleTempAction(this.Ped.Result.Handle, this.Vehicle.Result.Handle, 31, 3000);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"^1[ERROR] Exception in RevEngine: {ex.Message}");
                throw;
            }
            finally
            {
                Debug.WriteLine($"^5[INFO] Racer {this.Name} revved the engine.");
            }
        }

        internal void StartBurningTires()
        {
            try
            {
                var ped = this.Ped.Result;
                var vehicle = this.Vehicle.Result;
                if (ped == null || vehicle == null)
                {
                    throw new Exception($"Ped {ped} or Vehicle {vehicle}");
                }

                TaskVehicleTempAction(this.Ped.Result.Handle, this.Vehicle.Result.Handle, 30, 16600);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"^1[ERROR] Exception in StartBurningTires: {ex.Message}");
                throw;
            }
            finally
            {
                Debug.WriteLine($"^5[INFO] Racer {this.Name} started burning tires.");
            }
        }
    }
}