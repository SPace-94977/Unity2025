using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{  
    [Header("Properties")]
    [SerializeField] float moveSpeed = 10f;

    [Header("Padding")]
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;

    Shooter playerShooter;

    InputAction moveAction;
    InputAction fireAction;

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;


    void Start()
    {
        playerShooter = GetComponent<Shooter>();

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");

        InitBounds();
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
    }
   
    void InitBounds(){
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        transform.position +=moveVector * moveSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}