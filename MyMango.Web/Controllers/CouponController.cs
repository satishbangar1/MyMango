using Microsoft.AspNetCore.Mvc;
using MyMango.Web.Models;
using MyMango.Web.Service.IService;
using static MyMango.Web.Utility.SD;

namespace MyMango.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IBaseService _baseService;

        public CouponController(IBaseService baseService)
        {
            _baseService = baseService;
        }

        // GET: api/Coupon
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new RequestDto
            {
                ApiType = ApiType.GET,
                // adjust the URL if your Coupon API runs on a different port
                Url = "https://localhost:7001/api/CouponAPI"
            };

            var response = await _baseService.SendAsync(request);
            if (response == null)
                return StatusCode(500);

            return Ok(response);
        }
    }
}
