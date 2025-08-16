using jwtTokenAut.Models;

namespace jwtTokenAut.Services
{
    public interface IKilnInfoServices
    {
        Task<(int, string)> kilnPostData(KilnInfo model, string role);
    }
}
