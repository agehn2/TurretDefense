using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    //public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public Text waveCountdownText;

    private int waveNumber = 1;

    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnWave());
            StartCoroutine(SpawnWave2());
            StartCoroutine(SpawnWave3());
            countdown = timeBetweenWaves;
            waveCountdownText.text = string.Format("{0:00.00,}", countdown);
            return;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            StartCoroutine(SpawnWave2());
            StartCoroutine(SpawnWave3());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00,}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];

        EnemiesAlive = wave.count + wave.count2 + wave.count3;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
    }

    IEnumerator SpawnWave2()
    {
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count2; i++)
        {
            SpawnEnemy2(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2);
        }
    }

    IEnumerator SpawnWave3()
    {
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count3; i++)
        {
            SpawnEnemy3(wave.enemy3);
            yield return new WaitForSeconds(1f / wave.rate3);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy2(GameObject enemy2)
    {
        Instantiate(enemy2, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy3(GameObject enemy3)
    {
        Instantiate(enemy3, spawnPoint.position, spawnPoint.rotation);
    }
}
