using ABM_Customer.Business.Interfaces;
using Newtonsoft.Json;

namespace ABM_Customer.Services
{
    public class CRM_Customer : ICRM_Customer
    {

        //URL del servicio
        string URL_CUSTOMER = "https://raw.githubusercontent.com/robconery/json-sales-data/master/data/customers.json";

        public CRM_Customer()
        {
            
        }


        public List<CustomerData> GetCustomerList()
        {
            List<CustomerData> customerList = new List<CustomerData>();

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(URL_CUSTOMER).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string customerJson = response.Content.ReadAsStringAsync().Result;
                        customerList = JsonConvert.DeserializeObject<List<CustomerData>>(customerJson);
                        return customerList;
                    }
                    else
                    {
                        return customerList;
                    }
                }

            }
            catch
            {
                return customerList;
            }


        }



    }
}
