using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;

    private bool isMoving;
    private Vector2 startPos, EndPos;
    private char lastInput;

    private float playerSpeed = 1.5f;
    private float interpolationRatio = 0.0f;
    
    

    private Tweener tweener;
    public Animator animatorController;
    public AudioSource PlayerMove;
    public AudioSource eatPellets;
    
     
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInput();
        Tween();
        if (isMoving)
        {
            
        }
        

        WalkAnimation();

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

    void Tween()
    {
        // float distance = Vector2.Distance(activeTween.Target.position, activeTween.EndPos);

        
            interpolationRatio += playerSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, EndPos, interpolationRatio);

        
    }

    void playerInput()
    {
        if (Input.GetKeyDown("w"))
        {
            lastInput = 'w';
        }
        if (Input.GetKeyDown("a"))
        {
            lastInput = 'a';
        }
        if (Input.GetKeyDown("s"))
        {
            lastInput = 's';
        }
        if (Input.GetKeyDown("d"))
        {
            lastInput = 'd';
        }
    }

    void WalkAnimation()
    {
        animatorController.SetTrigger(lastInput);
    }

    void Audio()
    {
        if (isMoving)
        {
            
        }
    }
}