using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace MenuDyn.Models
{
    public class User
    {
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string birthdate { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public string profilePic { get; set; }
        public string suscription { get; set; }
        public string rut { get; set; }
        public string fairyName { get; set; }
        public string enterpriseName { get; set; }
    }
}
