using GridDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridDemo.Service;

public interface IUserDataService
{
    List<Person> GetUserDataList();
    void SetUserDataList(List<Person> users);
}
