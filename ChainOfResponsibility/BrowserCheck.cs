using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ChainOfResponsibility
{
    public class BrowserCheck:DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.hasHeadset)
                throw new Exception("Браузер відсутній");
            return base.Check(device);
        }
    }
}
