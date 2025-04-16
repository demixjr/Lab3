using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ChainOfResponsibility
{
    public class HeadphonesCheck: DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.hasHeadset)
                throw new Exception("Гарнітура відсутня");
            return base.Check(device);
        }
    }
}
