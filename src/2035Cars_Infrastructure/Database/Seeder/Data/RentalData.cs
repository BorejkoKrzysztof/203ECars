using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Infrastructure.Database.Seeder.Data
{
    public class RentalData
    {
        private readonly string _wwwRootPath;

        public RentalData(string wwwrootPath)
        {
            this._wwwRootPath = wwwrootPath;
        }

        public List<Rental> GetRentals()
        {
            return new List<Rental>()
        {
            new Rental()
            {
                Title = "Rynek",
                ShortTitle = "Ryn",
                Address = new Address("Rynek", "5c", "Warszawa", "00-001"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Audi",
                            Model = "E Tron",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 200.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Audi_e-tron.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Jaguar",
                            Model = "I Pace",
                            Equipment = new CarEquipment(true, true, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Jaguar_I_Pace.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Jan", "Nowak", "653987333"),
                                Address = new Address("Toruńska", "21/12", "Warszawa", "00-001"),
                                Account = new Account("jannowak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Tomasz", "Wasilewski", "564876223"),
                                Address = new Address("Śląska", "122", "Warszawa", "00-001"),
                                Account = new Account("tomaszwasilewski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Agata", "Morawska", "546783333"),
                                Address = new Address("Miejska", "12c", "Warszawa", "00-001"),
                                Account = new Account("agatamorawska@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                                                        new Employee()
                            {
                                Person = new Person("Mariusz", "Kowalski", "666354898"),
                                Address = new Address("Piłsudzkiego", "2d", "Warszawa", "00-001"),
                                Account = new Account("mariuszkowalski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Dworzec PKP",
                ShortTitle = "PKP",
                Address = new Address("Dworcowa", "1", "Warszawa", "00-008"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Krakowski", "964862168"),
                                Address = new Address("Dworcowa", "3", "Warszawa", "00-008"),
                                Account = new Account("krzysztofkrakowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Szczepaniak", "589777122"),
                                Address = new Address("Nowa", "1a", "Warszawa", "00-008"),
                                Account = new Account("alicjaszczepaniak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Brzeszczyński", "349118212"),
                                Address = new Address("Poznańska", "2a", "Warszawa", "00-008"),
                                Account = new Account("bartoszbrzeszczynski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Pudzianowski", "345789122"),
                                Address = new Address("Silna", "2d", "Warszawa", "00-008"),
                                Account = new Account("mariuszpudzianowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Śródmieście",
                ShortTitle = "Śrd",
                Address = new Address("Wesoła", "12/a", "Warszawa", "00-017"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Skoda",
                            Model = "Enyaq",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 350.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Skoda_Enyaq.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Kia",
                            Model = "Ev6",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Kia_ev6.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Marcel", "Wesołowski", "687211987"),
                                Address = new Address("Dworcowa", "3", "Warszawa", "00-017"),
                                Account = new Account("marcelwesolowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Andrzej", "Ponichtera", "332874649"),
                                Address = new Address("Polna", "1a", "Warszawa", "00-017"),
                                Account = new Account("andrzejponichtera@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Jacek", "Strach", "456987222"),
                                Address = new Address("Ogrodowa", "5c/13", "Warszawa", "00-017"),
                                Account = new Account("jacekstrach@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Jakub", "Gajdziński", "254956284"),
                                Address = new Address("Ogrodowa", "2d", "Warszawa", "00-017"),
                                Account = new Account("jacekgajdzinski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Praga",
                ShortTitle = "Prg",
                Address = new Address("Praska", "41", "Warszawa", "00-021"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Audi",
                            Model = "E-Tron",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Audi_e-tron.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Hyundai",
                            Model = "Ioniq",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Hyundai_Ioniq_5.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Gach", "123456789"),
                                Address = new Address("Kościelna", "3", "Warszawa", "00-021"),
                                Account = new Account("krzysztofgach@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Joanna", "Szarzyńska", "589777122"),
                                Address = new Address("Bukowa", "1a", "Warszawa", "00-021"),
                                Account = new Account("joannaszarzynska@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Robak", "349118212"),
                                Address = new Address("Czysta", "23", "Warszawa", "00-021"),
                                Account = new Account("bartoszrobak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Możejko", "345875698"),
                                Address = new Address("Silna", "2d", "Warszawa", "00-021"),
                                Account = new Account("mariuszmozejko@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Dworzec PKP",
                ShortTitle = "PKP",
                Address = new Address("Kolejowa", "1", "Wrocław", "45-573"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Katarzyna", "Zima", "245764789"),
                                Address = new Address("Dziedzicka", "3", "Wrocław", "45-573"),
                                Account = new Account("katarzynazima@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Jarosław", "Sobecki", "589777122"),
                                Address = new Address("Jaśminowa", "12", "Wrocław", "45-573"),
                                Account = new Account("jaroslawsobecki@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Oskar", "Okoń", "349118212"),
                                Address = new Address("Gdańska", "2a", "Wrocław", "45-573"),
                                Account = new Account("oskarokon@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartłomiej", "Miszewski", "345789122"),
                                Address = new Address("Gliwicka", "22a", "Wrocław", "45-573"),
                                Account = new Account("bartlomiejmiszewski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Rynek",
                ShortTitle = "Ryn",
                Address = new Address("Rynek", "12", "Wrocław", "50-004"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Magdalena", "Kisiel", "964862168"),
                                Address = new Address("Makowa", "3", "Wrocław", "50-004"),
                                Account = new Account("magdalenakisiel@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Oliwia", "Kotas", "124536789"),
                                Address = new Address("Łysogórska", "1a", "Wrocław", "50-004"),
                                Account = new Account("oliwiakotas@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Chmieliński", "125354676"),
                                Address = new Address("Poznańska", "2a", "Wrocław", "50-004"),
                                Account = new Account("bartoszchmielinski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Maciej", "Gad", "834847122"),
                                Address = new Address("Krótka", "2d/3", "Wrocław", "50-004"),
                                Account = new Account("maciejgad@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Krzyki",
                ShortTitle = "Krz",
                Address = new Address("Gwarna", "1a", "Wrocław", "50-473"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Szymon", "Nieradka", "376477283"),
                                Address = new Address("Dworcowa", "3", "Wrocław", "50-473"),
                                Account = new Account("szymonnieradka@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Szyszka", "589777122"),
                                Address = new Address("Krzyżowa", "122", "Wrocław", "50-473"),
                                Account = new Account("alicjaszyszka@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Robert", "Sudoł", "354834834"),
                                Address = new Address("Poznańska", "2a", "Wrocław", "50-473"),
                                Account = new Account("bartoszbrzeszczynski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Pudzianowski", "345789122"),
                                Address = new Address("Silna", "2d", "Wrocław", "50-473"),
                                Account = new Account("mariuszpudzianowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Port",
                ShortTitle = "Prt",
                Address = new Address("Portowa", "1", "Gdańsk", "80-000"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Hyundai",
                            Model = "Ioniq",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Hyundai_Ioniq_5.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Jaroslaw", "Szlęzak", "964862168"),
                                Address = new Address("Krośniewicka", "3", "Gdańsk", "80-000"),
                                Account = new Account("jaroslawszlezak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Wójtowicz", "589777122"),
                                Address = new Address("Nowa", "1a", "Gdańsk", "80-000"),
                                Account = new Account("alicjawojtowicz@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Marcin", "Frąckowiak", "349118212"),
                                Address = new Address("Poznańska", "2a", "Gdańsk", "80-000"),
                                Account = new Account("marcinfrackowiak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Michał", "Banaś", "345789122"),
                                Address = new Address("Silna", "2d", "Gdańsk", "80-000"),
                                Account = new Account("michalbanas@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Rynek",
                ShortTitle = "Ryn",
                Address = new Address("Rynek", "A", "Gdańsk", "80-001"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Jarosławski", "964862168"),
                                Address = new Address("Krzesiny", "3", "Gdańsk", "80-001"),
                                Account = new Account("krzysztofjaroslawski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Anna", "Szczepaniak", "589777122"),
                                Address = new Address("Nowa", "1a", "Gdańsk", "80-001"),
                                Account = new Account("annaszczepaniak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Artur", "Topolewski", "354235667"),
                                Address = new Address("Poznańska", "2a", "Gdańsk", "80-001"),
                                Account = new Account("arturtopolewski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Gutkowski", "345789122"),
                                Address = new Address("Pabianicka", "2d", "Gdańsk", "80-001"),
                                Account = new Account("mariuszgutkowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Zachód",
                ShortTitle = "Zch",
                Address = new Address("Zachodnia", "12", "Szczecin", "16-402"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Górzyński", "964862168"),
                                Address = new Address("Pawia", "3", "Szczecin", "16-402"),
                                Account = new Account("krzysztofgorzynski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Sak", "739584823"),
                                Address = new Address("Skibowa", "1a", "Szczecin", "16-402"),
                                Account = new Account("alicjasak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Grabarczyk", "349118212"),
                                Address = new Address("Rolna", "2a", "Szczecin", "16-402"),
                                Account = new Account("bartoszgrabarczyk@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Żurek", "345789122"),
                                Address = new Address("Silna", "2d", "Szczecin", "16-402"),
                                Account = new Account("mariuszzurek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Port",
                ShortTitle = "Prt",
                Address = new Address("Portowa", "12c", "Szczecin", "70-000"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Krakowski", "964862168"),
                                Address = new Address("Dworcowa", "3", "Szczecin", "70-000"),
                                Account = new Account("krzysztofkrakowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Szczepaniak", "589777122"),
                                Address = new Address("Nowa", "1a", "Szczecin", "70-000"),
                                Account = new Account("alicjaszczepaniak@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Brzeszczyński", "349118212"),
                                Address = new Address("Poznańska", "2a", "Szczecin", "70-000"),
                                Account = new Account("bartoszbrzeszczynski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Pudzianowski", "345789122"),
                                Address = new Address("Silna", "2d", "Szczecin", "70-000"),
                                Account = new Account("mariuszpudzianowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Stare Miasto",
                ShortTitle = "StM",
                Address = new Address("Rynek", "1a", "Kraków", "30-001"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Maciej", "Niedziałkowski", "964862168"),
                                Address = new Address("Kotlińska", "32/a", "Kraków", "30-001"),
                                Account = new Account("maciejniedzialkowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Kacper", "Smolarek", "273947238"),
                                Address = new Address("Korzenna", "1a", "Kraków", "30-001"),
                                Account = new Account("kacpersmolarek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Aleksander", "Chudzicki", "349118212"),
                                Address = new Address("Kozienicka", "2a", "Kraków", "30-001"),
                                Account = new Account("aleksanderchudzinski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Skrzypkowski", "345789122"),
                                Address = new Address("Lisia", "2d", "Kraków", "30-001"),
                                Account = new Account("mariuszskrzypkowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Wawel",
                ShortTitle = "Wwl",
                Address = new Address("Zamkowa", "12", "Kraków", "30-002"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Maciej", "Zieliński", "964862168"),
                                Address = new Address("Łanowa", "3", "Kraków", "30-002"),
                                Account = new Account("maciejzielinski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Karol", "Wysokiński", "589777122"),
                                Address = new Address("Mścibora", "1a", "Kraków", "30-002"),
                                Account = new Account("karolwysokinski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Przygodzki", "349118212"),
                                Address = new Address("Poznańska", "2a", "Kraków", "30-002"),
                                Account = new Account("bartoszprzygodzki@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Andrzej", "Lechowski", "345789122"),
                                Address = new Address("Łosiowa", "2d", "Kraków", "30-002"),
                                Account = new Account("andrzejlechowski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Kazimierz",
                ShortTitle = "Kzm",
                Address = new Address("Aleja 3-go Maja", "32/b", "Kraków", "31-321"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Krzysztof", "Wiśniewski", "964862168"),
                                Address = new Address("Dworcowa", "3", "Kraków", "31-321"),
                                Account = new Account("krzysztofwisniewski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Wieczorek", "589777122"),
                                Address = new Address("Nowa", "1a", "Kraków", "31-321"),
                                Account = new Account("alicjawieczorek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Karol", "Urbanek", "349118212"),
                                Address = new Address("Podmiejska", "24a", "Kraków", "31-321"),
                                Account = new Account("karolurbanek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Katarzyna", "Czekała", "345789122"),
                                Address = new Address("Opatowska", "2d", "Kraków", "31-321"),
                                Account = new Account("katarzynaczekala@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Rynek",
                ShortTitle = "Ryn",
                Address = new Address("Stare Miasto", "23", "Poznań", "60-001"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Dominik", "Fałek", "964862168"),
                                Address = new Address("Olkuska", "3", "Poznań", "60-001"),
                                Account = new Account("dominikfalek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Niemiec", "589777122"),
                                Address = new Address("Nowa", "1a", "Poznań", "60-001"),
                                Account = new Account("alicjaniemiec@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Strózik", "349118212"),
                                Address = new Address("Poznańska", "2a", "Poznań", "60-001"),
                                Account = new Account("bartoszstrozik@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Zagórski", "345789122"),
                                Address = new Address("Opolska", "2d", "Poznań", "60-001"),
                                Account = new Account("mariuszzagorski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            },
            new Rental()
            {
                Title = "Stary Browar",
                ShortTitle = "StB",
                Address = new Address("Półwiejska", "21", "Poznań", "60-001"),
                CreatedDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Cars = new List<Car>()
                    {
                        new Car()
                        {
                            Brand = "Opel",
                            Model = "Mokka",
                            Equipment = new CarEquipment(false, false, false, false),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 4,
                            PriceForOneHour = 100.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Opel_mokka.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Ford",
                            Model = "Mustang Mach E",
                            Equipment = new CarEquipment(true, true, true, true),
                            CarType = CarType.Suv,
                            DriveType = DriveOfCar.Hybrid,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 220.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Ford_Mustang_Mach_E.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Volkswagen",
                            Model = "Id3",
                            Equipment = new CarEquipment(false, false, false, true),
                            CarType = CarType.Sedan,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 150.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Vw_id3.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Tesla",
                            Model = "Model S",
                            Equipment = new CarEquipment(false, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Tesla_Model_S.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                        new Car()
                        {
                            Brand = "Porsche",
                            Model = "Taycan Turbo",
                            Equipment = new CarEquipment(true, true, true, false),
                            CarType = CarType.Sport,
                            DriveType = DriveOfCar.Electric,
                            AmountOfDoor = 4,
                            AmountOfSeats = 5,
                            PriceForOneHour = 320.00M,
                            IsRented = false,
                            Image = ConvertImage(@$"{this._wwwRootPath}\images\Porsche_Taycan_Turbo.png"),
                            CreatedDate = DateTime.UtcNow,
                            LastUpdateDate = DateTime.UtcNow,
                        },
                    },
                    Employees = new List<Employee>()
                        {
                            new Employee()
                            {
                                Person = new Person("Andrzej", "Czerniawski", "964862168"),
                                Address = new Address("Poprzeczna", "3", "Poznań", "60-001"),
                                Account = new Account("andrzejczerniawski@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Management,
                                Position = BuisnessPosition.Manager,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Alicja", "Lemańczyk", "589777122"),
                                Address = new Address("Ostrowska", "1a", "Poznań", "60-001"),
                                Account = new Account("alicjalemanczyk@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Marketing,
                                Position = BuisnessPosition.Director,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Bartosz", "Mocek", "349118212"),
                                Address = new Address("Poznańska", "2a", "Poznań", "60-001"),
                                Account = new Account("bartoszmocek@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                            new Employee()
                            {
                                Person = new Person("Mariusz", "Świerk", "345789122"),
                                Address = new Address("Silna", "2d", "Poznań", "60-001"),
                                Account = new Account("mariuszswierk@gmail.com", BCrypt.Net.BCrypt.HashPassword("secret1234")),
                                Department = Department.Customer_Service,
                                Position = BuisnessPosition.Employee,
                                LastLoggedAt = DateTime.UtcNow,
                                AcceptedOrders = new List<Order>(),
                                CreatedDate = DateTime.UtcNow,
                                LastUpdateDate = DateTime.UtcNow
                            },
                        }
            }
        };
        }




        private static byte[] ConvertImage(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
    }
}