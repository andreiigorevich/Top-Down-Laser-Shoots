using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem _hitEffect;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private int _scoreToAdd = 100;

    private CameraShape _cameraShape;
    private AudioPlayer _audioFX;
    private ScoreKeepre _score;
    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _score = FindObjectOfType<ScoreKeepre>();
        _audioFX = FindObjectOfType<AudioPlayer>();
        _cameraShape = Camera.main.GetComponent<CameraShape>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            ShapeCamera();
            PlayHitEffect();
            _audioFX.PlayExplosionClip();
            TakeDamage(damageDealer.GetDamageAmount());
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!_isPlayer)
        {
            _score.AddScore(_scoreToAdd);
        }
        else
        {
            _levelManager.Invoke("LoadEndScreen", 1.5f);
        }
        _audioFX.PlayDestroyClip();
        Destroy(gameObject);
        

    }


    private void PlayHitEffect()
    {
        if(_hitEffect != null)
        {
            ParticleSystem instance = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShapeCamera()
    {
        if(_cameraShape != null && _isPlayer)
        {
            _cameraShape.Play();
        }
        
    }

    public int GetCurrentHealth()
    {
        return health;
    }
    
}
