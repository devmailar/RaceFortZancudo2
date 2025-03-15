using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace RaceFortZancudo2.Client
{
    internal class Racer : BaseScript
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

        internal void AttachVehicleBlip()
        {
            this.Vehicle.Result.AttachBlip().Scale = 0.4f;
        }

        internal async Task SetVehicleRacingMode()
        {
            this.Vehicle.Result.DirtLevel = 40.0f;
            this.Vehicle.Result.EngineHealth = 1000.0f;
            this.Vehicle.Result.FuelLevel = 100.0f;
            this.Vehicle.Result.IsDriveable = true;
            this.Vehicle.Result.IsPersistent = true;
            this.Vehicle.Result.IsStolen = true;
            this.Vehicle.Result.CanEngineDegrade = true;

            this.Ped.Result.BlockPermanentEvents = true;
            this.Ped.Result.IsPersistent = true;
            this.Ped.Result.Task.DriveTo(this.Vehicle.Result, new Vector3(-759.03f, 5492.83f, 34.36f), 10.0f, 110.0f, (int)DrivingStyle.Rushed);
            this.Ped.Result.DrivingStyle = DrivingStyle.Rushed & DrivingStyle.IgnoreLights & DrivingStyle.AvoidTraffic & DrivingStyle.ShortestPath;

            await Delay(6000);

            this.Vehicle.Result.EnginePowerMultiplier = 5.0f;
            this.Vehicle.Result.EngineTorqueMultiplier = 5.0f;

            await Delay(6000);

            this.Vehicle.Result.EnginePowerMultiplier = 10.0f;
            this.Vehicle.Result.EngineTorqueMultiplier = 10.0f;

            SetVehicleHandlingFloat(this.Vehicle.Result.Handle, "CHandlingData", "fInitialDriveForce", 0.0f);
            SetVehicleHandlingFloat(this.Vehicle.Result.Handle, "CHandlingData", "fDriveInertia", 0.0f);
            SetVehicleHandlingFloat(this.Vehicle.Result.Handle, "CHandlingData", "fBrakeBiasFront", 0.0f);
            SetVehicleHandlingFloat(this.Vehicle.Result.Handle, "CHandlingData", "fBrakeBiasRear", 0.0f);
            SetVehicleHandlingFloat(this.Vehicle.Result.Handle, "CHandlingData", "fBrakeForce", 0.0f);

            await Delay(14000);
            TaskVehicleTempAction(this.Ped.Result.Handle, this.Vehicle.Result.Handle, 23, 4000);
            Debug.WriteLine($"^5[INFO] Racer {this.Name} is accelerating fast.");

            this.Ped.Result.Task.DriveTo(this.Vehicle.Result, new Vector3(-759.03f, 5492.83f, 34.36f), 10.0f, 110.0f, (int)DrivingStyle.Rushed);
            this.Ped.Result.DrivingStyle = DrivingStyle.Rushed & DrivingStyle.IgnoreLights & DrivingStyle.AvoidTraffic & DrivingStyle.ShortestPath;
        }
    }
}