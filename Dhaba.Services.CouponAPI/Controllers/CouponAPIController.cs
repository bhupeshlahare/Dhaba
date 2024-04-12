using Dhaba.Services.CouponAPI.Data;
using Dhaba.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dhaba.Services.CouponAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouponAPIController : ControllerBase
	{
		private readonly AppDBContext _db;

		public CouponAPIController(AppDBContext db)
		{
			_db = db;
		}

		[HttpGet]
		public object Get()
		{
			try
			{
				IEnumerable<Coupon> ObjList = _db.Coupons.ToList();
				return ObjList;
			}
			catch (Exception ex)
			{

			}
			return null;

		}

		[HttpGet]
		[Route("{id:int}")]
		public object Get(int id)
		{
			try
			{
				Coupon ObjList = _db.Coupons.First(u => u.CouponId == id);
				return ObjList;
			}
			catch (Exception ex)
			{

			}
			return null ;
		}
	}
}
