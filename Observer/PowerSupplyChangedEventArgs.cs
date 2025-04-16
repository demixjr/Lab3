using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Observer
{
    public class PowerSupplyChangedEventArgs : EventArgs
    {
        public bool IsPoweredOn { get; }

        public PowerSupplyChangedEventArgs(bool isPoweredOn)
        {
            IsPoweredOn = isPoweredOn;
        }
    }
}
