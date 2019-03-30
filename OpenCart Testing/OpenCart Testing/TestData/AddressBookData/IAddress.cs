using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData.AddressBookData
{
    public interface IAddress
    {
        string Firstname { get; }
        string Lastname { get; }     
        string Company { get; }    
        string Address1 { get; }
        string Address2 { get; }    
        string City { get; }
        string Postcode { get; }
        string Country { get; }
        string RegionState { get; }
        bool Default { get; }
    }
}
