namespace RentApp.Infrastructure.Model
{
    public class Address : Entity
    
    {
        public string Street { get; set; }    
        public string City { get; set; }   
        public string ZipCode { get; set; }   
        public string Country { get; set; }   
        
        
    }
}