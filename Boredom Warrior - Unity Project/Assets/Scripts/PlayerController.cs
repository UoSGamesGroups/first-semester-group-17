using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float groundCheckRadius;
	public Transform groundCheck; 
	public LayerMask whatIsGround; 
	private bool grounded; 
	private bool doubleJump; 
	private float moveVelocity; 
	public Transform firePoint;
	public GameObject sword;

	// Use this for initialization
	void Start () {
	}
		
	// Update is called once per frame
	void Update () {
	
// Movement -----------------------------------------------------------------------------------------------------------------

		// Jumping

		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}
	
		// Double Jump

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) 
		
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			doubleJump = true; 
		}

		if (grounded)
			doubleJump = false;

		// Horizontal Movement

		moveVelocity = 0f; 
	

		if (Input.GetKey (KeyCode.D)) 
		{
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			moveVelocity = -moveSpeed; 
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

// Shooting -----------------------------------------------------------------------------------------------------------

		if(Input.GetKeyDown(KeyCode.E))
			{
				Instantiate(sword, firePoint.position, firePoint.rotation);
			}


	}


	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround); 
			
			

		

	}


}
