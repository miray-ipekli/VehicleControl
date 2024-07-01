using System;
using VehicleControl.Enums;
using VehicleControl.Models;
using VehicleControl.Services;

namespace VehicleControl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Aracın başlangıç konumunu ve yönünü giriniz (örn: 3 2 N): ");
                string initialPosition = Console.ReadLine();

                Console.Write("Komut dizisini giriniz (örn: FFRFFLFFFFFL): ");
                string commandSequence = Console.ReadLine().ToUpper();


                // Başlangıç pozisyonunu ayrıştırma
                var parts = initialPosition.Split(' ');
                if (parts.Length != 3)
                {
                    throw new ArgumentException("Başlangıç konumu ve yönü hatalı formatta.");
                }

                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);

                // Yönü kontrol etme
                string directionInput = parts[2].ToUpper();
                if (!Enum.IsDefined(typeof(Direction), directionInput))
                {
                    throw new ArgumentException("Geçersiz yön bilgisi.");
                }
                Direction direction = Enum.Parse<Direction>(directionInput);

                // 10x10 platform sınırları kontrolü
                if (x < 0 || x > 10 || y < 0 || y > 10)
                {
                    throw new ArgumentException("Başlangıç konumu platform sınırlarının dışında.");
                }


                // Aracı başlatma
                Vehicle vehicle = new Vehicle(x, y, direction);

                // Komutları işleme
                CommandProcessor processor = new CommandProcessor();
                processor.ProcessCommands(vehicle, commandSequence);

                Console.WriteLine($"Aracın son konumu ve yönü: {vehicle.Position.X} {vehicle.Position.Y} {vehicle.Direction}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Geçersiz sayı formatı.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
