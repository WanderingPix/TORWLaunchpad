using LaunchpadReloaded.Options.Modifiers;
using MiraAPI.GameOptions;

namespace LaunchpadReloaded.Modifiers.Fun;

public sealed class TorchModifier : LPModifier
{
    public override string ModifierName => "Torch";
    public override string GetDescription()
    {
        return "You can see when lights are sabotaged!";
    }

    public override int GetAssignmentChance() => (int)OptionGroupSingleton<GameModifierOptions>.Instance.TorchChance;
    public override int GetAmountPerGame() => 1;
}