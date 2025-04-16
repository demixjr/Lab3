namespace Lab3
{
    public class Memory
    {
        private int RAM;
        private int ROM;

        private int usedROM;

        public Memory(int ram, int rom) 
        {
            this.RAM = ram;
            this.ROM = rom;
         
            usedROM = 0;
        }

        public void AllocateROM(int size)
        {
            if(size < (ROM- usedROM))
            {
                usedROM += size;
            }
        }
        
        public int FreeROM()
        {
            return ROM - usedROM;
        }
        public int GetROM()
        {
            return ROM;
        }


        public int GetRAM()
        {
            return RAM;
        }
    }
}
