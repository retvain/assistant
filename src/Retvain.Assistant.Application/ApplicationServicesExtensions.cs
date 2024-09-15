using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Retvain.Assistant.Application.Commands;
using Retvain.Assistant.Application.Commands.Help;
using Retvain.Assistant.Application.Commands.Help.Contracts;
using Retvain.Assistant.Application.Commands.PureS;
using Retvain.Assistant.Application.Commands.PureS.Contracts;
using Retvain.Assistant.Application.Commands.PureS.Services;

namespace Retvain.Assistant.Application;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<PureServersService>();

        AddMediatr(services);
    }

    private static void AddMediatr(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<HelpCommand, ICommandResult>, HelpCommandHandler>();
        services.AddTransient<IRequestHandler<PureSCommand, ICommandResult>, PureSCommandHandler>();
    }
}