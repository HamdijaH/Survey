namespace Survey1
{
    public class SurveyObject
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;   
        public DateTime Start { get; set; }
        public DateTime End { get; set; }   
        public string description { get; set; } = string.Empty; 
        public string createdBy { get; set; } = string.Empty;

    }
}
 