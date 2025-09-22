using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PaddleController player1;
    public PaddleController player2;

    private PlayerInput input;


    void Awake()
    {
        input = new PlayerInput();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        if (player1 != null)
        {
            input.Paddles.MovePlayer1.performed += player1.OnMove;
            input.Paddles.MovePlayer1.canceled += player1.OnMove;
        }

        if (player2 != null)
        {
            input.Paddles.MovePlayer2.performed += player2.OnMove;
            input.Paddles.MovePlayer2.canceled += player2.OnMove;
        }
        
    }

}
