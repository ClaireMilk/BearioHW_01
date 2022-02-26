using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tansision : MonoBehaviour
{
    public AudioSource startAudio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StartGame", 3f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
