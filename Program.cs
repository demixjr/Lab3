
using System;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            ConsoleMenu menu = new ConsoleMenu();

            Console.WriteLine("Симулятор пристроїв");
            Console.WriteLine("1 с = 1 година в симуляції");
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Оберіть пристрій:");

            
                while (!exit)
                {
                try
                {
                    int device = menu.DeviceChoose();
                    switch (device)
                    {

                        case 1:
                            Computer computer = null;
                            while (computer == null)
                            {
                                computer = (Computer)menu.AddDevice(1);

                            }
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Девайс додано");
                            bool computerReady = true;
                            while (computerReady)
                            {
                                int choose = menu.ActionChoose();
                                bool action = false;
                                try
                                {
                                    switch (choose)
                                    {
                                        case 0:
                                            computerReady = false;
                                            break;
                                        case 1:
                                            computer.RunDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Комп'ютер запущено");
                                            break;
                                        case 2:
                                            computer.PowerSupply_On();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення під'єднано");
                                            break;
                                        case 3:
                                            bool network = computer.ConnectToNetwork();
                                            if (network)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Під'єднано до мережі");
                                            break;
                                        case 4:
                                            bool browser = computer.DownloadBrowser();
                                            if (browser)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Браузер завантажено");
                                            break;
                                        case 5:
                                            int game = computer.DownloadGame();
                                            if (game > 0)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гру {game} завантажено");
                                            break;
                                        case 6:
                                            bool headset = computer.ConnectHeadSet();
                                            if (headset)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гарнітуру підключено");
                                            break;
                                        case 7:
                                            bool charge = computer.ChargeBattery();
                                            if (charge)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Джерело безперервного живлення заряджено");
                                            break;
                                        case 8:
                                            if (computer.Work())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали працювати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви працюєте.");
                                                action = computer.Work();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили працювати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 9:
                                            if (computer.Play())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали грати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви граєте.");
                                                action = computer.Play();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили грати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 10:
                                            if (computer.Chat())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали спілкуватися. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви спілкуєтесь.");
                                                action = computer.Chat();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили спілкуватися");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 11:
                                            if (computer.ListenMusic())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали слухати музику. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви слухаєте музику.");
                                                action = computer.ListenMusic();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили слухати музику");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 12:
                                            if (computer.WatchVideo())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали дивитись відео. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви дивитесь відео.");
                                                action = computer.WatchVideo();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили дивитись відео");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 13:
                                            computer.PowerSupply_Off();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення вимкнено");
                                            break;
                                        case 14:
                                            computer.CloseDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Компютер вимкнено");
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]{ex.Message}");
                                }

                            }
                            break;
                        case 2:
                            Laptop laptop = null;
                            while (laptop == null)
                            {
                                laptop = (Laptop)menu.AddDevice(2);

                            }
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ноутбук додано");
                            bool laptopReady = true;
                            while (laptopReady)
                            {
                                int choose = menu.ActionChoose();
                                bool action = false;
                                try
                                {
                                    switch (choose)
                                    {
                                        case 0:
                                            laptopReady = false;
                                            break;
                                        case 1:
                                            laptop.RunDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ноутбук запущено");
                                            break;
                                        case 2:
                                            laptop.PowerSupply_On();
                                            laptop.ChargeBattery();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення під'єднано");
                                            break;
                                        case 3:
                                            bool network = laptop.ConnectToNetwork();
                                            if (network)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Під'єднано до мережі");
                                            break;
                                        case 4:
                                            bool browser = laptop.DownloadBrowser();
                                            if (browser)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Браузер завантажено");
                                            break;
                                        case 5:
                                            int game = laptop.DownloadGame();
                                            if (game > 0)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гру {game} завантажено");
                                            break;
                                        case 6:
                                            bool headset = laptop.ConnectHeadSet();
                                            if (headset)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гарнітуру підключено");
                                            break;
                                        case 7:
                                            bool charge = laptop.ChargeBattery();
                                            if (charge)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Акумулятор заряджено");
                                            break;
                                        case 8:
                                            if (laptop.Work())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали працювати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви працюєте.");
                                                action = laptop.Work();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили працювати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 9:
                                            if (laptop.Play())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали грати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви граєте.");
                                                action = laptop.Play();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили грати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 10:
                                            if (laptop.Chat())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали спілкуватися. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви спілкуєтесь.");
                                                action = laptop.Chat();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили спілкуватися");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 11:
                                            if (laptop.ListenMusic())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали слухати музику. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви слухаєте музику.");
                                                action = laptop.ListenMusic();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили слухати музику");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 12:
                                            if (laptop.WatchVideo())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали дивитись відео. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви дивитесь відео.");
                                                action = laptop.WatchVideo();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили дивитись відео");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 13:
                                            laptop.PowerSupply_Off();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення вимкнено");
                                            break;
                                        case 14:
                                            laptop.CloseDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ноутбук вимкнено");
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]{ex.Message}");
                                }

                            }
                            break;
                        case 3:
                            Smartphone smartphone = null;
                            while (smartphone == null)
                            {
                                smartphone = (Smartphone)menu.AddDevice(3);

                            }
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Смартфон додано");
                            bool smartphoneReady = true;
                            while (smartphoneReady)
                            {
                                int choose = menu.ActionChoose();
                                bool action = false;
                                try
                                {
                                    switch (choose)
                                    {
                                        case 0:
                                            smartphoneReady = false;
                                            break;
                                        case 1:
                                            smartphone.RunDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Смартфон увімкнено");
                                            break;
                                        case 2:
                                            smartphone.PowerSupply_On();
                                            smartphone.ChargeBattery();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення під'єднано");
                                            break;
                                        case 3:
                                            bool network = smartphone.ConnectToNetwork();
                                            if (network)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Під'єднано до мережі");
                                            break;
                                        case 4:
                                            bool browser = smartphone.DownloadBrowser();
                                            if (browser)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Браузер завантажено");
                                            break;
                                        case 5:
                                            int game = smartphone.DownloadGame();
                                            if (game > 0)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гру {game} завантажено");
                                            break;
                                        case 6:
                                            bool headset = smartphone.ConnectHeadSet();
                                            if (headset)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гарнітуру підключено");
                                            break;
                                        case 7:
                                            bool charge = smartphone.ChargeBattery();
                                            if (charge)
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Акумулятор заряджено");
                                            break;
                                        case 8:
                                            if (smartphone.Work())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали працювати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви працюєте.");
                                                action = smartphone.Work();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили працювати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 9:
                                            if (smartphone.Play())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали грати. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви граєте.");
                                                action = smartphone.Play();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили грати");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 10:
                                            if (smartphone.Chat())
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали спілкуватися. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви спілкуєтесь.");
                                                action = smartphone.Chat();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили спілкуватися");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 11:
                                            if (smartphone.ListenMusic())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали слухати музику. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви слухаєте музику.");
                                                action = smartphone.ListenMusic();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили слухати музику");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 12:
                                            if (smartphone.WatchVideo())
                                            {

                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали дивитись відео. \nНатисніть кнопку щоб вийти з симуляції");
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви дивитесь відео.");
                                                action = smartphone.WatchVideo();

                                                if (Console.KeyAvailable)
                                                {
                                                    action = false;
                                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили дивитись відео");
                                                    break;
                                                }
                                            }
                                            break;
                                        case 13:
                                            smartphone.PowerSupply_Off();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення вимкнено");
                                            break;
                                        case 14:
                                            smartphone.CloseDevice();
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Смартфон вимкнено");
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]{ex.Message}");
                                }

                            }
                            break;
                        case 0:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка {ex.Message}");
                }
            }
            
        }
            }

        }
    

