using CshMicro.Web.Entities;
using CshMicro.Web.Entities.Dto;

namespace CshMicro.Web.Services.IServices
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
