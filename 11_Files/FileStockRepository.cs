using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    class FileStockRepository : IFileRepository
    {
        private long        Id      = 0;
        private StockIO     stockIO  = new StockIO();
        private List<Stock> stocks  = new List<Stock>();

        public FileStockRepository() { }

        public FileStockRepository(DirectoryInfo dir) { }
        
        public string StockFileName(long id){return "stock"+id+".txt";}
        public string StockFileName(Stock stock){return "stock"+stock.Id+".txt";}

        public long NextId(){return ++Id;}

        public void SaveStock(Stock stock)
        {
            stock.Id = NextId();
            stocks.Add(stock);
            stockIO.WriteStock(new FileInfo(StockFileName(stock.Id)), stock);
        }

        public Stock LoadStock(long id)
        {
            return stockIO.ReadStock(new FileInfo(StockFileName(id)));
        }

        public void Clear()
        {
            stocks.Clear();
        }

        ICollection IStockRepository.FindAllStocks()
        {
            return stocks;
        }
    }
}
