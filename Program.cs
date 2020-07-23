using System;

namespace RTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, you should first set service variables - use SERVICE");
            var coinsService = new CoinsStateStorage();
            var machineService = new MachineService(coinsService);


            for (;;)
            {
                try
                {
                    Console.WriteLine("What do you do?");
                    var line = Console.ReadLine();


                    if (line == "exit")
                    {
                        break;
                    }

                    line = line.ToUpper();
                    switch (line)
                    {
                        case "N":
                            machineService.InsertNickel();
                            break;
                        case "D":
                            machineService.InsertDime();
                            break;
                        case "Q":
                            machineService.InsertQuarter();
                            break;
                        case "DOLLAR":
                            machineService.InsertDollar();
                            break;
                        case "GET-A":
                            machineService.SellProduct("A");
                            break;
                        case "GET-B":
                            machineService.SellProduct("B");
                            break;
                        case "GET-C":
                            machineService.SellProduct("C");
                            break;
                        case "COIN-RETURN":
                            machineService.ReturnMoney();
                            break;
                        case "SERVICE":
                        {
                            int nikelCount = 0;
                            int dimeCount = 0;
                            int quarterCount = 0;

                            //_______________________________________
                            Console.WriteLine("Nickel Count?: ");
                            var nikelCountString = Console.ReadLine();


                            if (!int.TryParse(nikelCountString, out nikelCount))
                            {
                                new ArgumentException("Invalid argument.");
                            }

                            coinsService.NickerCoinState.Count = nikelCount;
                            //_______________________________________
                            Console.WriteLine("Dime Count?: ");
                            var dimeCountString = Console.ReadLine();
                            if (!int.TryParse(dimeCountString, out dimeCount))
                            {
                                new ArgumentException("Invalid argument.");
                            }

                            coinsService.DimeCoinState.Count = dimeCount;
                            //_______________________________________
                            Console.WriteLine("Quarter Count?: ");
                            var quarterCountString = Console.ReadLine();

                            if (!int.TryParse(quarterCountString, out quarterCount))
                            {
                                new ArgumentException("Invalid argument.");
                            }

                            coinsService.QuarterCoinState.Count = quarterCount;
                            break;
                            //_______________________________________
                        }
                        default:
                            throw new ArgumentException("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}