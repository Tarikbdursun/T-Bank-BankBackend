using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfUserDal<Customer>, ICustomerUserDal
    {

    }
}
