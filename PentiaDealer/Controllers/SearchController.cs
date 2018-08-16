using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PentiaDealer.Models;

namespace PentiaDealer.Controllers
{
    public class SearchController : Controller
    {
       
        private PentiaDealerContext context = new PentiaDealerContext();
        

        // GET: Search
        public ActionResult Index(string s)
        {
            return View(context.Customers.ToList());
        }

        public JsonResult SearchCustomers(string SearchSpec, string SearchValue)
        {
            switch (SearchSpec)
            {
                case "CustomerFirstName":
                    var res = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (cp.SalesPersonId == sp.SalesPersonId) &&
                                     (cus.Name.Contains(SearchValue)))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };
                    return Json(res);

                case "CustomerLastName":
                    var res2 = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (cp.SalesPersonId == sp.SalesPersonId) &&
                                     (cus.Surname.Contains(SearchValue)))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res2);
                case "CustomerAddress":
                    var res3 = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (cp.SalesPersonId == sp.SalesPersonId) &&
                                     (cus.Address.Contains(SearchValue)))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res3);

                default:
                    return Json("");
            }   

        }

        public JsonResult SearchCars(string SearchSpec, string SearchValue)
        {
            
            switch (SearchSpec)
            {
                case "CarMake":
                    var res = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (c.Make.Contains(SearchValue)) &&
                                     (cp.SalesPersonId == sp.SalesPersonId))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res);

                case "CarModel":
                    var res2 = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (c.Model.Contains(SearchValue)) &&
                                     (cp.SalesPersonId == sp.SalesPersonId))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res2);
                default:
                    return Json("");
            }


        }

        public JsonResult SearchSP(string SearchSpec, string SearchValue)
        {
            switch (SearchSpec)
            {
                case "SPName":
                    var res = from cp in context.CarPurchases
                              from c in context.Cars
                              from cus in context.Customers
                              from sp in context.SalesPeople
                              where ((cp.CustomerId == cus.CustomerId) &&
                                     (cp.CarId == c.CarId) &&
                                     (cp.SalesPersonId == sp.SalesPersonId) &&
                                     (sp.Name.Contains(SearchValue)))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res);

                case "SPAddress":
                    var res2 = from cp in context.CarPurchases
                               from c in context.Cars
                               from cus in context.Customers
                               from sp in context.SalesPeople
                               where ((cp.CustomerId == cus.CustomerId) &&
                                      (cp.CarId == c.CarId) &&
                                      (cp.SalesPersonId == sp.SalesPersonId) &&
                                      (sp.Address.Contains(SearchValue)))
                              select new Result
                              {
                                  Customers = cus,
                                  Cars = c,
                                  SalesPerson = sp,
                                  BuyDate = cp.OrderDate,
                                  Price = cp.PricePaid
                              };

                    return Json(res2);
                default:
                    return Json("");
            }
        }




    }
}