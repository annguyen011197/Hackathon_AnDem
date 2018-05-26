using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLine : MonoBehaviour {

    int maxZone;
    int Zone;

    // Use this for initialization
    void Start () {
        Zone = maxZone = Mathf.FloorToInt(Config.SIZE_ZONE * 1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Zone < maxZone)
        {
            Zone += 1;
        }
        else if (Zone > maxZone)
        {
            Zone -= 1;
        }
        float scale = Zone / Config.SIZE_ZONE;
        transform.localScale = new Vector3(scale, scale, 1f);
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * 5f);
    }

    public void setZone(float length)
    {
        maxZone = Mathf.FloorToInt(length);
    }
}
