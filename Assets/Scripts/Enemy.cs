using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Use this for initialization
    int speed = 5;
    bool isNot = false;
    Vector3 destination;
    Vector3 start;
    float x;
    float y;
    void Start()
    {
        destination = new Vector3(0, 0, transform.position.z);
        start = transform.position;
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        x = width / 2;
        y = height / 2;
        float rotation = HelperUtils.AngleBetweenVector2(start,destination);
        transform.Rotate(0,0,rotation);
    }

    void checkCenter()
    {

        if (gameObject != null)
        {
            if (transform.position.x < x && transform.position.x > -x
    			&& transform.position.y > -y && transform.position.y < y)
            {
                isNot = true;
            }
            if (transform.position.x == 0 && transform.position.y == 0)
            {
                Destroy(gameObject);
            }
            if (transform.position.x > x || transform.position.x < -x)
            {
                if (isNot)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        //Debug.Log(destination);
        checkCenter();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Vector3 dectectPoint = transform.position;
            float y3 =y+1,x3=x+1;
            if((int) dectectPoint.y==0){

                 y3=0;
                 x3=start.x;
            }
            else
            if((int) dectectPoint.y<0){
                y3=y-1;
                x3= -(dectectPoint.x -start.x)*(dectectPoint.y-y)/(y3-dectectPoint.y) + dectectPoint.x;
            }
            else
            if((int) dectectPoint.y>0){
                y3=y+1;
                x3=-(dectectPoint.x -start.x)*(dectectPoint.y-y)/(y3-dectectPoint.y) + dectectPoint.x;
            }
            destination = new Vector3(x3,y3,destination.z);
            float rot = HelperUtils.AngleBetweenVector2(destination,dectectPoint);
            transform.Rotate(0,0,rot);
            if(destination.x > 0 ){
                transform.Rotate(0,0,180+rot);
            }
        }
    }
}
