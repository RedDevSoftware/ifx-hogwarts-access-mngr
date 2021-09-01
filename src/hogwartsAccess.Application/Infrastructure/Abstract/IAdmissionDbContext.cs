namespace Ifx.Services.hogwartsAccess.Application.Infrastructure.Abstract
{
    using System.Threading.Tasks;
    using System.Threading;
    using Ifx.Services.hogwartsAccess.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IAdmissionDbContext
    {
        DbSet<Admission> Admissions { get; set; }
        DbSet<Student> Students { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
