using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;

    public static PlayerLook instance;

    bool can_Move;

    private void Awake()
    {
        instance = this;
        LockCursor();
        can_Move = true;
    }

    private void LockCursor()
    {

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(can_Move)
         CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * (Time.deltaTime);
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * (Time.deltaTime);
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void stop_Movement()
    {
        can_Move = false;
        playerBody.GetComponent<PlayerMove>().stop_Movement();
    }
}
