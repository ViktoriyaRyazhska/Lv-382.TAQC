using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Data
{
    public interface IUser
    {
        string Name { get; }        // Required
        string Password { get; }    // Required
        string Rights { get; set; }
        string Token { get; set; }
    }
}
