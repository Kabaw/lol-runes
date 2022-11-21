using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;
using System.Collections.Generic;

namespace LoLRunes.Infra
{
    public interface IInspectorDataProvider
    {
        string lcuEnginePath { get; }
        string lcuEngineFileName { get; }
        RuneMenuEnum runeMenu { get; set; }
        Dictionary<RuneTypeEnum, string> lcuIdMapping { get; }
        ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; }
    }
}   