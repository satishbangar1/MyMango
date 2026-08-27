using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMango.Services.CouponAPI.Data;
using MyMango.Services.CouponAPI.Models;
using MyMango.Services.CouponAPI.Models.Dto;

namespace MyMango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }



        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<Coupon> objList = await _db.Coupons.ToListAsync();
                _response.Result = _mapper.Map<List<CouponDto>>(objList);
                //_response.Result = objList;
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Coupon obj = await _db.Coupons.FirstAsync(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ResponseDto> Get(string code)
        {
            try
            {
                Coupon obj = await _db.Coupons.FirstAsync(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] CouponDto couponDto)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(couponDto);
                await _db.Coupons.AddAsync(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] CouponDto couponDto)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(couponDto);
                 _db.Coupons.Update(obj);
                await _db.SaveChangesAsync();
                _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }

        [HttpDelete]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {

                Coupon obj = await _db.Coupons.FirstAsync(u => u.CouponId == id);
                 _db.Coupons.Remove(obj);
                await _db.SaveChangesAsync();
              //  _response.Result = _mapper.Map<CouponDto>(obj);
                return _response;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}