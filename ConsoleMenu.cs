namespace Lab1
{
 
    public class ConsoleMenu
    {
       public Device AddDevice(int num)
       {
          
            int cores;
            double clockSpeedGHz;
            int ram;
            int rom;
            int capacity;

                try
                {
                    Console.WriteLine("Введіть кількість ядер процесора:");
                    cores = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть тактову частоту процесора:");
                    clockSpeedGHz = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість оперативної пам'яті:");
                    ram = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кількість постійної пам'яті:");
                    rom = int.Parse(Console.ReadLine());

                    switch (num)
                    {
                        case 1:
                            bool ups = false;
                            Console.WriteLine("Чи наявне джерело безперебійного живлення?(yes/no)");
                            string truth = Console.ReadLine();

                            if (truth == "yes")
                            {
                                ups = true;
                            }
                            else if (truth == "no")
                            {
                                ups = false;
                            }
                            else
                            {
                                throw new Exception("Невірний вибір");
                            }

                            Computer computer = new Computer(cores, clockSpeedGHz, ram, rom, ups);
                            return computer;

                        case 2:
                            Console.WriteLine("Введіть ємність акумумятора");
                            capacity = int.Parse(Console.ReadLine());

                            if (capacity < 5000 || capacity > 7000)
                                throw new Exception("Невірна ємність");
                            Laptop laptop = new Laptop(cores, clockSpeedGHz, ram, rom, capacity);
                            return laptop;

                        case 3:
                            Console.WriteLine("Введіть ємність акумумятора");
                            capacity = int.Parse(Console.ReadLine());

                            if (capacity < 2000 || capacity > 3000)
                                throw new Exception("Невірна ємність");
                            Smartphone smartphone = new Smartphone(cores, clockSpeedGHz, ram, rom, capacity);
                            return smartphone;
                        default:
                            throw new Exception("Невірний вибір");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
       }

        public int DeviceChoose()
        {
            Console.WriteLine("Натисніть нуль щоб вийти");
            Console.WriteLine("1. Комп'ютер");
            Console.WriteLine("2. Ноутбук");
            Console.WriteLine("3. Телефон");

            try
            {
                int choose = int.Parse(Console.ReadLine());

               
                if (choose < 0 || choose > 3)
                {
                    throw new Exception("Невірний вибір");
                }
                
                return choose;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int ActionChoose()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Оберіть дію");
            Console.WriteLine("1. Увімкнути пристрій");
            Console.WriteLine("2. Увімкнути живлення");
            Console.WriteLine("3. Увімкнути інтернет");
            Console.WriteLine("4. Скачати браузер");
            Console.WriteLine("5. Скачати гру");
            Console.WriteLine("6. Під'єднати гарнітуру");
            Console.WriteLine("7. Зарядити батарею");
            Console.WriteLine("8. Працювати");
            Console.WriteLine("9. Грати");
            Console.WriteLine("10. Спілкуватися");
            Console.WriteLine("11. Слухати музику");
            Console.WriteLine("12. Дивитися відео");
            Console.WriteLine("13. Вимкнути живлення");
            Console.WriteLine("14. Вимкнути пристрій");
            Console.WriteLine("0. Обрати інший пристрій");

            try
            {
                int choose = int.Parse(Console.ReadLine());
                if (choose < 0 || choose > 14)
                    throw new Exception("Невiрний вибiр");
                return choose;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
    }
}
