﻿using UnityEngine;
using System.Collections;

public class ChangeDirection : MonoBehaviour {
    public Vector2 Direction;
    public Vector3 NewSpawnPoint;
    public float Angle;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<AutoMovement>().ChangeDirection(Direction);
            coll.gameObject.GetComponent<AutoMovement>().ChangeAngle(Angle);
            coll.gameObject.GetComponent<Die>().SpawnPointCameraRelative = NewSpawnPoint;
            Camera.main.GetComponent<AutoMovement>().ChangeDirection(Direction);
            Camera.main.GetComponent<CameraLimits>().ChangeLimits();
            Camera.main.transform.position = transform.position - Vector3.forward * 10;
            Destroy(gameObject);
        }
    }
}
