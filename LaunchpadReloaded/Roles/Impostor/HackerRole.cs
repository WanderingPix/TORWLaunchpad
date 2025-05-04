using LaunchpadReloaded.Features;
using MiraAPI.Roles;
using System;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Impostor;

public class HackerRole(IntPtr ptr) : RoleBehaviour(ptr), IImpostorRole
{
    public string RoleName => "Hacker";
    public string RoleDescription => "Hack meetings and sabotage the crewmates";
    public string RoleLongDescription => "Hack crewmates and make them unable to do tasks\nAnd view the admin map from anywhere!";
    public Color RoleColor => LaunchpadPalette.HackerColor;
    public override bool IsDead => false;
    public CustomRoleConfiguration Configuration => new(this)
    {
        Icon = LaunchpadAssets.HackButton,
        OptionsScreenshot = LaunchpadAssets.HackerBanner,
    };
}
