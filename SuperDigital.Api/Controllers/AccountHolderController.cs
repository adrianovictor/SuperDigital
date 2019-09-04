using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Api.Messages.Request;
using SuperDigital.Api.Messages.Resource;
using SuperDigital.Api.Queries.Resources;
using SuperDigital.Domain.Model.Accounts;
using SuperDigital.QueryProcessor.Dispatcher;
using SuperDigital.QueryProcessor.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        private readonly IQueryUniqueHandler<QueryAccountHolder, AccountHolderResource> _queryUnique;
        private readonly IQueryListHandler<QueryMoviment, MovimentResource> _queryMoviment;

        public AccountHolderController(IQueryUniqueHandler<QueryAccountHolder, AccountHolderResource> queryUnique,
            IQueryListHandler<QueryMoviment, MovimentResource> queryMoviment)
        {
            _queryUnique = queryUnique;
            _queryMoviment = queryMoviment;
        }

        #region GET
        [Route("self")]
        [HttpGet]
        [ProducesResponseType(typeof(AccountHolderResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var result = _queryUnique.Handle(new QueryAccountHolder { AccountNumber = "0021648", AccountDigit = "0035" }).Result;

            return Ok(result);
        }


        [Route("self/account_moviment")]
        [HttpGet]
        [ProducesResponseType(typeof(List<MovimentResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get_AccountMoviment([FromQuery] QueryMoviment query)
        {
            //var result = _queryMoviment.Handle(new QueryMoviment {
            //    InitialDate = DateTime.Now.AddDays(-7),
            //    EndDate = DateTime.Now,
            //    AccountNumber = "0021648",
            //    AccountDigit = "0035"
            //}).Result;

            var result = await _queryMoviment.Handle(query);

            return Ok(result);
        }
        #endregion
    }
}