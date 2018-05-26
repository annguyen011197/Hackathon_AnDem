using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :  MonoBehaviour {

    float timerCounter = 0;

    float Speed;
    float Radius;
    float Dir = 1;
    const float MAX_SPEED = 8;
    float RadiusMax;
    float lengthZone = 337;

    //Use this for initialization
    void Start()
    {
        //674
        transform.position = new Vector3(lengthZone, 0, 0f);
        Speed = 1;
        Radius = RadiusMax = 2;

    }

    //Update is called once per frame
    void Update()
    {
        updateSpeed();
        timerCounter += Time.deltaTime * Speed ;
        var oldPosition = transform.position;
        GameObject gameZone = GameObject.FindGameObjectWithTag("Zone");
        if (gameZone == null) return;
        float x = Mathf.Cos(timerCounter) * (gameZone.GetComponent<Renderer>().bounds.size.x / 2f);
        float y = Mathf.Sin(timerCounter) * (gameZone.GetComponent<Renderer>().bounds.size.y / 2f);
        var newPosition = transform.position;

        transform.position = new Vector3(x, y, 0f);
        //Debug.Log(transform.position);

       
        float angle = HelperUtils.AngleBetweenVector2(gameZone.transform.position, transform.position);
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        //transform.Rotate(0, 0, worldDegrees);
        //Draw circle

    }

    void updateSpeed()
    {
        //if(Radius < RadiusMax)
        //{
        //    Radius += 0.05f;
        //}
        //else if (Radius > RadiusMax)
        //{
        //    Radius -= 0.05f;
        //}
        //Radius = NumberUlti.Round(Radius, 2);
       
        float acceleration;
        if (ApplicationUtil.platform == RuntimePlatform.Android)
        {
            //acceleration = Input.acceleration.x;
            acceleration = 0.1f;
        }
        else
        {
            acceleration = 1.5f;
        }

        Speed = MAX_SPEED * acceleration * -1;
        //Debug.Log("Speed: " + Speed.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        //Debug.Log("Detect OnCollisionEnter2D");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        //Debug.Log("Detect OnCollisionEnter");
    }

    public void updateRadius(float newRadius)
    {
        RadiusMax = newRadius;
    }
}
