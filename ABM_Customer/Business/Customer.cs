using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ABM_Customer.Business
{

    public class Customer : Interfaces.ICustomer
    {
        private Data.Entities.CopernicusContext _dbContext;
        private Services.ICRM_Customer _serviceCustomer;
        private readonly IMapper _mapper;



        public Customer(Data.Entities.CopernicusContext dbContext, Services.ICRM_Customer serviceCustomer, IMapper mapper)
        {
            _dbContext = dbContext;
            _serviceCustomer = serviceCustomer;
            _mapper = mapper;
        }


        /// <summary>
        /// Resetemoa la tabla CUSTOMER de la DDBB
        /// Elimina todos los elementos y vuelve a obtenerlos desde el servicio
        /// </summary>
        /// <returns></returns>
        public bool ResetCustomer()
        {
            try
            {
                //Eliminamos los elementos de la tabla Customer
                _dbContext.Customers.RemoveRange(_dbContext.Customers);
                //Extraemos los customers desde el servicio
                List<Services.CustomerData> customerList = _serviceCustomer.GetCustomerList();
                _dbContext.Customers.AddRange(MapToEntity(customerList));
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }


        }


        /// <summary>
        /// Convierte un customer del servicio en una entity de la DDBB
        /// </summary>
        public List<Data.Entities.Customers> MapToEntity(List<Services.CustomerData> serviceCustomerList)
        {
            List<Data.Entities.Customers> listReturn = serviceCustomerList.Select(c => _mapper.Map<Data.Entities.Customers>(c))
                                                                          .ToList();
            return listReturn;
        }


        /// <summary>
        /// Retorna un listado de todos los customers de la DDBB
        /// </summary>
        /// <returns></returns>
        public List<Data.Entities.Customers> GetList()
        {
            List<Data.Entities.Customers> listReturn = new List<Data.Entities.Customers>();
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch
            {
                return listReturn;
            }
        }


        /// <summary>
        /// Mapea un objeto customer entity a su DTO
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public DTO.CustomerDTO MapToDTO(Data.Entities.Customers customer)
        {
            return _mapper.Map<DTO.CustomerDTO>(customer);
        }

        /// <summary>
        /// Mapea un lustado de customers en su DTO
        /// </summary>
        /// <param name="customerList"></param>
        /// <returns></returns>
        public List<DTO.CustomerDTO> MapToDTO(List<Data.Entities.Customers> customerList)
        {
            return customerList.Select(c => _mapper.Map<DTO.CustomerDTO>(c))
                               .ToList();  
        }

        /// <summary>
        /// Crea un nuevo customer
        /// </summary>
        /// <returns></returns>
        public bool Create(Requests.NewConsumer newConsumer)
        {
            try
            {
                //Creamos el nuevo customer
                _dbContext.Customers.Add(new Data.Entities.Customers()
                {
                    id = GetNewIdCustomer(),
                    email = newConsumer.email,
                    first = newConsumer.first,
                    last = newConsumer.last,
                    created = DateTime.Now,
                    country = newConsumer.country,
                    company = newConsumer.company,
                });
                //Guardamos
                _dbContext.SaveChanges();

                return true;
            } catch
            {
                return false;
            }

        }

        /// <summary>
        /// Genera un nuevo id customer
        /// </summary>
        /// <returns></returns>
        private int GetNewIdCustomer()
        {
            if (_dbContext.Customers.Any())
            {
                return _dbContext.Customers.Max(c => c.id) + 1;
            } else
            {
                return 1;
            }
        }

        /// <summary>
        /// Elimina un customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                Data.Entities.Customers? customers = _dbContext.Customers.FirstOrDefault(c => c.id == id);
                if (customers != null)
                {
                    _dbContext.Customers.Remove(customers);
                    _dbContext.SaveChanges();
                }
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
