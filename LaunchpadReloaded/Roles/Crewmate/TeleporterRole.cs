using LaunchpadReloaded.Buttons.Crewmate;
using LaunchpadReloaded.Features;
using MiraAPI.Hud;
using MiraAPI.Roles;
using System;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Crewmate;

public class TeleporterRole(IntPtr ptr) : CrewmateRole(ptr), ICustomRole
{
    public string RoleName => "Teleporter";
    public string RoleLongDescription => "Zoom out and teleport across the map!";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => LaunchpadPalette.TeleporterColor;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        OptionsScreenshot = LaunchpadAssets.CaptainBanner,
        Icon = LaunchpadAssets.TeleportButton,
    };
}