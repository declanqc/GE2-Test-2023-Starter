using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{

    public FPSController PlayerControls;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Boid;
    public GameObject Boid2;
    public GameObject Camholder;
    public bool InPod = false;

    public Vector3 OldCamPos;




    public void Start()
    {
        OldCamPos = PlayerCamera.transform.position;
    }



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
            PlayerCamera.transform.position = Camholder.transform.position;
            
            PlayerCamera.transform.rotation = Boid.transform.rotation;
            Destroy(Player.GetComponent<FPSController>());
            Control();

        }
        else
        {

        }
        if(Input.GetKeyDown("z") && InPod == true)
        {
            PlayerCamera.transform.position = OldCamPos;
            InPod = false;
            Debug.Log("exited");
        }


        IEnumerator Control()
        {
            Boid2.AddComponent<BoidController>();
            return null;
        }

    }



}
