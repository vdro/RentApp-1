using System.Collections.Generic;

namespace RentApp.Infrastructure.Model
{
    public class Owner : Person
    {
        public List<Flat> Flats { get; set; }
        
    }
}