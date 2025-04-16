namespace Lab3
{
    public class CPU
    {
        int Cores { get; set; }
        double ClockSpeedGHz { get; set; }

        public CPU( int cores, double clockSpeedGHz)
        {
            Cores = cores;
            ClockSpeedGHz = clockSpeedGHz;
        }
        
        public int GetCores()
        {
            return Cores;
        }
        public double GetClockSpeedGHz()
        {
            return ClockSpeedGHz;
        }
    }
}
