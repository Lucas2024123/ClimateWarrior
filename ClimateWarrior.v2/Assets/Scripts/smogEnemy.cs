using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogEnemy : MonoBehaviour
{
    public float size;
    public float points;
    // Start is called before the first frame update
    void Start()
    {
        points = 5 - size / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
