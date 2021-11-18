using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle Data")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 1.0f;
    public float maxIdleTime = 2.0f;
}
