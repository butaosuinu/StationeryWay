﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScriptImplementation : GameManagerScript
{
    bool playerOneTurn = true;
    PlayerScript player0, player1;
    bool calculateVerocity = false;

    bool gameEnd = false;
	// Use this for initialization
	void Start () {
        player0 = GameObject.Find("Player0").GetComponent<PlayerScript>();
        player1 = GameObject.Find("Player1").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update () {
		if(calculateVerocity)
        {
            if(DummyVerocityZero())
            {
                playerOneTurn = !playerOneTurn;
                SetTurn();
                calculateVerocity = false;
            }
        }

        //MoveGround();
	}

    bool movedown = true;
    void MoveGround()
    {
        if(movedown)
        {
            GameObject.Find("Ground").transform.position = GameObject.Find("Ground").transform.position - new Vector3(0, 1.0f, 0);
            if(GameObject.Find("Ground").transform.position.y < -1.0f)
            {
                movedown = false;
            }
        }
        else
        {
            GameObject.Find("Ground").transform.position = GameObject.Find("Ground").transform.position + new Vector3(0, 1.0f, 0);
            if (GameObject.Find("Ground").transform.position.y > 1.0f)
            {
                movedown = true;
            }
        }
    }

    void SetTurn()
    {
        if (playerOneTurn)
        {
            player0.SetPlayerActivate(true);
            player1.SetPlayerActivate(false);
        }
        else
        {
            player0.SetPlayerActivate(false);
            player1.SetPlayerActivate(true);
        }

    }

    bool DummyVerocityZero()
    {
        return player0.IsRigidbodyVelocityZero() && player1.IsRigidbodyVelocityZero();
    }

    public override void PlayerShoot()
    {
        calculateVerocity = true;
    }

    public override void GameEnd(int playerNum)
    {
        if(!gameEnd)
        {
            gameEnd = true;

            if(playerNum == 0)
            {
                //Debug.Log("2PWon");
                GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "2PWon";
            }
            else
            {
                //Debug.Log("1PWon");
                GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "1PWon";
            }
        }
    }
}
