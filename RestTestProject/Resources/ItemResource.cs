﻿using RestTestProject.Data;
using RestTestProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestProject.Resources
{
    public class ItemResource : ARestCrud<SimpleEntity>
    {
        public ItemResource() : base(RestUrlRepository.GetItem())
        {
        }
    }

}
