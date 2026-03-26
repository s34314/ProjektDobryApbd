using APBD_Tut2_Example.Models;

namespace APBD_Tut2_Example.Services.Reservations;

public interface IEquipment
{
    public void AddEquipment(Equipment equipment);
    public void CancelReservation(int RenterId);
    public List<Equipment> GetAllEquipments(); 
    Equipment GetEquipment(int id);
}