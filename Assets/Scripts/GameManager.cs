using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int currentScore;
    public int currentLevel = 0;

    public static GameManager singleton;

    // Se llama antes del start
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        Debug.Log("Next level");
    }

    public void RestartLevel()
    {
        Debug.Log("Restart");
        singleton.currentScore = 0;
        FindObjectOfType<BallControler>().ResetBall();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            // Guardar score
            PlayerPrefs.SetInt("HighScore",bestScore);
        }
    }
}
