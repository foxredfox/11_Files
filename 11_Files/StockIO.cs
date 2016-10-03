using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    class StockIO
    {
        private String output;
        private String NL = Environment.NewLine;

        public void WriteStock(StringWriter a, Stock b)
        {
            a.Write(b.Symbol + NL + b.PricePerShare + NL + b.NumShares + NL);
            a.Close();
        }

        public void WriteStock(FileInfo a, Stock b)
        {
            Byte[] info = new UTF8Encoding(true).GetBytes(b.Symbol + " " + b.PricePerShare + " " + b.NumShares);

            using (FileStream fs = a.OpenWrite()){
                fs.Write(info, 0, info.Length);
            }
        }

        public Stock ReadStock(StringReader data)
        {
            Stock  stock = new Stock(data.ReadLine(), Convert.ToDouble(data.ReadLine()), Convert.ToInt32(data.ReadLine()));
            return stock;
        }

        public Stock ReadStock(FileInfo data)
        {
            String   dataString;

            using (StreamReader reader = data.OpenText())
            {
                dataString = reader.ReadToEnd();
            }

            String[] dataSplit     = dataString.Split(' ');
            String   Symbol        = dataSplit[0];
            double   PricePerShare = Convert.ToDouble(dataSplit[1]);
            int      NumShares     = Convert.ToInt32(dataSplit[2]);
            Stock    stock         = new Stock(Symbol, PricePerShare, NumShares);
            
            return   stock;
        }
    }
}