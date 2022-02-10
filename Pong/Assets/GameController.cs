using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    int leftPlayerScore, rightPlayerScore;
    public int maxScore = 3;
    public Text ScoreText;

    public GameObject gameOverUI;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.anyKeyDown)
            {
                Restart();
            }
        }
    }

    public void Score(bool leftPlayer)
    {
        if (leftPlayer)
        {
            leftPlayerScore++;
        }
        else
        {
            rightPlayerScore++;
        }
       
        if (leftPlayerScore >= maxScore)
        {
            ScoreText.text = "Player 1 Wins";
            GameOver();
        }
        else if (rightPlayerScore >= maxScore)
        {
            ScoreText.text = "Player 2 Wins";
            GameOver(); ;
        }
        else
        {
            ScoreText.text = leftPlayerScore + " : " + rightPlayerScore;
        }
    }   

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
