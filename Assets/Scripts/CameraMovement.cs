using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedH;
    private float yaw = 0.0f;

    private Rigidbody rb;
    public float moveSpeed = 2.5f;
    public JoyStick joyStick;
    private Vector3 direction;
    private Vector3 originalAngle;

    // touch control
    private Vector2 firstTouch;

    // Animal Close Up
    [HideInInspector] public Transform beforeCloseUp;
    public UIController uIController;
    public Vector3 offset;
    private GameObject targetAnimal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalAngle = transform.eulerAngles;
        beforeCloseUp = transform;
    }

    void Update()
    {
        if (uIController.closeUp)
        {
            transform.position = targetAnimal.transform.position + offset;
            transform.LookAt(targetAnimal.transform);
            transform.eulerAngles -= new Vector3(6f, 0f, 0f);
        }
        else if (joyStick.isActiveAndEnabled)
        {
            direction = joyStick.InputDirection;
            if (direction.magnitude != 0)
            {
                MoveCamera();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            CameraMove();
        }
    }

    void MoveCamera()
    {
        if (direction.y < 0)
            rb.velocity = -transform.forward * moveSpeed;
        else if (direction.y > 0)
            rb.velocity = transform.forward * moveSpeed;
        if (direction.x != 0)
            Rotate();
    }

    void CameraMove()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                firstTouch = touch.position;
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 dir = firstTouch - touch.position;
                    if (dir.y < -20f)
                        rb.velocity = transform.forward * moveSpeed;
                    else if (dir.y > 20f)
                        rb.velocity = -transform.forward * moveSpeed;
                    else
                        rb.velocity = Vector3.zero;
                    if (Mathf.Abs(dir.x) > 20f)
                    {
                        yaw += (dir.x > 0 ? -1f : 1f) * speedH;

                        transform.eulerAngles = new Vector3(originalAngle.x, yaw, originalAngle.z);
                    }
            }
            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector3.zero;
        }
    }

    void Rotate()
    {
        yaw += speedH * direction.x;
        transform.eulerAngles = new Vector3(originalAngle.x, yaw, originalAngle.z);
    }

    public void SetTargetAnimal(GameObject target)
    {
        targetAnimal = target;
    }

    public void ResetCamera()
    {
        transform.position = beforeCloseUp.position;
        transform.rotation = beforeCloseUp.rotation;
        transform.eulerAngles = beforeCloseUp.eulerAngles;
        targetAnimal = null;
    }
}
