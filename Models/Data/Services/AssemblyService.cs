using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class AssemblyService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public AssemblyService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create a list 
        public List<AssemblyViewModel> GetAssembly()
        {
            List<Assembly> assemblies = _Context.Assemblies.ToList();
            List<AssemblyViewModel> model = assemblies.Select(x => new AssemblyViewModel
            {
                AssemblyId = x.AssemblyId,
                AssemblyName = x.AssemblyName
            }).ToList();
            return model;
        }

        //Add new data 
        public bool AddAssembly(AssemblyViewModel model)
        {
            Assembly assembly = new Assembly()
            {
                AssemblyName = model.AssemblyName
            };
            _Context.Assemblies.Add(assembly);
            _Context.SaveChanges();
            return true;
        }
        //update data
        public bool UpdateAssembly(AssemblyViewModel model)
        {
            Assembly assembly = _Context.Assemblies.Where(x => x.AssemblyId == model.AssemblyId).FirstOrDefault();
            assembly.AssemblyName = model.AssemblyName;
            _Context.Assemblies.Update(assembly);
            _Context.SaveChanges();

            return true;

        }
        //Delete data
        public bool DeleteAssembly(int id)
        {
            //localhost:1234/Title/Delete/1
            Assembly assembly = _Context.Assemblies.Where(x => x.AssemblyId == id).FirstOrDefault();
            _Context.Assemblies.Remove(assembly);
            _Context.SaveChanges();
            return true;
        }
        //Get details of the table
        public AssemblyViewModel GetAssemblyDetails(int id)
        {
            Assembly assembly = _Context.Assemblies.Where(x => x.AssemblyId == id).FirstOrDefault();
            AssemblyViewModel model = new AssemblyViewModel
            {
                AssemblyId = assembly.AssemblyId,
                AssemblyName = assembly.AssemblyName
            };
            return model;
        }
    }
}
