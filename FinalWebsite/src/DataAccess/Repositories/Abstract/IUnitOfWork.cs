namespace WebApp.Repositories.Abstract;

public interface IUnitOfWork
{
    public IDirectorRepository DirectorRepository { get; }
    public IActorRepository ActorRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IMovieRepository MovieRepository { get; }
   /* public ICommentRepository CommentRepository { get; }*/
    public IShoppingRepository ShoppingRepository { get; }
    public IOderHeaderRepository OderHeaderRepository { get; }
    public IOderDetailtRepository OderDetailtRepository { get; }
    Task SaveChangeAsync();
}
