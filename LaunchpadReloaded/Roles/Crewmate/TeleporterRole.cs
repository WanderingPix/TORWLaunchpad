using LaunchpadReloaded.Features;
using MiraAPI.Roles;
using System;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Crewmate;

public class TeleporterRole(IntPtr ptr) : RoleBehaviour(ptr), ICrewmateRole
{
    public string RoleName => "Teleporter";
    public string RoleLongDescription => "Zoom out and teleport across the map!";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => LaunchpadPalette.TeleporterColor;
    public override bool IsDead => false;

    public CustomRoleConfiguration Configuration => new(this)
    {
        OptionsScreenshot = LaunchpadAssets.CaptainBanner,
        Icon = LaunchpadAssets.TeleportButton,
    };
}