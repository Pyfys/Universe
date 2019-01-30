using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGravity : MonoBehaviour {

    public const float gravitationalConstant = 50f;
    public Vector3 velocity;
    public float mass = 1f;

    public Transform sunTransform;
    //public Transform projectionPlane;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // gravity
        if (sunTransform)
        {
            float distanceFromSun = (this.transform.position - sunTransform.position).magnitude;
            float forceMagnitude = (gravitationalConstant * mass) / (distanceFromSun * distanceFromSun);

            Vector3 directionTowardsTheSun = (sunTransform.position - transform.position).normalized;
            Vector3 acceleration = directionTowardsTheSun * forceMagnitude / mass;

            velocity += acceleration * Time.deltaTime;
        }
        transform.position += velocity * Time.deltaTime;

        // line
        //var lineRenderer = GetComponent<LineRenderer>();
        // draw to floor
        //lineRenderer.SetPosition(0, this.transform.position);
        // draw to sun
    }
    /*
        public GameObject sphere;
        public GameObject sun;
        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {
            Vector3 difference = sun.transform.position - sphere.transform.position;
            float dist = difference.magnitude;
            Vector3 gravityDirection = difference.normalized;
            float gravity = 6.7f * (sun.transform.localScale.x * sphere.transform.localScale.x * 20)/dist * dist;
            Vector3 gravityVector = (gravityDirection * gravity);
            sphere.transform.GetComponent<Rigidbody>().AddForce(sphere.transform.forward, ForceMode.Acceleration);
            sphere.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
        }
        */
}
