using CMS.Studio.Domain.CQRS.Commands.Base;
using CMS.Studio.Domain.Models.Responses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Studio.Handler;

public class HandlerChecker
{
    private readonly IServiceProvider _serviceProvider;

    public HandlerChecker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void CheckHandlers()
    {
        var handler = _serviceProvider.GetService<IRequestHandler<CreateOrUpdateCommand, MessageResponse>>();
        if (handler == null)
        {
            Console.WriteLine("Handler for CreateOrUpdateCommand not registered.");
        }
        else
        {
            Console.WriteLine("Handler for CreateOrUpdateCommand is registered.");
        }
    }
}