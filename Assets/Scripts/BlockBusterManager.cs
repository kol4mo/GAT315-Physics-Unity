using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockBusterManager : MonoBehaviour {
    [SerializeField] IntVariable score;
    [SerializeField] int scoreToPass;
    [SerializeField] IntVariable ammo;
    [SerializeField] int limit;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scorewinText;
    [SerializeField] TMP_Text scoreloseText;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] GameObject levelWin;
    [SerializeField] GameObject levelLose;
    [SerializeField] BoolVariable finished;

    [SerializeField] string nextLevel;

    // Start is called before the first frame update
    void Start() {
        ammo.value = limit; 
        levelWin.SetActive(false);
        levelLose.SetActive(false);
        finished.value = false;
        score.value = 0;
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Score: " + score.value;
        ammoText.text = ammo.value + "/" + limit;

        if (finished.value) {


            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (score.value > scoreToPass) {
                levelWin.SetActive(true);
                scorewinText.text = "Score: " + score.value;
            }


            if (score.value < scoreToPass) {
                levelLose.SetActive(true);
                scoreloseText.text = "Score: " + score.value;
            }
        }
    }

    public void retry() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        ammo.value = limit;
        levelWin.SetActive(false);
        levelLose.SetActive(false);
        finished.value = false;
        score.value = 0;
    }

    public void continueLevel() {
        SceneManager.LoadScene(nextLevel);
    }
}
