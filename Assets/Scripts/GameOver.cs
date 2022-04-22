using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _victory;

    private AudioSource _source;
    private float _timeBetweenCheck = 2f;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.DeadPlayer += PlaySoundLose;
        _spawner.AllWaveComplite += StartCheckCountEnemy;
    }

    private void OnDisable()
    {
        _player.DeadPlayer -= PlaySoundLose;
        _spawner.AllWaveComplite -= StartCheckCountEnemy;
    }

    private void StartCheckCountEnemy()
    {
        StartCoroutine(CheckCountEnemy(_timeBetweenCheck));
    }

    private IEnumerator CheckCountEnemy(float timeBetweenCheck)
    {
        int lastElement = 1;
        var waitSeconds = new WaitForSeconds(timeBetweenCheck);

        while (_spawner.transform.childCount >= lastElement)
        {
            Debug.Log(_spawner.transform.childCount);
            yield return waitSeconds;
        }

        PlaySoundVictory();
    }

    private void PlaySoundLose()
    {
        _source.PlayOneShot(_lose);
    }

    private void PlaySoundVictory()
    {
        _source.PlayOneShot(_victory);
    }
}
