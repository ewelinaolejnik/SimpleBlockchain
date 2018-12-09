using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SimpleBlockchain.Data
{
    public class Block
    {
        public Block(int index, BankAccount data, string previousHash)
        {
            Index = index;
            Data = data;
            PreviousHash = previousHash;
            Timestamp = DateTime.Now;

            Hash = GetHash();
        }

        public int Index { get; private set; }
        public DateTime Timestamp { get; private set; }

        public BankAccount Data { get; private set; }

        public string Hash { get; private set; }
        public string PreviousHash { get; private set; }

        public string GetHash()
        {
            using(SHA256 SHA256 = SHA256.Create())
            {
                byte[] blockBytes = Encoding.ASCII
                    .GetBytes($"{Index} {Timestamp} {JsonConvert.SerializeObject(Data)} {PreviousHash}");

                byte[] hashBytes = SHA256.ComputeHash(blockBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    stringBuilder.Append($"{hashByte:X2}");
                }

                return stringBuilder.ToString();
            }
        }
    }
}