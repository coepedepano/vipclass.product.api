using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vipclass.products.Domain.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Coin> ListAll() {

            var list = new List<Coin>();
            var btc = new Coin { 
              Id = 1,
              Name= "BTC"
            };
            var eth = new Coin
            {
                Id = 2,
                Name = "ETH"
            };
            var litecoin = new Coin
            {
                Id = 3,
                Name = "LITECOIN"
            };
            var ADA = new Coin
            {
                Id = 4,
                Name = "ADA"
            };
            var polkadot = new Coin
            {
                Id = 5,
                Name = "polkadot"
            };
            var solana = new Coin
            {
                Id = 6,
                Name = "solana"
            };

            list.Add(btc);
            list.Add(eth);
            list.Add(litecoin);
            list.Add(ADA);
            list.Add(polkadot);
            list.Add(solana);

            return list;

        }
    }
}
