using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{

    public FPSController PlayerControls;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Boid;
    public Vector3 Camholder = Vector3.zero;
    public bool InPod = false;



    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPSController>())
        {
            Debug.Log("entered");
            InPod = true;
        }
    }

    public void Update()
    {
        
        if(InPod == true)
        {
            Debug.Log("InPod");
            Player.transform.position = Boid.transform.position;
            Player.transform.rotation = Boid.transform.rotation;
            PlayerCamera.transform.position = Boid.transform.position;
            
            PlayerCamera.transform.rotation = Boid.transform.rotation;
            Camholder = PlayerCamera.transform.position;
            Camholder.y += 20f;

        }
    }



}
