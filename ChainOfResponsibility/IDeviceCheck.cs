namespace Lab3.ChainOfResponsibility
{
    public interface IDeviceCheck
    {
        void SetNext(IDeviceCheck next);
        bool Check(Device device);

    }
}
