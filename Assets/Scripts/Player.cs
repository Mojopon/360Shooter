using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        controller.SetSpeed(moveSpeed);
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        controller.SetRotatingMovement(turnSpeed * horizontalInput);
    }
}
