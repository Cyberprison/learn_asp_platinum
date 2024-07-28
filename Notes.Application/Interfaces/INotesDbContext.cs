using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces
{
    public class INotesDbContext
    {
        //все сущности
        DbSet<Note> Notes { get; set; }

        //дублирование метода
        //сохранения контекста в БД
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
