
namespace Registration.DataAccess
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<Register>> GetRegisters();
        Task<Register> GetRegister(int id);
        Task<Register> CreateRegister(Register register);
    }
}