using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IControllable
{
    private InputSystem _inputSystem;
    private Interact _interact;
    private Rigidbody2D _rb;
    private Animator animator;
    private Vector2 readMovement;
    
    public bool CanControl = true;
    
    [SerializeField] private float _speed;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Enable();
        
        _interact = GetComponent<Interact>();
        
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        readMovement = ReadMovement();
        Animation();
    }
    private void FixedUpdate()
    {
        if (CanControl)
        {
            Move(readMovement);
        }
    }
    
    private void OnEnable()
    {
        _inputSystem.Gameplay.Interact.performed += Interact;
    }
    
    private void OnDisable()
    {
        _inputSystem.Gameplay.Interact.performed -= Interact;
    }

    private Vector2 ReadMovement()
    {
        return _inputSystem.Gameplay.Movement.ReadValue<Vector2>();
    }

    public void Move(Vector2 direction)
    {
        direction.Normalize();
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    private void Animation()
    {
        MoveAnimation.OnMoving(animator, (ReadMovement() != new Vector2(0,0)));
        if (readMovement.x != 0)
            {
                MoveAnimation.Revers(transform, (readMovement.x > 0));
            }
    }

    public void Interact(InputAction.CallbackContext obj)
    {
        if (CanControl)
        {
            _interact.MakeInterraction();
        }
    }

    private void OnDestroy()
    {
        _inputSystem.Disable();
    }
}
