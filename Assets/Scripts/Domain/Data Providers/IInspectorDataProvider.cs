using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        public string lcuEnginePath { get; }
        RuneMenuEnum runeMenu { get; set; }
        LcuRuneIdConfig lcuRuneIdConfig { get; }
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
    }
}   