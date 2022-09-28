using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 _moveSpeed;

    private Vector2 _offset;
    private Material _matirial;

    private void Awake()
    {
        _matirial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offset = _moveSpeed * Time.deltaTime;
        _matirial.mainTextureOffset += _offset;
    }
}
