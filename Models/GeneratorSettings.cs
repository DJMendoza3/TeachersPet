namespace TeachersPet.Models
{
    public class GeneratorSettings
    {
        public string TestName { get; set; } = null!;
        public string TestDescription { get; set; } = null!;
        //replace testgroup with a ref to a testgroup object that refs a user in the future
        public string TestGroup { get; set; } = null!;
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
        
        public static TestDto ParseResponse(string response) 
        {
            TestDto test = new TestDto() { Questions = new List<QuestionDto>()};
            string formattedResponse = response.Trim('"');
            List<string> splitLines = formattedResponse.Split(@"\n").ToList();
            int count = 3;
            foreach(string line in splitLines) {
                if(string.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                if(count % 3 == 0) {
                    test.Questions.Add(new QuestionDto() {Answers = new List<AnswerDto>()});
                }
                Console.WriteLine("This is the line:" + line);
                List<string> splitLine = line.Split(":").ToList();
                if(splitLine[0].Contains("Question")) {
                    test.Questions.Last().Text = splitLine[1];
                }
                else if(splitLine[0].Contains("Correct Answer")) {
                    string formattedAnswer = splitLine[1].Replace("\",", "").Trim();
                    Console.WriteLine("This is the correct answer:" + formattedAnswer);
                    var answer = test.Questions.Last().Answers.FirstOrDefault(a => a.Text == formattedAnswer);
                    if(answer != null) {
                        answer.IsCorrect = true;
                    }
                    continue;
                }
                else if(splitLine[0].Contains("Answer")) {
                    List<string> splitAnswers = splitLine[1].Split(",").ToList();
                    
                    foreach(string answer in splitAnswers) {
                        if(string.IsNullOrWhiteSpace(answer)) {
                            continue;
                        }
                        string formattedAnswer = answer.Trim(new char[] {'{', '}', ' ', '"'});
                        test.Questions.Last().Answers.Add(new AnswerDto() {Text = formattedAnswer});
                        Console.WriteLine("This is the answer:" + formattedAnswer);
                    }
                }
                
                count++;
            }
            Console.WriteLine("This is the test:" + test);
            return test;
        }
    }
}