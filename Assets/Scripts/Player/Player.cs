using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    private float inputX;
    private float inputY;
    private bool isWalking;
    private bool isRunning;
    private bool isIdle;
    private bool isCarrying = false;
    private ToolEffect toolEffect = ToolEffect.none;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;
    private bool isLiftingToolUp;
    private bool isLiftingToolDown;
    private bool isPickingRight;
    private bool isPickingLeft;
    private bool isPickingUp;
    private bool isPickingDown;
    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    private bool isSwingingToolUp;
    private bool isSwingingToolDown;

    private Camera mainCamera;

    private Rigidbody2D playerRigidbody2D;
#pragma warning disable 414
    private Direction playerDirection;
#pragma warning restore 414

    private float movementSpeed;

    private bool _playerInputIsDisabled = false;
    public bool playerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    protected override void Awake()
    {
        base.Awake();

        playerRigidbody2D = GetComponent<Rigidbody2D>();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        #region Player Input

        if (!playerInputIsDisabled)
        {
            ResetAnimationTriggers();
            PlayerMovementInput();
            PlayerWalkInput();

            EventHandler.CallMovementEvent(inputX,
                                           inputY,
                                           isWalking,
                                           isRunning,
                                           isIdle,
                                           isCarrying,
                                           toolEffect,
                                           isUsingToolRight,
                                           isUsingToolLeft,
                                           isUsingToolUp,
                                           isUsingToolDown,
                                           isLiftingToolRight,
                                           isLiftingToolLeft,
                                           isLiftingToolUp,
                                           isLiftingToolDown,
                                           isPickingRight,
                                           isPickingLeft,
                                           isPickingUp,
                                           isPickingDown,
                                           isSwingingToolRight,
                                           isSwingingToolLeft,
                                           isSwingingToolUp,
                                           isSwingingToolDown,
                                           false,
                                           false,
                                           false,
                                           false);
        }

        #endregion
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(inputX * movementSpeed * Time.deltaTime, inputY * movementSpeed * Time.deltaTime);
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + move);
    }

    private void ResetAnimationTriggers()
    {
        toolEffect = ToolEffect.none;
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isLiftingToolUp = false;
        isLiftingToolDown = false;
        isPickingRight = false;
        isPickingLeft = false;
        isPickingUp = false;
        isPickingDown = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isSwingingToolUp = false;
        isSwingingToolDown = false;
    }

    private void PlayerMovementInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 && inputY != 0)
        {
            inputX = inputX * 0.71f;
            inputY = inputY * 0.71f;
        }

        if (inputX != 0 || inputY != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            if (inputX < 0)
            {
                playerDirection = Direction.left;
            }
            else if (inputX > 0)
            {
                playerDirection = Direction.right;
            }
            else if (inputY < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }
        else if (inputX == 0 && inputY == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
        }
    }
    private void PlayerWalkInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();
        EventHandler.CallMovementEvent(inputX,
                               inputY,
                               isWalking,
                               isRunning,
                               isIdle,
                               isCarrying,
                               toolEffect,
                               isUsingToolRight,
                               isUsingToolLeft,
                               isUsingToolUp,
                               isUsingToolDown,
                               isLiftingToolRight,
                               isLiftingToolLeft,
                               isLiftingToolUp,
                               isLiftingToolDown,
                               isPickingRight,
                               isPickingLeft,
                               isPickingUp,
                               isPickingDown,
                               isSwingingToolRight,
                               isSwingingToolLeft,
                               isSwingingToolUp,
                               isSwingingToolDown,
                               false,
                               false,
                               false,
                               false);
    }

    private void ResetMovement()
    {
        inputX = 0f;
        inputY = 0f;
        isRunning = false;
        isIdle = false;
        movementSpeed = Settings.runningSpeed;
    }

    public void EnablePlayerInput()
    {
        playerInputIsDisabled = false;
    }
    public void DisablePlayerInput()
    {
        playerInputIsDisabled = true;
    }

    public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }
}
