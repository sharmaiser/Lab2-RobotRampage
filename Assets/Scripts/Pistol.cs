﻿

using UnityEngine;
using System.Collections;

public class Pistol : Gun
{
	override protected void Update()
	{
		base.Update();
		// Shotgun & Pistol have semi-auto fire rate
		if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
				> fireRate)
		{
			lastFireTime = Time.time;
			Fire();
		}
	}
}
