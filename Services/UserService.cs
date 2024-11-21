using Course_System.DTOs;
using Course_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;
using System.Reflection;

namespace Course_System.Services
{
    public class UserService
    {
        private readonly CourseSystemDbContext _context;
        public UserService(CourseSystemDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            return await _context.Users.Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                DOB = u.DOB,
            }).ToListAsync();
        }
        public async Task<ICollection<UserDTO>> GetUsersByName(string name)
        {
            return await _context.Users.Where(u => (u.FirstName + u.LastName).Contains(name))
            .Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName
                Role = u.Role,
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                DOB = u.DOB,
            }).ToListAsync();
        }
        public async Task<UserDTO> GetUserById(string id)
        {
            return await _context.Users.Where(u => u.Id.Equals(id))
            .Select(u => new UserDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                DOB = u.DOB,
            }).FirstOrDefaultAsync();
        }
        public async Task<string> GetUserRole(string id)
        {
            return await _context.Users.Where(u => u.Id.Equals(id)).Select(u => u.Role).FirstOrDefaultAsync();
        }
        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateUser(string idToUpdate, User user)
        {
            try
            {
                User u = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(idToUpdate));
                if (u == null)
                {
                    return false;
                }
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Role = user.Role;
                u.Gender = user.Gender;
                u.Email = user.Email;
                u.Phone = user.Phone;
                u.DOB = user.DOB;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(string id)
        {
            try
            {
                User toDelete = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
                if (toDelete == null)
                {
                    throw new Exception("Invalid user");
                }
                _context.Users.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
