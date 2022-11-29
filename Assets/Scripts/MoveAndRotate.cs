using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{

    public GameObject targetObject;
    public GameObject fireObject;


    public Transform targetTransform;
    public Vector3 targetPosition;

    public bool flip;

    public float activationRange = 4;
    public float speedPerSecond = 1;
    public float spriteAngleCompensation = 0;

    public bool useActivationRange = false;


    void Start()
    {

        if (targetTransform == null)
        {
            targetTransform = GameObject.FindWithTag("Player").transform;
        }
    }


    void Update()
    {
        Vector3 scale = transform.localScale;

        if (fireObject.GetComponent<FireIntensity>().thisLight.intensity >= 0.8f)
        {
            //move toward target
            Vector3 directionVector = targetTransform.position - transform.position;

            //compute distance
            float distanceToTarget = Vector3.Distance(targetTransform.position, transform.position);
            float distanceToTarget2 = directionVector.magnitude;

            //normalize vector
            directionVector.Normalize();

            if (useActivationRange && distanceToTarget2 > activationRange)
            {
                return;
            }

            if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.position -= directionVector * speedPerSecond * Time.deltaTime;
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.position -= directionVector * speedPerSecond * Time.deltaTime;
            }

            transform.localScale = scale;

            transform.right = directionVector;
            transform.Rotate(new Vector3(0, 0, spriteAngleCompensation));
        }
        else
        {

            //move toward target
            Vector3 directionVector = targetTransform.position - transform.position;

            //compute distance
            float distanceToTarget = Vector3.Distance(targetTransform.position, transform.position);
            float distanceToTarget2 = directionVector.magnitude;

            //normalize vector
            directionVector.Normalize();

            if (useActivationRange && distanceToTarget2 > activationRange)
            {
                return;
            }

            if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.position += directionVector * speedPerSecond * Time.deltaTime;
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.position += directionVector * speedPerSecond * Time.deltaTime;
            }

            transform.localScale = scale;

            transform.right = directionVector;
            transform.Rotate(new Vector3(0, 0, spriteAngleCompensation));
        }


    }
}
