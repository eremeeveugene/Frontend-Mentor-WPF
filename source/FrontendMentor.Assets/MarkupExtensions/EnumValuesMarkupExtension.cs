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

namespace FrontendMentor.Assets.MarkupExtensions;

public class EnumValuesMarkupExtension : LazyMarkupExtension<EnumValuesMarkupExtension>
{
    public Type? Type { get; set; }

    public object GetEnumValues()
    {
        return Type?.IsEnum == true
            ? Enum.GetValues(Type)
            : throw new InvalidOperationException("The provided Type must be a non-null enum type.");
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return GetEnumValues();
    }
}