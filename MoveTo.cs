using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public bool moveToTarget = false;
    public Transform target;
    public float speed = 2f;

    public bool moveToVector = false;
    public Vector3 vector;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveToTarget)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if(transform.position == target.transform.position)
            {
                moveToTarget = false;
            }
        }

        if (moveToVector)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, vector, step);

            if (transform.position == vector)
            {
                moveToVector = false;
            }
        }
    }

    public void MoveToTarget(GameObject _object)
    {
        target = _object.transform;

        moveToTarget = true;
        moveToVector = false;
    }

    public void MoveToTarget()
    {
        moveToTarget = true;
        moveToVector = false;
    }

    public void MoveToVector(Vector3 _vector)
    {
        vector = _vector;

        moveToVector = true;
        moveToTarget = false;
    }

    public void MoveToVector()
    {
        moveToVector = true;
        moveToTarget = false;
    }
}
