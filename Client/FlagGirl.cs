using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace RaceFortZancudo2.Client
{
    internal class FlagGirl
    {
        private readonly Task<Ped> Ped;
        private readonly string Name;
        private Vector3 Spawn;

        internal FlagGirl(string name, PedHash model, Vector3 spawn)
        {
            this.Name = name;
            this.Ped = World.CreatePed(model, spawn, 82.49f);
            this.Spawn = spawn;

            Debug.WriteLine($"^5[INFO] FlagGirl {this.Name} created.");
        }

        internal async Task WalkToAsync(Vector3 destination)
        {
            try
            {
                var ped = await this.Ped;
                if (ped == null)
                {
                    throw new Exception($"Ped {ped}");
                }

                ped.Task.GoTo(destination);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"^1[ERROR] Exception in WalkToAsync: {ex.Message}");
                throw;
            }
            finally
            {
                Debug.WriteLine($"^5[INFO] FlagGirl {this.Name} walking to {destination}");
            }
        }

        internal void Dance()
        {
            try
            {
                var ped = this.Ped.Result;
                if (ped == null)
                {
                    throw new Exception($"Ped {ped}");
                }

                ped.Heading = 168.70f;
                ped.Task.PlayAnimation("mp_safehouse", "lap_dance_girl", 8f, -1, AnimationFlags.Loop);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"^1[ERROR] Exception in DanceAsync: {ex.Message}");
                throw;
            }
            finally
            {
                Debug.WriteLine($"^5[INFO] FlagGirl {this.Name} started dancing.");
            }
        }
    }
}