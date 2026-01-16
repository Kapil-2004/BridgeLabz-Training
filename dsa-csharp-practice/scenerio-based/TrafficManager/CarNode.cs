namespace TrafficManager
{
    public class CarNode
    {
        public Car Data { get; set; }
        public CarNode Next { get; set; }

        public CarNode(Car car)
        {
            Data = car;
            Next = null;
        }
    }
}
