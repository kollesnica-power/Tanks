using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Canvas m_FadeCanvas;
    [SerializeField] private Text m_GameOverText;

    private bool isGameOver = false;

    private static GameManager instance = null;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    void Awake() {

        if (instance == null) {

            instance = this;

        } else if (instance != this) {

            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);

    }

    private void Update() {

        // Waiting for input when game is over
        if (isGameOver && Input.GetKeyDown(KeyCode.Return)) {

            //StartAgain();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        }

    }

    public void AddScore(int value) {

        // Get value from string
        int currentValue = int.Parse(m_ScoreText.text.Substring(8));

        // Increase value
        currentValue += value;

        // Set GUI text
        m_ScoreText.text = "Score : " + currentValue;

    }

    // Fade in scene and show game over text
    public void GameOver() {

        isGameOver = true;

        m_FadeCanvas.gameObject.SetActive(true);
        m_GameOverText.gameObject.SetActive(true);

        //ClearMines();

    }

    // Fade out scene and hide game over text
    private void StartAgain() {

        isGameOver = false;

        m_FadeCanvas.gameObject.SetActive(false);
        m_GameOverText.gameObject.SetActive(false);

        TankController.Instanse.gameObject.SetActive(true);

        // Set zero sore
        m_ScoreText.text = "Score : 0";

    }

    private void ClearMines() {

        GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");

        foreach (var item in mines) {

            Destroy(item);

        }

    }

}
