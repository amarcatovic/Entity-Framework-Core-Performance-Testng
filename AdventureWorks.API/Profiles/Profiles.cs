using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.API.Data.BusinessObjects;
using AdventureWorks.API.Data.Models;
using AutoMapper;

namespace AdventureWorks.API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<SalesOrderDetail, OrderDetailTest>();
        }
    }
}
