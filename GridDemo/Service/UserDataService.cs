using GridDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridDemo.Service;

public class UserDataService : IUserDataService
{
    private List<Person> _users = new List<Person>();

    public List<Person> GetUserDataList()
    {
        return _users;
    }

    public void SetUserDataList(List<Person> users)
    {
        if(users != null)
        {
            _users = users;
        }
    }
}
