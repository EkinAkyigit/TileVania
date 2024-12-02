//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;

//public class GameSession : MonoBehaviour
//{
//    [SerializeField] public int playerLives = 3;
//    [SerializeField] int score = 0;
//    [SerializeField] TextMeshProUGUI livesText;
//    [SerializeField] TextMeshProUGUI scoreText;

//    private int scoreThreshold = 3; // Her 3 skor için artýþ saðlanacak

//    private int previousMilestone = 0; // Önceden kontrol edilen skor eþiði

//    void Update()
//    {
//        CheckScoreForHealth();
//    }

//    void CheckScoreForHealth()
//    {
//        // Eðer skor 3'ün katýna ulaþtýysa ve bu eþiði geçmediyse
//        if (score >= previousMilestone + scoreThreshold)
//        {
//            playerLives++; // Caný artýr
//            previousMilestone += scoreThreshold; // Eþiði güncelle
//            Debug.Log("Can Arttý! Yeni Can: " + playerLives);
//        }
//    }
//    void Awake()
//    {
//        int numGameSessions = FindObjectsOfType<GameSession>().Length;
//        if (numGameSessions > 1)
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            DontDestroyOnLoad(gameObject);
//        }
//    }

//    void Start()
//    {
//        livesText.text = playerLives.ToString();
//        scoreText.text = score.ToString();
//    }

//    public void ProcessPlayerDeath()
//    {
//        if (playerLives > 1)
//        {
//            TakeLife();
//        }
//        else
//        {
//            ResetGameSession();
//        }
//    }

//    public void AddToScore(int pointsToAdd)
//    {
//        score += pointsToAdd;
//        scoreText.text = score.ToString();
//    }
//    void TakeLife()
//    {
//        playerLives--;
//        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//        SceneManager.LoadScene(currentSceneIndex);
//        livesText.text = playerLives.ToString();
//    }

//    void ResetGameSession()
//    {
//        FindObjectOfType<ScenePersist>().ResetScenePersist();
//        SceneManager.LoadScene(0);
//        Destroy(gameObject);
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    private int scoreThreshold = 3; // Her 3 skor için artýþ saðlanacak

    private int previousMilestone = 0; // Önceden kontrol edilen skor eþiði

    void Update()
    {
        CheckScoreForHealth();
    }

    void CheckScoreForHealth()
    {
        // Eðer skor 3'ün katýna ulaþtýysa ve bu eþiði geçmediyse
        if (score >= previousMilestone + scoreThreshold)
        {
            playerLives++; // Caný artýr
            previousMilestone += scoreThreshold; // Eþiði güncelle
            livesText.text = playerLives.ToString();
            Debug.Log("Can Arttý! Yeni Can: " + playerLives);
        }
    }

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}


