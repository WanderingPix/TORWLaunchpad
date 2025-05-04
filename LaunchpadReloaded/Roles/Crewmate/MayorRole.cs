using LaunchpadReloaded.Features;
using MiraAPI.Roles;
using System;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Crewmate;

public class MayorRole(IntPtr ptr) : RoleBehaviour(ptr), ICrewmateRole
{
    public string RoleName => "Mayor";
    public string RoleDescription => "You get extra votes.";
    public string RoleLongDescription => "You get extra votes every round.\nUse these votes to eject the Impostor!";
    public Color RoleColor => LaunchpadPalette.MayorColor;
    public override bool IsDead => false;
    public CustomRoleConfiguration Configuration => new(this)
    {
        OptionsScreenshot = LaunchpadAssets.MayorBanner,
    };
}
