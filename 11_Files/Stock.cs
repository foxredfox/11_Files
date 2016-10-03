using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Files
{
    public class Stock : Asset
    {
        public String Symbol{ get; set; }
        public double PricePerShare{ get; set; }
        public int    NumShares{ get; set; }
        public long   Id {get; set;}

        public Stock(){}
        public Stock(String Symbol, double PricePerShare, int NumShares)
        {
            this.Symbol        = Symbol;
            this.PricePerShare = PricePerShare;
            this.NumShares     = NumShares;
        }

        public String GetName()
        {
            return Symbol;
        }

        public double GetValue()
        {
            return NumShares * PricePerShare;
        }

        public static double TotalValue(Asset[] stocks)
        {
            return stocks.Sum(stock => stock.GetValue());
        }

        public override int GetHashCode(){ return base.GetHashCode(); }

        public override String ToString()
        {
            return 
                "Stock[symbol="+ Symbol +
                ",pricePerShare="+ PricePerShare.ToString().Replace(',', '.') + 
                ",numShares="+ NumShares +"]";
        }

        public override bool Equals(object stock)
        {
            bool  equal   = true;
            Stock _stock = (Stock)stock;
            
            if(_stock.Symbol != Symbol)
                equal = false;

            if(_stock.PricePerShare != PricePerShare)
                equal = false;
                
            if(_stock.NumShares != NumShares)
                equal = false;

            return equal;
        }
    }
}
