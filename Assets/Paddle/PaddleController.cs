using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{

    public float movementSpeed = 5f;

    public int playerIndex = 1;

    float movementInput;

    void Update()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + Time.deltaTime * movementSpeed * movementInput
        );
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<float>();
    }

}
