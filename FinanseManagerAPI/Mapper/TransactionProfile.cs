using AutoMapper;
using FinanseManagerAPI.Models;
using FinanseManagerAPI.Models.DTOs;

namespace FinanseManagerAPI.Mapper
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile() 
        {
            CreateMap<TransactionDTO, Transaction>();
        }
    }
}
