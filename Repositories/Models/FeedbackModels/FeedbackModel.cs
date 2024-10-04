namespace Repositories.Models.FeedbackModels
{
    public class FeedbackModel
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public Guid AccountID { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; } = null!;
    }
}
