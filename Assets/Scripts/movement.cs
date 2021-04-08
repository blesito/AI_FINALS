using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;

   

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
           
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //for movement
                agent.SetDestination(hit.point);

                //rotation of player
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));
                transform.eulerAngles = new Vector3(0,rotationY,0);

            }
        }
    }
}
