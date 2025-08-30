using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Hebi : MonoBehaviour
{
    public Rigidbody2D snake;
    public float moveSpeed = 5;
    public LogicManager logicManager;
    
    private InputAction _moveAction;
    private Vector2 _lastDirection = Vector2.right; // starting movement
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("move");
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveAction.triggered)
        {
            Vector2 direction = _moveAction.ReadValue<Vector2>();
            
            // Prioritize horizontal movement if its magnitude is greater
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                direction = new Vector2(direction.x, 0);
            }
            // Otherwise, prioritize vertical movement
            else
            {
                direction = new Vector2(0, direction.y);
            }
            snake.linearVelocity = direction.normalized * moveSpeed;
            _lastDirection = direction;
        }
        else
        {
            snake.linearVelocity = _lastDirection.normalized * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ringo"))
        {
            Debug.Log("Ringo hit!");
            Destroy(collision.gameObject);
            logicManager.ScorePoint(gameObject);
            logicManager.SpawnRingo();
        }
    }

    public void ReverseDirection()
    {
        var reversedDirection = _lastDirection.normalized * moveSpeed * -1;
        snake.linearVelocity = reversedDirection;
        _lastDirection = reversedDirection;
    }
}
