using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boid;




    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("entered");
        }
    }

    public void Update()
    {
        
    }



}
