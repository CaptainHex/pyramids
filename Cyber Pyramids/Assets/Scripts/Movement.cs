using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    RaycastHit hit;
    public GameObject selected;
    public GameObject placeHolder;
    private Vector3 pos;
    private bool yesMove = false;
    private float dist = 0;
    private Vector3 clickPostition;
    private Plane[] planes = new Plane[6];
    private Plane plane;
    // Use this for initialization
    void Start ()
    {
        plane = new Plane(Vector3.up, new Vector3(0, .75f, 0));
        /*
        planes[0] = new Plane(Vector3.up, new Vector3(0, .75f, 0));
        planes[1] = new Plane(Vector3.up, new Vector3(0, 1.25f, 0));
        planes[2] = new Plane(Vector3.up, new Vector3(0, 1.75f, 0));
        planes[3] = new Plane(Vector3.up, new Vector3(0, 2.25f, 0));
        planes[4] = new Plane(Vector3.up, new Vector3(0, 2.75f, 0));
        planes[5] = new Plane(Vector3.up, new Vector3(0, 3.25f, 0));
        */
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Piece")
            {
                selected = hit.transform.gameObject;
                yesMove = true;
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            yesMove = false;
            selected.transform.position = new Vector3(Mathf.Round(selected.transform.position.x), selected.transform.position.y - .25f, Mathf.Round(selected.transform.position.z));
            selected = placeHolder;
        }
        
        if (yesMove)
        {
            Move();
        }
        
	}

    void Move()
    {
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distanceToPlane;

        if (plane.Raycast (ray, out distanceToPlane))
        {
            clickPostition = ray.GetPoint(distanceToPlane);
            if (clickPostition.x >= -4.5f && clickPostition.z >= -4.5f && clickPostition.x <= 4.5f && clickPostition.z <= 4.5f)
            {
                plane = new Plane(Vector3.up, new Vector3(0, 1.25f, 0));

                if (clickPostition.x >= -3.5f && clickPostition.z >= -3.5f && clickPostition.x <= 3.5f && clickPostition.z <= 3.5f)
                {
                    plane = new Plane(Vector3.up, new Vector3(0, 1.75f, 0));

                    if (clickPostition.x >= -2.5f && clickPostition.z >= -2.5f && clickPostition.x <= 2.5f && clickPostition.z <= 2.5f)
                    {
                        plane = new Plane(Vector3.up, new Vector3(0, 2.25f, 0));

                        if (clickPostition.x >= -1.5f && clickPostition.z >= -1.5f && clickPostition.x <= 1.5f && clickPostition.z <= 1.5f)
                        {
                            plane = new Plane(Vector3.up, new Vector3(0, 2.75f, 0));

                            if (clickPostition.x >= -.5f && clickPostition.z >= -.5f && clickPostition.x <= .5f && clickPostition.z <= .5f)
                            {
                                plane = new Plane(Vector3.up, new Vector3(0, 3.25f, 0));

                            }
                            else
                            {
                                plane = new Plane(Vector3.up, new Vector3(0, 2.75f, 0));
                            }

                        }
                        else
                        {
                            plane = new Plane(Vector3.up, new Vector3(0, 2.25f, 0));
                        }

                    }
                    else
                    {
                        plane = new Plane(Vector3.up, new Vector3(0, 1.75f, 0));
                    }

                }
                else
                {
                    plane = new Plane(Vector3.up, new Vector3(0, 1.25f, 0));
                }
            }
            else
            {
                plane = new Plane(Vector3.up, new Vector3(0, .75f, 0));
            }
        }
        selected.transform.position = clickPostition;
    }

}
