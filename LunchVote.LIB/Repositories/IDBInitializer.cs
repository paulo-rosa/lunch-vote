using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchVote.LIB.Repositories
{
    public interface IDBInitializer
    {
        Task Initialize();
    }
}
