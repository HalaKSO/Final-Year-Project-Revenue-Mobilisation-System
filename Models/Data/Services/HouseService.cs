using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevenueApp.Models.Data.RevenueDBContext;
using RevenueApp.Models.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevenueApp.Models.Data.Services
{
    public class HouseService
    {
        private RevenueDBContext.RevenueDBContext _Context;
        public HouseService(RevenueDBContext.RevenueDBContext context)
        {
            _Context = context;
        }
        //Create House dropdowns
        public HouseViewModel CreateHouse()
        {
            HouseViewModel model = new()
            {
                CustomerList = new SelectList(_Context.Customers, "CustomerId", "FullName"),
                HseCatList = new SelectList(_Context.HouseCategories, "HseCatId", "HseCatName")

            };

            return model;
        }
        //list of House
        public List<HouseViewModel> GetHouse()
        {
            List<House> houses = _Context.Houses.Include(x => x.Customer)
                                                .Include(x => x.HseCat)
                                                .ToList();
            List<HouseViewModel> model = houses.Select(x => new HouseViewModel
            {
                HseId = x.HseId,
                HseNumber = x.HseNumber,
                HseBlockNumber = x.HseBlockNumber,
                CustomerId = x.CustomerId,
                CustomerName = $"{x.Customer.CustomerFname} {x.Customer.CustomerLname}",
                HseDigitalAddress = x.HseDigitalAddress,
                HseLocation = x.HseLocation,
                HseTelNumber = x.HseTelNumber,
                HseRegDate = x.HseRegDate,
                HseCatId = x.HseCatId,
                HouseCategoryName = x.HseCat.HseCatName

            }).ToList();

            return model;
        }

        //Housese details
        public HouseViewModel GetHouseDetails(int id)
        {
            House house = _Context.Houses.Where(x => x.HseId == id)
                                            .Include(x => x.Customer)
                                            .Include(x => x.HseCat)
                                            .FirstOrDefault();

            HouseViewModel model = new()
            {
                HseCatId = house.HseCatId,
                HseBlockNumber = house.HseBlockNumber,
                CustomerId = house.CustomerId,
                CustomerName = $"{house.Customer.CustomerFname} {house.Customer.CustomerLname}",
                HseDigitalAddress = house.HseDigitalAddress,
                HseLocation = house.HseLocation,
                HseRegDate = house.HseRegDate,
                HseTelNumber = house.HseTelNumber,
                HseNumber = house.HseNumber,
                HseId=house.HseId,
                HouseCategoryName = house.HseCat.HseCatName
            };

            return model;
        }
        
        public bool UpdateHouse(HouseViewModel model)
        {
            House house = _Context.Houses.Where(x => x.HseId == model.HseId).Include(x => x.Customer)
                                                                            .Include(x => x.HseCat)
                                                                            .FirstOrDefault();
            house.HseId = model.HseId;
            house.HseRegDate = model.HseRegDate;
            house.CustomerId = model.CustomerId;
            house.HseLocation = model.HseLocation;
            house.HseCatId = model.HseCatId;
            house.HseDigitalAddress = model.HseDigitalAddress;
            house.HseTelNumber = model.HseTelNumber;
            house.HseNumber = model.HseNumber;
            house.HseBlockNumber = model.HseBlockNumber;
            _Context.Houses.Update(house);
            _Context.SaveChanges();
            return true;
        }
       
        //Delete House
        public bool DeleteHse(int id)
        {
            House house = _Context.Houses.Where(x => x.HseId == id)
                                           .Include(x => x.Customer)
                                           .Include(x => x.HseCat)
                                           .FirstOrDefault();
            _Context.Houses.Remove(house);
            _Context.SaveChanges();
            return true;
        }


        public bool AddHouse(HouseViewModel model, int customerId)
        {
            int houseId, houseCategoryId;



            houseCategoryId = model.HseCatId;

            House house = new()
            {
                HseName = model.HseName,
                CustomerId = customerId,
                HseBlockNumber = model.HseBlockNumber,
                HseNumber = model.HseNumber,
                HseCatId = model.HseCatId,
                HseDigitalAddress = model.HseDigitalAddress,
                HseTelNumber = model.HseTelNumber,
                HseLocation = model.HseLocation,
                HseRegDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _Context.Houses.Add(house);
            _Context.SaveChanges();

            houseId = house.HseId;
        


            //Calculate the new business bill for the year

            bool currentbillresult = CalculateCurrentBillForTheYear(houseId, houseCategoryId, customerId);
            if (currentbillresult)
                return true;

            return false;

        }

        private bool CalculateCurrentBillForTheYear(int houseId, int houseCategoryId, int customerId)
        {
            //get hsecatid
            HouseRate rate = _Context.HouseRates.Where(x => x.HseCatId == houseCategoryId)
                                                      .Include(x => x.HseCat)
                                                      .FirstOrDefault();



            HouseBill houseBill = new()
            {
                HseBillDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                HseId = houseId,
                HseCurrentBill = rate.HseRate,
                YearBill = rate.HseRate,
                HsePrevPayment = "0",
                HseArrears = "0",
                HseTotalAmtDue = rate.HseRate,
                CustomerId = customerId,
                HseRateId = rate.HseRateId
            };

            _Context.HouseBills.Add(houseBill);
            _Context.SaveChanges();

            return true;
        }


        //customers list
        public List<CustomerViewModel> GetCustomers()
        {
            List<Customer> customers = _Context.Customers.Include(x => x.Title)
                                                   .Include(x => x.Gender)
                                                   .Include(x => x.Relation)
                                                   .Include(x => x.Image)
                                                   .ToList();
            List<CustomerViewModel> model = customers.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                CustomerLname = x.CustomerLname,
                CustomerFname = x.CustomerFname,
                FullName = $"{x.CustomerFname} {x.CustomerLname}",
                CustomerDoB = x.CustomerDoB,
                TitleId = x.TitleId,
                TitleName = x.Title.TitleName,
                CustomerDigitalAddress = x.CustomerDigitalAddress,
                CustomerResidentialAddress = x.CustomerResidentialAddress,
                CustomerContact = x.CustomerContact,
                CustomerNationality = x.CustomerNationality,
                CustomerEmail = x.CustomerEmail,
                CustomerNextOfKin = x.CustomerNextOfKin,
                CustomerSsn = x.CustomerSsn,
                CustomerNextOfKinContact = x.CustomerNextOfKinContact,
                CustomerTinNumber = x.CustomerTinNumber,
                GhanaCardNumber = x.GhanaCardNumber,
                GenderId = x.GenderId,
                GenderType = x.Gender.GenderType,
                ImageId = x.ImageId,
                Photos = x.Image.Photo,
                base64stringpic = Convert.ToBase64String(x.Image.Photo)


            }).ToList();

            return model;
        }

    }
}
