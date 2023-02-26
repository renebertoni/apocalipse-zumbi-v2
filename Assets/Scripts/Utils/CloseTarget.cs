using System;
using UnityEngine;

[Serializable]
public class CloseTarget : ScriptableObject {
    public Collider[] Targets;
    public bool HasCloseTarget;

    public void CreateCloseTarget(Collider[] targets, bool hasCloseTarget)
    {
        Targets = targets;
        HasCloseTarget = hasCloseTarget;
    }
}
