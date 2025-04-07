using LaunchpadReloaded.Features;
using MiraAPI.Roles;
using System;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Coven;

public class DarkFairyRole(IntPtr ptr) : ImpostorRole(ptr), ICovenRole
{
    public string RoleName => "Dark Fairy";
    public string RoleDescription => "Hack meetings and sabotage the crewmates";
    public string RoleLongDescription => "Hack crewmates and make them unable to do tasks\nAnd view the admin map from anywhere!";
    public Color RoleColor => LaunchpadPalette.DarkFairyColor;
    public CustomRoleConfiguration Configuration => new(this)
    {
        Icon = LaunchpadAssets.DarkFairyButton,
        UseVanillaKillButton = false,
        CanUseVent = false,
        CanUseSabotage = false,
    };
}
