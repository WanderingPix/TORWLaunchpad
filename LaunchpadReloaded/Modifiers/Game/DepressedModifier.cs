using LaunchpadReloaded.Options.Modifiers;
using MiraAPI.GameOptions;

namespace LaunchpadReloaded.Modifiers.Fun;

public sealed class DepressedModifier : LPModifier
{
    public override string ModifierName => "Depressed";
    public override int GetAssignmentChance() => (int)OptionGroupSingleton<GameModifierOptions>.Instance.DepressedChance;
    public override int GetAmountPerGame() => 1;
    
    public override string GetDescription()
    {
        return "Your speed is reduced and you look lifeless...";
    }

    public override void OnActivate()
    {
        if (Player != null)
        {
            Player.MyPhysics.Speed *= 0.75f;
            PlayerControl.LocalPlayer.RpcSetHat("");
            PlayerControl.LocalPlayer.RpcSetSkin("");
            PlayerControl.LocalPlayer.RpcSetVisor("");
        }
    }

    public override void OnDeactivate()
    {
        if (Player != null)
        {
            Player.MyPhysics.Speed /= 0.75f;
        }
    }
}