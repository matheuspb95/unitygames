﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float velocity;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                float dist = pos.x - transform.position.x;
                dist = (dist / 100) * velocity;
                transform.Translate(dist, 0, 0);
            }
            else
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float dist = pos.x - transform.position.x;
                dist = (dist / 100) * velocity;
                transform.Translate(dist, 0, 0);
            }
        }
    }
}
