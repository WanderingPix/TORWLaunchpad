using MiraAPI.Roles;
using UnityEngine;

namespace LaunchpadReloaded.Roles.Crewmate;

public interface ICrewmateRole : ICustomRole
{
    ModdedRoleTeams ICustomRole.Team => ModdedRoleTeams.Crewmate;
    RoleOptionsGroup ICustomRole.RoleOptionsGroup => new("\u2666 Crewmate Roles \u2666", new Color32(120, 204, 236, 255));
    TeamIntroConfiguration? ICustomRole.IntroConfiguration => new(Color.cyan, "CREWMATE", $"You are a Crewmate. Do tasks and vote off the {Palette.ImpostorRed.ToTextColor()}Impostor</color>.");
}