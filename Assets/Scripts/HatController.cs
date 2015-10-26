using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour 
{
	public Camera cam;

	private float maxWitdh;
	private Rigidbody2D rb2d;
	private Renderer render;
	// Use this for initialization
	void Start () 
	{
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWitdh = cam.ScreenToWorldPoint (upperCorner);
		render = GetComponent<Renderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		float hatWidth = render.bounds.extents.x;
		maxWitdh = targetWitdh.x - hatWidth;
	}
	
	
	// Update is called once per physics timestep
	void FixedUpdate () 
	{
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);

		float targetWitdh = Mathf.Clamp (targetPosition.x, -maxWitdh, maxWitdh);
		targetPosition = new Vector3 (targetWitdh, targetPosition.y, targetPosition.z);

		rb2d.MovePosition (targetPosition );
	}
}
