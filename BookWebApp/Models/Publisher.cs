namespace BookWebApp.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Авторы
        public ICollection<Author> Authors { get; set; }=new List<Author>();

        //Многие ко многим(Издатели\Авторы)
        public List<PublishersAuthors> PublishersAuthors { get; set; } = new List<PublishersAuthors>();
    }
}
