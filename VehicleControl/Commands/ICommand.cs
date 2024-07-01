﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleControl.Models;

namespace VehicleControl.Commands
{
    public interface ICommand
    {
        void Execute(Vehicle vehicle);
    }
}

