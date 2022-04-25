namespace Microservice1.Interfaces
{
    public interface IUnitOfWork
    {
        ICellPhoneRepository CellphoneRepository { get; }
        Task<bool> Complete();
    }
}
