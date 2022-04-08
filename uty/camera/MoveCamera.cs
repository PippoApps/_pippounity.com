using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	//
	// VARIABLES
	//

	public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;       // Speed of the camera when being panned
	public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

	private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
	private bool isPanning;     // Is the camera being panned?
	private bool isRotating;    // Is the camera being rotated?
	private bool isZooming;     // Is the camera zooming?

	//
	// UPDATE
	//
	public float keysWalkSpeed = 0.1f;
	public void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = new Vector3(transform.position.x + keysWalkSpeed, transform.position.y, transform.position.z);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position = new Vector3(transform.position.x - keysWalkSpeed, transform.position.y, transform.position.z);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - keysWalkSpeed);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + keysWalkSpeed);
		}
	}

void Update()
	{



		// Get the left mouse button
		if (Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
			Debug.Log("Mouse 0");
		}

		// Get the right mouse button
		if (Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
			Debug.Log("Mouse 1");
		}

		// Get the middle mouse button
		if (Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
			Debug.Log("Mouse 2");
		}

		// Disable movements on button release
		if (!Input.GetMouseButton(0)) isRotating = false;
		if (!Input.GetMouseButton(1)) isPanning = false;
		if (!Input.GetMouseButton(2)) isZooming = false;

		// Rotate camera along X and Y axis
		if (isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
		}

		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}

		// Move the camera linearly along Z axis
		if (isZooming)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

			Vector3 move = pos.y * zoomSpeed * transform.forward;
			transform.Translate(move, Space.World);
		}
	}
}