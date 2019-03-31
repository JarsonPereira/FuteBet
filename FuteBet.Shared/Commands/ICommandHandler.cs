using System;
using System.Collections.Generic;
using System.Text;

namespace FuteBet.Shared.Commands
{
    public interface ICommandHandler<Request> where Request:IRequest
    {
        IResponse Handler(Request request);
    }
}
