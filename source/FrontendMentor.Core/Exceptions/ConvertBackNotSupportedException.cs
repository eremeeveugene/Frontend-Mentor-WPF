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

namespace FrontendMentor.Core.Exceptions;

public class ConvertBackNotSupportedException : NotSupportedException
{
    public ConvertBackNotSupportedException()
        : base("ConvertBack operation is not supported.")
    {
    }

    public ConvertBackNotSupportedException(string message)
        : base(message)
    {
    }

    public ConvertBackNotSupportedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}