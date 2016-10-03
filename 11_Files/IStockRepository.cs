using System.Collections;

namespace _11_Files
{
    interface IStockRepository
    {
        long        NextId();
        void        SaveStock(Stock stock);
        Stock       LoadStock(long id);
        void        Clear();
        ICollection FindAllStocks();
    }
}
