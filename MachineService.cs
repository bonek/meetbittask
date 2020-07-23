using System;
using System.Collections.Generic;

namespace RTask
{
    class MachineService
    {

        private CoinsStateStorage CoinsRepository = new CoinsStateStorage();
        private ProductRepository ProductRepository = new ProductRepository();
        private readonly CoinsStateStorage coinsStateStorage;

        public MachineService(CoinsStateStorage coinsStateStorage)
        {
            this.coinsStateStorage = coinsStateStorage;
        }

        #region UserStateStorage
        private int NickelCount { get; set; }
        private int DimeCount { get; set; }
        private int QuarterCount { get; set; }
        private int DollarCount { get; set; }
        #endregion


        public void InsertNickel()
        {
            NickelCount++;
            Console.WriteLine("Added Nickel");
        }

        public void InsertDime()
        {
            DimeCount++;
            Console.WriteLine("Added Dime");
        }

        public void InsertQuarter()
        {
            QuarterCount++;
            Console.WriteLine("Added Quarter");
        }

        public void InsertDollar()
        {
            DollarCount++;
            Console.WriteLine("Added Dollar");
        }

        public void ReturnMoney()
        {
            for (int i = 0; i < NickelCount; i++)
            {
                Console.WriteLine("N");
            }
            for (int i = 0; i < DimeCount; i++)
            {
                Console.WriteLine("D");
            }
            for (int i = 0; i < QuarterCount; i++)
            {
                Console.WriteLine("Q");
            }
            NickelCount = 0;
            DimeCount = 0;
            QuarterCount = 0;
        }

        private void CalculateRest(decimal insertedAmount, ProductEntity product)
        {
            var rest = insertedAmount - product.Price;

            List<CoinState> stateList = new List<CoinState> { coinsStateStorage.QuarterCoinState, coinsStateStorage.DimeCoinState,coinsStateStorage.NickerCoinState,  };


            int index = 0;
           
         while(rest > 0 && index < stateList.Count)
            {
                if(rest >= stateList[index].Value)
                {
                    if(stateList[index].Count != 0)
                    {
                        int countOfCoins = (int)Math.Floor(rest / stateList[index].Value);
                        for(int i=0; i < countOfCoins; i++)
                        {
                            Console.WriteLine(stateList[index].Symbol);
                        }
                       
                        rest = Math.Round(100 * (rest - (countOfCoins * stateList[index].Value))) / 100;
                    }
                }


                index++;
            }
   
           
        }

        private void AddUserCoinsToMachineStorage()
        {

            coinsStateStorage.NickerCoinState.Count += NickelCount;
            coinsStateStorage.DimeCoinState.Count += DimeCount;
            coinsStateStorage.QuarterCoinState.Count += QuarterCount;
            NickelCount = 0;
            DimeCount = 0;
            QuarterCount = 0;
        }
        public void SellProduct(string id)
        {
            var product = ProductRepository.GetProduct(id);

            var insertedAmount = Convert.ToDecimal(NickelCount) * 0.05M + Convert.ToDecimal(DimeCount) * 0.10M + Convert.ToDecimal(QuarterCount) * 0.25M + DollarCount;

            if (insertedAmount < product.Price)
            {
                throw new Exception("Not enough money");
            }
            else
            {
                CalculateRest(insertedAmount, product);
                AddUserCoinsToMachineStorage();

                Console.WriteLine(product.ID);

            }


        }
    }



}



