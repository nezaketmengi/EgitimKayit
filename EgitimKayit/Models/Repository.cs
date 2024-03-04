namespace EgitimKayit.Models
{
    public static class Respository
    {
        private static List<Candidate> applications = new();
        public static IEnumerable<Candidate> Applications => applications; //geriye liste döndürmek için, yani kimler başvuru yaptı görmek istediğimizde IEnumerable
        public static void Add(Candidate candidate)
        {
            applications.Add(candidate); // formdan gelen verileri listeye eklemek için
        }
    }
}