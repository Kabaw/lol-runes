using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneShardsComp : MonoBehaviour
{
    [SerializeField] private List<GameObject> RuneShardSets;

    public void ResetShards()
    {
        DeactivateAll(RuneShardSets);
        ActivateAll(RuneShardSets);
    }

    private void ActivateAll(List<GameObject> gameObjects)
    {
        foreach (GameObject go in gameObjects)
            go.SetActive(true);
    }

    private void DeactivateAll(List<GameObject> gameObjects)
    {
        foreach (GameObject go in gameObjects)
            go.SetActive(false);
    }
}
