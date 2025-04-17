using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Infrastructure.Context;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GranjaDeHuevo.Domain.Interface.Repository;

namespace GranjaDeHuevo.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomersRepository
    {
        public CustomerRepository(AppGranjaDeHuevoContext context) : base(context)
        {
        }

        public List<CustomersDTO> GetCustomers()
        {
            return _context.Customers
                .Where(c => c.Deleted == false)
                .OrderByDescending(c => c.CustomerId)
                .Select(c => new CustomersDTO
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                }).ToList();
        }

        public async Task<CustomersDTO> GetCustomersById(int id)
        {
            return await _context.Customers
                .Where(c => !c.Deleted && c.CustomerId == id)
                .OrderByDescending(c => c.CustomerId)
                .Select(c => new CustomersDTO
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Address = c.Address,
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Customers.AnyAsync(e => e.Email == email);
        }

        public async Task<bool> PhoneExistsAsync(string phone)
        {
            return await _context.Customers.AnyAsync(p => p.Phone == phone);
        }
    }
}
