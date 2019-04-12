using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Joystick
    public GameObject joyStick;

    // Double Tap Recognition
    int tapCount;
    public float maxDubbleTapTime;
    float newTime;

    // Change of UI
    [HideInInspector] public bool closeUp;
    public GameObject wholeScreen;
    public GameObject animalScreen;

    // Camera Setting
    public CameraMovement cameraMovement;

    private void Start()
    {
        tapCount = 0;
    }

    void Update()
    {
        DetectTypeofTouch();
    }

    void DetectTypeofTouch()
    {
        if (!closeUp && Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
                tapCount++;
            //else if (touch.phase == TouchPhase.Began)
                //SetJoyStick(touch);
            if (tapCount == 1)
                newTime = Time.time + maxDubbleTapTime;
            else if (tapCount == 2 && Time.time <= newTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                    if (hit.transform.tag == "Cats")
                        SetCloseUp(hit.transform.gameObject);
                tapCount = 0;
            }
            if (Time.time > newTime)
                tapCount = 0;
        }
    }

    void SetCloseUp(GameObject targetAnimal)
    {
        // Set Camera here
        cameraMovement.SetTargetAnimal(targetAnimal);
        cameraMovement.beforeCloseUp = cameraMovement.gameObject.transform;
        animalScreen.SetActive(true);
        wholeScreen.SetActive(false);
        closeUp = true;
    }

    public void OutOfCloseUp()
    {
        cameraMovement.ResetCamera();
        animalScreen.SetActive(false);
        wholeScreen.SetActive(true);
        closeUp = false;
    }

    void SetJoyStick(Touch touch)
    {
        Vector2 pos = touch.position;
        joyStick.transform.position = pos;
    }

    public void LoadARScene()
    {
        SceneManager.LoadScene("ARInteraction");
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("ARMap");
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
}