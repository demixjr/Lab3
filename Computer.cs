namespace Lab1
{
    public class Computer: Device, IActions
    {
        public Computer(int cores, double clockSpeedGHz, int ram, int rom, bool hasUPS)
        {
            CPU = new CPU(cores, clockSpeedGHz);
            memory = new Memory(ram, rom);
            powerSupply = new PowerSupply();
            if (hasUPS)
            {
                battery = new Battery(500);
            }

            powerSupply.On += PowerSupply_On;
            powerSupply.Off += PowerSupply_Off;
        }

        public bool Work()
        {
            if (isRunning && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged())
            {
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Комп'ютер не увімкнено");
            }
            else
            {
                throw new Exception("Комп'ютер не має живлення");
            }
        }
        public bool Play()
        {
            if (isRunning && hasPowerSupply && games > 0 && CPU.GetCores() >= 4 && CPU.GetClockSpeedGHz() >= 3.0 && memory.GetRAM() >= 2)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (games <= 0)
            {
                throw new Exception("Ігри на комп'ютері відсутні");
            }
            else if (CPU.GetCores() < 4 || CPU.GetClockSpeedGHz() < 3.0 || memory.GetRAM() < 4)
            {
                throw new Exception("Комп'ютер слабкий для гри в ігри");
            }
            else if (isRunning && battery.IsCharged() && games > 0 && CPU.GetCores() >= 4 && CPU.GetClockSpeedGHz() >= 3.0 && memory.GetRAM() >= 2)
            {
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            if (!hasPowerSupply)
            {
                throw new Exception("Комп'ютер не має живлення");
            }
            
            else 
            {
                throw new Exception("Комп'ютер не увімкнено");
            }
        }
        public bool Chat()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Комп'ютер не увімкнено");
            }
            else if(!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if(!connectedToNetwork)
            {
                throw new Exception("Комп'ютер не підключений до мережі");
            }
            else
            {
                throw new Exception("Комп'ютер не має живлення");
            }

        }
        public bool ListenMusic()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded && hasHeadset )
            {
                Thread.Sleep(1000);
                return true;
            }
            else if(!hasHeadset)
            {
                throw new Exception("Гарнітура відсутня");
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded && hasHeadset)
            {
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Комп'ютер не увімкнено");
            }
            else if (!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Комп'ютер не підключений до мережі");
            }
            else
            {
                throw new Exception("Комп'ютер не має живлення");
            }
        }
        public bool WatchVideo()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            else if (hasPowerSupply || ((battery != null && battery.IsCharged())))
            {
                throw new Exception("Комп'ютер не увімкнено");
            }
            else if (!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Комп'ютер не підключений до мережі");
            }
            else
            {
                throw new Exception("Комп'ютер не має живлення");
            }
        }
    }
}
