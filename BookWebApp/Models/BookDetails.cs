namespace BookWebApp.Models;
    public enum StatusEnum
    {
        complite = 0,
        write = 1,
    }

    public enum LanguageEnum
    { 
        ru = 0,
        en = 1, 
        ua = 2,
    }

    public enum GenreEnum
    { 
        fantastic,
        fantasy,
        litrpg,
        scientific,
        historical
    }

    public class BookDetails
    {
        public int BookId { get; set; }
        public Book Book { get; set; }//Один к одному
        public double Rank { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.complite;

        public decimal PaperbackCost { get; set; }
        public decimal HardcoverCost { get; set; }
        public DateTime Year { get; set; }
        public string Editor { get; set; }
        public string Illustrator { get; set; }
        public int PageCount { get; set; }
        public LanguageEnum Language { get; set; }
        public byte ReadingAge { get; set; }
        public GenreEnum Genre { get; set; }
        public int Reviews { get; set; }



    }
    
