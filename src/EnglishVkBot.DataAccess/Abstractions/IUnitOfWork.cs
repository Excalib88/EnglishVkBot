using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVkBot.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        void Rollback();

        Task SaveChanges();
    }
}
