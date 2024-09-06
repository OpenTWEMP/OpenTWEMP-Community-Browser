﻿// <copyright file="MainGamingSupportHub.cs" company="The OpenTWEMP Project">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

#define GAME_ENGINE_SUPPORT_TWEMP
#undef GAME_ENGINE_SUPPORT_TWEMP

#define GAME_ENGINE_SUPPORT_RTW
#undef GAME_ENGINE_SUPPORT_RTW

namespace TWEMP.Browser.Core.GamingSupport;

/// <summary>
/// Defines the centralized API to provide external access to all gaming support features.
/// </summary>
public static class MainGamingSupportHub
{
#if GAME_ENGINE_SUPPORT_TWEMP
    public static void LaunchGameEngineAsTWEMP()
    {
        // Implement this static method when adding TWEMP game engine support.
    }
#endif

    public static void LaunchGameEngineAsM2TW()
    {
    }

#if GAME_ENGINE_SUPPORT_RTW
    public static void LaunchGameEngineAsRTW()
    {
        // Implement this static method when adding RTW game engine support.
    }
#endif
}