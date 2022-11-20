using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
        LcuRuneIdConfig lcuRuneIdConfig { get; }
        RuneMenuEnum runeMenu { get; set; }
    }
}   