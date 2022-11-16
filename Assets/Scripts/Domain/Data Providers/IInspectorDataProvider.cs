using LoLRunes.Enumerators;
using LoLRunes.ScriptableObjects;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
        RuneMenuEnum runeMenu { get; set; }
    }
}