using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneLine : MonoBehaviour
{

    int maxZone;
    int Zone;
    // Use this for initialization
    void Start()
    {
        Zone = maxZone = Mathf.FloorToInt(Config.SIZE_ZONE * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void setZone(float zone)
    {
        maxZone = Mathf.FloorToInt(zone);
    }
}
