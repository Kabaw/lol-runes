﻿using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;

namespace LoLRunes.Domain.Services.Interfaces
{
    public interface IRuneService
    {
        Rune Instantiate(RuneTypeEnum runeType);
    }
}