using System;
using VehicleControl.Enums;
using VehicleControl.Models;

namespace VehicleControl.Commands
{
    public class RotateCommand : ICommand
    {
        private readonly char _rotation;

        public RotateCommand(char rotation)
        {
            _rotation = rotation;
        }

        public void Execute(Vehicle vehicle)
        {
            try
            {
                // Mevcut araç yönünün enum içindeki indeksini alır
                int currentDirectionIndex = (int)vehicle.Direction;

                // Direction enumunda tanımlı olan yönlere ait sayısal değerlerin sayısını alır
                int numberOfDirections = Enum.GetValues(typeof(Direction)).Length;

                switch (_rotation)
                {
                    //Sola dönüş
                    case 'L':                    
                        // Bu işlem, enum içindeki yönlere saat yönü tersine döndürme sağlar
                        vehicle.Direction = (Direction)(((currentDirectionIndex + numberOfDirections - 1) % numberOfDirections));
                        break;

                    //Sağa dönüş
                    case 'R':
                        // Bu işlem, enum içindeki yönlere saat yönünde döndürme sağlar
                        vehicle.Direction = (Direction)(((currentDirectionIndex + 1) % numberOfDirections));
                        break;

                    default:
                        throw new InvalidOperationException($"Geçersiz dönüş komutu: {_rotation}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dönüş komutu sırasında hata: {ex.Message}");
                throw; 
            }
        }
    }
}
