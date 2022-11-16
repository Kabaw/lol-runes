﻿using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;
using UnityEngine;

namespace LoLRunes.Domain.Services
{
    public class RuneService : IRuneService
    {
        public RuneService() { }

        public Rune Instantiate(RuneTypeEnum runeType)
        {
            Debug.Log(ToString());
            return new Rune(runeType);
        }
    }
}