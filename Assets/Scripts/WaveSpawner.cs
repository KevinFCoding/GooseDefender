using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    private float _countdown = 2f;

    [SerializeField] private Text _waveCountdownText;

    private int _waveIndex = 1;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

        //_waveCountdownText.text = Mathf.Round(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        _waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
