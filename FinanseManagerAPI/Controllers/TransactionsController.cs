using AutoMapper;
using FinanseManagerAPI.Data;
using FinanseManagerAPI.Interfaces;
using FinanseManagerAPI.Models;
using FinanseManagerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanseManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITransactions _transactions;
        private readonly UserManager<IdentityUser> _user;

        public TransactionsController(IMapper mapper, ITransactions transactions, UserManager<IdentityUser> user)
        {           
            _mapper = mapper;
            _transactions = transactions;
            _user = user;
        }
        [HttpPost("AddTransaction")]
        [Authorize]
        public async Task<IActionResult> AddNewTransaction([FromBody] TransactionDTO transactionDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = _user.GetUserId(User);
            if(userId == null) 
            {
                return Unauthorized("You need to login first");
            }
            Transaction mappedTransaction = _mapper.Map<Transaction>(transactionDTO);
            Transaction transaction = new Transaction()
            {
                Description = mappedTransaction.Description,
                Amount = mappedTransaction.Amount,
                Date = mappedTransaction.Date,
                UserId = userId,
                Category = mappedTransaction.Category, 
                PaymentMethod = mappedTransaction.PaymentMethod,
                Type = mappedTransaction.Type
            };
            await _transactions.AddTransaction(transaction);
            return Ok(transactionDTO);      
        }
        [HttpDelete("Delete/{transactionId}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransaction(int transactionId)
        {
            var userId = _user.GetUserId(User);
            if(userId == null)
            {
                return Unauthorized("You need to login first");
            }
            await _transactions.DeleteTransaction(transactionId, userId);
            return Ok();
        }

    }
}
