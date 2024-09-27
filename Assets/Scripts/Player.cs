using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private Tweener tweener;

    private int moveCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tweener.activeTween == null)
        {
            switch (moveCount)
            {
                case 0:
                    //left
                    tweener.AddTween(item.transform, item.transform.position, new Vector2(-5.5f, 3.5f), 1.5f);
                    moveCount++;
                    break;
                case 1:
                    //down
                    tweener.AddTween(item.transform, item.transform.position, new Vector2(-5.5f, -0.5f), 1.5f);
                    moveCount++;
                    break;
                case 2:
                    //right
                    tweener.AddTween(item.transform, item.transform.position, new Vector2(-0.5f, -0.5f), 1.5f);
                    moveCount++;
                    break;
                case 3:
                    //up
                    tweener.AddTween(item.transform, item.transform.position, new Vector2(-0.5f, 3.5f), 1.5f);
                    moveCount = 0;
                    break;
            }
        }
    }
}