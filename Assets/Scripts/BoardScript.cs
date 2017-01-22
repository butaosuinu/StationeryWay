using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

    private float cycle;
    [SerializeField]
    public int delay;
	// Use this for initialization
	void Start () {
        cycle = Mathf.PI / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0)
        {
            cycle += Mathf.PI / 90;
            transform.position = new Vector3(transform.position.x, transform.position.y + (float)(0.1 * Mathf.Sin(cycle)), transform.position.z);
        }
        else
            delay--;
	}
}
