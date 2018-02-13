using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public float distanceToCenter;
    public float speed;
    public float friction;
    Vector3 center;
    float rotSpeedX = 0;
    float rotSpeedY = 0;
    float rotX = 0;
    float rotY = 0;

    // Use this for initialization
    void Start () {
        center = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))
        {
            rotSpeedX = -Input.GetAxis("Mouse X") * speed;
            rotSpeedY = -Input.GetAxis("Mouse Y") * speed;
        }
        else
        {
            rotSpeedX -= rotSpeedX * friction;
            rotSpeedY -= rotSpeedY * friction;
        }
        rotX += rotSpeedX * Time.deltaTime;
        rotY += rotSpeedY * Time.deltaTime;
        rotX %= 2.0f * Mathf.PI;
        rotY = Mathf.Min(Mathf.Max(rotY, -1), 1);
        Vector3 cameraloc = new Vector3(distanceToCenter * Mathf.Cos(rotX) * Mathf.Cos(rotY), distanceToCenter * Mathf.Sin(rotY), distanceToCenter * Mathf.Sin(rotX) * Mathf.Cos(rotY));
        transform.position = cameraloc + center;
        transform.LookAt(center);
	}
}
