using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button exitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadSecondLevel()
    {
    }
    
    public void LoadFirstLevel()
    {
        SceneManager.sceneLoaded += onSceneLoad;
        SceneManager.LoadScene("MainScene");
    }
    
    public void ExitGame()
    {
        SceneManager.sceneLoaded += onSceneLoad;
        SceneManager.LoadScene("StartScene");
    }

    public void onSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            exitButton = GameObject.FindWithTag("ExitButton").GetComponent<Button>();

        }
        exitButton.onClick.AddListener(ExitGame);
    }
}
