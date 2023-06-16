namespace TeachersPet.Models
{
    public class GeneratorSettings
    {
        public string Subject { get; set; } = null!;
        public string Topic { get; set; } = null!;
        public int Grade { get; set; } = 0;
        public float Difficulty { get; set; } = 0;
        public int NumberOfQuestions { get; set; }
        public int NumberOfAnswers { get; set; }


        public float CalculateCredits() {
            
            int baseCredits = 1;
            float questionModifier = (float)NumberOfQuestions / 10;
            float answerModifier = (float)NumberOfAnswers / 4;

            return baseCredits + questionModifier + answerModifier;
        }
    }
}