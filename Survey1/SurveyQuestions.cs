namespace Survey1
{
    public class SurveyQuestions
    {
        public int id { get; set; }
        public int surveyId { get; set; }
        public string text { get; set; } = string.Empty;
        public string questionType { get; set; } = string.Empty;

    }
}
