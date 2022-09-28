using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip _playerShootClip;
    [SerializeField] [Range(0f, 1f)]float _playerShootingVolume = 0.5f;

    [Header("Explosion")]
    [SerializeField] AudioClip _explosionClip;
    [SerializeField] [Range(0f, 1f)] float _explosionVolume = 0.5f;

    [Header("Destroy")]
    [SerializeField] AudioClip _destroyClip;
    [SerializeField][Range(0f, 1f)] float _destroyVolume = 0.5f;

    static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();   
    }

    private void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayPlayerShootingClip()
    {
        PlayAudioClip(_playerShootClip, _playerShootingVolume);
    }

    public void PlayExplosionClip()
    {
        PlayAudioClip(_explosionClip, _explosionVolume);
    }

    public void PlayDestroyClip()
    {
        PlayAudioClip(_destroyClip, _destroyVolume);
    }

    private void PlayAudioClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
