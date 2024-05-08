using System.ComponentModel;

namespace BookWebApp.Models
{
    public class Author
    {
        public int Id { get; set; }

        [DefaultValue("Dmitry")]
        public string Name { get; set; }

        //Книги автора
        public ICollection<Book> Books { get; set; }=new List<Book>();
        //Издательства
        public List<Publisher> Publishers { get; set; } = new List<Publisher>();
        //Многие ко многим(Издатели\Авторы)
        public List<PublishersAuthors> PublishersAuthors { get; set; } = new List<PublishersAuthors>();


    }
}
