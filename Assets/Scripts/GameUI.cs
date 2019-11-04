﻿

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	[SerializeField]
	Sprite redReticle;
	[SerializeField]
	Sprite yellowReticle;
	[SerializeField]
	Sprite blueReticle;
	[SerializeField]
	Image reticle;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;

    public void UpdateReticle()
	{
		switch (GunEquipper.activeWeaponType)
		{
			case Constants.Pistol:
				reticle.sprite = redReticle;
				break;
			case Constants.Shotgun:
				reticle.sprite = yellowReticle;
				break;
			case Constants.AssaultRifle:
				reticle.sprite = blueReticle;
				break;
			default:
				return;
		}
	}

	// Use this for initialization
	void Start()
	{
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }

    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }

    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    // 2
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }
    // 3
    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        // Restart the Coroutine so it doesn’t end early
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }
    // 4
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }
    // 5
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
    // Update is called once per frame
    void Update()
	{

	}
}
