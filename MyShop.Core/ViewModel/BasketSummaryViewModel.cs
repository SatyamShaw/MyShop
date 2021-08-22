using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModel
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal BasketValue { get; set; }

        public BasketSummaryViewModel()
        {

        }

        public BasketSummaryViewModel(int basketCount, decimal basketValue)
        {
            this.BasketCount = basketCount;
            this.BasketValue = basketValue;
        }

    }
}
