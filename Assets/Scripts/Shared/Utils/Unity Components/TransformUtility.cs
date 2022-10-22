using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.Utils.UnityComponents
{
    public static class TransformUtility
    {
        public static Transform FindParentByTag(Transform transform, string tag)
        {
            if (!transform)
                return null;

            Transform parentTransform = transform.parent;

            while (parentTransform)
            {
                if(parentTransform.CompareTag(tag))
                    return parentTransform;
                else
                    parentTransform = parentTransform.parent;
            }

            return null;
        }
    }
}