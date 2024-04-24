namespace ComputerClub.Models
{
    public class Orders : Singleton
    {
        public static Orders Instance => Instance<Orders>();
        public List<Order> OrdersList { get; set; } = new List<Order>();

        private Orders()  { }
    }
}