using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Rigidbody playerRb;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button RestartButton;
    public GameObject titleScreen;
    public bool isGameActive;

    private int score;
    private float spawnRate = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score +" Pts.";
    }

    public void GameOver()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();

        playerRb.freezeRotation = false;
        playerRb.useGravity = true;
        playerRb.AddForce(Vector3.forward * 50000, ForceMode.Impulse);
        RestartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;

        score = 0;
        UpdateScore(0);
        spawnRate = spawnRate / difficulty;

        titleScreen.gameObject.SetActive(false);
    }
}