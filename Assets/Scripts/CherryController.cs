using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CherryController : MonoBehaviour
{
    [SerializeField]
    private GameObject bonusCherry;

    private GameObject currentCherry;
    private float spawnRate = 2f;
    private float cherrySpeed = 10f;

    // private Camera mainCamera;
    private Tweener tweener;
    private Vector3 startPos = new Vector3(0f, 0f, 0f);
    private Vector3 endPos = new Vector3(0f, 0f, 0f);
    
    
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //reduce sqawnRate by amount of time that has passed by this frame
        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0 && bonusCherry && tweener.activeTween == null)
        {
            SpawnCherry();
            tweener.AddTween(currentCherry.transform, currentCherry.transform.position,new Vector3(endPos.x, endPos.y, 0f) , cherrySpeed);
            spawnRate = 10f;
        }

    }

    void SpawnCherry()
    {
        int spawnSide = Random.Range(0,4);
        float xPos = 0.0f;
        float yPos = 0.0f;
        startPos = new Vector3(0f, 0f, 0f);
        endPos = new Vector3(0f, 0f, 0f);
            
        switch (spawnSide)
        {
            case 0: // Top
                xPos = Random.Range(0.285f, 0.755f);
                startPos = Camera.main.ViewportToWorldPoint(new Vector3(xPos, 1.1f, 0f));
                endPos = Camera.main.ViewportToWorldPoint(new Vector3(xPos, -0.1f, 0f));
                break;
            case 1: // Left
                yPos = Random.Range(0.0f, 1.0f);
                startPos = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, yPos, 0f));
                endPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, yPos, 0f));
                break;
            case 2: // Bot
                xPos = Random.Range(0.285f, 0.755f);
                startPos = Camera.main.ViewportToWorldPoint(new Vector3(xPos,-0.1f, 0f));
                endPos = Camera.main.ViewportToWorldPoint(new Vector3(xPos, 1.1f, 0f));
                break;
            case 3: // Right
                yPos = Random.Range(0.0f, 1.0f);
                startPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, yPos, 0f));
                endPos = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, yPos, 0f));
                break;
        }   
        
        currentCherry = Instantiate(bonusCherry, new Vector3(startPos.x, startPos.y, 0f), Quaternion.identity);
    }

    void CherryMove()
    {
        while (currentCherry.transform.position != endPos)
        {
            tweener.AddTween(currentCherry.transform, currentCherry.transform.position,new Vector3(endPos.x, endPos.y, 0f) , cherrySpeed);
        }
        Destroy(currentCherry);
    }

    
}
