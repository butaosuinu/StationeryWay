using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    [SerializeField]
    public int playerNum { get; private set; }

    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float directionOffset;

    private bool active;
    private int turnPhase;
    

    private float newDirection;

    private int powerTimer;
    private float speed;
    
    Rigidbody rigid;
    GameManagerScript manager;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        active = false;
        turnPhase = 0;
        powerTimer = 0;
        getDirection();
    }
	
	// Update is called once per frame
	void Update () {
		if(active)
        {
            //Can rotate or press flick button
            if(turnPhase == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    powerTimer = 0;
                    turnPhase++;
                }

                //Rotation with left/right button
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    newDirection += directionOffset;
                    //TO BE ADDED
                    //Texture.transform.rotaion = transform.rotaion * Quaternion.Euler(0, newDirection, 0);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    newDirection -= directionOffset;
                    //TO BE ADDED
                }
            }

            else if (turnPhase == 1) //Wait for button release
            {
                powerTimer++;
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    speed = maxSpeed * (Mathf.Sin( (Mathf.Deg2Rad*powerTimer) % Mathf.PI) ); //movement speed

                    if (speed > 0)
                        turnPhase++;
                    else
                        turnPhase--;
                }
            }
            else if(turnPhase == 2) //Move
            {
                /*speed = Mathf.Max(0, speed - friction);
                if (speed == 0)*/

                /*transform.position.Set(
                    speed * Mathf.Cos(Mathf.Deg2Rad * newDirection),
                    speed * Mathf.Sin(Mathf.Deg2Rad * newDirection),
                    player.transform.position.z);
             */

                newDirection = newDirection * Mathf.Deg2Rad;
                rigid.AddForce(speed * new Vector3(Mathf.Cos(newDirection), 0, Mathf.Sin(newDirection))) ;
                manager.PlayerShoot();

                turnPhase++;
            }
            else if(turnPhase == 3) //End turn
            {
                //togglePlayerActivate(false);
            }
        }
	}

    public virtual void togglePlayerActivate(bool activate)
    {
        active = activate;
        turnPhase = 0;
        getDirection();
    }

    private void getDirection()
    {
        //currentDirection = Vector3.Angle(new Vector3(1, 0, 0), transform.rotation * new Vector3(0, 0, 1));
        //newDirection = currentDirection;
        newDirection = 0;//transform.rotation.eulerAngles.y;//transform.forward;
        //transform.rotation.SetEulerAngles(new Vector3(0, 0, 0));
    }

    bool IsRigidbodyVelocity()
    {
        return true;
    }
}
