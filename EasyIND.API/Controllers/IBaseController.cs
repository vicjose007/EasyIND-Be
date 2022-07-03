using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EasyIND.API.Controllers
{

    public interface IODataController
    {
        Type TypeDto { get; set; }
        IMapper _mapper { get; set; }
    }

    public interface IBaseController : IODataController
    {

        IValidatorFactory _validationFactory { get; set; }
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
        string TypeName { get; set; }
    }
}
