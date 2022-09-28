using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float paddindgLeft;
    [SerializeField] private float paddindgright;
    [SerializeField] private float paddindgTop;
    [SerializeField] private float paddindgDown;

    Shotter _sooter;
    private Vector2 _rawInput;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    private void Awake()
    {
        _sooter = GetComponent<Shotter>();
    }

    private void Start()
    {
        InitBounds();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 delta = _rawInput * Time.deltaTime * _speed;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + paddindgLeft, _maxBounds.x - paddindgright);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + paddindgDown, _maxBounds.y - paddindgTop);
        transform.position = newPosition;
    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (_sooter != null) 
        {
            _sooter.isFireing = value.isPressed;
        }
    }    

}
