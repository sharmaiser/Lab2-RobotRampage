﻿

using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

	public int type;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.GetComponent<Player>() != null
			&& collider.gameObject.tag == "Player")
		{

			collider.gameObject.GetComponent<Player>().PickUpItem(type);
			GetComponentInParent<PickupSpawn>().PickupWasPickedUp();
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
