using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController GameControllerInstance;
    public Slider healthSlider;
    public float PlayerHealth;
    public Canvas map;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public int LeveltoLoad;
    public float moveSpeed = 10;

    private Quaternion originalCameraRotation;

    void Start()
    {
        GameControllerInstance = this;
        originalCameraRotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update ()
    {
        healthSlider.value = PlayerHealth;
        Vector3 playerPos = transform.position;
    }

    private void ResetCameraRotation()
    {
        Camera.main.transform.rotation = originalCameraRotation;
    }

    public void LoadLevel(int LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("Jump"))
            {

                GameController.GameControllerInstance.LoadLevel(LeveltoLoad);
            }
        }
    }
}
