using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.API.Data.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.API.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AdventureWorks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AdventureWorks2019Context _context;

        public TestController(AdventureWorks2019Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailTest>>> GetPurchaseOrderHeaders()
        {
            var timer = new Stopwatch();

            // EF Core Query
            timer.Start();
            var efCoreQueryTest = await _context.SalesOrderDetails
                .Include(sod => sod.SalesOrder)
                .ThenInclude(soh => soh.Territory)
                .Where(sod => sod.SalesOrder.DueDate.Year >= 2012 && sod.SalesOrder.DueDate.Year <= 2014)
                .Select(sod => 
                    new OrderDetailTest
                    {
                        SalesOrderID = sod.SalesOrder.SalesOrderId,
                        OrderDate = sod.SalesOrder.OrderDate,
                        DueDate = sod.SalesOrder.DueDate,
                        ShipDate = sod.SalesOrder.ShipDate,
                        SalesOrderNumber = sod.SalesOrder.SalesOrderNumber,
                        Rowguid = sod.Rowguid,
                        UnitPrice = sod.UnitPrice,
                        Name = sod.SalesOrder.Territory.Name
                    })
                .OrderByDescending(sod => sod.DueDate)
                .AsNoTracking()
                .ToListAsync();

            timer.Stop();
            Console.WriteLine($"EF Core Query: { timer.ElapsedMilliseconds }[ms]");
            timer.Reset();

            // EF Core View
            timer.Start();
            var efCoreViewTest = await _context.VWTest
                .OrderByDescending(x => x.DueDate)
                .ToListAsync();
            timer.Stop();
            Console.WriteLine($"EF Core View: { timer.ElapsedMilliseconds }[ms]");
            timer.Reset();

            // SQL Procedure
            timer.Start();
            var sqlProcedureTest = await _context
                .VWTest.FromSqlRaw("EXEC SP_Test")
                .ToListAsync();
            timer.Stop();
            Console.WriteLine($"SQL Procedure { timer.ElapsedMilliseconds }[ms]");

            return efCoreQueryTest;
        }
    }
}
