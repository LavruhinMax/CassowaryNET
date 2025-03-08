namespace CassowaryApp.Service
{
    public class questionAnswer
    {
        public string question { get; set; }
        public string answer { get; set; }
        public bool showAnswer { get; set; }
    }

    public class faqGroup
    {
        public string group { get; set; }
        public List<questionAnswer> questions { get; set; }
    }

}
