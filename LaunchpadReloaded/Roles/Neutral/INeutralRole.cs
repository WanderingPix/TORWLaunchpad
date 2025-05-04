using MiraAPI.Roles;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Neutral;

public interface INeutralRole : ICustomRole
{
    ModdedRoleTeams ICustomRole.Team => ModdedRoleTeams.Custom;
    RoleOptionsGroup ICustomRole.RoleOptionsGroup => new("\u2666 Neutral Roles \u2666", Color.gray);
    TeamIntroConfiguration? ICustomRole.IntroConfiguration => new(Color.gray, "NEUTRAL", "You are a Neutral. You do not have a team.");
}