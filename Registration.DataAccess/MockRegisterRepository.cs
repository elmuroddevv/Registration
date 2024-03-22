using System.Collections.Concurrent;

namespace Registration.DataAccess
{
    public class MockRegisterRepository : IRegisterRepository
    {
        private static object locker = new();
        private static ConcurrentDictionary<int, Register> _registers = new ConcurrentDictionary<int, Register>();
        public MockRegisterRepository()
        {
            Init();
        }
        private void Init()
        {
            _registers.TryAdd(1, new Register { Id = 1, FullName = "Someone Onest", Phone = "90-000-00-00", Email = "some@one.com", Login = "som0ne", Password = "assassin0w"});
            _registers.TryAdd(2, new Register { Id = 2, FullName = "Nothing Think", Phone = "90-000-20-02", Email = "noth@ing.com", Login = "n0thing", Password = "9rit9fdsw"});
            _registers.TryAdd(3, new Register { Id = 3, FullName = "Body Bodys", Phone = "90-000-30-03", Email = "bo@dys.com", Login = "b0dy1s", Password = "ddgde3jsdw4rfew"});
            _registers.TryAdd(4, new Register { Id = 4, FullName = "Melon Melony", Phone = "90-000-40-04", Email = "mel@on.com", Login = "m2el0nDev", Password = "dgey38eudh"});
            _registers.TryAdd(5, new Register { Id = 5, FullName = "Honry Henrys", Phone = "90-000-05-50", Email = "honr@ys.com", Login = "henry33", Password = "dbeyg7eydf7"});
        }
        public async Task<IEnumerable<Register>> GetRegisters()
        {
            return await Task.FromResult(_registers.Values);
        }
        public async Task<Register> GetRegister(int id)
        {
            return await Task.FromResult(_registers[id]);
        }

        public async Task<Register> CreateRegister(Register register)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _registers.Keys.Max() + 1;
            }
            register.Id = newId;
            _registers.TryAdd(newId, register);
            return await Task.FromResult(register);
        }
    }
}
