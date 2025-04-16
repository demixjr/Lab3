using Lab3.ChainOfResponsibility;
using Lab3.Observer;

namespace Lab3
{

    abstract public class Device
    {

        protected CPU CPU;
        protected Memory memory;
        public PowerSupply powerSupply;
        protected Battery battery;

        protected bool hasPowerSupply;
        protected bool isRunning;
        protected bool connectedToNetwork;
        protected bool browserDownloaded;
        public bool hasHeadset;

        protected IsRunningCheck runningCheck;
        protected PowerCheck powerCheck;
        protected NetworkCheck networkCheck;
        protected MemoryCheck memoryCheck;
        protected BrowserCheck browserCheck;
        protected GamesCheck gamesCheck;
        protected HeadphonesCheck headphonesCheck;
       
        protected int games = 0;

        public virtual void SubscribeToPowerSupply(PowerSupply powerSupply)
        {
            powerSupply.PowerChanged += OnPowerChanged;
        }

        protected virtual void OnPowerChanged(object sender, PowerSupplyChangedEventArgs e)
        {
            hasPowerSupply = e.IsPoweredOn;
        }
        public CPU GetCPU()
        {
            return CPU;
        }
        public Memory GetMemory() 
        { 
            return memory;
        }

        public Battery GetBattery()
        {
            return battery;
        }
        public bool HasPowerSupply()
        {
            return hasPowerSupply;
        }
        public bool IsRunning()
        {
            return isRunning;
        }
        public bool IsConnectedToNetwork()
        {
            return connectedToNetwork;
        }
        public bool IsBrowserDownloaded()
        {
            return browserDownloaded;
        }
        public bool HasGames()
        {
            if (games > 0)
                return true;
            else
                return false;
        }
        public void PowerSupply_Off()
        {
            if (!hasPowerSupply)
                throw new Exception("Живлення вже вимкнено");
            hasPowerSupply = false;
        }

        public void PowerSupply_On()
        {
            if (hasPowerSupply)
                throw new Exception("Живлення вже увімкненщ");
            hasPowerSupply = true;

        }
        public bool ConnectHeadSet()
        {
            if (hasHeadset)
                throw new Exception("Гарнітуру вже підєднано");
            hasHeadset = true;
            return hasHeadset;
        }
        public bool RunDevice()
        {
            powerCheck = new PowerCheck();
            powerCheck.Check(this);
            isRunning = true;
            return isRunning;
        }

        public bool CloseDevice()
        {
            if(!isRunning)
                throw new Exception("Пристрій вже вимкнений");
            else
                isRunning = false;
            return isRunning;
        }

        public bool ConnectToNetwork()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();

            powerCheck.SetNext(runningCheck);
            if (powerCheck.Check(this))
                connectedToNetwork = true;
            return connectedToNetwork;
        }
        public bool ChargeBattery()
        {
            if (battery != null && (battery.DeviceCharge() < battery.DeviceCapacity()))
            {
                battery.ChargeBattery(battery.DeviceCapacity() - battery.DeviceCharge() - 1);
                return true;
            }
            else if(battery == null)
                throw new Exception("Батарея відсутня");
            return false;
        }
        public bool DownloadBrowser()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            networkCheck = new NetworkCheck();
            memoryCheck = new MemoryCheck(1);

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(networkCheck);
            networkCheck.SetNext(memoryCheck);

            if (powerCheck.Check(this))
            {
                browserDownloaded = true;
                memory.AllocateROM(1);
            }
            return browserDownloaded;
        }
        public int DownloadGame()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            networkCheck = new NetworkCheck();
            memoryCheck = new MemoryCheck(10);

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(networkCheck);
            networkCheck.SetNext(memoryCheck);

            if (powerCheck.Check(this))
            {
                games += 1;
                memory.AllocateROM(10);
            }
            return games;
        }
          
        abstract public bool Work();
        abstract public bool Play();
        abstract public bool Chat();
        abstract public bool ListenMusic();
        abstract public bool WatchVideo();
    }
}
