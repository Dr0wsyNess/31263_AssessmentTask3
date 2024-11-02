using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Tweener tweener;
    private Vector3 lastDirection = Vector3.zero;
    private Vector3 currentDirection = Vector3.zero;
    public Animator animatorController;
    public AudioSource moveSound;
    public AudioSource eatPellets;
    
    private string lastInput = "blank";
    private string CurrentInput = "blank";
    private RaycastHit colHit;
    private LayerMask pellets;

    public ParticleSystem dust;
    

    private float playerSpeed = 0.5f;

    [SerializeField]
    private Tilemap wallTileTL;
    [SerializeField]
    private Tilemap wallTileTR;
    [SerializeField]
    private Tilemap wallTileBL;
    [SerializeField]
    private Tilemap wallTileBR;
     
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        pellets = LayerMask.GetMask("Pellets");

    }

    // Update is called once per frame
    void Update()
    {
        //check if player did an input
        PlayerLastInput();
        
        //if PacStudent is not lerping
        if (tweener.activeTween == null)
        {
            
            //check lastInput is if its walkable update currentInput to lastInput and lerp to position
            if(IsWalkable(lastDirection))
            {
                UpdateCurrentInput();
                PlayerMove();
            }
            else
            {
                if (IsWalkable(currentDirection))
                {
                    PlayerMove();
                }
            }
        }
    }



    void PlayerLastInput()
    {
        if (Input.GetKeyDown("w"))
        {
            lastDirection = Vector3.up;
            lastInput = "w";
        }
        if (Input.GetKeyDown("a"))
        {
            lastDirection = Vector3.left;
            lastInput = "a";
        }
        if (Input.GetKeyDown("s"))
        {
            lastDirection = Vector3.down;
            lastInput = "s";
        }
        if (Input.GetKeyDown("d"))
        {
            lastDirection = Vector3.right;
            lastInput = "d";
        }
    }

    void UpdateCurrentInput()
    {
        CurrentInput = lastInput;
        animatorController.SetTrigger(CurrentInput);
        currentDirection = lastDirection;
    }

    void PlayerMove()
    {
        if (CurrentInput != "blank")
        {
            tweener.AddTween(item.transform, item.transform.position, item.transform.position + currentDirection, playerSpeed);
            Audio();
            CreateDust();
        }
    }

    bool IsWalkable(Vector3 move)
    {
        Vector3Int gridPostitionTL = wallTileTL.WorldToCell(item.transform.position + move);
        Vector3Int gridPostitionTR = wallTileTR.WorldToCell(item.transform.position + move);
        Vector3Int gridPostitionBL = wallTileBL.WorldToCell(item.transform.position + move);
        Vector3Int gridPostitionBR = wallTileBR.WorldToCell(item.transform.position + move);
        
        if (wallTileTL.HasTile(gridPostitionTL) || wallTileTR.HasTile(gridPostitionTR) || wallTileBL.HasTile(gridPostitionBL) || wallTileBR.HasTile(gridPostitionBR))
        {
            return false;
        }
        return true;
    }

    void Audio()
    {
        if (Physics.Raycast(item.transform.position, currentDirection, out colHit, 1.0f, pellets))
        {
            if (Vector3.Distance(item.transform.position, colHit.point) < 1)
            {
                moveSound.Stop();
                eatPellets.Play();
            }
        }
        else
        {
                eatPellets.Stop();
                moveSound.Play();
        }
        // Debug.DrawRay(item.transform.position, currentDirection * 1.0f, Color.red);
    }

    void CreateDust()
    {
        dust.Play();
    }
}