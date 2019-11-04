﻿

using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

	private static Game singleton;
	[SerializeField]
	RobotSpawn[] spawns;
	public int enemiesLeft;

	// 1
	void Start()
	{
		singleton = this;
		SpawnRobots();
	}

	// 2
	private void SpawnRobots()
	{
		foreach (RobotSpawn spawn in spawns)
		{
			spawn.SpawnRobot();
			enemiesLeft++;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
