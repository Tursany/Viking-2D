using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController GameControllerInstance;
    public Slider healthSlider;
    public float PlayerHealth;

    private Quaternion originalCameraRotation;

    void Start()
    {
        GameControllerInstance = this;
        originalCameraRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        healthSlider.value = PlayerHealth;
    }

    private void ResetCameraRotation()
    {
        Camera.main.transform.rotation = originalCameraRotation;
    }

    public void LoadLevel(int LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
