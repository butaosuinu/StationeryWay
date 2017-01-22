using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOilDrop : MonoBehaviour {
    public bool oildrop_on { get; private set; }
    [SerializeField]
    GameObject oildropIcon;

    bool move_start = false;
    Rigidbody rigid;

    Vector3 startPos;

    [SerializeField]
    float oil_span;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(oildrop_on && !move_start && rigid.velocity.magnitude >= 0.01f)
        {
            move_start = true;

            startPos = transform.position;
        }

        if(move_start)
        {
            DropOil();

            if(rigid.velocity.magnitude < 0.01f)
            {
                move_start = false;
                oildrop_on = false;

                oildropIcon.SetActive(false);
            }
        }
	}

    public void OilDropOn()
    {
        oildrop_on = true;
        oildropIcon.SetActive(true);
    }

    void DropOil()
    {
        if(Vector3.Distance(transform.position, startPos) >= oil_span)
        {
            //Debug.Log("oil");
            GameObject obj = (GameObject)Instantiate(Resources.Load("Oil"), GameObject.Find("Oils").transform);
            obj.GetComponent<OilScript>().Init(transform.position, GetComponent<PlayerScript>().playerNum);

            startPos = transform.position;
        }
    }
}
