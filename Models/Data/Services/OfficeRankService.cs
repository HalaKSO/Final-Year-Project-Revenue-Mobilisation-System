using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class OfficeRankService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public OfficeRankService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create a list 
        public List<OfficeRankViewModel> GetRanks()
        {
            List<OfficeRank> officeRanks = _Context.OfficeRanks.ToList();
            List<OfficeRankViewModel> model = officeRanks.Select(x => new OfficeRankViewModel
            {
                RankId = x.RankId,
                RankName = x.RankName
            }).ToList();
            return model;
        }
        //Add new data 
        public bool AddRanks(OfficeRankViewModel model)
        {
            OfficeRank officeRank = new OfficeRank()
            {
                RankName = model.RankName
            };
            _Context.OfficeRanks.Add(officeRank);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateRanks(OfficeRankViewModel model)
        {
            OfficeRank officeRank = _Context.OfficeRanks.Where(x => x.RankId == model.RankId).FirstOrDefault();
            officeRank.RankName = model.RankName;
            _Context.OfficeRanks.Update(officeRank);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteRank(int id)
        {
            //localhost:1234/OfficeRank/Delete/1
            OfficeRank officeRank = _Context.OfficeRanks.Where(x => x.RankId == id).FirstOrDefault();
            _Context.OfficeRanks.Remove(officeRank);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public OfficeRankViewModel GetRankDetails(int id)
        {
            OfficeRank officeRank = _Context.OfficeRanks.Where(x => x.RankId == id).FirstOrDefault();
            OfficeRankViewModel model = new OfficeRankViewModel
            {
                RankId = officeRank.RankId,
                RankName = officeRank.RankName
            };
            return model;
        }
    }
}
