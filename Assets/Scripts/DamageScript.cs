using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
	RaycastHit hit;
	private int hitRange = 2;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Jump"))	//on button input for jump which is spacebar
		{
			
			Vector3 forward = transform.TransformDirection(Vector3.forward);	//same variables as the AI
			Vector3 origin = transform.position;

			if (Physics.Raycast(origin, forward, out hit, hitRange) && hit.collider.gameObject.tag == "Enemy")		//if the raycast hits an object with the tag enemy
			{ 
				{
					UnityEngine.Debug.Log("Damage");
					Destroy(hit.collider.gameObject);			//destroy the object that the raycast collided with
				}
			}
		}
	}

}
