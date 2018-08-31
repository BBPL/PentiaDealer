using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
                    var res = Search(customer => customer.Name.Contains(SearchValue));
                    return Json(res);

                case "CustomerLastName":
                    var res2 = Search(customer => customer.Surname.Contains(SearchValue));
                    return Json(res2);

                case "CustomerAddress":
                    var res3 = Search(customer => customer.Address.Contains(SearchValue));
                    return Json(res3);

                default:
                    return Json("");
            }
        }

        private IQueryable<Result> Search(Func<Customers, bool> filter)
        {
            return from cp in context.CarPurchases
                   from c in context.Cars
                   from cus in context.Customers
                   from sp in context.SalesPeople
                   where cp.CustomerId == cus.CustomerId
                   where cp.CarId == c.CarId
                   where cp.SalesPersonId == sp.SalesPersonId
                   where filter(cus)
                   select new Result
                   {
                       Customers = cus,
                       Cars = c,
                       SalesPerson = sp,
                       BuyDate = cp.OrderDate,
                       Price = cp.PricePaid
                   };
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
                              where cp.CustomerId == cus.CustomerId
                              where cp.CarId == c.CarId
                              where cp.SalesPersonId == sp.SalesPersonId
                              where c.Make.Contains(SearchValue)
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
                               where cp.CustomerId == cus.CustomerId
                               where cp.CarId == c.CarId
                               where cp.SalesPersonId == sp.SalesPersonId
                               where c.Model.Contains(SearchValue)
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
                              where cp.CustomerId == cus.CustomerId
                              where cp.CarId == c.CarId
                              where cp.SalesPersonId == sp.SalesPersonId
                              where sp.Name.Contains(SearchValue)
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