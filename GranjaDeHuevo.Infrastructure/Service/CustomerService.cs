using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using GranjaDeHuevo.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class CustomerService : BaseService<Customers>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly AppGranjaDeHuevoContext _context;

        public CustomerService(ICustomersRepository customersRepository, AppGranjaDeHuevoContext context) : base(customersRepository, context)
        {
            _customersRepository = customersRepository;
            _context = context;
        }

        public List<CustomersDTO> GetCustomers()
        {
            return _customersRepository.GetCustomers();
        }

        public override async Task Update(Customers customers)
        {
            var emailExists = await _customersRepository.ExistsAsync(c => c.Email == customers.Email && c.CustomerId != customers.CustomerId);
            var phoneExists = await _customersRepository.ExistsAsync(c => c.Phone == customers.Phone && c.CustomerId != customers.CustomerId);

            if (emailExists)
                throw new ArgumentException("Este correo ya esta registrado por otro usuario.");

            if (phoneExists)
                throw new ArgumentException("Este telefono ya esta registrado por otro usuario.");

            Customers customerToUpdate = await _customersRepository.GetId(customers.CustomerId);

            customerToUpdate.FirstName = customers.FirstName;
            customerToUpdate.LastName = customers.LastName;
            customerToUpdate.Email = customers.Email;
            customerToUpdate.Phone = customers.Phone;
            customerToUpdate.Address = customers.Address;

            customerToUpdate.UserModify = customers.UserModify;
            customerToUpdate.ModifyDate = DateTime.UtcNow;

            await base.Update(customerToUpdate);
        }

        public override async Task Remove(Customers customers)
        {
            Customers customerToDelete = await _customersRepository.GetId(customers.CustomerId);

            customerToDelete.UserDelete = customers.UserDelete;
            customerToDelete.Deleted = true;
            customerToDelete.DeletedDate = DateTime.UtcNow;

            await base.Update(customerToDelete);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _customersRepository.ExistsAsync(e => e.Email == email);
        }

        public async Task<bool> PhoneExists(string phone)
        {
            return await _customersRepository.ExistsAsync(p => p.Phone == phone);
        }
    }
}
