using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySql.Data.MySqlClient;
using ConsoleApp8.Services;
namespace ConsoleApp8.MySql
{
    class DatabaseRun
    {
        
        private static string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;";

        public static void DataRunner()
        {
            

            var CarSql = @"CREATE TABLE IF NOT EXISTS Cars(
	            Id INT AUTO_INCREMENT PRIMARY KEY,
                Brand varchar(60),
                Model varchar(50),
                Year int,
                KmPerLiter float,
                TotalKm int,
                DailyPrice int,
                WeeklyPrice int,
                MonthlyPrice int,
                Status boolean default true
    
                );";

            var CustomerSql = @"CREATE TABLE IF NOT EXISTS Customer(
	                Id INT AUTO_INCREMENT PRIMARY KEY,
                    CustomerName varchar(50),
                    CustomerSurname varchar(50),
                    CustomerPassword varchar(50),
                    CustomerPhone varchar(50),
                    CustomerTc varchar(50),
                    CustomerBirthYear varchar(50));";

            


            var RentSql = @"CREATE TABLE IF NOT EXISTS Rent(
	                Id int Auto_increment PRIMARY KEY,
                    CarId int,
                    CustomerId int,
                    RentDate varchar(50),
                    ReturnDate varchar(50) 
                );";

            var AdminSql = @"CREATE TABLE IF NOT EXISTS Admin(
	                Username varchar(50),
                    Password varchar (50)
                );";

            var AdminInsert = @"INSERT INTO Admin(Username, Password) VALUES
                ('root' , 'root');";

            var CarInsert = @"INSERT INTO Cars (Brand, Model, Year, KmPerLiter, TotalKm, DailyPrice, WeeklyPrice, MonthlyPrice) VALUES
            ('Alfa Romeo', 'Giulietta 1.6 JTDM', 2018, 19.0, 80000, 300, 1500, 4500),
            ('Alfa Romeo', '159 2.0 JTS', 2010, 11.2, 160000, 250, 1250, 3750),
            ('Alfa Romeo', 'MiTo 1.4 TB', 2012, 15.5, 120000, 200, 1000, 3000),
            ('Alfa Romeo', 'Giulia 2.2 Diesel', 2021, 17.0, 30000, 500, 2500, 7500),
            ('Alfa Romeo', 'Stelvio 2.0 TB', 2020, 12.0, 50000, 600, 3000, 9000),
            ('Alfa Romeo', '147 1.6 TS', 2008, 10.8, 180000, 150, 750, 2250),
            ('Audi', 'A3 Sportback 1.6 TDI', 2018, 20.0, 90000, 500, 2500, 7500),
            ('Audi', 'A4 2.0 TDI', 2015, 17.5, 150000, 450, 2250, 6750),
            ('Audi', 'Q5 2.0 TDI', 2017, 14.0, 80000, 550, 2750, 8250),
            ('Audi', 'A6 3.0 TDI', 2019, 12.0, 60000, 650, 3250, 9750),
            ('Audi', 'Q7 3.0 TDI', 2020, 10.5, 50000, 700, 3500, 10500),
            ('Audi', 'A5 Sportback 2.0 TDI', 2021, 14.8, 30000, 600, 3000, 9000),
            ('BMW', 'F30 320d', 2016, 18.0, 120000, 600, 3000, 9000),
            ('BMW', 'E46 320i', 2002, 11.0, 190000, 500, 2500, 7500),
            ('BMW', 'E36 318i', 1998, 12.5, 210000, 400, 2000, 6000),
            ('BMW', 'F10 520i', 2015, 13.5, 120000, 650, 3250, 9750),
            ('BMW', 'G20 320i', 2020, 15.0, 30000, 700, 3500, 10500),
            ('BMW', 'F25 X3 xDrive20d', 2018, 16.5, 60000, 750, 3750, 11250),
            ('Dacia', 'Duster 1.5 dCi', 2021, 20.0, 40000, 400, 2000, 6000),
            ('Dacia', 'Logan 1.5 dCi', 2015, 21.0, 120000, 350, 1750, 5250),
            ('Dacia', 'Sandero Stepway 1.0 TCe', 2022, 19.5, 20000, 300, 1500, 4500),
            ('Dacia', 'Dokker 1.5 dCi', 2018, 22.0, 80000, 400, 2000, 6000),
            ('Dacia', 'Lodgy 1.5 dCi', 2017, 20.0, 100000, 450, 2250, 6750),
            ('Dacia', 'Spring Electric', 2023, 0, 10000, 700, 3500, 10500),
            ('Fiat', 'Egea 1.6 Multijet', 2022, 22.0, 15000, 350, 1750, 5250),
            ('Fiat', 'Linea 1.3 Multijet', 2015, 19.0, 140000, 300, 1500, 4500),
            ('Fiat', 'Doblo 1.6 Multijet', 2020, 18.0, 60000, 400, 2000, 6000),
            ('Fiat', 'Fiorino 1.3 Multijet', 2021, 20.0, 40000, 350, 1750, 5250),
            ('Fiat', 'Panda 1.2', 2019, 6.0, 50000, 250, 1250, 3750),
            ('Fiat', '500 1.2 Lounge', 2018, 5.0, 70000, 300, 1500, 4500),
            ('Ford', 'Focus 1.5 TDCi', 2018, 20.0, 100000, 400, 2000, 6000),
            ('Ford', 'Fiesta 1.0 EcoBoost', 2020, 22.0, 60000, 350, 1750, 5250),
            ('Ford', 'Mondeo 2.0 TDCi', 2016, 17.0, 120000, 450, 2250, 6750),
            ('Ford', 'Kuga 2.0 TDCi', 2020, 18.0, 70000, 550, 2750, 8250),
            ('Ford', 'Transit Connect 1.5 TDCi', 2021, 15.0, 80000, 500, 2500, 7500),
            ('Ford', 'Puma 1.0 EcoBoost', 2022, 19.5, 30000, 600, 3000, 9000),
            ('Honda', 'Civic 1.6 i-DTEC', 2019, 23.0, 80000, 400, 2000, 6000),
            ('Honda', 'CR-V 1.6 i-DTEC', 2018, 19.0, 100000, 450, 2250, 6750),
            ('Honda', 'Jazz 1.3', 2021, 18.0, 40000, 350, 1750, 5250),
            ('Honda', 'HR-V 1.5 i-VTEC', 2020, 17.0, 60000, 500, 2500, 7500),
            ('Honda', 'Accord 2.2 i-DTEC', 2017, 18.5, 120000, 600, 3000, 9000),
            ('Honda', 'Amaze 1.2 i-VTEC', 2022, 21.0, 25000, 350, 1750, 5250),
            ('Hyundai', 'i20 1.4 CRDi', 2019, 21.0, 80000, 400, 2000, 6000),
            ('Hyundai', 'i30 1.6 CRDi', 2020, 19.0, 70000, 450, 2250, 6750),
            ('Hyundai', 'Tucson 1.6 CRDi', 2021, 17.5, 60000, 500, 2500, 7500),
            ('Hyundai', 'Santa Fe 2.2 CRDi', 2019, 14.0, 90000, 600, 3000, 9000),
            ('Hyundai', 'Kona 1.6 CRDi', 2021, 18.0, 40000, 550, 2750, 8250),
            ('Hyundai', 'Elantra 1.6 CRDi', 2020, 21.0, 50000, 450, 2250, 6750),
            ('Jaguar', 'F-Pace 2.0d', 2021, 12.0, 30000, 700, 3500, 10500),
            ('Jaguar', 'XE 2.0d', 2020, 13.5, 40000, 650, 3250, 9750),
            ('Jaguar', 'XF 2.0d', 2019, 14.0, 50000, 750, 3750, 11250),
            ('Jaguar', 'E-Pace 2.0d', 2021, 15.0, 20000, 800, 4000, 12000),
            ('Jaguar', 'I-Pace', 2020, 0, 30000, 1000, 5000, 15000),
            ('Jaguar', 'XJ 3.0d', 2017, 11.0, 80000, 850, 4250, 12750),
            ('Nissan', 'Qashqai 1.5 dCi', 2021, 22.0, 30000, 550, 2750, 8250),
            ('Nissan', 'X-Trail 1.6 dCi', 2020, 20.0, 40000, 600, 3000, 9000),
            ('Nissan', 'Juke 1.5 dCi', 2019, 23.0, 50000, 500, 2500, 7500),
            ('Nissan', 'Leaf Electric', 2022, 0, 15000, 750, 3750, 11250),
            ('Nissan', 'Altima 2.5', 2018, 15.0, 80000, 450, 2250, 6750),
            ('Nissan', 'Micra 1.2', 2017, 18.0, 90000, 300, 1500, 4500),
            ('Opel', 'Astra 1.6 CDTi', 2020, 20.0, 70000, 500, 2500, 7500),
            ('Opel', 'Corsa 1.4', 2019, 18.0, 50000, 350, 1750, 5250),
            ('Opel', 'Insignia 2.0 CDTi', 2021, 17.5, 60000, 550, 2750, 8250),
            ('Opel', 'Mokka 1.6 CDTi', 2020, 19.0, 45000, 600, 3000, 9000),
            ('Opel', 'Zafira 1.6 CDTi', 2018, 21.0, 80000, 400, 2000, 6000),
            ('Opel', 'Grandland X 1.6 CDTi', 2021, 17.0, 30000, 650, 3250, 9750),
            ('Peugeot', '308 1.6 HDi', 2019, 22.0, 70000, 500, 2500, 7500),
            ('Peugeot', '208 1.5 BlueHDi', 2020, 23.0, 50000, 450, 2250, 6750),
            ('Peugeot', '3008 1.6 BlueHDi', 2021, 21.0, 40000, 600, 3000, 9000),
            ('Peugeot', '508 2.0 BlueHDi', 2020, 19.5, 60000, 700, 3500, 10500),
            ('Peugeot', 'Partner 1.5 BlueHDi', 2022, 23.5, 20000, 400, 2000, 6000),
            ('Peugeot', 'Traveller 2.0 BlueHDi', 2021, 20.0, 35000, 650, 3250, 9750),
            ('Mitsubishi', 'Outlander 2.2 DI-D', 2020, 17.0, 60000, 550, 2750, 8250),
            ('Mitsubishi', 'L200 2.4 DI-D', 2021, 16.0, 40000, 600, 3000, 9000),
            ('Mitsubishi', 'ASX 1.6 DI-D', 2019, 18.5, 70000, 500, 2500, 7500),
            ('Mitsubishi', 'Eclipse Cross 1.5', 2020, 17.0, 50000, 600, 3000, 9000),
            ('Mitsubishi', 'Pajero 3.2 DI-D', 2018, 13.5, 90000, 700, 3500, 10500),
            ('Mitsubishi', 'Space Star 1.2', 2021, 19.0, 30000, 400, 2000, 6000),
            ('Porsche', '911 Carrera 2.0', 2020, 10.5, 20000, 1500, 7500, 22500),
            ('Porsche', 'Macan 2.0', 2021, 12.0, 40000, 1300, 6500, 19500),
            ('Porsche', 'Cayenne 3.0', 2020, 9.0, 30000, 1700, 8500, 25500),
            ('Porsche', 'Panamera 4.0', 2021, 8.5, 25000, 2000, 10000, 30000),
            ('Porsche', 'Taycan 4S', 2022, 0, 10000, 2000, 10000, 30000),
            ('Porsche', '718 Cayman 2.0', 2021, 11.0, 30000, 1400, 7000, 21000),
            ('Renault', 'Clio 1.5 dCi', 2020, 22.0, 50000, 350, 1750, 5250),
            ('Renault', 'Megane 1.5 dCi', 2021, 21.0, 60000, 450, 2250, 6750),
            ('Renault', 'Kadjar 1.6 dCi', 2020, 20.0, 70000, 500, 2500, 7500),
            ('Renault', 'Talisman 1.6 dCi', 2021, 18.5, 60000, 600, 3000, 9000),
            ('Renault', 'Captur 1.5 dCi', 2022, 21.5, 40000, 550, 2750, 8250),
            ('Renault', 'Zoe Electric', 2021, 0, 15000, 700, 3500, 10500),
            ('Seat', 'Leon 1.6 TDI', 2021, 22.0, 60000, 500, 2500, 7500),
            ('Seat', 'Ibiza 1.0 TSI', 2020, 21.0, 50000, 400, 2000, 6000),
            ('Seat', 'Ateca 1.6 TDI', 2020, 20.5, 70000, 550, 2750, 8250),
            ('Seat', 'Arona 1.6 TDI', 2021, 21.0, 45000, 500, 2500, 7500),
            ('Seat', 'Exeo 2.0 TDI', 2019, 18.5, 80000, 600, 3000, 9000),
            ('Seat', 'Mii Electric', 2022, 0, 10000, 450, 2250, 6750),
            ('Suzuki', 'Swift 1.2 Dualjet', 2021, 19.0, 30000, 350, 1750, 5250),
            ('Suzuki', 'Vitara 1.6 DDIS', 2020, 18.5, 60000, 450, 2250, 6750),
            ('Suzuki', 'Baleno 1.2', 2021, 21.0, 50000, 400, 2000, 6000),
            ('Suzuki', 'S-Cross 1.6 DDIS', 2020, 17.5, 70000, 500, 2500, 7500),
            ('Suzuki', 'Jimny 1.5 DDIS', 2021, 16.0, 40000, 600, 3000, 9000),
            ('Suzuki', 'Alto 1.0', 2020, 18.0, 30000, 300, 1500, 4500),
            ('Subaru', 'Outback 2.0D', 2021, 18.0, 60000, 600, 3000, 9000),
            ('Subaru', 'Forester 2.0D', 2020, 16.5, 70000, 650, 3250, 9750),
            ('Subaru', 'Impreza 1.6', 2019, 17.5, 50000, 500, 2500, 7500),
            ('Subaru', 'XV 1.6D', 2020, 19.0, 40000, 550, 2750, 8250),
            ('Subaru', 'Levorg 1.6D', 2021, 18.0, 30000, 600, 3000, 9000),
            ('Subaru', 'BRZ 2.0', 2022, 0, 15000, 700, 3500, 10500),
            ('Tesla', 'Model 3 Standard Range Plus', 2022, 0, 20000, 1200, 6000, 18000),
            ('Tesla', 'Model S Long Range', 2022, 0, 30000, 1500, 7500, 22500),
            ('Tesla', 'Model X Long Range', 2022, 0, 25000, 1800, 9000, 27000),
            ('Tesla', 'Model Y Long Range', 2022, 0, 15000, 1600, 8000, 24000),
            ('Tesla', 'Cybertruck', 2023, 0, 5000, 2000, 10000, 30000),
            ('Tesla', 'Roadster', 2022, 0, 10000, 2500, 12500, 37500),
            ('Tofaş', 'Fiat Egea 1.3 Multijet', 2020, 22.0, 50000, 350, 1750, 5250),
            ('Tofaş', 'Fiat Doblo 1.3 Multijet', 2019, 20.0, 60000, 450, 2250, 6750),
            ('Tofaş', 'Fiat Fiorino 1.3 Multijet', 2021, 21.0, 70000, 400, 2000, 6000),
            ('Tofaş', 'Fiat Panda 1.2', 2020, 18.0, 40000, 300, 1500, 4500),
            ('Tofaş', 'Fiat 500 1.2', 2019, 23.0, 30000, 500, 2500, 7500),
            ('Tofaş', 'Fiat Tipo 1.6 Multijet', 2021, 20.0, 50000, 600, 3000, 9000),
            ('Toyota', 'Corolla 1.6 D-4D', 2020, 22.0, 60000, 500, 2500, 7500),
            ('Toyota', 'Yaris 1.5 Hybrid', 2021, 25.0, 50000, 400, 2000, 6000),
            ('Toyota', 'Hilux 2.4 D-4D', 2021, 19.0, 70000, 600, 3000, 9000),
            ('Toyota', 'RAV4 2.0 D-4D', 2020, 20.0, 80000, 550, 2750, 8250),
            ('Toyota', 'Land Cruiser 2.8 D-4D', 2021, 18.0, 90000, 700, 3500, 10500),
            ('Toyota', 'Supra 3.0', 2021, 15.0, 20000, 1000, 5000, 15000),
            ('Volkswagen', 'Golf 1.6 TDI', 2020, 21.0, 60000, 500, 2500, 7500),
            ('Volkswagen', 'Passat 2.0 TDI', 2021, 22.0, 70000, 550, 2750, 8250),
            ('Volkswagen', 'Tiguan 2.0 TDI', 2021, 19.5, 80000, 600, 3000, 9000),
            ('Volkswagen', 'Polo 1.6 TDI', 2020, 23.0, 40000, 450, 2250, 6750),
            ('Volkswagen', 'Arteon 2.0 TDI', 2021, 20.0, 50000, 700, 3500, 10500),
            ('Volkswagen', 'ID.4 Electric', 2022, 0, 10000, 800, 4000, 12000),
            ('Volvo', 'XC60 2.0 D4', 2021, 20.0, 60000, 650, 3250, 9750),
            ('Volvo', 'S60 2.0 D3', 2020, 21.0, 50000, 600, 3000, 9000),
            ('Volvo', 'V90 2.0 D4', 2021, 19.0, 70000, 700, 3500, 10500),
            ('Volvo', 'XC90 2.0 T6', 2020, 18.0, 80000, 800, 4000, 12000),
            ('Volvo', 'XC40 2.0 D3', 2021, 22.0, 60000, 550, 2750, 8250),
            ('Volvo', 'Polestar 2 Electric', 2022, 0, 15000, 1000, 5000, 15000),
            ('Mercedes-Benz', 'A-Class A180d', 2020, 20.0, 60000, 700, 3500, 10500),
            ('Mercedes-Benz', 'B-Class B200d', 2020, 21.0, 50000, 750, 3750, 11250),
            ('Mercedes-Benz', 'E-Class E220d', 2021, 22.0, 70000, 900, 4500, 13500),
            ('Mercedes-Benz', 'C-Class C180d', 2020, 19.0, 60000, 800, 4000, 12000),
            ('Mercedes-Benz', 'GLC 250d', 2020, 18.0, 80000, 1000, 5000, 15000),
            ('Mercedes-Benz', 'S-Class S500', 2020, 17.0, 90000, 1200, 6000, 18000),
            ('Land Rover', 'Range Rover Evoque', 2021, 16.0, 50000, 1100, 5500, 16500),
            ('Land Rover', 'Discovery Sport 2.0', 2021, 15.0, 40000, 1200, 6000, 18000),
            ('Land Rover', 'Defender 110 2.0', 2021, 14.5, 30000, 1300, 6500, 19500),
            ('Land Rover', 'Freelander 2.2', 2018, 18.0, 70000, 1000, 5000, 15000),
            ('Land Rover', 'Range Rover Sport 3.0', 2020, 14.0, 80000, 1400, 7000, 21000),
            ('Land Rover', 'Discovery 4 3.0', 2019, 16.0, 90000, 1100, 5500, 16500),
            ('Chrysler', 'Pacifica Hybrid', 2021, 0, 25000, 1200, 6000, 18000),
            ('Chrysler', 'Voyager', 2020, 0, 20000, 1000, 5000, 15000),
            ('Chrysler', '300C 3.0 CRD', 2019, 16.5, 80000, 750, 3750, 11250),
            ('Chrysler', 'Grand Voyager', 2018, 0, 70000, 850, 4250, 12750),
            ('Chrysler', 'Chrysler 200 2.4', 2017, 15.0, 90000, 600, 3000, 9000),
            ('Chrysler', 'Saratoga 3.0', 2017, 14.0, 100000, 500, 2500, 7500),
            ('Mini', 'Cooper 1.5', 2020, 18.5, 40000, 600, 3000, 9000),
            ('Mini', 'Countryman 1.5', 2021, 17.0, 50000, 650, 3250, 9750),
            ('Mini', 'Clubman 1.5', 2020, 19.0, 30000, 550, 2750, 8250),
            ('Mini', 'John Cooper Works 2.0', 2021, 16.5, 20000, 700, 3500, 10500),
            ('Mini', 'Convertible 1.5', 2021, 18.0, 25000, 750, 3750, 11250),
            ('Mini', 'Electric 1.0', 2022, 0, 15000, 1000, 5000, 15000),
            ('Lexus', 'RX 450h', 2020, 15.0, 60000, 850, 4250, 12750),
            ('Lexus', 'NX 300h', 2021, 17.0, 50000, 900, 4500, 13500),
            ('Lexus', 'IS 300h', 2020, 18.0, 40000, 750, 3750, 11250),
            ('Lexus', 'ES 300h', 2021, 16.0, 30000, 800, 4000, 12000),
            ('Lexus', 'LS 500h', 2020, 15.5, 70000, 1000, 5000, 15000),
            ('Lexus', 'LC 500h', 2021, 0, 20000, 1200, 6000, 18000),
            ('Ferrari', 'Portofino M', 2021, 0, 15000, 4000, 20000, 60000),
            ('Ferrari', 'Roma', 2021, 0, 10000, 3500, 17500, 52500),
            ('Ferrari', 'F8 Tributo', 2020, 0, 20000, 4500, 22500, 67500),
            ('Ferrari', '812 GTS', 2020, 0, 30000, 5000, 25000, 75000),
            ('Togg', 'T10X 1.0', 2023, 0, 10000, 1000, 5000, 15000),
            ('Togg', 'T10X 2.0', 2023, 0, 5000, 1200, 6000, 18000),
            ('Togg', 'T10X Electric', 2023, 0, 15000, 1500, 7500, 22500),
            ('Togg', 'T10X Performance', 2023, 0, 20000, 1700, 8500, 25500),
            ('Togg', 'T10X SUV', 2023, 0, 8000, 1300, 6500, 19500),
            ('Togg', 'T10X Sedan', 2023, 0, 3000, 1400, 7000, 21000);";

            string connect = "Server=localhost;Database=CarRent;User=root;Password=122333;"; // ilk bu assagida gordugunuz kodu tektek var command= new mysqlcommand formatında yazdım fakat calısmadı. boyle yapmak en ıyısı.

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();

                var commands = new List<string> { CustomerSql, AdminSql, RentSql, CarSql, CarInsert, AdminInsert };

                foreach (var sql in commands)
                {
                    try
                    {
                        using (var command = new MySqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine($"Başarıyla çalıştırıldı: {sql.Substring(0, Math.Min(sql.Length, 30))}...");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hata oluştu: {ex.Message}");
                    }
                }
            }








        }




    }

}
