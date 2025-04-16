namespace Lab3
{
    public class Battery
    {
        int Capacity { get; set; }
        int Charge { get; set; }

        public Battery(int capacity)
        {
            Capacity = capacity;
            Charge = capacity;
        }
        public void DischargeBattery(int amount)
        {
            if ((Charge - amount) < 0)
            {
                throw new System.Exception("Пристрій розряджено");
            }
            else
            {
                Charge -= amount;
            }
        }
        public void ChargeBattery(int amount)
        {
            if((Charge + amount) < Capacity )
            {
                Charge += amount; 
            }
           
            else
            {
                throw new System.Exception("Пристрій вже заряджено");
            }
        }

        public int DeviceCapacity()
        {
            return Capacity;
        }
        public int DeviceCharge()
        {
            return Charge;
        }
        public bool IsCharged()
        {
            if(Charge > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
