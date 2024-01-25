namespace Library.API.Models
{
    public class Livro
    {
        public Livro(string title, string actor, string description)
        {
            Title = title;
            Actor = actor;
            Description = description;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }
    }
}
