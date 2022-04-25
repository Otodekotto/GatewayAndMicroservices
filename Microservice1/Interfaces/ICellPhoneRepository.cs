using Microservice1.Models;

namespace Microservice1.Interfaces
{
    public interface ICellPhoneRepository
    {
        Task<bool> AddNewCellphoneAsync(CellPhone cellphone);
        bool RemoveCellphone(CellPhone cellphone);
        bool UpdateCellphone(CellPhone cellphone);
        Task<List<CellPhone>> ListAllCellphonesAsync();
        Task<CellPhone> FindCellphoneAsync(int id);
    }
}
