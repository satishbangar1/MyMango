using MyMango.Web.Models;
namespace MyMango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer);
    }
}
