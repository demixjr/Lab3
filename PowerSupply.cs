using System;

namespace Lab1
{
    public class PowerSupply
    {
        public event Action On;
        public event Action Off;
        public bool isPoweredOn = false;

        public void TurnOn()
        {
            if (!isPoweredOn)
            {
                isPoweredOn = true;
                On?.Invoke();
               
            }
            else
                throw new Exception("Живлення вже увімкнено");
 
        }
        public void TurnOff()
        {
            if (isPoweredOn)
            {
                isPoweredOn = false;
                Off?.Invoke();
            }
            else
                throw new Exception("Живлення вже вимкнено");
        }
    }
}
