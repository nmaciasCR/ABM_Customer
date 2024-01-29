using ABM_Customer.Services;

namespace ABM_Customer.Business.Interfaces
{
    public interface ICustomer
    {
        bool ResetCustomer();
        List<Data.Entities.Customers> MapToEntity(List<Services.CustomerData> serviceCustomerList);
        List<Data.Entities.Customers> GetList();
        DTO.CustomerDTO MapToDTO(Data.Entities.Customers customer);
        List<DTO.CustomerDTO> MapToDTO(List<Data.Entities.Customers> customerList);
        bool Create(Requests.NewConsumer newConsumer);
        bool Delete(int id);
    }
}
