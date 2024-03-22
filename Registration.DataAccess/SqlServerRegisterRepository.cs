using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.DataAccess
{
    public class SqlServerRegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _dbContext;
        public SqlServerRegisterRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Register> CreateRegister(Register register)
        {
            await _dbContext.Registers.AddAsync(register);
            await _dbContext.SaveChangesAsync();
            return register;
        }

        public async Task<Register> GetRegister(int id)
        {
            var result = await _dbContext.Registers.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Register>> GetRegisters()
        {
            return await _dbContext.Registers.ToListAsync();
        }
    }
}
