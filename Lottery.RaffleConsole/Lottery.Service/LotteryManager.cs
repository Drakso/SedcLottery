using Lottery.Data;
using Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Service
{
    public class LotteryManager : ILotteryManager
    {
        private readonly IRepository<Award> _awardRepository;
        private readonly IRepository<UserCodeAward> _userCodeAwardRepository;
        private readonly IRepository<UserCode> _userCodeRepository;

        public LotteryManager(IRepository<Award> awardRepository,
            IRepository<UserCodeAward> userCodeAwardRepository,
            IRepository<UserCode> userCodeRepository)
        {
            _awardRepository = awardRepository;
            _userCodeAwardRepository = userCodeAwardRepository;
            _userCodeRepository = userCodeRepository;
        }

        public void GiveAward(RaffledType type)
        {
            //TODO: get all not winning users day/final submit
            var users = _userCodeRepository.GetAll().Include(x => x.Code).Where(x => !x.Code.IsWinning);

            if (type == RaffledType.PerDay)
            {
                users = users.Where(x => x.SentAt.Date == DateTime.Now.Date);
            }

            var usersList = users.ToList();

            //TODO: get random user from list above
            var rnd = new Random();
            var randomUserIndex = rnd.Next(0, usersList.Count - 1);
            var winningUser = usersList[randomUserIndex];

            //TODO: get random award per type
            //TODO: match user with award            
        }

        private Award GetRandomAward(RaffledType type)
        {
            var awards = _awardRepository.GetAll().Where(x => x.RuffledType == (byte)type).ToList();
            var awardedAwards = _userCodeAwardRepository
                .GetAll()
                .Where(x => x.Award.RuffledType == (byte)type)
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

            if (availableAwards.Count == 0)
                throw new ApplicationException("We are out of awards. Sorry!");

            var rnd = new Random();
            var randomAwardIndex = rnd.Next(0, availableAwards.Count);
            return availableAwards[randomAwardIndex];
        }
    }
}
