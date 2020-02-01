using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MaxSpeed = 1;
    public float RollAccel = 1.0f;
    public float HaltRate = 0.5f;
    public float HaltFactor = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Rigidbody ourBody = GetComponent<Rigidbody>();
        if (Input.GetAxis("Halt") != 0.0f)
        {
            Vector3 facing = ourBody.angularVelocity.normalized;

            Vector3 delta = ((-facing) * HaltRate + ((-facing) * ourBody.angularVelocity.sqrMagnitude * HaltFactor)) * Time.fixedDeltaTime;
            if (ourBody.angularVelocity.sqrMagnitude < delta.sqrMagnitude)
            {
                delta = -ourBody.angularVelocity;
            }
            ourBody.angularVelocity += delta;
        }
        else
        {
            if (Input.GetAxis("Roll") != 0.0f)
            {
                ourBody.angularVelocity += ourBody.transform.forward * (-Input.GetAxis("Roll") * Time.fixedDeltaTime) * RollAccel;
            }
            if (Input.GetAxis("Pitch") != 0.0f)
            {
                ourBody.angularVelocity += ourBody.transform.right * (Input.GetAxis("Pitch") * Time.fixedDeltaTime) * RollAccel;
            }
            if (Input.GetAxis("Yaw") != 0.0f)
            {
                ourBody.angularVelocity += ourBody.transform.up * (Input.GetAxis("Yaw") * Time.fixedDeltaTime) * RollAccel;
            }
        }
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        bool vert = Input.GetAxis("Vertical") != 0.0f;
        bool hori = Input.GetAxis("Horizontal") != 0.0f;
        bool up = Input.GetAxis("Boost") != 0.0f;

        if (vert)
        {
            //Adding velocity
            movement += ourBody.transform.forward * (Input.GetAxis("Vertical"));
        }
        if (hori)
        {
            //Adding velocity
            movement += ourBody.transform.right * Input.GetAxis("Horizontal");
        }
        if (up)
        {
            movement += ourBody.transform.up * Input.GetAxis("Boost");
        }
        if (movement.sqrMagnitude != 0.0f)
        {
            movement = movement * Time.fixedDeltaTime * MaxSpeed;
            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }
            if (ourBody.velocity.magnitude > movement.magnitude)
            {
                movement -= (ourBody.velocity.normalized * (movement.magnitude / 4));
            }
            ourBody.velocity += movement;
        }
    }


}
