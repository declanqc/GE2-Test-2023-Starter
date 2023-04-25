using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod : MonoBehaviour
{
    public BoidController boidController;
    

    public FPSController PlayerControls;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Boid;
    public GameObject Boid2;
    public GameObject Camholder;
    public bool InPod = false;

    public Vector3 OldCamPos;
    public Vector3 OldPlayerPos;




    public void Start()
    {
        OldCamPos = PlayerCamera.transform.position;
        OldPlayerPos = Player.transform.position;
    }


    IEnumerator Control()
    {
        Boid2.GetComponent<BoidController>().enabled = true;
        return null;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPSController>())
        {
            Control();
            Boid2.GetComponent<Boid>().enabled = false;
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
            

        }
        else
        {

        }
        if(Input.GetKeyDown("z") && InPod == true)
        {
            PlayerCamera.transform.position = OldCamPos;
            Player.transform.position = OldPlayerPos;

            InPod = false;
            Debug.Log("exited");
            Boid2.GetComponent<BoidController>().enabled = false;
            Boid2.GetComponent<Boid>().enabled = true;

        }


       

        
    }



}
