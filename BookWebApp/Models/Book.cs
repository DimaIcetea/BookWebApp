namespace BookWebApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int AuthorId { get; set; }

        //Автор книги
        public Author Author { get; set; }
        //Детали книги(Один к одному)
        public BookDetails Details { get; set; }

    }
}
