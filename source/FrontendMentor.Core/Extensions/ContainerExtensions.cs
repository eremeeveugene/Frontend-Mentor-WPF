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

using DryIoc;

namespace FrontendMentor.Core.Extensions;

public static class ContainerExtensions
{
    extension(IContainer container)
    {
        public void RegisterSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            container.Register<TService, TImplementation>(Reuse.Singleton);
        }

        public void RegisterViewWithViewModel<TView, TViewModel>()
            where TView : class
            where TViewModel : class
        {
            container.Register<TView>(Reuse.Transient);
            container.Register<TViewModel>(Reuse.Transient);
        }
    }
}