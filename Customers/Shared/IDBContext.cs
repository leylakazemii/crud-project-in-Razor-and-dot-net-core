using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Customers.Shared
{
    public interface IDBContext
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChanges();
    }
}