namespace APBD_Tut2_Example.Models;

public abstract class User(string fName, string L9Name)
{
    private static int _nextId = 1;

    public int Id { get; set; } = _nextId++;
    public string FName { get; set; } = fName;
    public string LName { get; set; } = L9Name;
    
    public abstract int GetMaxReservations();
}

public class Student(string fName, string LName) : User(fName, LName)
{
    public override int GetMaxReservations() => 2;
}

public class Teacher(string fName, string LName) :  User(fName, LName)
{
    public override int GetMaxReservations() => 3;
}