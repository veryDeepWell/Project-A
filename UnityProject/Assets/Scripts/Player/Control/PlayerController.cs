using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour, IControllable
{
    private InputSystem _inputSystem;
    private Interact _interact;
    private Rigidbody2D _rb;
    private Animator animator;

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
        MoveAnimate(ReadMovement());
    }
    private void FixedUpdate()
    {
        Move(ReadMovement());
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

    public void Interact(InputAction.CallbackContext obj)
    {
        _interact.MakeInterraction();
    }

    private void OnDestroy()
    {
        _inputSystem.Disable();
    }

    private void MoveAnimate(Vector2 _vector)
    {
        if ((_vector.x != 0) || (_vector.y != 0))
        {
            MoveAnimation.OnMoving(animator);
            if (_vector.x > 0)
            {
                MoveAnimation.Revers(transform, true);
            }
            else if (_vector.x < 0)
            {
                MoveAnimation.Revers(transform, false);
            }
        }
        else
        {
            MoveAnimation.OnStand(animator);
        }

    }
}