using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class RelationService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public RelationService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create a list 
        public List<RelationViewModel> GetRelation()
        {
            List<Relation> relations = _Context.Relations.ToList();
            List<RelationViewModel> model = relations.Select(x => new RelationViewModel
            {
                RelationId = x.RelationId,
                RelationType = x.RelationType
            }).ToList();
            return model;
        }
        //Add new data 
        public bool AddRelation(RelationViewModel model)
        {
            Relation relation = new Relation()
            {
                RelationType = model.RelationType
            };
            _Context.Relations.Add(relation);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateRelation(RelationViewModel model)
        {
            Relation relation = _Context.Relations.Where(x => x.RelationId == model.RelationId).FirstOrDefault();
            relation.RelationType = model.RelationType;
            _Context.Relations.Update(relation);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteRelation(int id)
        {
            //localhost:1234/Relation/Delete/1
            Relation relation = _Context.Relations.Where(x => x.RelationId == id).FirstOrDefault();
            _Context.Relations.Remove(relation);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public RelationViewModel GetRelationDetails(int id)
        {
            Relation relation = _Context.Relations.Where(x => x.RelationId == id).FirstOrDefault();
            RelationViewModel model = new RelationViewModel
            {
                RelationId = relation.RelationId,
                RelationType = relation.RelationType
            };
            return model;
        }
    }
}
