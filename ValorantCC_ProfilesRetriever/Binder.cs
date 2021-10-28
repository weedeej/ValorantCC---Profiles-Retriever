﻿using System.Collections.Generic;
namespace ValorantCC_ProfilesRetriever
{
    public partial class Actionmapping
    {
        public bool alt { get; set; }
        public int bindIndex { get; set; }
        public string characterName { get; set; }
        public bool cmd { get; set; }
        public bool ctrl { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public bool shift { get; set; }
    }

    public partial class Boolsetting
    {
        public string settingEnum { get; set; }
        public bool value { get; set; }
    }

    public partial class Floatsetting
    {
        public string settingEnum { get; set; }
        public float value { get; set; }
    }

    public partial class Intsetting
    {
        public string settingEnum { get; set; }
        public int value { get; set; }
    }

    public partial class Stringsetting
    {
        public string settingEnum { get; set; }
        public string value { get; set; }
    }

    public partial class CrosshairProfile
    {
        public ProfileSettings Primary { get; set; }
        public ProfileSettings aDS { get; set; }
        public SniperSettings Sniper { get; set; }
        public bool bUsePrimaryCrosshairForADS { get; set; }
        public bool bUseCustomCrosshairOnAllPrimary { get; set; }
        public bool bUseAdvancedOptions { get; set; }

        public string ProfileName { get; set; }
    }

    public partial class ProfileSettings
    {
        public CrosshairColor Color { get; set; }
        public bool bHasOutline { get; set; }
        public int OutlineThickness { get; set; }
        public CrosshairColor OutlineColor { get; set; }
        public float OutlineOpacity { get; set; }
        public int CenterDotSize { get; set; }
        public float CenterDotOpacity { get; set; }
        public bool bDisplayCenterDot { get; set; }
        public bool bFixMinErrorAcrossWeapons { get; set; }
        public LineSettings InnerLines { get; set; }
        public LineSettings OuterLines { get; set; }

    }

    public partial class SniperSettings
    {
        public CrosshairColor CenterDotColor { get; set; }
        public int CenterDotSize { get; set; }
        public float CenterDotOpacity { get; set; }
        public bool bDisplayCenterDot { get; set; }
    }
    public partial class CrosshairColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }
    }

    public partial class LineSettings
    {
        public int LineThickness { get; set; }
        public int LineLength { get; set; }
        public int LineOffset { get; set; }
        public bool bShowMovementError { get; set; }
        public bool bShowShootingError { get; set; }
        public bool bShowMinError { get; set; }
        public float Opacity { get; set; }
        public bool bShowLines { get; set; }
        public float firingErrorScale { get; set; }
        public float movementErrorScale { get; set; }
    }

    public partial class ProfileList
    {
        public int CurrentProfile { get; set; }
        public List<CrosshairProfile> Profiles { get; set; }
    }

    public partial class Data
    {
        public Actionmapping[] actionMappings { get; set; }
        public object[] axisMappings { get; set; }
        public Boolsetting[] boolSettings { get; set; }
        public Floatsetting[] floatSettings { get; set; }
        public Intsetting[] intSettings { get; set; }
        public int roamingSetttingsVersion { get; set; }
        public Stringsetting[] stringSettings { get; set; }
    }

}