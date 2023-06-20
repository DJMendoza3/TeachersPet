namespace TeachersPet.Models
{
    public class OpenAiResponse
    {
        public string id { get; set; }
        public string object_ { get; set; }
        public string created { get; set; }
        public string model { get; set; }
        public string[] choices { get; set; }
        public string unsage { get; set; }
        
    }
}