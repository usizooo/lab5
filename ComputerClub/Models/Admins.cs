using ComputerClub.View_Models;

namespace ComputerClub.Models
{
    public class Admins : Singleton
    {
        public static Admins Instance => Instance<Admins>();
        private Admins() 
        {
            //AdminsList = new List<Admin>()
            //{
            //    new Admin("ivan", "i123i")
            //};
        }

        public List<Admin> AdminsList { get; set; } = new List<Admin>();
    }
}
