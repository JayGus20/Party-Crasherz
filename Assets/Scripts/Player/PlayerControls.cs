using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float testMoveSpeed;
    private Rigidbody2D rb;
    private Vector2 playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    void OnMove(InputValue inputValue)
    {
        playerInput = inputValue.Get<Vector2>();
        Debug.Log(playerInput);
        MovePlayer();
    }

    void OnAbility1(InputValue inputValue) 
    {
        Player.instance.UseAbility1();
    }

    void OnAbility2(CallbackContext contextCallback) 
    {
        Player.instance.UseAbility2();
    }

    void MovePlayer()
    {
        Vector2 playerVelocity = new Vector2(
        playerInput.x * testMoveSpeed,
        playerInput.y * testMoveSpeed);

        rb.velocity = playerVelocity;
    }
}
