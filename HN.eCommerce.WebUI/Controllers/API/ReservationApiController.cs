using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.WebUI.Core;
using HN.eCommerce.WebUI.Models;
using Core.Common.Contracts;

namespace HN.eCommerce.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    [RoutePrefix("api/reservation")]
    [UsesDisposableService]
    public class ReservationApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ReservationApiController(IProductService productService)
        {
            _ProductService = productService;
        }

        private IProductService _ProductService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ProductService);
        }

        [HttpGet]
        [Route("availablecars/{pickupDate}/{returnDate}")]
        public HttpResponseMessage GetAvailableCars(HttpRequestMessage request, DateTime pickupDate, DateTime returnDate)
        {
            return GetHttpResponse(request, () =>
            {
                //Product[] products = _ProductService.GetAllProducts();

                List<Car> availableCars = new List<Car>();


                availableCars.Add(new Car()
                {
                    CarId = 1,
                    Color = "blue",
                    CurrentlyRented = false,
                    Description = "Description car1",
                    RentalPrice = 125.25m,
                    Year = 1999
                });

                availableCars.Add(new Car()
                {
                    CarId = 2,
                    Color = "green",
                    CurrentlyRented = false,
                    Description = "Description car2",
                    RentalPrice = 225.25m,
                    Year = 2010
                });

                availableCars.Add(new Car()
                {
                    CarId = 3,
                    Color = "red",
                    CurrentlyRented = false,
                    Description = "Description car3",
                    RentalPrice = 105.00m,
                    Year = 2008
                });


                Car[] cars = availableCars.ToArray();

                return request.CreateResponse<Car[]>(HttpStatusCode.OK, cars);
            });
        }

        [HttpPost]
        [Route("reservecar")]
        public HttpResponseMessage ReserveCar(HttpRequestMessage request, [FromBody]ReservationModel reservationModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                string user = User.Identity.Name; // this method is secure to only the authenticated user to reserve
                Reservation reservation = new Reservation()
                {
                    CarId = 1,
                    RentalDate = new DateTime(2015,03,12),
                    ReservationId=844485,
                    ReturnDate = new DateTime(2015, 03, 12).AddDays(30)
                    
                };
                    //_RentalService.MakeReservation(user, reservationModel.Car, reservationModel.PickupDate, reservationModel.ReturnDate);

                response = request.CreateResponse<Reservation>(HttpStatusCode.OK, reservation);

                return response;
            });
        }
    }
}
