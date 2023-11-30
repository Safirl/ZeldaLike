/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes) and MMI Teaching (IUT Bordeaux Montaigne)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {
	private Vector3 offset = new Vector3(0f, 0f, -10f);
	private float smoothTime = 0.25f;
	private Vector3 velocity = Vector3.zero;

	[SerializeField] private Transform target;

void Update()
	{
		Vector3 targetPosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}



}
 //   public GameObject m_objectToFollow;
	
	//// At each frame, the camera position is set to the "objetToFollow" x and y coordinates
 //   // (z remains the one of the camera, to respect the depth)
	//void Update () {
 //       if (m_objectToFollow != null)
 //       {
 //           this.transform.position = new Vector3(m_objectToFollow.transform.position.x,
 //                                                 m_objectToFollow.transform.position.y,
 //                                                 this.transform.position.z);
 //       }
	//}