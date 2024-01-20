// <copyright file="FormLocaleSnapshot.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.CommonLibrary;

public class FormLocaleSnapshot
{
    public FormLocaleSnapshot(string formName, Dictionary<string, string> formContent)
    {
        this.FormName = formName;
        this.FormContent = formContent;
    }

    public string FormName { get; }

    public Dictionary<string, string> FormContent { get; }

    public string GetLocalizedValueByKey(string targetKey)
    {
        if (this.FormContent.ContainsKey(targetKey))
        {
            return this.FormContent[targetKey];
        }

        return string.Empty;
    }
}
