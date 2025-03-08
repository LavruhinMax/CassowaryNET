using CassowaryApp.Pages;

namespace CassowaryApp.Service
{
    public static class UserContext
    {
        public static int ID { get; set; }
        public static string Login {get; set;}
        public static string Password { get; set; }
        public static string Status { get; set; }
        public static string Name { get; set; }
        public static string lastName { get; set; }
        public static string Adress { get; set; }
        public static string LSnumber { get; set; }
        public static int Tariff { get; set; }
        public static string Technology { get; set; }
        public static string Phone { get; set; }
        public static string Email { get; set; }
        public static int isPaused { get; set; }
    }
}
