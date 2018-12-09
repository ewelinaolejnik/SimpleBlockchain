using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlockchain.Data
{
    public class Blockchain
    {
        public List<Block> Blocks { get; private set; }

        public Blockchain()
        {
            Blocks = new List<Block>();
            AddGenesisBlock();
        }

        private void AddGenesisBlock()
        {
            if (!Blocks.Any())
            {
                Blocks.Add(new Block(0, null, null));
            }
        }

        public void GenerateBlock(BankAccount data)
        {
            if (!Blocks.Any())
            {
                throw new InvalidOperationException("Before generating first block, genesis block must be added");
            }

            Block lastBlock = Blocks.Last();
            int index = Blocks.Count();
            Blocks.Add(new Block(index, data, lastBlock.Hash));
        }

        public bool IsBlockchainValid()
        {
            for (int i = 1; i < Blocks.Count(); i++)
            {
                if (Blocks[i].Hash != Blocks[i].GetHash())
                {
                    return false;
                }

                if (Blocks[i - 1].Hash != Blocks[i].PreviousHash)
                {
                    return false;
                }
            }

            return true;
        }
    }
}