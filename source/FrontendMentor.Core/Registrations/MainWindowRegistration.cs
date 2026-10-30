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

namespace FrontendMentor.Core.Registrations;

/// <summary>
///     Tells the application which registered window service is its main window.
/// </summary>
internal sealed class MainWindowRegistration
{
    public MainWindowRegistration(Type serviceType)
    {
        ServiceType = serviceType;
    }

    /// <summary>
    ///     Gets the service type of the main window.
    /// </summary>
    public Type ServiceType { get; }
}