using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        private readonly Context context;

        public UserService(Context _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await context.Users.ToListAsync();
        }

        //Get/{id}
        public async Task<User> GetByIdUser(int? id)
        {
            return await context.Users.FindAsync(id);
        }

        //Post
        public async Task<User> PostUser(User data)
        {
            context.Users.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        //Put
        public async Task<User> PutUser(User data)
        {
            context.Entry(data).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return data;
        }

        //Delete
        public async Task<User> DeleteUser(int? id)
        {
            var data = await context.Users.FindAsync(id);
            context.Remove(data);
            await context.SaveChangesAsync();
            return data;
        }

        public User GetByEmail(string email)
        {
            var data = context.Users.Where(x => x.Email == email).FirstOrDefault();
            return data;
        }
    }
}
