using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.TestData
{
    public interface ISearchCriteria
    {
        string Keyword { get; }
        bool Description { get; }
        string Category { get; }
        bool Subcategory { get; }
    }
}
