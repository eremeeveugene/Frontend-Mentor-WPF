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

using FrontendMentor.Core.Extensions;
using FrontendMentor.Core.Registrations;
using FrontendMentor.Core.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace FrontendMentor.Core.Tests.Extensions;

[TestClass]
public sealed class ServiceCollectionExtensionsTests
{
    [TestMethod]
    public void AddFactory_PassesTheArgumentAndResolvesTheOtherDependencies()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGreeter, Greeter>()
            .AddFactory<Person, IWelcome, Welcome>()
            .BuildServiceProvider();

        var factory = serviceProvider.GetRequiredService<Func<Person, IWelcome>>();

        var welcome = factory(new Person("Ada"));

        Assert.AreEqual("Hello, Ada", welcome.Text);
    }

    [TestMethod]
    public void AddFactory_EveryCallCreatesANewObject()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGreeter, Greeter>()
            .AddFactory<Person, IWelcome, Welcome>()
            .BuildServiceProvider();

        var factory = serviceProvider.GetRequiredService<Func<Person, IWelcome>>();

        Assert.AreNotSame(factory(new Person("Ada")), factory(new Person("Ada")));
    }

    [TestMethod]
    public void AddFactory_UsesTheRegisteredSubstituteOfADependency()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGreeter, LoudGreeter>()
            .AddFactory<Person, IWelcome, Welcome>()
            .BuildServiceProvider();

        var welcome = serviceProvider.GetRequiredService<Func<Person, IWelcome>>()(new Person("Ada"));

        Assert.AreEqual("HELLO, ADA", welcome.Text);
    }

    [TestMethod]
    public void AddFactory_AFactoryCanBeUsedInsideAConstructor()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGreeter, Greeter>()
            .AddFactory<Person, IWelcome, Welcome>()
            .AddFactory<Team, ITeamWelcome, TeamWelcome>()
            .BuildServiceProvider();

        var teamWelcome = serviceProvider.GetRequiredService<Func<Team, ITeamWelcome>>()(new Team(new Person("Ada")));

        Assert.AreEqual("Hello, Ada", teamWelcome.Leader.Text);
    }

    [TestMethod]
    public void AddFactory_WithoutAMatchingConstructorParameter_ThrowsWhenTheFactoryIsResolved()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IGreeter, Greeter>()
            .AddFactory<int, IWelcome, Welcome>()
            .BuildServiceProvider();

        Assert.ThrowsExactly<InvalidOperationException>(() =>
            serviceProvider.GetRequiredService<Func<int, IWelcome>>());
    }

    [TestMethod]
    public void AddMainWindow_RegistersTheWindowAndMarksItAsTheMainWindow()
    {
        var serviceProvider = new ServiceCollection()
            .AddMainWindow<IFakeWindow, FakeWindow>()
            .BuildServiceProvider();

        var registration = serviceProvider.GetRequiredService<MainWindowRegistration>();

        Assert.AreEqual(typeof(IFakeWindow), registration.ServiceType);
        Assert.IsInstanceOfType<FakeWindow>(serviceProvider.GetRequiredService<IFakeWindow>());
    }

    public interface IFakeWindow : IWindow
    {
    }

    public sealed class FakeWindow : IFakeWindow
    {
        public void Show()
        {
        }

        public void Close()
        {
        }
    }

    public sealed class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public sealed class Team
    {
        public Team(Person leader)
        {
            Leader = leader;
        }

        public Person Leader { get; }
    }

    public interface IGreeter
    {
        string Greet(string name);
    }

    public interface IWelcome
    {
        string Text { get; }
    }

    public interface ITeamWelcome
    {
        IWelcome Leader { get; }
    }

    public sealed class Greeter : IGreeter
    {
        public string Greet(string name)
        {
            return $"Hello, {name}";
        }
    }

    public sealed class LoudGreeter : IGreeter
    {
        public string Greet(string name)
        {
            return $"Hello, {name}".ToUpperInvariant();
        }
    }

    public sealed class Welcome : IWelcome
    {
        public Welcome(IGreeter greeter, Person person)
        {
            Text = greeter.Greet(person.Name);
        }

        public string Text { get; }
    }

    public sealed class TeamWelcome : ITeamWelcome
    {
        public TeamWelcome(Func<Person, IWelcome> welcomeFactory, Team team)
        {
            Leader = welcomeFactory(team.Leader);
        }

        public IWelcome Leader { get; }
    }
}