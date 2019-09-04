
namespace ConsoleTest
{
    class Car
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string colour { get; set; }
        public int milage { get; set; }

        public string FullInfo
        {
            get
            {
                return $"Car Id :{Id} Car Brand :{brand} Car Colour:{colour} Car Milage:{milage}";
            }
        }

    }
}
