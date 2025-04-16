using Lab3.Observer;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
           
            bool deviceReady = false;
            ConsoleMenu menu = ConsoleMenu.GetInstance();

            Console.WriteLine("Симулятор пристроїв");
            Console.WriteLine("1 с = 1 година в симуляції");
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Оберіть пристрій:");
            while (!exit)
            {
                try
                {
                    Device device = null;
                    int deviceChoose = menu.DeviceChoose();
                    switch (deviceChoose)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            do
                            {
                                device = (Computer)menu.AddDevice(1);
                            }
                            while (device == null);
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Девайс додано");
                            deviceReady = true;
                            break;
                        case 2:
                            do
                            {
                                device =(Laptop)menu.AddDevice(2);
                            }
                            while (device == null);
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Девайс додано");
                            deviceReady = true;
                            break;
                        case 3:
                            do
                            {
                                device = (Smartphone)menu.AddDevice(3);
                            }
                            while (device == null);
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Девайс додано");
                            deviceReady = true;
                            break;

                    }
                    while (deviceReady)
                    {
                        int choose = menu.ActionChoose();
                        bool action = false;
                        try
                        {
                            switch (choose)
                            {
                                case 0:
                                    deviceReady = false;
                                    device = null;
                                    break;
                                case 1:
                                    device.RunDevice();
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Девайс запущено");
                                    break;
                                case 2:
                                    device.powerSupply.TurnOn();
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення під'єднано");
                                    break;
                                case 3:
                                    bool network = device.ConnectToNetwork();
                                    if (network)
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Під'єднано до мережі");
                                    break;
                                case 4:
                                    bool browser = device.DownloadBrowser();
                                    if (browser)
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Браузер завантажено");
                                    break;
                                case 5:
                                    int game = device.DownloadGame();
                                    if (game > 0)
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гру {game} завантажено");
                                    break;
                                case 6:
                                    bool headset = device.ConnectHeadSet();
                                    if (headset)
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Гарнітуру підключено");
                                    break;
                                case 7:
                                    bool charge = device.ChargeBattery();
                                    if (charge)
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Джерело безперервного живлення заряджено");
                                    break;
                                case 8:
                                    if (device.Work())
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали працювати. \nНатисніть кнопку щоб вийти з симуляції");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви працюєте.");
                                        action = device.Work();

                                        if (Console.KeyAvailable)
                                        {
                                            action = false;
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили працювати");
                                            break;
                                        }
                                    }
                                    break;
                                case 9:
                                    if (device.Play())
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали грати. \nНатисніть кнопку щоб вийти з симуляції");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви граєте.");
                                        action = device.Play();

                                        if (Console.KeyAvailable)
                                        {
                                            action = false;
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили грати");
                                            break;
                                        }
                                    }
                                    break;
                                case 10:
                                    if (device.Chat())
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали спілкуватися. \nНатисніть кнопку щоб вийти з симуляції");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви спілкуєтесь.");
                                        action = device.Chat();

                                        if (Console.KeyAvailable)
                                        {
                                            action = false;
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили спілкуватися");
                                            break;
                                        }
                                    }
                                    break;
                                case 11:
                                    if (device.ListenMusic())
                                    {

                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали слухати музику. \nНатисніть кнопку щоб вийти з симуляції");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви слухаєте музику.");
                                        action = device.ListenMusic();

                                        if (Console.KeyAvailable)
                                        {
                                            action = false;
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили слухати музику");
                                            break;
                                        }
                                    }
                                    break;
                                case 12:
                                    if (device.WatchVideo())
                                    {

                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви почали дивитись відео. \nНатисніть кнопку щоб вийти з симуляції");
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви дивитесь відео.");
                                        action = device.WatchVideo();

                                        if (Console.KeyAvailable)
                                        {
                                            action = false;
                                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Ви закінчили дивитись відео");
                                            break;
                                        }
                                    }
                                    break;
                                case 13:
                                    device.powerSupply.TurnOff();
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Живлення вимкнено");
                                    break;
                                case 14:
                                    device.CloseDevice();
                                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]Компютер вимкнено");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}]{ex.Message}");
                        }

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
       