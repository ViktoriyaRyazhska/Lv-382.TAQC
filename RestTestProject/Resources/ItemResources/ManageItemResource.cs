using RestSharp;
using RestTestProject.Data;
using RestTestProject.Entity;
using RestTestProject.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Resources
{
    public class ManageItemResource : ARestCrud<SimpleEntity>
    {
        public ManageItemResource() : base(RestUrlRepository.ManageItem())
        {
        }

    }
}
