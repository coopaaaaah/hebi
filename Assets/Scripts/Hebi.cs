using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Hebi : MonoBehaviour
{
    public Rigidbody2D snake;
    public float moveSpeed = 5;
    public LogicManager logicManager;
    
    private InputAction _moveAction;
    private Vector2 _lastDirection;
    
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
            snake.linearVelocity = direction.normalized * moveSpeed;
            _lastDirection = direction;
        }
        else
        {
            snake.linearVelocity = _lastDirection.normalized * moveSpeed;
        }
        
        if (HitWall(transform.position))
        {
            Destroy(gameObject);
        }
    }
    
    bool HitWall(Vector2 direction)
    {
        // could use 2D collision instead
        const double leftWall = 7.4;
        const double rightWall = -7.4;
        const double topWall = 3.44;
        const double bottomWall = -3.44;
        return direction.y > topWall || direction.y < bottomWall || direction.x < rightWall || direction.x > leftWall;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        logicManager.SpawnRingo();
    }
}
