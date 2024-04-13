using Dhaba.Services.CouponAPI.Data;
using Dhaba.Services.CouponAPI.Models;
using Dhaba.Services.CouponAPI.Models.Dto;
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
		private ResponseDto _response;

		public CouponAPIController(AppDBContext db)
		{
			_db = db;
			_response = new ResponseDto();
		}

		[HttpGet]
		public ResponseDto Get()
		{
			try
			{
				IEnumerable<Coupon> ObjList = _db.Coupons.ToList();
				_response.Result = ObjList;
				
			}
			catch (Exception ex)
			{
				_response.IsSucess = false;
				_response.Result = ex.Message;
			}
			return _response;

		}

		[HttpGet]
		[Route("{id:int}")]
		public ResponseDto Get(int id)
		{
			try
			{
				Coupon Obj = _db.Coupons.First(u => u.CouponId == id);
				_response.Result = Obj;
			}
			catch (Exception ex)
			{
				_response.IsSucess=false;
				_response.Result = ex.Message;
			}
			return _response;
		}
	}
}
