using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Reproducer : MonoBehaviour
{
    [SerializeField] private AudioClip _awake;
    [SerializeField] private AudioClip _hurt;
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioClip _attack;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySoundAwake()
    {
        _source.PlayOneShot(_awake);
    }

    public void PlaySoundHurt()
    {
        _source.PlayOneShot(_hurt);        
    }

    public void PlaySoundDie()
    {
        _source.PlayOneShot(_die);
    }

    public void PlaySoundAttack()
    {
        _source.PlayOneShot(_attack);
    }
}
