using BusinessLogicLayer.DTO.Results;
using System;

namespace BusinessLogicLayer.Extensions
{
    public static class ExceptionExtensions
    {
        public static RequestResultDTO RequestResult(this Exception exception)
        {
            return new RequestResultDTO 
            {
                IsSuccessful = false, 
                Errors = new[] 
                { 
                    exception.GetBaseException().Message 
                } 
            };
        }
    }
}
