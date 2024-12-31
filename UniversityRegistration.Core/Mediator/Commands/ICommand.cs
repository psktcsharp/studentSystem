using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Mediator;

namespace UniversityRegistration.Core.Mediator.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
