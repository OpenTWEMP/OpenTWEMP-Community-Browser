// <copyright file="M2TWCustomQuickConfigStateView.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TWEMP.Browser.Core.GamingSupport.TotalWarEngine.M2TW.Configuration.Frontend;

using System.Reflection;
using TWEMP.Browser.Core.CommonLibrary.CustomManagement.Gaming.Configuration;

public class M2TWCustomQuickConfigStateView : ICustomQuickConfigState
{
    public M2TWCustomQuickConfigStateView()
    {
        this.IsEnabledWindowedMode = true;
        this.IsEnabledFullScreenMode = false;
        this.ValidatorVideo = false;
        this.ValidatorBorderless = false;

        this.ValidatorLogLevel1 = false;
        this.ValidatorLogLevel2 = false;
        this.ValidatorLogLevel3 = true;
        this.EnabledLogsHistorySaving = false;

        this.IsShouldBeDeleted_MapRWM = false;
        this.IsShouldBeDeleted_TextBin = false;
        this.IsShouldBeDeleted_SoundPacks = false;

        this.UseLauncherProvider_TWEMP = true;
        this.UseLauncherProvider_M2TWEOP_NativeSetup = false;
        this.UseLauncherProvider_M2TWEOP_NativeBatch = false;
        this.UseLauncherProvider_M2TWEOP = false;
    }

    public bool IsEnabledWindowedMode { get; set; }

    public bool IsEnabledFullScreenMode { get; set; }

    public bool ValidatorVideo { get; set; }

    public bool ValidatorBorderless { get; set; }

    public bool ValidatorLogLevel1 { get; set; }

    public bool ValidatorLogLevel2 { get; set; }

    public bool ValidatorLogLevel3 { get; set; }

    public bool EnabledLogsHistorySaving { get; set; }

    public bool IsShouldBeDeleted_MapRWM { get; set; }

    public bool IsShouldBeDeleted_TextBin { get; set; }

    public bool IsShouldBeDeleted_SoundPacks { get; set; }

    public bool UseLauncherProvider_TWEMP { get; set; }

    public bool UseLauncherProvider_M2TWEOP_NativeSetup { get; set; }

    public bool UseLauncherProvider_M2TWEOP_NativeBatch { get; set; }

    public bool UseLauncherProvider_M2TWEOP { get; set; }

    public Dictionary<string, bool> GetStateViewOfProperties()
    {
        Dictionary<string, bool> properties = new Dictionary<string, bool>();

        Type currentType = this.GetType();
        PropertyInfo[] currentProperties = currentType.GetProperties();

        foreach (PropertyInfo currentProperty in currentProperties)
        {
            if (currentProperty.PropertyType.Equals(typeof(bool)))
            {
                object? propertyValue = currentProperty.GetValue(this);
                bool targetValue = Convert.ToBoolean(propertyValue);

                properties.Add(key: currentProperty.Name, value: targetValue);
            }
        }

        return properties;
    }

    public void SetPropertiesByStateView(Dictionary<string, bool> stateView)
    {
        Type currentType = this.GetType();
        PropertyInfo[] currentProperties = currentType.GetProperties();

        foreach (PropertyInfo currentProperty in currentProperties)
        {
            Type currentPropertyType = currentProperty.PropertyType;

            foreach (KeyValuePair<string, bool> propertyView in stateView)
            {
                bool hasEqualName = propertyView.Key.Equals(currentProperty.Name);
                bool hasEqualType = currentPropertyType.Equals(typeof(bool));

                if (hasEqualName && hasEqualType)
                {
                    currentProperty.SetValue(this, propertyView.Value);
                }
            }
        }
    }
}
