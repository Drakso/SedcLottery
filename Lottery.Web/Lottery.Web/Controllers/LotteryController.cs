using System.Collections.Generic;
using System.Web.Http;
using Lottery.Service;
using Lottery.View.Model;

namespace Lottery.Web.Controllers
{
    public class LotteryController : ApiController
    {
        // Here is an instance of our manager or service. The dependency will be resolved through the constructor by the IOC Container
        private readonly ILotteryManager _lotteryManager;

        public LotteryController(ILotteryManager lotteryManager)
        {
            _lotteryManager = lotteryManager;
        }

        [HttpPost]
        public AwardModel SubmitCode([FromBody] UserCodeModel userCodeModel) // FromBody = we force the api to read the input from the HTTP request body
        {
            return _lotteryManager.CheckCode(userCodeModel);
        }
    }
}
