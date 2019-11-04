﻿

using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

	private static Game singleton;
	[SerializeField]
	RobotSpawn[] spawns;
	public int enemiesLeft;
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;

    // 1
    void Start()
	{
		singleton = this;
		SpawnRobots();
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
    }

	// 2
	private void SpawnRobots()
	{
		foreach (RobotSpawn spawn in spawns)
		{
			spawn.SpawnRobot();
			enemiesLeft++;
		}
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);
            // Spawn next wave and restart count down
            if (waveCountdown == 0)
            {
                SpawnRobots();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        // Give player bonus for clearing the wave before timer is done
        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }

    public static void RemoveEnemy()
    {

        // Update is called once per frame
        void Update()
        {

        }
    }
}
