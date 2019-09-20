using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlockchainDemo
{
    class Program
    {
        private static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var chains = new List<Blockchain>();
            var blockchain = new Blockchain();
            var blockchain2 = new Blockchain();
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:Scott,receiver:Zeeshan,amount:10}"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:Zeeshan,receiver:Scott,amount:5}"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:Zeeshan,receiver:Scott,amount:5}"));

            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");

            Console.WriteLine(JsonConvert.SerializeObject(blockchain, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {blockchain.IsValid()}");

            Console.WriteLine($"Update amount to 1000");
            blockchain.Chain[1].Data = "{sender:Scott,receiver:Zeeshan,amount:1000}";

            Console.WriteLine($"Is Chain Valid: {blockchain.IsValid()}");

            Console.WriteLine($"Update hash");
            blockchain.Chain[1].Hash = blockchain.Chain[1].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {blockchain.IsValid()}");

            chains.Add(blockchain);
            chains.Add(blockchain2);

            Console.WriteLine($"Update the entire chain");

            //for (int i = 1; i < blockchain.Chain.Count; i++)
            //{
            //    blockchain.Chain[i].PreviousHash = blockchain.Chain[i - 1].Hash;
            //    blockchain.Chain[i].Hash = blockchain.Chain[i].CalculateHash();
            //}

            blockchain.Chain[2].PreviousHash = blockchain.Chain[1].Hash;
            blockchain.Chain[2].Hash = blockchain.Chain[2].CalculateHash();
            blockchain.Chain[3].PreviousHash = blockchain.Chain[2].Hash;
            blockchain.Chain[3].Hash = blockchain.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {blockchain.IsValid()}");

            Console.ReadKey();
        }
    }
}
