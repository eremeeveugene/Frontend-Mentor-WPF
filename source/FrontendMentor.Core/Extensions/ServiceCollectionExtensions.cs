// --------------------------------------------------------------------------------
// Copyright (C) 2026 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.Registrations;
using FrontendMentor.Core.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;

namespace FrontendMentor.Core.Extensions;

/// <summary>
///     Extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    private static readonly MethodInfo GetRequiredServiceMethod = typeof(ServiceProviderServiceExtensions).GetMethod(
        nameof(ServiceProviderServiceExtensions.GetRequiredService), [typeof(IServiceProvider), typeof(Type)])!;

    /// <summary>
    ///     Registers the main window of the application. The application shows it when it starts.
    /// </summary>
    /// <typeparam name="TWindow">The service type of the window.</typeparam>
    /// <typeparam name="TImplementation">The implementation type of the window.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddMainWindow<TWindow, TImplementation>(this IServiceCollection services)
        where TWindow : class, IWindow
        where TImplementation : class, TWindow
    {
        return services.AddTransient<TWindow, TImplementation>()
            .AddSingleton(new MainWindowRegistration(typeof(TWindow)));
    }

    /// <summary>
    ///     Registers a factory for an object that needs a runtime argument in addition to its registered
    ///     dependencies. Consumers inject <c>Func&lt;TArgument, TService&gt;</c> and call it with the argument.
    ///     Constructor arguments other than <typeparamref name="TArgument" /> are resolved from the service provider.
    ///     The factory is compiled once from the constructor, so a call does not use reflection, and a new
    ///     constructor dependency needs no change in the registration.
    /// </summary>
    /// <typeparam name="TArgument">The type of the runtime argument.</typeparam>
    /// <typeparam name="TService">The service type that the factory returns.</typeparam>
    /// <typeparam name="TImplementation">The implementation type that the factory creates.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddFactory<TArgument, TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        return services.AddSingleton<Func<TArgument, TService>>(serviceProvider =>
        {
            var create = CompileFactory<TArgument, TService, TImplementation>();

            return argument => create(serviceProvider, argument);
        });
    }

    /// <summary>
    ///     Compiles a delegate that calls the constructor with the most parameters of an implementation.
    ///     The runtime argument is passed to the first parameter of its type, and every other parameter
    ///     is resolved from the service provider.
    /// </summary>
    /// <typeparam name="TArgument">The type of the runtime argument.</typeparam>
    /// <typeparam name="TService">The service type that the delegate returns.</typeparam>
    /// <typeparam name="TImplementation">The implementation type that the delegate creates.</typeparam>
    /// <returns>The compiled delegate.</returns>
    private static Func<IServiceProvider, TArgument, TService> CompileFactory<TArgument, TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        var constructors = typeof(TImplementation).GetConstructors(BindingFlags.Public | BindingFlags.Instance);

        ConstructorInfo? constructor = null;

        foreach (var candidate in constructors)
        {
            if (constructor == null || candidate.GetParameters().Length > constructor.GetParameters().Length)
            {
                constructor = candidate;
            }
        }

        if (constructor == null)
        {
            throw new InvalidOperationException($"Type '{typeof(TImplementation)}' has no public constructor.");
        }

        var serviceProvider = Expression.Parameter(typeof(IServiceProvider), "serviceProvider");
        var argument = Expression.Parameter(typeof(TArgument), "argument");

        var parameters = constructor.GetParameters();
        var arguments = new Expression[parameters.Length];
        var isArgumentUsed = false;

        for (var i = 0; i < parameters.Length; i++)
        {
            var parameterType = parameters[i].ParameterType;

            if (!isArgumentUsed && parameterType == typeof(TArgument))
            {
                arguments[i] = argument;
                isArgumentUsed = true;

                continue;
            }

            arguments[i] = Expression.Convert(
                Expression.Call(GetRequiredServiceMethod, serviceProvider, Expression.Constant(parameterType)),
                parameterType);
        }

        if (!isArgumentUsed)
        {
            throw new InvalidOperationException(
                $"The constructor of '{typeof(TImplementation)}' has no parameter of type '{typeof(TArgument)}'.");
        }

        return Expression.Lambda<Func<IServiceProvider, TArgument, TService>>(
            Expression.New(constructor, arguments), serviceProvider, argument).Compile();
    }
}