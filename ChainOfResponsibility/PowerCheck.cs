namespace Lab3.ChainOfResponsibility
{
    public class PowerCheck: DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.HasPowerSupply() && (device.GetBattery() == null || !device.GetBattery().IsCharged()))
            {
                throw new Exception("Пристрій не має заряду");
            }
            return base.Check(device);
        }
    }
}
