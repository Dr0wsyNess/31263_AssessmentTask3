using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private Tweener tweener;
    private int moveCount = 1;
    public Animator animatorController;
    public AudioSource PlayerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

    }

    // Update is called once per frame
    void Update()
    {
        // if (tweener.activeTween == null)
        // {
        //     PlayerMove.Play();
        //     switch (moveCount)
        //     { 
        //         case 0:
        //             //left
        //             tweener.AddTween(item.transform, item.transform.position, new Vector2(-5.5f, 3.5f), 1.5f);
        //             moveCount++;
        //             animatorController.SetTrigger("MoveLeft");
        //             break;
        //         case 1:
        //             //down
        //             tweener.AddTween(item.transform, item.transform.position, new Vector2(-5.5f, -0.5f), 1.5f);
        //             moveCount++;
        //             animatorController.SetTrigger("MoveDown");
        //             break;
        //         case 2:
        //             //right
        //             tweener.AddTween(item.transform, item.transform.position, new Vector2(-0.5f, -0.5f), 1.5f);
        //             moveCount++;
        //             animatorController.SetTrigger("MoveRight");
        //             break;
        //         case 3:
        //             //up
        //             tweener.AddTween(item.transform, item.transform.position, new Vector2(-0.5f, 3.5f), 1.5f);
        //             moveCount = 0;
        //             animatorController.SetTrigger("MoveUp");
        //             break;
        //     }
        // }
    }
}