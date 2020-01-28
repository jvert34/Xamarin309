using Xamarin.Forms.Maps;

namespace TPNote
{
    public class Student
    {
        public int Id { get; set; }
#pragma warning disable CA1707 // Les identificateurs ne doivent pas contenir de traits de soulignement
        public int Student_id { get; set; }
        public double Gps_lat { get; set; }
        public double Gps_long { get; set; }
        public string Student_message { get; set; }
#pragma warning restore CA1707 // Les identificateurs ne doivent pas contenir de traits de soulignement
        public string PlaceName { get; set; }
        public Position Position { get; set; }
    }
}