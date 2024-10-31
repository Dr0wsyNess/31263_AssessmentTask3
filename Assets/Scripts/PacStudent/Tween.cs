using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween 
{
    //Auto-implemented properties where it can be publicly accessible but set privately
    public Transform Target {get; private set; }
    public Vector3 StartPos{get; private set; }
    public Vector3 EndPos {get; private set; }
    public float StartTime {get; private set; }
    public float Duration {get; private set; }

    public Tween(Transform target, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        this.Target = target;
        this.StartPos = startPos;
        this.EndPos = endPos;
        this.StartTime = startTime;
        this.Duration = duration;
    }
    
}
