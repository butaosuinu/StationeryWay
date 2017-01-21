using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    [SerializeField]
    private int playerNum;

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

    [SerializeField]
    GameObject arrow;

    Slider slider;
    bool slider_direction_right = true;
    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();

        /*active = true;
        //active = false;
        turnPhase = 0;
        powerTimer = 0;
        getDirection();*/
        SetPlayerActivate(playerNum == 0 ? true : false);
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
                    arrow.SetActive(false);
                }

                //Rotation with left/right button
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    newDirection += directionOffset;
                    //TO BE ADDED
                    //Texture.transform.rotaion = transform.rotaion * Quaternion.Euler(0, newDirection, 0);
                    transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    newDirection -= directionOffset;
                    //TO BE ADDED
                    transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
                }
            }

            else if (turnPhase == 1) //Wait for button release
            {
                if(slider_direction_right)
                {
                    slider.value += 1.0f / 60.0f;
                    if(slider.value >= 1.0f)
                    {
                        slider_direction_right = false;
                        slider.value = 1.0f;
                    }
                }
                else
                {
                    slider.value -= 1.0f / 60.0f;
                    if (slider.value <= 0.0f)
                    {
                        slider_direction_right = true;
                        slider.value = 0.0f;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    turnPhase++;
                }
                /*powerTimer++;
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    speed = maxSpeed * (Mathf.Sin( (Mathf.Deg2Rad*powerTimer) % Mathf.PI) ); //movement speed

                    if (speed > 0)
                        turnPhase++;
                    else
                        turnPhase--;
                }*/
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
                Vector3 forward = transform.forward;
                float power = slider.value;

                //newDirection = newDirection * Mathf.Deg2Rad;
                //rigid.AddForce(speed * new Vector3(Mathf.Cos(newDirection), 0, Mathf.Sin(newDirection))) ;
                rigid.AddForce(forward * power * 1000.0f);
                //rigid.AddForce(Vector3.up * 100.0f);
                manager.PlayerShoot();

                turnPhase++;
            }
            else if(turnPhase == 3) //End turn
            {
                //togglePlayerActivate(false);
            }
        }

        CheckGameEnd();
	}

    void CheckGameEnd()
    {
        if(transform.position.y <= -5.0f)
        {
            manager.GameEnd(playerNum);
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

    public bool IsRigidbodyVelocityZero()
    {
        if(rigid.velocity.magnitude < 0.01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetPlayerActivate(bool activate)
    {
        if (activate)
        {
            active = activate;
            turnPhase = 0;
            getDirection();
            arrow.SetActive(true);
        }
        else
        {
            active = activate;
            turnPhase = 0;
            getDirection();
            arrow.SetActive(false);
        }
    }
}
