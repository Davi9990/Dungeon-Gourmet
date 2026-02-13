using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    public float currentLife = 100;
    public float TotalLife = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Morte();
    }

    public void Morte()
    {
        if(currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
