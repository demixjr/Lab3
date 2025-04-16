using Lab3.ChainOfResponsibility;
using Lab3.Observer;

namespace Lab3
{
    public class Smartphone : Device
    {

        public Smartphone(int cores, double clockSpeedGHz, int ram, int rom, int capacity)
        {
            CPU = new CPU(cores, clockSpeedGHz);
            memory = new Memory(ram, rom);
            powerSupply = new PowerSupply();
            battery = new Battery(capacity);

            SubscribeToPowerSupply(powerSupply);
        }
        protected override void OnPowerChanged(object sender, PowerSupplyChangedEventArgs e)
        {
            hasPowerSupply = e.IsPoweredOn;
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
                battery.DischargeBattery(62);
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
                Thread.Sleep(1000);
                battery.DischargeBattery(187);
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
                battery.DischargeBattery(62);
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
                battery.DischargeBattery(62);
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
                battery.DischargeBattery(187);
                return true;
            }
            return false;
        }
    }
}
