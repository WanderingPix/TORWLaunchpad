using MiraAPI.Roles;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Impostor;

public interface IImpostorRole : ICustomRole
{
    ModdedRoleTeams ICustomRole.Team => ModdedRoleTeams.Impostor;
    RoleOptionsGroup ICustomRole.RoleOptionsGroup => new("\u2666 Impostor Roles \u2666", new Color32(203, 83, 84, 255));
    TeamIntroConfiguration? ICustomRole.IntroConfiguration => new(Color.red, "IMPOSTOR", "You are an Impostor. Sabotage and kill the crew.");
}