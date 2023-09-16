namespace KheftProject.Book.Business.Abstractions;

public interface IUnpaidBooksRemoverJob
{
    Task RemoveUnpaidBooks();
}