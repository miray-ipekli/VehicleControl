using System;
using System.Collections.Generic;
using VehicleControl.Commands;
using VehicleControl.Models;

namespace VehicleControl.Services
{
    public class CommandProcessor
    {
        private readonly Dictionary<char, ICommand> _commandMap;

        public CommandProcessor()
        {
            //Gelen komuta göre yön ve hareket metotlarının ilişkilendirilmesi
            _commandMap = new Dictionary<char, ICommand>
            {
                { 'L', new RotateCommand('L') },
                { 'R', new RotateCommand('R') },
                { 'F', new MoveForwardCommand() }
            };
        }

        public void ProcessCommands(Vehicle vehicle, string commands)
        {
            foreach (var command in commands)
            {
                try
                {
                    if (_commandMap.ContainsKey(command))
                    {
                        _commandMap[command].Execute(vehicle);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Geçersiz komut: {command}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Komut işleme sırasında hata: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
