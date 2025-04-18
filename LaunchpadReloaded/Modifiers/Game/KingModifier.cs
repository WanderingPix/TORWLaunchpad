using LaunchpadReloaded.Components;
using LaunchpadReloaded.Options.Modifiers;
using MiraAPI.GameOptions;
using UnityEngine;

namespace LaunchpadReloaded.Modifiers.Fun;

public sealed class KingModifier : LPModifier
{
    public override string ModifierName => "VIP";
    public override int GetAssignmentChance() => (int)OptionGroupSingleton<GameModifierOptions>.Instance.KingChance;
    public override int GetAmountPerGame() => 1;

    public override string GetDescription()
    {
        return "You just look fancy!";
    }

    public override void OnActivate()
    {
        PlayerControl.LocalPlayer.RpcSetHat("hat_NewYear2024");
        PlayerControl.LocalPlayer.RpcSetSkin("skin_Bling");
        PlayerControl.LocalPlayer.RpcSetVisor("visor_masque_white");
    }

    public override void OnDeactivate()
    {
        PlayerControl.LocalPlayer.RpcSetHat("");
        PlayerControl.LocalPlayer.RpcSetSkin("");
        PlayerControl.LocalPlayer.RpcSetVisor("");
    }
}