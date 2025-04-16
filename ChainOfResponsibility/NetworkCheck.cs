namespace Lab3.ChainOfResponsibility
{
    public class NetworkCheck : DeviceCheck
    {
        public override bool Check(Device device)
        {
            if (!device.IsConnectedToNetwork())
                throw new Exception("Немає підключення до мережі");
            return base.Check(device);
        }
    }

}
