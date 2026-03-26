namespace APBD_Tut2_Example.Exceptions;

public class EquipmentException
{
    public class RentalConflictExpectation(int equipmentId, DateTime from, DateTime to)
        : Exception($"Equipment {equipmentId} is already reserved for {from} to {to}");
    
    public class RentalNotFoundExpectation(int rentalId)
        : Exception($"Equipment {rentalId} not found");
    
    public class EquipmentNotFound(int rentalId)
        : Exception($"Equipment {rentalId} not found");
    
    public class EquipmentUnavailableExpectation(int equipmentId)
        : Exception($"Equipment {equipmentId} is unavailable");
    
    public class TooManyReservations(int userId)
        : Exception($"User {userId} has to many reservations");
        
}