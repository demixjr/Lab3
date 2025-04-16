using Lab3.ChainOfResponsibility;

namespace Lab3
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
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();

            powerCheck.SetNext(runningCheck);

            if (powerCheck.Check(this) && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (powerCheck.Check(this))
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            return false;
        }
        public override bool Play()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            gamesCheck = new GamesCheck();

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(gamesCheck);

            if (powerCheck.Check(this) && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (powerCheck.Check(this))
            {
                Thread.Sleep(500);
                battery.DischargeBattery(1750);
                return true;
            }
            return false;
        }
        public override bool Chat()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            networkCheck = new NetworkCheck();
            browserCheck = new BrowserCheck();

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(networkCheck);
            networkCheck.SetNext(browserCheck);

            if (powerCheck.Check(this) && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (powerCheck.Check(this))
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            return false;
        }
        public override bool ListenMusic()
        {

            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            networkCheck = new NetworkCheck();
            browserCheck = new BrowserCheck();
            headphonesCheck = new HeadphonesCheck();

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(networkCheck);
            networkCheck.SetNext(browserCheck);
            browserCheck.SetNext(headphonesCheck);

            if (powerCheck.Check(this) && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (powerCheck.Check(this))
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(580);
                return true;
            }
            return false;
        }
        public override bool WatchVideo()
        {
            powerCheck = new PowerCheck();
            runningCheck = new IsRunningCheck();
            networkCheck = new NetworkCheck();
            browserCheck = new BrowserCheck();
            headphonesCheck = new HeadphonesCheck();

            powerCheck.SetNext(runningCheck);
            runningCheck.SetNext(networkCheck);
            networkCheck.SetNext(browserCheck);
            browserCheck.SetNext(headphonesCheck);

            if (powerCheck.Check(this) && hasPowerSupply)
            {
                Thread.Sleep(1000);
                return true;
            }
            else if (powerCheck.Check(this))
            {
                Thread.Sleep(1000);
                battery.DischargeBattery(1750);
                return true;
            }
            return false;
        }
        }
    }
