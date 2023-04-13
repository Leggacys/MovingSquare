using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
  public float speed;
  [HideInInspector]
  public Vector2 moveDir;
  public float smoothInputSpeed = .2f;

  private Rigidbody2D _rb;
  private bool isMoving;
  private PlayerInput _playerInput;
  private Vector2 currentInputValue;
  private Vector2 smoothInputValue;

  private void Awake()
  {
    _playerInput = GetComponent<PlayerInput>();
    _rb = GetComponent<Rigidbody2D>();
  }


  private void Update()
  {
    moveDir = _playerInput.actions["Move"].ReadValue<Vector2>();
    isMoving = Convert.ToBoolean(moveDir.magnitude);

  }


  private void FixedUpdate()
  {
    //_rb.MovePosition(_rb.position + moveDir*speed*Time.fixedDeltaTime);
    
    currentInputValue = Vector2.SmoothDamp(currentInputValue, moveDir*speed, ref smoothInputValue, smoothInputSpeed,10);
    _rb.velocity = currentInputValue;
  }
  
  
}
