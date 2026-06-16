namespace LocadoraDeCarrosAPI.Models
{
    public class Car
    {
        public int CarId { get; private set; }
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public int Year { get; private set; }
        public decimal DailyRate { get; private set; }

        protected Car() 
        { 

        }

        public Car(string model, string brand, int year, decimal dailyRate)
        {
            Model = model;
            Brand = brand;
            Year = year;
            DailyRate = dailyRate;
        }

        public void UpdateCar(string model, string brand, int year, decimal dailyRate)
        {
            Model = model;
            Brand = brand;
            Year = year;
            DailyRate = dailyRate;
        }
    }
}
