namespace AzsApp.WF.Models
{
    internal class Data
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int AmountOfFuel { get; set; }

        public int Station_ID { get; set; }
    }
}
