﻿using System;
using LoLRunes.CustumAttributes;

namespace LoLRunes.Enumerators.Extensions
{
    public static class RuneTypeEnumExtension
    {        
        private static T GetAttribute<T>(this RuneTypeEnum runeType)
            where T : Attribute
        {
            return (runeType.GetType().GetMember(Enum.GetName(runeType.GetType(), runeType))[0].GetCustomAttributes(typeof(T), inherit: false)[0] as T);
        }

        public static RunePositionReferenceEnum GetPositionReference(this RuneTypeEnum runeType)
        {
            return runeType.GetAttribute<RunePositionReferenceAttribute>().RunePositionReference;
        }
    }
}