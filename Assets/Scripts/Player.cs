using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public int score = 0;

    [SerializeField] private float speed = 5f;

    public InputSystem_Actions inputs;

    [SerializeField] private Vector2 moveInput;

    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += OnMovement;
        inputs.Player.Move.canceled += OnMovement;


        inputs.Player.Attack.performed += OnAttack;
        inputs.Player.Attack.canceled += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            MovementMechanism(moveInput);
        }
    }
    private void MovementMechanism(Vector2 input)
    {
        transform.position += (Vector3)input * speed * Time.deltaTime;
    }


}
