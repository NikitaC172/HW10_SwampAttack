using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _wave;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private bool _lastWave = false;

    public event UnityAction AllEnemySpawned;
    public event UnityAction AllWaveComplite;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantietEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            if (_lastWave == true && _spawned == _currentWave.Count)
            {
                AllWaveComplite?.Invoke();
            }
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_wave.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantietEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _wave[index];
        EnemyCountChanged(0, 1);

        if (_currentWaveNumber == _wave.Count - 1)
        {
            _lastWave = true;
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _player.AddMoney(enemy.Reward);
    }
}


[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}