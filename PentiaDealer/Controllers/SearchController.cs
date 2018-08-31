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
                    var res = SearchByCustomer(customer => customer.Name.Contains(SearchValue));
                    return Json(res);

                case "CustomerLastName":
                    var res2 = SearchByCustomer(customer => customer.Surname.Contains(SearchValue));
                    return Json(res2);

                case "CustomerAddress":
                    var res3 = SearchByCustomer(customer => customer.Address.Contains(SearchValue));
                    return Json(res3);

                default:
                    return Json("");
            }
        }

        private IQueryable<Result> SearchByCustomer(Func<Customers, bool> filter)
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
                    var res = Search(car => car.Make.Contains(SearchValue));
                    return Json(res);

                case "CarModel":
                    var res2 = Search(car => car.Model.Contains(SearchValue));
                    return Json(res2);
                default:
                    return Json("");
            }
        }

        private IQueryable<Result> Search(Func<Cars, bool> filter)
        {
            return from cp in context.CarPurchases
                from c in context.Cars
                from cus in context.Customers
                from sp in context.SalesPeople
                where cp.CustomerId == cus.CustomerId
                where cp.CarId == c.CarId
                where cp.SalesPersonId == sp.SalesPersonId
                where filter(c)
                select new Result
                {
                    Customers = cus,
                    Cars = c,
                    SalesPerson = sp,
                    BuyDate = cp.OrderDate,
                    Price = cp.PricePaid
                };
        }

        public JsonResult SearchSP(string SearchSpec, string SearchValue)
        {
            switch (SearchSpec)
            {
                case "SPName":
                    var res = SearchBySalesPeople(salesPeople => salesPeople.Name.Contains(SearchValue));
                    return Json(res);

                case "SPAddress":
                    var res2 = SearchBySalesPeople(salesPeople => salesPeople.Address.Contains(SearchValue));
                    return Json(res2);

                default:
                    return Json("");
            }
        }

        private IQueryable<Result> SearchBySalesPeople(Func<SalesPeople, bool> filter)
        {
            return from cp in context.CarPurchases
                from c in context.Cars
                from cus in context.Customers
                from sp in context.SalesPeople
                where cp.CustomerId == cus.CustomerId
                where cp.CarId == c.CarId
                where cp.SalesPersonId == sp.SalesPersonId
                where filter(sp)
                select new Result
                {
                    Customers = cus,
                    Cars = c,
                    SalesPerson = sp,
                    BuyDate = cp.OrderDate,
                    Price = cp.PricePaid
                };
        }
    }
}