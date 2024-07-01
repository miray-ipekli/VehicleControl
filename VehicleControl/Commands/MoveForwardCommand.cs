using System;
using VehicleControl.Enums;
using VehicleControl.Models;

namespace VehicleControl.Commands
{
    public class MoveForwardCommand : ICommand
    {
        public void Execute(Vehicle vehicle)
        {
            try
            {
                switch (vehicle.Direction)
                {
                    case Direction.N:
                        // Kuzey yönünde ileri hareket: Y koordinatını arttırır, sınır kontrolü yapar
                        if (vehicle.Position.Y < 11) vehicle.Position.Y++;
                        else throw new InvalidOperationException("Araç sınırın dışına çıkamaz.");
                        break;

                    case Direction.S:
                        // Güney yönünde ileri hareket: Y koordinatını azaltır, sınır kontrolü yapar
                        if (vehicle.Position.Y > 0) vehicle.Position.Y--;
                        else throw new InvalidOperationException("Araç sınırın dışına çıkamaz.");
                        break;

                    case Direction.E:
                        // Doğu yönünde ileri hareket: X koordinatını arttırır, sınır kontrolü yapar
                        if (vehicle.Position.X < 11) vehicle.Position.X++;
                        else throw new InvalidOperationException("Araç sınırın dışına çıkamaz.");
                        break;

                    case Direction.W:
                        // Batı yönünde ileri hareket: X koordinatını azaltır, sınır kontrolü yapar
                        if (vehicle.Position.X > 0) vehicle.Position.X--;
                        else throw new InvalidOperationException("Araç sınırın dışına çıkamaz.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hareket komutu sırasında hata: {ex.Message}");
                throw;
            }
        }
    }
}
