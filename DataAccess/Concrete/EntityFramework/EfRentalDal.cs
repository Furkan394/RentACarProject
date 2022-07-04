using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rn in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rn.CarId equals cr.Id
                             join cs in context.Customers on rn.CustomerId equals cs.Id
                             join br in context.Brands on cr.BrandId equals br.Id
                             join u in context.Users on cs.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rn.Id,
                                 BrandName = br.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CompanyName = cs.CompanyName,
                                 RentDate = rn.RentDate,
                                 ReturnDate = rn.ReturnDate,
                             };
                return result.ToList();
                   
            }
        }
    }
}
