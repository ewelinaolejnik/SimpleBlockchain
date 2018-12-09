using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SimpleBlockchain.Data;

namespace SimpleBlockChain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlockchain()
        {
            Blockchain blockchain = MockedBlockchainService.Blockchain;
            return Ok(blockchain.Blocks);
        }

        [HttpPost]
        public IActionResult AddBankAccount([FromBody] BankAccount bankAccount)
        {
            Blockchain blockchain = MockedBlockchainService.Blockchain;
            blockchain.GenerateBlock(bankAccount);
            return Created(Request.GetDisplayUrl(), bankAccount);
        }

        [HttpGet]
        [Route("validate")]
        public IActionResult IsBlockchainValid()
        {
            Blockchain blockchain = MockedBlockchainService.Blockchain;
            if (blockchain.IsBlockchainValid())
            {
                return Ok("Blockchain is valid.");
            }
            else
            {
                return BadRequest("Blockchain is invalid");
            }

        }
    }
}