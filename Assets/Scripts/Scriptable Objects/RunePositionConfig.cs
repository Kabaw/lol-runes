using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResolutionRunePositionConfig_xx", menuName = "Scriptable Objects/Positioning/ResolutionRunePositionConfig")]
public class ResolutionRunePositionConfig : ScriptableObject
{
    [SerializeField] private int resolutionX;
    [SerializeField] private int resolutionY;
    [SerializeField] private int windowX;
    [SerializeField] private int windowY;
    [SerializeField] private string positions;
}