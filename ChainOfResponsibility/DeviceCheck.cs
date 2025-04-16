using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3.ChainOfResponsibility
{
    public class DeviceCheck : IDeviceCheck
    {
        protected IDeviceCheck next;
        public void SetNext(IDeviceCheck next)
        {
            this.next = next;
        }

        public virtual bool Check(Device device)
        {
            if (next != null)
            {
                return next.Check(device);
            }
            return true;
        }
    }

}
