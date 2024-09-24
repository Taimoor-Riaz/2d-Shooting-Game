using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector3 cameraOffset = Vector3.zero;

    private void Start()
    {
        if (playerCamera == null) { playerCamera = Camera.main; }
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

    }
}
