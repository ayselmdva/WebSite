namespace WebApp.Repositories.Concrete;

public class UnitOfWork :IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    private IDirectorRepository _directorRepository;
    private IActorRepository _actorRepository;
    private IGenreRepository _genreRepository;
    private IMovieRepository _movieRepository;
   /* private ICommentRepository _commentRepository;*/
    private IShoppingRepository _shoppingRepository;
    private IOderHeaderRepository _oderHeaderRepository;
    private IOderDetailtRepository _oderDetailtRepository;

   
    public IDirectorRepository DirectorRepository => _directorRepository ??= new DirectorRepository(_context);
    public IActorRepository ActorRepository=>_actorRepository ??=new ActorRepository(_context);
    public IGenreRepository GenreRepository=>_genreRepository ??=new GenreRepository(_context);
    public IMovieRepository MovieRepository=>_movieRepository ??=new MovieRepository(_context);
   /* public ICommentRepository CommentRepository=> _commentRepository ??= new CommentRepository(_context);*/
    public IShoppingRepository ShoppingRepository=>_shoppingRepository ??= new ShoppingRepository(_context);
    public IOderHeaderRepository OderHeaderRepository => _oderHeaderRepository ??= new OderHeaderRepository(_context);
    public IOderDetailtRepository OderDetailtRepository=>_oderDetailtRepository ??= new OderDetailtRepository(_context);


    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
