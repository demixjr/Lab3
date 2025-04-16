using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ChainOfResponsibility
{
    public class IsRunningCheck : DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.IsRunning())
                throw new Exception("Пристрій не увімкнено");
            return base.Check(device);
        }
    }

}
