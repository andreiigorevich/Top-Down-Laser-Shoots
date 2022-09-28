using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShape : MonoBehaviour
{

    [SerializeField] private float _shakeDuration = 1f;
    [SerializeField] private float _magnitudeShake = 0.5f;

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapseTime = 0f;
        while(elapseTime < _shakeDuration)
        {
            transform.position = _startPosition + (Vector3)Random.insideUnitCircle * _magnitudeShake;
            elapseTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        transform.position = _startPosition;
    }

}
