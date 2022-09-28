using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    [Header("Laser setining")]
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _laserSpeed = 10f;
    [SerializeField] float _laserLiveTime = 5f;
    [SerializeField] float _baseRateOfFire = 0.2f;
    private AudioPlayer _audioPlayer;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float _rateOfFireVariant = 0f;
    [SerializeField] float _minFireRateEnemy = 1f;

    Coroutine fireCoroutine;

    public bool isFireing;

    void Start()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        if (useAI == true)
        {
            isFireing = true;
        }
    }

    void Update()
    {
        Fire();   
    }

    private void Fire()
    {
        if (isFireing && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFireing && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
        
    }

    private float RandomEnemiyFireRate()
    {
        float randomAiFireRate = Random.Range(_baseRateOfFire - _rateOfFireVariant, _baseRateOfFire + _rateOfFireVariant);

        return Mathf.Clamp(randomAiFireRate, _minFireRateEnemy, float.MaxValue);
    }

    private IEnumerator FireContinously()
    { 
        while(true)
        {
            GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            _audioPlayer.PlayPlayerShootingClip();
            Rigidbody2D rb;
            rb = laser.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * _laserSpeed;
            }

            Destroy(laser, _laserLiveTime);
            if (!useAI)
            {
                yield return new WaitForSeconds(_baseRateOfFire);
            }
            else
            {
                yield return new WaitForSeconds(RandomEnemiyFireRate());
            }
            
        }
    }
}
