using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    private Scene scene;
    public Canvas completeCanvas;
    public TMP_Text completeText;
    public AudioSource yayAudio;
    void Start()
    {
        //completeCanvas.gameObject.SetActive(false);
		scene = SceneManager.GetActiveScene();
        yayAudio = GetComponent<AudioSource>();
        completeCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Retrying Level");
            RetryLevel();
        }
    }

    public void CompletedLevel()
    {
        completeText.text = "Level " + (scene.buildIndex) + " complete!";
        //Debug.Log(scene.buildIndex);
        //completeCanvas.gameObject.SetActive(true);
		Debug.Log(yayAudio);
        yayAudio.Play();
        completeCanvas.enabled = true;
    }

    public void NextLevel()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void RetryLevel()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
