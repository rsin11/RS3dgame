using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI youWonText;
    public Button restartButton;
    private float spawnRate = 2.0f;
    int score = 0;
    public bool isGameActive;
    private int totalScore = 50;
    public bool wonGame;



    void Start()
    {
        score = 0;
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        if (isGameActive == true)
        {
            for (int x = 0; x < 10; x++)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, target.Count);
                Instantiate(target[index]);
            }
        }

    }

    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        ScoreText.text = "Score:" + score;
        if (score == totalScore)
        {
            WonGame();
         
        }
    }
    public void WonGame()
    {
        youWonText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        wonGame = true;
    }
    //GameOver method
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
