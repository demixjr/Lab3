namespace Lab1
{
    
    abstract public class Device
    {

        protected CPU CPU;
        protected Memory memory;
        protected PowerSupply powerSupply;
        protected Battery battery;

        protected bool hasPowerSupply;
        protected bool isRunning;
        protected bool connectedToNetwork;
        protected bool browserDownloaded;
        public bool hasHeadset;

        protected int games = 0;
       
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
            if (hasPowerSupply)
            {
                isRunning = true;
                return isRunning;
            }
            else if(!hasPowerSupply && battery == null)
            {
                throw new Exception("Джерело безперервного живлення відсутнє");
            }
            else if (!hasPowerSupply && battery != null )
            {
                if (!battery.IsCharged())
                {
                    throw new Exception("Немає енергії");
                }
                isRunning = true;
                return isRunning;      
            }
            else if (isRunning)
            {
                throw new Exception("Пристрій вже увімкнено");
            }
            else if (battery != null && !battery.IsCharged())
                throw new Exception("Немає енергії");
            else
                return false;
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
            if(connectedToNetwork)
            {
                throw new Exception("Пристрій вже має підключення");
            }
            else if(isRunning && hasPowerSupply)
            {
                connectedToNetwork = true;
                return connectedToNetwork;
            }
            else if(isRunning && (battery != null && battery.IsCharged()))
            {
                connectedToNetwork = true;
                return connectedToNetwork;
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Увімкніть пристрій");
            }
            else
            {
                throw new Exception("Пристрій розряджений");
            }
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
            if(browserDownloaded)
            {
                throw new Exception("Браузер вже є на пристрої");
            }
            if(isRunning && memory.FreeROM() > 1 && connectedToNetwork)
            {
                browserDownloaded = true;
                memory.AllocateROM(1);
                return browserDownloaded;
            }
            else if(!isRunning)
            {
                throw new Exception("Увімкніть пристрій");
            }
            else if (memory.FreeROM() <= 1)
            {
                throw new Exception("Недостатньо місця");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Підключення до мережі відсутнє");
            }
            return false;
        }
        public int DownloadGame()
        {
            if (isRunning && memory.FreeROM() > 10 && connectedToNetwork)
            {
                games += 1;
                memory.AllocateROM(10);
                return games;
            }
            else if(!isRunning)
            {
                throw new Exception("Увімкніть пристрій");
            }
            else if (memory.FreeROM() <= 1)
            {
                throw new Exception("Недостатньо місця");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Підключення до мережі відсутнє");
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
