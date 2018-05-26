using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperUtils : MonoBehaviour
{

    static public float AngleBetweenVector2(Vector3 vec1, Vector3 vec2)
    {
        Vector2 vec2_1 = new Vector2(vec1.x, vec1.y);
        Vector2 vec2_2 = new Vector2(vec2.x, vec2.y);
        Vector2 diference = vec2_1 - vec2_2;
        float sign = (vec2_1.y < vec2_2.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}