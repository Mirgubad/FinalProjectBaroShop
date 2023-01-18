using DataAccess.Repositories.Abstarct;
using Web.Services.Abstract;
using Web.ViewModels.About;

namespace Web.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IBusinessInfoRepository _businessInfoRepository;
        private readonly IFactRepository _factRepository;
        private readonly IWhatWeDoRepository _whatWeDoRepository;

        public AboutService(IBusinessInfoRepository businessInfoRepository,
            IFactRepository factRepository,
            IWhatWeDoRepository whatWeDoRepository)
        {
            _businessInfoRepository = businessInfoRepository;
            _factRepository = factRepository;
            _whatWeDoRepository = whatWeDoRepository;
        }
        public async Task<AboutIndexVM> GetAllAsync()
        {
            var model = new AboutIndexVM
            {
                BusinessInfos = await _businessInfoRepository.GetAllAsync(),
                Facts = await _factRepository.GetAllAsync(),
                WhatWedo = await _whatWeDoRepository.GetAsync(),

            };
            return model;
        }
    }
}
