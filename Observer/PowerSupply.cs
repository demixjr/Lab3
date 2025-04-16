namespace Lab3.Observer
{
    public class PowerSupply
    {
        public event EventHandler<PowerSupplyChangedEventArgs> PowerChanged;
        private bool isPoweredOn;
        public PowerSupply()
        {
            isPoweredOn = false;
        }
        public void TurnOn()
        {
            if (!isPoweredOn)
            {
                isPoweredOn = true;
                OnPowerChanged(new PowerSupplyChangedEventArgs(isPoweredOn));
            }
        }

        public void TurnOff()
        {
            if (isPoweredOn)
            {
                isPoweredOn = false;
                OnPowerChanged(new PowerSupplyChangedEventArgs(isPoweredOn));
            }
        }

        private void OnPowerChanged(PowerSupplyChangedEventArgs e)
        {
            PowerChanged?.Invoke(this, e);
        }
    }
}
