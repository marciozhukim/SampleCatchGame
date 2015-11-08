using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };

public class HatController : MonoBehaviour 
{
	public Camera cam;

	private float maxWitdh;
	private Rigidbody2D rb2d;
	private Renderer render;
	// Use this for initialization
	public float minSwipeLength = 200f;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	public static Swipe swipeDirection;

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
		DetectSwipe();
	}
	public void DetectSwipe ()
	{

		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			
			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			
			//normalize the 2d vector
			currentSwipe.Normalize();
			
			//swipe upwards
			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				Debug.Log("up swipe");
			}
			//swipe down
			if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				Debug.Log("down swipe");
			}
			//swipe left
			if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				Debug.Log("left swipe");
			}
			//swipe right
			if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				Debug.Log("right swipe");
			}
			Debug.DrawLine(new Vector3(firstPressPos.x, firstPressPos.y),new Vector3(secondPressPos.x,secondPressPos.y), Color.red, 0.0f, false);
			Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
			Debug.Log("Line Here");
		}
	}
}
