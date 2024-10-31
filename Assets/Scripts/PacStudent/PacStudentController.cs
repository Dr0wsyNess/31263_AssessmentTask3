using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Tweener tweener;
    private Vector3 direction = Vector3.zero;
    public Animator animatorController;
    public AudioSource moveSound;
    public AudioSource eatPellets;
    
    private bool isMoving;
    private Vector3 startPos, EndPos;
    private char lastInput = ' ';
    private char CurrentInput = ' ';
    private RaycastHit colHit;

    private float playerSpeed = 1.5f;
    
     
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player did an input
        PlayerLastInput();
        
        //if PacStudent is not lerping
        if (tweener.activeTween != null)
        {
            //check lastInput is if its walkable update currentInput to lastInput and lerp to position
            if(IsWalkable(lastInput))
            {
                UpdateCurrentInput();
                PlayerMove();
            }
            else
            {
                if (IsWalkable(CurrentInput))
                {
                    PlayerMove();
                }
            }
        }
        PlayerMove();
        

        // WalkAnimation();
        
    }



    void PlayerLastInput()
    {
        if (Input.GetKeyDown("w"))
        {
            direction = Vector3.up;
            lastInput = 'w';
        }
        if (Input.GetKeyDown("a"))
        {
            direction = Vector3.left;
            lastInput = 'a';
        }
        if (Input.GetKeyDown("s"))
        {
            direction = Vector3.down;
            lastInput = 's';
        }
        if (Input.GetKeyDown("d"))
        {
            direction = Vector3.right;
            lastInput = 'd';
        }
    }

    void UpdateCurrentInput()
    {
        CurrentInput = lastInput;
        WalkAnimation();

    }

    void PlayerMove()
    {
        if (CurrentInput == ' ')
        {
            tweener.AddTween(item.transform, item.transform.position, item.transform.position + direction, playerSpeed);
        }
    }

    bool IsWalkable(char move)
    {
        // if (Physics.Raycast(item.transform.position, direction, out colHit, 5.0f, ))
        return false;
    }

    void WalkAnimation()
    {
        animatorController.SetTrigger(lastInput);
    }

    void Audio()
    {
        
    }
}