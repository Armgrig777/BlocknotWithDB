using BlocknotWithRepo.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithRepo.Data.Abstract
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        void Add(T record);
        void Update(T record);
        void Delete(T record);
        void SaveChanges();
    }
}
