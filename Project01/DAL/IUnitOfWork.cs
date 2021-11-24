using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserDetailsRepository UserDetailsRepository { get; }

        int Save();
    }
}
