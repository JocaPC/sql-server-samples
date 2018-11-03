﻿using Belgrade.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IQueryPipe sqlQuery = null;
        ICommand sqlCmd = null;
        private readonly string EMPTY_PRODUCTS_ARRAY = "{\"data\":[]}";

        public ProductController(IQueryPipe sqlQueryService, ICommand sqlCommandService)
        {
            this.sqlQuery = sqlQueryService;
            this.sqlCmd = sqlCommandService;
        }
        
        // GET api/Product
        [HttpGet]
        public async Task Get()
        {
            await sqlQuery.Sql(
@"select ProductID, Name, Color, Price, Quantity, JSON_VALUE(Data, '$.MadeIn') as MadeIn, JSON_QUERY(Tags) as Tags 
from Product
FOR JSON PATH, ROOT('data')").Stream(Response.Body, EMPTY_PRODUCTS_ARRAY);
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            var cmd = new SqlCommand(
@"select ProductID, Name, Color, Price, Quantity
from Product
where ProductId = @id
FOR JSON PATH, WITHOUT_ARRAY_WRAPPER");

            cmd.Parameters.AddWithValue("id", id);
            await sqlQuery.Sql(cmd).Stream(Response.Body, "{}");
        }
    
        // POST api/Product
        [HttpPost]
        public async Task Post()
        {
            string product = new StreamReader(Request.Body).ReadToEnd();
            var cmd = new SqlCommand("InsertProductFromJson");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductJson", product);
            await sqlCmd.Sql(cmd).Exec();
        }

        // PATCH api/Product
        [HttpPatch]
        public async Task Patch(int id)
        {
            string product = new StreamReader(Request.Body).ReadToEnd();
            var cmd = new SqlCommand("UpsertProductFromJson");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductId", id);
            cmd.Parameters.AddWithValue("ProductJson", product);
            await sqlCmd.Sql(cmd).Exec();
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            string product = new StreamReader(Request.Body).ReadToEnd();
            var cmd = new SqlCommand("UpdateProductFromJson");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProductID", id);
            cmd.Parameters.AddWithValue("ProductJson", product);
            await sqlCmd.Sql(cmd).Exec();
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var cmd = new SqlCommand(@"delete Product where ProductId = @id");
            cmd.Parameters.AddWithValue("id", id);
            await sqlCmd.Sql(cmd).Exec();
        }

        // GET api/Product/Report1
        [HttpGet("Report1")]
        public async Task Report1()
        {
            await sqlQuery.Sql(
@"select Color as [key],
    	AVG( Price ) as value
from Product
group by Color
FOR JSON PATH").Stream(Response.Body);
        }

        // GET api/Product/Report2
        [HttpGet("Report2")]
        public async Task Report2()
        {
            await sqlQuery.Sql(@"
select  Color as x,
        AVG (Price) / MAX(Price) as y
from Product
group by Color
FOR JSON PATH").Stream(Response.Body);
        }

        [HttpGet("Report3")]
        public async Task Report3()
        {
            await sqlQuery.Sql(@"
select  Color as x,
        AVG (Price) / MAX(Price) as y
from Product
group by Color
FOR JSON PATH").Stream(Response.Body);
        }
    }
}