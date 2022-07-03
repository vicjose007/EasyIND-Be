using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Application.Validators.Generic
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidator
    {

        /// <summary>
        /// Este metodo se encarga de decidir cual RuleSet se se ejecutara, en base a una evaluacion del objeto enviado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual string[] GetRulerelativeName(object dto)
        {
            return new string[] { "default" };
        }
    }
}
