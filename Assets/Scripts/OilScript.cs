using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilScript : MonoBehaviour {
    const int maxTrun = 3;
    int turn;
    int playerNum;
    float y_offset = 0.49f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.gameObject.GetComponent<PlayerScript>().playerNum != playerNum || turn != maxTrun)
        {
            other.gameObject.GetComponent<PlayerFriction>().SetSmallFriction();
        }
    }

    public void Init(Vector3 pos, int playerNum)
    {
        turn = maxTrun;
        transform.position = pos - new Vector3(0, y_offset, 0);
        this.playerNum = playerNum;
    }

    public void DecreaseTurn()
    {
        turn--;
        if(turn == 0)
        {
            Destroy(gameObject);
        }
    }
}
