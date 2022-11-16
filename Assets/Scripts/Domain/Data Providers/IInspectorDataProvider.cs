using LoLRunes.Domain.ScriptableObjects;
using LoLRunes.Enumerators;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
        RuneMenuEnum runeMenu { get; set; }
    }
}