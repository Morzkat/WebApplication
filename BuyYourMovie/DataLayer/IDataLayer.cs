using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuyYourMovie.DataLayer
{
    //a inteface with basics methods necessaries
    public interface IDataLayer<ModelsClass>
    {
        SqlConnection connection { get; }
        IEnumerable<ModelsClass> GetAll();
        ModelsClass GetById(int id);
        bool DeleteById(int id);
        bool Put(ModelsClass updateLog, int id);
        bool Post(ModelsClass newLog);
    }
}
