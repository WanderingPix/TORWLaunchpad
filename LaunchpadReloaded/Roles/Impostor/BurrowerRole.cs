using Il2CppInterop.Runtime.Attributes;
using LaunchpadReloaded.Features;
using MiraAPI.Roles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Impostor;

public class BurrowerRole(IntPtr ptr) : RoleBehaviour(ptr), IImpostorRole
{
    public string RoleName => "Burrower";
    public string RoleDescription => "Create vents around the map.";
    public string RoleLongDescription => "Move around the map easier\nBy digging new vents.";
    public Color RoleColor => LaunchpadPalette.BurrowerColor;
    public override bool IsDead => false;
    public CustomRoleConfiguration Configuration => new(this)
    {
        Icon = LaunchpadAssets.DigVentButton,
        OptionsScreenshot = LaunchpadAssets.HackerBanner,
    };

    [HideFromIl2Cpp]
    public List<Vent> DugVents { get; } = [];
}
