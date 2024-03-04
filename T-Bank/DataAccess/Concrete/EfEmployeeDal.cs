using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfUserDal<Employee>, IEmployeeUserDal
    {

    }
}
