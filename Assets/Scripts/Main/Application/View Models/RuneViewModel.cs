using System;
using LoLRunes.Enumerators;

namespace LoLRunes.View.ViewModel
{
    public class RuneViewModel
    {
        public RuneTypeEnum RuneType { get; set; }

        public RuneViewModel DeepCopy()
        {
            return MemberwiseClone() as RuneViewModel;
        }
    }
}