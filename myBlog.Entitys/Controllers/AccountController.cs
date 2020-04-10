using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using myBlog.Models;
using myBlog.Interfaces;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using myBlog.Data;

namespace myBlog.Controllers
{
    //http://www.mukeshkumar.net/articles/dotnetcore/crud-operation-in-asp-net-core-web-api-with-entity-framework-core
    //https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx
    //https://www.c-sharpcorner.com/article/using-fluentvalidation-in-asp-net-core/
    //https://stackoverflow.com/questions/58834222/how-to-update-tables-not-recreate-them-using-net-core-entity-framework-migrat
    //https://www.c-sharpcorner.com/article/crud-operations-unit-testing-in-asp-net-core-web-api-with-xunit/


    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private IAccount accRepo;
        public AccountController(IAccount account)
        {
            accRepo = account;
        }
        

        [HttpGet]
        [Route("GetAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            // var accouns = await _context.Accounts.ToListAsync();
            // return Ok(accouns);
            try{
                var accounts = await accRepo.GetAccounts();
                if(accounts == null)
                {
                    return NotFound();
                }
                return Ok(accounts);
            }
            catch(Exception){
               return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAccount")]
        public async Task<IActionResult> GetAccount(int? accountId)
        {
            if(accountId == null){
                    return BadRequest();
            }
            try{
                var account = await accRepo.GetAccount(accountId);
                if(account == null){
                    return NotFound(account);
                }
                return Ok(account);
            }catch(Exception){
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody]Account model)
        {
            
           if(ModelState.IsValid){
               try
               {
                   //var accId = await accRepo.AddAccount(model);
                   var accId = await accRepo.AddAccount(model);
                   if(accId != null)
                   {
                       return Ok(accId);
                   }
                   else {
                       return NotFound(accId);
                   }
               }
               catch (System.Exception)
               {
                   return BadRequest();
               }
           }
           return BadRequest();
        }

        


        [HttpPost]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int? accountId)
        {
            int result = 0;
            if(accountId == null)
            {
                return BadRequest();
            }
            try
            {
                result = await accRepo.DeleteAccount(accountId);
                if(result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (System.Exception)
            {
                
               return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody]Account model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await accRepo.UpdateAccount(model);
                    return Ok();
                }
                catch (System.Exception ex)
                {
                    if(ex.GetType().FullName == "Ms.EFCore.DbUpdate.ConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                    
                }
            }
            return BadRequest();
        }
    }
}