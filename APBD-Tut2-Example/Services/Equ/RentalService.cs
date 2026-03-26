using APBD_Tut2_Example.Enums;
using APBD_Tut2_Example.Exceptions;
using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Rentals;


public class RentalService 
{
    private readonly List<Renter> _rentals = []; 
    
    public void CreateRental(User user, Equipment equipment, DateTime from, DateTime to)
    {

        if (equipment.Status != ItemStatus.Available)
        {
            throw new EquipmentException.EquipmentUnavailableExpectation(equipment.id);
        }

        
        int activeUserRentals = _rentals.Count(rental => 
                                        !rental.jestOddane 
                                        && rental.user == user);

        if (activeUserRentals >= user.GetMaxReservations()) 
        {
            throw new EquipmentException.TooManyReservations(user.Id);
        }

        
        bool rentalConflict = _rentals.Any(rental =>
                                        !rental.jestOddane
                                        && rental.equipment == equipment
                                        && rental.Overlaps(from, to));

        if (rentalConflict)
        {
            throw new EquipmentException.RentalConflictExpectation(equipment.id, from, to);
        }
        
        
        var newRental = new Renter(equipment, user, from, to);
        _rentals.Add(newRental);

        
        equipment.Status = ItemStatus.Unavailable;
    }

    public void ReturnEquipment(int rentalId)
    {
        
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);
        
        if (rental is null)
        {
            throw new EquipmentException.RentalNotFoundExpectation(rentalId);
        }
        
        
        rental.ReturnDate = DateTime.Now; 
        rental.equipment.Status = ItemStatus.Available;
    }

    public List<Renter> GetUserRentals(User user)
    {
        
        return _rentals.Where(rental => rental.user == user && !rental.jestOddane).ToList();
    }

    public List<Renter> GetAll()
    {
        return _rentals;
    }
}