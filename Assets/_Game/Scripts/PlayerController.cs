using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector3 cameraOffset = Vector3.zero;
    [SerializeField] private PlayerSC playerSC;
    private float playerSpeed;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Animator playerAnim;
   public static Action<bool> OnPlayerFlip;

    private void Start()
    {
        if (playerCamera == null) { playerCamera = Camera.main; }
        playerSpeed = playerSC.playerSpeed;
        playerSprite.sprite = playerSC.playerSprite;
        playerAnim.runtimeAnimatorController = playerSC.playerAnimator;
    }
    private void FixedUpdate()
    {
        float moveX = floatingJoystick.Horizontal * playerSpeed * Time.deltaTime;
        float moveY = floatingJoystick.Vertical * playerSpeed * Time.deltaTime;

        Vector3 playerPosition = transform.position;
        Vector3 cameraPosition = playerCamera.transform.position;
        playerPosition = new Vector3(playerPosition.x + moveX, playerPosition.y + moveY, playerPosition.z);
        transform.position = playerPosition;
        playerCamera.transform.position = new Vector3(playerPosition.x,playerPosition.y,cameraPosition.z)+cameraOffset;
        if (moveX < 0)
        {
            playerSprite.flipX = true;
            OnPlayerFlip?.Invoke(true);
        }
        else if (moveX > 0)
        {
            playerSprite.flipX = false; 
            OnPlayerFlip?.Invoke(false);
        }

        float movementMagnitude = new Vector2(moveX, moveY).magnitude;

     
        playerAnim.SetFloat("Speed", movementMagnitude);
    }
}


