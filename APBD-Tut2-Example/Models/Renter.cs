using APBD_Tut2_Example.Exceptions;

namespace APBD_Tut2_Example.Models;

public class Renter(Equipment equipment, User user, DateTime From, DateTime To)
{
        public static int _nextId = 1;
        public int Id { get; } =  _nextId++;
        public Equipment equipment { get; set; } = equipment;
        public User user { get; set; } =  user;
        public DateTime From { get; set; } = From >= To ? throw new ArgumentException("Invalid time range") : From;
        public DateTime dueDate { get; set; } = To;
        public DateTime? ReturnDate { get; set; } = null;

        public bool jestOddane => ReturnDate.HasValue;
        
        public bool Overlaps(DateTime from, DateTime to)
        {
                return !(From > to || from > To);
        }
}

        