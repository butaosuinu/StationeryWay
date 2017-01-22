using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFriction : MonoBehaviour {

    PhysicMaterial material;
    [SerializeField]
    float largeFriction, smallFriction;
    // Use this for initialization
    [SerializeField]
    GameObject largeIcon, smallIcon;
	void Start () {
        material = GetComponent<BoxCollider>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetFriction()
    {
        material.dynamicFriction = 0.6f;
        material.staticFriction = 0.6f;

        largeIcon.SetActive(false);
        smallIcon.SetActive(false);
    }

    public void SetLargeFriction()
    {
        material.dynamicFriction = largeFriction;
        material.staticFriction = largeFriction;

        largeIcon.SetActive(true);
        smallIcon.SetActive(false);
    }

    public void SetSmallFriction()
    {
        material.dynamicFriction = smallFriction;
        material.staticFriction = smallFriction;

        largeIcon.SetActive(false);
        smallIcon.SetActive(true);
    }
}
