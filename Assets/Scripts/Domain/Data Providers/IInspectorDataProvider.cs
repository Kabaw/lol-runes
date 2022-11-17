using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
        RuneMenuEnum runeMenu { get; set; }
    }
}