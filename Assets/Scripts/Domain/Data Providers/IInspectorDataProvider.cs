using LoLRunes.Domain.ScriptableObjects;
using LoLRunes.Shared.Enums;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
        RuneMenuEnum runeMenu { get; set; }
    }
}