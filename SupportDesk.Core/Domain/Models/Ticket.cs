using SupportDesk.Core.Domain.Enums;

namespace SupportDesk.Core.Domain.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public string Text { get; set; }
        public DateTime CreatetAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public User Costumer { get; set; }
        public List<Comment> Comments { get; set; }
        public TicketStatus Status { get; set; }


        public Ticket(Category category,User costumer,string text)
        {
            Id = Guid.NewGuid();
            CreatetAt = DateTime.Now;
            LastUpdate = DateTime.Now;
            Costumer = costumer;
            Comments = new List<Comment>();
            Category = category;
        }

        public void AddComment(Comment comment)
        {
            if (comment == null)
                return;

            Comments.Add(comment);
        }
    }
}
