using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    public GameObject mainCamera;
    float invcosTheta1;
    public float speed = 50.0f;
    void Start()
    {
        Cursor.visible = false;
        if (mainCamera == null)
        {
            mainCamera = Camera.main.gameObject;
        }
    }
    void Walk(float units)
    {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        transform.position += forward * units;
    }

    void Strafe(float units)
    {
        transform.position += mainCamera.transform.right * units;

    }
    void Fly(float units)
    {
        transform.position += Vector3.up * units;
    }
    void Pitch(float angle)
    {
        float theshold = 0.95f;
        if ((angle > 0 && invcosTheta1 < -theshold) || (angle < 0 && invcosTheta1 > theshold))
        {
            return;
        }
        // A pitch is a rotation around the right vector
        Quaternion rot = Quaternion.AngleAxis(angle, transform.right);

        transform.rotation = rot * transform.rotation;
    }
    void Roll(float angle)
    {
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot * transform.rotation;
    }
    void Yaw(float angle)
    {
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = rot * transform.rotation;
    }
    private void Update()
    {
        
        float speed = this.speed;

        invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);


        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Fly(speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Fly(-speed * Time.deltaTime);
        }
        float contWalk = Input.GetAxis("Vertical");
        float contStrafe = Input.GetAxis("Horizontal");
        Walk(contWalk * speed * Time.deltaTime);
        Strafe(contStrafe * speed * Time.deltaTime);
    }

  


}
