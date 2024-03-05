// --------------------------------------------------------------------------------
// Copyright (C) 2024 Eugene Eremeev (also known as Yevhenii Yeriemeieiv).
// All Rights Reserved.
// --------------------------------------------------------------------------------
// This software is the confidential and proprietary information of Eugene Eremeev
// (also known as Yevhenii Yeriemeieiv) ("Confidential Information"). You shall not
// disclose such Confidential Information and shall use it only in accordance with
// the terms of the license agreement you entered into with Eugene Eremeev (also
// known as Yevhenii Yeriemeieiv).
// --------------------------------------------------------------------------------

using FrontendMentor.Core.Helpers;
using System.Windows.Input;

namespace FrontendMentor.Assets.Cursors;

public static class Cursors
{
    private const string HandCursorUriString =
        "pack://application:,,,/FrontendMentor.Assets;component/Cursors/HandCursor.cur";

    private static Cursor? _handCursor;

    public static Cursor HandCursor
    {
        get
        {
            if (_handCursor != null)
            {
                return _handCursor;
            }

            _handCursor = CursorsHelper.LoadCursor(new Uri(HandCursorUriString));

            return _handCursor;
        }
    }
}