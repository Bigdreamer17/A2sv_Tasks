public class Library
{
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";

    public List<Book> Books { get; set; }

    public List<MediaItem> MediaItems { get; set;}   

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }
    public void AddBook(Book book)
    {   
        // Adds a Books 
        Books.Add(book);   
    }

    public void RemoveBook(Book book)
    {
        // Removes a Book
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        // Adds Media Item
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        // Removes MediaItem
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        // Prints the catalog
        Console.WriteLine("Books: ");
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Publication Year: {book.PublicationYear}");
        }

        Console.WriteLine();
        Console.WriteLine("Media Items:");
        foreach (var item in MediaItems)
        {
            Console.WriteLine($"Title: {item.Title}, Media Type: {item.MediaType}, Duration: {item.Duration} minutes");
        }
    }
}

public class Book
{
    public string Title { get; set;}
    public string Author { get; set;}
    public int ISBN { get; set;}
    public int PublicationYear { get; set;}

}

public class MediaItem
{
    public string Title { get; set;}
    public string MediaType { get; set;}
    public int Duration { get; set;}

}

public class Program
{

    public static void Main()
    {
        Library library = new Library("Abrehot", "4 kilo");

        Console.WriteLine("Wellcome to Abrehot :)" );
        Console.WriteLine("********************* /n");
        Console.WriteLine("Please Specify what you what to do");
        Console.WriteLine("1 - To Add a Book");
        Console.WriteLine("2 - To Remove a Book");
        Console.WriteLine("3 - To Add a Media Item");
        Console.WriteLine("4 - To Remove Media Item");

        int UserAction = Convert.ToInt32(Console.ReadLine());

        switch  (UserAction)
        {
            case 1:
                Console.WriteLine("How many Books do u want to Add? ");
                int BookAmount = Convert.ToInt32(Console.ReadLine());
                int intializer = 0;
                while (intializer <= BookAmount)
                {
                       Console.WriteLine("Enter Title of the Book: ");
                       string BookName = Console.ReadLine();
                       
                       Console.WriteLine("Enter Author of the Book: ");
                       string BookAuthor = Console.ReadLine();
                       
                       Console.WriteLine("Enter ISBN of the Book: ");
                       int BookISBN = Convert.ToInt32(Console.ReadLine());
                       
                       Console.WriteLine("Enter Publication Year of the Book: ");
                       int BookPublicationYear = Convert.ToInt32(Console.ReadLine());

                       Book bookAdd = new Book { Title = BookName, Author = BookAuthor, ISBN = BookISBN, PublicationYear = BookPublicationYear};

                       library.AddBook(bookAdd);

                       intializer ++;
                }
            break;

            case 2:
                Console.WriteLine("What Book do u want to Remove? ");
                string Bookname = Console.ReadLine();

                Book bookRemove = library.Books.FirstOrDefault(b => b.Title == Bookname);

                if (bookRemove != null)
                {
                    library.RemoveBook(bookRemove);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not Found in the Library.");
                }
            break;

            case 3:
                Console.WriteLine("How many Media Item do u want to Add? ");
                int MediaAmount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < MediaAmount; i++)
                {
                       Console.WriteLine("Enter Title of the Book: ");
                       string MediaName = Console.ReadLine();
                       
                       Console.WriteLine("Enter Title of the Book: ");
                       string Mediatype = Console.ReadLine();
                       
                       Console.WriteLine("Enter Title of the Book: ");
                       int MediaDuration = Convert.ToInt32(Console.ReadLine());
            
                       MediaItem media = new MediaItem { Title = MediaName, MediaType = Mediatype, Duration = MediaDuration};

                       library.AddMediaItem(media);
                }
            break;

            case 4:
                Console.WriteLine("What Media do u want to Remove? ");
                string Medianame = Console.ReadLine();

                MediaItem Media = library.MediaItems.FirstOrDefault(b => b.Title == Medianame);

                if (Media != null)
                {
                    library.RemoveMediaItem(Media);
                    Console.WriteLine("Media removed successfully.");
                }
                else
                {
                    Console.WriteLine("Media not Found in the Library.");
                }
            break;


        }   
    }
}