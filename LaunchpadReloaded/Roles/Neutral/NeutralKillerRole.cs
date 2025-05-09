using AmongUs.GameOptions;
using LaunchpadReloaded.Features;
using LaunchpadReloaded.Buttons.Neutral;
using LaunchpadReloaded.Roles.Afterlife.Outcast;
using MiraAPI.Roles;
using UnityEngine;
using Il2CppSystem.Text;

namespace LaunchpadReloaded.Roles.Neutral;

public class NeutralKillerRole(System.IntPtr ptr) : RoleBehaviour(ptr), INeutralRole
{
    public string RoleName => "Neutral Killer";
    public string RoleDescription => "Neutral who can kill.\nThis is just a template role, it does nothing at this point, but will in the future.";
    public string RoleLongDescription => "This is just a template role, it does nothing at this point, but will in the future.";
    public Color RoleColor => LaunchpadPalette.NeutralKillerColor;
    public override bool IsDead => false;

    public CustomRoleConfiguration Configuration => new(this)
    {
        CanGetKilled = true,
        CanUseVent = true,
        GhostRole = (RoleTypes)RoleId.Get<OutcastGhostRole>(),
    };

    public override void AppendTaskHint(StringBuilder taskStringBuilder)
    {
        // remove default task hint
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return GameManager.Instance.DidHumansWin(gameOverReason);
    }
}