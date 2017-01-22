using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour {
    public bool powerup_on { get; private set; }
    [SerializeField]
    GameObject powerupIcon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PowerUpOn()
    {
        powerup_on = true;
        powerupIcon.SetActive(true);
    }

    public void ResetPowerUpFlag()
    {
        powerup_on = false;
        powerupIcon.SetActive(false);
    }
}
