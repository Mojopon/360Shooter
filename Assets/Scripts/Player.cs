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
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        controller.Rotate(turnSpeed * horizontalInput);
        var velocity = transform.rotation * Vector3.up * moveSpeed;
        controller.Move(velocity);
    }
}
