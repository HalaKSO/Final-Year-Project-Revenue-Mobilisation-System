using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class TitleService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public TitleService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;   
        }
        //Create a list 
        public List<TitleViewModel> GetTitle()
        {
            List<Title> titles = _Context.Titles.ToList();
            List<TitleViewModel> model = titles.Select(x => new TitleViewModel
            {
                TitleId = x.TitleId,
                TitleName = x.TitleName
            }).ToList();
            return model;
        }
        //Add new data 
        public bool AddTitle(TitleViewModel model)
        {
            Title title = new Title()
            {
                TitleName = model.TitleName
            };
            _Context.Titles.Add(title);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateTitle(TitleViewModel model)
        {
            Title title = _Context.Titles.Where(x => x.TitleId == model.TitleId).FirstOrDefault();
            title.TitleName = model.TitleName;
            _Context.Titles.Update(title);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteTitle(int id)
        {
            //localhost:1234/Title/Delete/1
            Title title = _Context.Titles.Where(x => x.TitleId == id).FirstOrDefault();
            _Context.Titles.Remove(title);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public TitleViewModel GetTitleDetails(int id)
        {
            Title title = _Context.Titles.Where(x => x.TitleId == id).FirstOrDefault();
            TitleViewModel model = new TitleViewModel
            {
                TitleId = title.TitleId,
                TitleName = title.TitleName
            };
            return model;
        }

    }
}
