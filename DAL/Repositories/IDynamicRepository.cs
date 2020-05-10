using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IDynamicRepository
    {
        int Add<T>(string uspName, T item);
        T Add<T>(string uspName, object param);
        T Get<T>(string uspName, object param = null);
        List<T> All<T>(string uspName, object param = null);
        List<T> List<T>(string query, object param = null);
        int Delete(string uspName, object param = null);
        int DeleteMultiple(string uspName, string ids);
        void Delete<T>(T entity);
        T Find<T>(string uspName, int id);
        T FindBy<T>(string uspName, object entityParam = null);
        T FindByName<T>(string name);
        int Update<T>(string uspName, T entity);
        int AddOrUpdateDynamic(string uspName, dynamic entity);
    }
}
