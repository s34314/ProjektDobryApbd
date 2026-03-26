using APBD_Tut2_Example.Models;
using APBD_Tut2_Example.Exceptions;
namespace APBD_Tut2_Example.Services.Reservations;

public class EquipmentService : IEquipment
{
    private static readonly List<Equipment> _equipmentList = [];

    public void CancelReservation(int RenterId)
    {
        _equipmentList.RemoveAll(e => e.id == RenterId);
    }
    
    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }
    
    

    public Equipment GetEquipment(int id)
    {
        var equipment = _equipmentList.FirstOrDefault(e => e.id == id);
        if (equipment is null)
        {
            throw new EquipmentException.EquipmentNotFound(id);
        }
        return equipment;
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipmentList;
    }
}