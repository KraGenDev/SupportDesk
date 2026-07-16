namespace SupportDesk.Core.Domain.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User Creator { get; set; }

        public Comment(string text,User creator)
        {
            Id = Guid.NewGuid();
            Text = text;
            Creator = creator;
        }
    }
}
