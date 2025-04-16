namespace Lab1
{
    public class Laptop : Device
    {

        public Laptop(int cores, double clockSpeedGHz, int ram, int rom, int capacity)
        {
            CPU = new CPU(cores, clockSpeedGHz);
            memory = new Memory(ram, rom);
            powerSupply = new PowerSupply();
            battery = new Battery(capacity);

            powerSupply.On += PowerSupply_On;
            powerSupply.Off += PowerSupply_Off;
        }

        public override bool Work()
        {
            if (isRunning && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged())
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Ноутбук не увімкнений");
            }
            else if(!hasPowerSupply && battery != null && !battery.IsCharged())
            {
                throw new Exception("Ноутбук розряджений");
            }
            else
            {
                throw new Exception("Ноутбук не має живлення");
            }
        }
        public override bool Play()
        {
            if (isRunning && hasPowerSupply && games > 0 && CPU.GetCores() >= 4 && CPU.GetClockSpeedGHz() >= 3.0 && memory.GetRAM() >= 2)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if(!isRunning)
            {
                throw new Exception("Ноутбук не увімкнений");
            }
            else if (games <= 0)
            {
                throw new Exception("Ігри на ноутбуці відсутні");
            }
            else if (CPU.GetCores() < 4 || CPU.GetClockSpeedGHz() < 3.0 || memory.GetRAM() < 4)
            {
                throw new Exception("Ноутбук слабкий для гри в ігри");
            }
            else if (isRunning && battery.IsCharged() && games > 0 && CPU.GetCores() >= 4 && CPU.GetClockSpeedGHz() >= 3.0 && memory.GetRAM() >= 2)
            {
                Thread.Sleep(500);
                battery.DischargeBattery(1750);
                return true;
            }
            else if (!hasPowerSupply || (battery != null && !battery.IsCharged()))
            {
                throw new Exception("Ноутбук розряджений");
            }
            return false;
        }
        public override bool Chat()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            else if (hasPowerSupply || (battery != null && battery.IsCharged()))
            {
                throw new Exception("Ноутбук не увімкнений");
            }
            else if (!hasPowerSupply || (battery != null && !battery.IsCharged()))
            {
                throw new Exception("Ноутбук розряджений");
            }
            else if (!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Ноутбук не підключений до мережі");
            }
            return false;
            

        }
        public override bool ListenMusic()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded && hasHeadset)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded && hasHeadset)
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            else if (!isRunning && (hasPowerSupply || (battery != null && battery.IsCharged())))
            {
                throw new Exception("Ноутбук не увімкнений");
            }
            else if (!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Ноутбук не підключений до мережі");
            }
            else if (!hasHeadset)
            {
                throw new Exception("Гарнітура відсутня");
            }
            else if (!hasPowerSupply || (battery != null && !battery.IsCharged()))
            {
                throw new Exception("Ноутбук розряджений");
            }
             
            
            return false;
        }
        public override bool WatchVideo()
        {
            if (isRunning && hasPowerSupply && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (isRunning && battery != null && battery.IsCharged() && connectedToNetwork && browserDownloaded)
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(1750);
                return true;
            }
            else if (!isRunning && (hasPowerSupply || (battery != null && battery.IsCharged())))
            {
                throw new Exception("Ноутбук не увімкнений");
            }
            else if (!browserDownloaded)
            {
                throw new Exception("Браузер відсутній");
            }
            else if (!connectedToNetwork)
            {
                throw new Exception("Ноутбук не підключений до мережі");
            }
            else if (!hasPowerSupply || (battery != null && !battery.IsCharged()))
            {
                throw new Exception("Ноутбук розряджений");
            }
            
            return false;
            }
        }
    }
