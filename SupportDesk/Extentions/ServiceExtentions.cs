using FluentValidation;
using SupportDesk.Api.Validators;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Api.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddValidators(this IServiceCollection service)
        {
            service.AddScoped<IValidator<User>,UserValidator>();

            return service;
        }
    }
}
