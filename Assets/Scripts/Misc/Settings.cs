using JetBrains.Annotations;
using UnityEngine;

public static class Settings
{
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;

    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;

    // Player
    public static int inputX;
    public static int inputY;
    public static int isWalking;
    public static int isRunning;
    //public static int isIdle;
    //public static int isCarrying;
    public static int toolEffect;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int isPickingUp;
    public static int isPickingDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    // Shared
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;

    static Settings()
    {
        inputX              = Animator.StringToHash("xInput");
        inputY              = Animator.StringToHash("yInput");
        isWalking           = Animator.StringToHash("isWalking");
        isRunning           = Animator.StringToHash("isRunning"); 
        //isIdle              = Animator.StringToHash("isIdle");
        //isCarrying          = Animator.StringToHash("isCarrying");
        toolEffect          = Animator.StringToHash("toolEffect");
        isUsingToolRight    = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft     = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp       = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown     = Animator.StringToHash("isUsingToolDown");
        isLiftingToolRight  = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft   = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolUp     = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown   = Animator.StringToHash("isLiftingToolDown");
        isPickingRight      = Animator.StringToHash("isPickingRight");
        isPickingLeft       = Animator.StringToHash("isPickingLeft");
        isPickingUp         = Animator.StringToHash("isPickingUp");
        isPickingDown       = Animator.StringToHash("isPickingDown");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft  = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolUp    = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown  = Animator.StringToHash("isSwingingToolDown");

        idleUp    = Animator.StringToHash("idleUp");
        idleDown  = Animator.StringToHash("idleDown");
        idleLeft  = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }
}
