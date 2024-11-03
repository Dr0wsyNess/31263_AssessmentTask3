using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPelletPoint()
    {
        score += 10;
        scoreText.text = score.ToString();
    }
    
    public void AddCherryPoint()
    {
        score += 100;
        scoreText.text = score.ToString();
    }
}
