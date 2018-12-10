using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private string horizontalInptuName;
    [SerializeField] private string verticalInptuName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    bool can_Move;

    private void Awake()
    {
        can_Move = true;
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(can_Move)
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInptuName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInptuName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.root.name != "_Level"  && hit.transform.root.name != "Robot")
        {
            Destroy(hit.transform.gameObject);
            GUI_HUD.instance.fileCollected(hit.transform.name);
        }
            
    }

    public void stop_Movement()
    {
        can_Move = false;
    }

    public void start_Movement()
    {
        can_Move = true;
    }
}
