using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lottery.Data;
using Lottery.Data.Model;
using Lottery.Mapper;
using Lottery.Service.UoW;
using Lottery.View.Model;

namespace Lottery.Service
{
    // This is the lottery service or manager. From here we can execute all the business logic
    public class LotteryManager : ILotteryManager
    {
        // These are all the dependencies. They will all be resolved by the AutoFac IOC Container through the constructor
        private readonly DbContext _dbContext;
        private readonly IRepository<Code> _codeRepository;
        private readonly IRepository<Award> _awardRepository;
        private readonly IRepository<UserCode> _userCodeRepository;
        private readonly IRepository<UserCodeAward> _userCodeAwardRepository;

        public LotteryManager(IRepository<Code> codeRepository, 
            IRepository<UserCode> userCodeRepository,
            IRepository<Award> awardRepository, 
            IRepository<UserCodeAward> userCodeAwardRepository, 
            DbContext dbContext)
        {
            _dbContext = dbContext;
            _codeRepository = codeRepository;
            _awardRepository = awardRepository;
            _userCodeRepository = userCodeRepository;
            _userCodeAwardRepository = userCodeAwardRepository;
        }

        public AwardModel CheckCode(UserCodeModel userCodeModel)
        {
            // This is how we call the unit of work class. We create it in a using block so we can dispose of it automatically when we are done
            using (var uow = new UnitOfWork(_dbContext))
            {
                var code = _codeRepository.GetAll().FirstOrDefault(x => x.CodeValue == userCodeModel.Code.CodeValue);

                if(code == null)
                    throw new ApplicationException("Invalid code.");

                if(code.IsUsed)
                    throw new ApplicationException("Code is used.");
                
                var userCode = new UserCode
                {
                    Code = code,
                    Email = userCodeModel.Email,
                    FirstName = userCodeModel.FirstName,
                    LastName = userCodeModel.LastName,
                    SentAt = DateTime.Now
                };
                
                // Here we interact with the context and save something, but the changes are not yet written in the database
                _userCodeRepository.Insert(userCode);

                Award award = null;
                if (code.IsWinning)
                {
                    // This is a custom function that is called for getting a random award
                    award = GetRandomAward(RuffledType.Immediate);

                    var userCodeAward = new UserCodeAward
                    {
                        Award = award,
                        UserCode = userCode,
                        WonAt = DateTime.Now
                    };

                    _userCodeAwardRepository.Insert(userCodeAward);
                }

                code.IsUsed = true;

                // Here the unit of work Commit method is called and if everything passed, then the changes are saved in to the database
                uow.Commit();

                // After we are done with the logic, we transform the Award object into AwardModel object that is used in the Application
                return award?.Map<Award, AwardModel>();
            }
        }

        private Award GetRandomAward(RuffledType type)
        {
            var awards = _awardRepository.GetAll().Where(x => x.RuffledType == (byte) type).ToList();
            var awardedAwards = _userCodeAwardRepository
                .GetAll()
                .Where(x => x.Award.RuffledType == (byte) type)
                .Select(x => x.Award)
                .GroupBy(x => x.Id)
                .ToList();

            var availableAwards = new List<Award>();

            foreach (var award in awards)
            {
                var numberOfAwardedAwards = awardedAwards
                    .FirstOrDefault(x => x.Key == award.Id)?.Count() ?? 0;
                var awardsLeft = award.Quantity - numberOfAwardedAwards;
                availableAwards.AddRange(Enumerable.Repeat(award, awardsLeft));
            }

            if(availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();
            var randomAwardIndex = rnd.Next(0, availableAwards.Count);
            return availableAwards[randomAwardIndex];
        }
    }
}
