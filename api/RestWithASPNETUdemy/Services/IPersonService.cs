using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Cliente Create(Cliente person);
        Cliente FindByID(long id);
        List<Cliente> FindAll();
        Cliente Update(Cliente person);
        void Delete(long id);
    }
}
