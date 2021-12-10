using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] ghosts;
    public GameObject pacman;

    public GameObject gameOverPanel;
    public GameObject startPanel;
    public GameObject scorePanel;
    public Text scoreText;
    public Text gameOverScore;
    public Text gameOverText;
    public Transform pellet;

    private float score;


    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        scorePanel.SetActive(false);
        score = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Score : " + score.ToString();
        if(pellet.childCount <= 0)
        {
            GameWon();
        }
    }

    public void IncreaseScore(float increase)
    {
        score += increase;
    }


    public void PowerUpActivated()
    {
        StartCoroutine(SetGhostFrighten());

    }

    public void GameStart()
    {
        startPanel.SetActive(false);
        scorePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameWon()
    {
        gameOverText.text = "GAME\nWON";
        gameOverPanel.SetActive(true);
        gameOverScore.text = "Score : " + score.ToString();
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME\nOVER";
        gameOverPanel.SetActive(true);
        gameOverScore.text = "Score : " + score.ToString(); 
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    IEnumerator SetGhostFrighten()
    {
        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Frightened>().frightenedState();
        }

        yield return new WaitForSeconds(10f);

        foreach(GameObject ghost in ghosts)
        {
            if(ghost.GetComponent<Frightened>().isFrightened)
                ghost.GetComponent<Frightened>().ResetState();
        }
    }
}
