using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ChainOfResponsibility
{
    public class GamesCheck: DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.HasGames())
                throw new Exception("Ігри на ноутбуці відсутні");
            else if(device.GetCPU().GetCores() < 4 || device.GetCPU().GetClockSpeedGHz() < 3.0 || device.GetMemory().GetRAM() < 4)
                throw new Exception("Ноутбук слабкий для гри в ігри");
            return base.Check(device);
        }
    }
}
