using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    public Tween activeTween {get; set; }
    
    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            float distance = Vector2.Distance(activeTween.Target.position, activeTween.EndPos);
            if (distance > 0.1f)
            {
                float interpolationRatio = (Time.time - activeTween.StartTime) / activeTween.Duration;
                activeTween.Target.position = Vector2.Lerp(activeTween.StartPos, activeTween.EndPos, interpolationRatio);

            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }
    }

    public void AddTween(Transform targetObject, Vector2 startPos, Vector2 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            
        }
    }
    
}
