using APBD_Tut2_Example.Enums;

namespace APBD_Tut2_Example.Models;

public class Equipment(string name)
{
    private static int _nextId = 1;
    public int id { get; } = _nextId++;
    public string name { get; set; } = name;
    public ItemStatus Status { get; set; } = ItemStatus.Available;
}

public class Laptop(string name, string Processor, int ram) : Equipment(name)
{
    public string Processor { get; set; } = Processor;
    public int ram { get; set; } = ram;
}

public class Projektor(string name, String lens) : Equipment(name)
{
    public string lens { get; set; } = lens;
}

public class Camera(string name, String lens, int res) : Equipment(name)
{
    public string lens { get; set; } = lens;
    public int res { get; set; } = res;
}


