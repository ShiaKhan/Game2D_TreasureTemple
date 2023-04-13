using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLive = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI LivesText; 
    [SerializeField] TextMeshProUGUI ScoreText; 
  

    LevelManager LevelManager;

    private void Awake() {
        LevelManager = FindObjectOfType<LevelManager>();
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
                Destroy(gameObject);
        }
        else
        {
                DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        LivesText.text = playerLive.ToString();
        ScoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLive > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();      
        }
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersists();
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        ScoreText.text = score.ToString();    
    }


    void TakeLife()
    {
            playerLive = playerLive - 1;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            LivesText.text = playerLive.ToString();            
    }
     
    
    
}
