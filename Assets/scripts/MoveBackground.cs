using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {



	public float speed;
	private float x;
	public float FinalDestination;
    public float OriginalDestionation;

    // Update is called once per frame
    void Update () {

        if (AnimationController.IsPaused){
            return;
        }
        x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= FinalDestination)
        {
			x = OriginalDestionation;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}


	}
}
