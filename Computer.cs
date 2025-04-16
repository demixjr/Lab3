using Lab3.ChainOfResponsibility;

namespace Lab3
{
    public class Computer: Device
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
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
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
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
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
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
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
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
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
                Thread.Sleep(500);
                battery.DischargeBattery(500);
                throw new Exception("Джерело безперервного живлення без енергії");
            }
            return false;
        }
        }
    }

