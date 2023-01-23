using WebApi.DBOperations;

namespace webApi.Application.GenreOperations.createGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookStoreDBContext _context;

        public CreateGenreCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        { 
            
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}