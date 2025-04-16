using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ChainOfResponsibility
{
    public class MemoryCheck: DeviceCheck
    {
        int neededROM;
        public MemoryCheck(int neededROM) 
        {
            this.neededROM = neededROM;
        }
        public override bool Check(Device device)
        {
            if (device.GetMemory().FreeROM() < neededROM)
                throw new Exception("Недостатньо місця");
            return base.Check(device);
        }
    }
}
