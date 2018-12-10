using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private string horizontalInptuName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController charController;

    bool can_Move;

    private bool isJumping;

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
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
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

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        isJumping = false;
    }
}
