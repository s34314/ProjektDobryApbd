using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Services.Rentals;
using APBD_Tut2_Example.Services.Reservations;
using APBD_Tut2_Example.Enums;

var user1 = new Teacher("Jan", "Kowalski");
var user2 = new Student("Michael", "Doe");

var equip1 = new Laptop("Dell XPS", "i7", 16);
var equip2 = new Camera("Sony Alpha", "Full Frame", 4);
var equip3 = new Projektor("Epsztain EB-X", "Short Throw");

IEquipment equipment = new EquipmentService();

equipment.AddEquipment(equip1);
equipment.AddEquipment(equip2);
equipment.AddEquipment(equip3);

RentalService rentalService = new RentalService();

try
{
    Console.WriteLine("\n[Attempt to rent equipment that is not available]: ");
    rentalService.CreateRental(
        user1,
        equip2,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Attempt to create conflicting rental]: ");
    rentalService.CreateRental(
        user1,
        equipment.GetEquipment(1),
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
    
    rentalService.CreateRental(
        user2,
        equip1,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Attempt to return not existing rental]: ");
    rentalService.ReturnEquipment(10);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Attempt to get not existing equipment]: ");
    var equipment1 = equipment.GetEquipment(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\n[Attempt to exceed limit (Student max 2)]: ");
    rentalService.CreateRental(user2, equip3, DateTime.Now, DateTime.Now.AddDays(1));
    rentalService.CreateRental(user2, equipment.GetEquipment(2), DateTime.Now, DateTime.Now.AddDays(1));
    rentalService.CreateRental(user2, equip1, DateTime.Now, DateTime.Now.AddDays(1));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\n--- Raport końcowy ---");
Console.WriteLine($"Liczba wszystkich wypożyczeń: {rentalService.GetAll().Count}");