namespace LocadoraDeCarrosAPI.Models
{
    public class Rental
    {
        public int RentalId { get; private set; }
        public int CarId { get; private set; }
        public Car? Car { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        protected Rental() 
        { 

        }

        public Rental(int carId, DateTime startDate, DateTime endDate)
        {
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
        }


    }
}
