using Registration.DataAccess;
using Registration.Models;

namespace Registration.Services
{
    public class RegisterService : IGenericService<RegisterModel>
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public async Task<RegisterModel> Create(RegisterModel model)
        {
            var register = new Register
            {
                FullName = model.FullName,
                Phone = model.Phone,
                Email = model.Email,
                Login = model.Login,
                Password = model.Password
            };
            var createdRegister = await _registerRepository.CreateRegister(register);
            var result = new RegisterModel
            {
                FullName = createdRegister.FullName,
                Phone = createdRegister.Phone,
                Email = createdRegister.Email,
                Login = createdRegister.Login,
                Password = createdRegister.Password,
                Id = createdRegister.Id
            };
            return result;
        }

        public async Task<RegisterModel> Get(int id)
        {
            var register = await _registerRepository.GetRegister(id);
            var model = new RegisterModel
            {
                Id = register.Id,
                FullName = register.FullName,
                Phone = register.Phone,
                Email = register.Email,
                Login = register.Login,
                Password = register.Password
            };
            return model;

        }

        public async Task<IEnumerable<RegisterModel>> GetAll()
        {
            var result = new List<RegisterModel>();
            var registers = await _registerRepository.GetRegisters();
            foreach (var register in registers)
            {
                var model = new RegisterModel
                {
                    FullName = register.FullName,
                    Phone = register.Phone,
                    Email = register.Email,
                    Login = register.Login,
                    Password = register.Password,
                    Id = register.Id
                };
                result.Add(model);
            }
            return result;
        }
    }
}
