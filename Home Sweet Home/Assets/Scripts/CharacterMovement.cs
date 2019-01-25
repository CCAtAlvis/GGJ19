using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 10f;
	Animator ab;
    private Rigidbody rb;

	public Animation CharAnim;

    void Start()
    {
		ab = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        transform.Translate(movement * speed * Time.deltaTime);

		if(Input.GetKey(KeyCode.W))
        {
			ab.SetInteger ("mov", 1);
			print ("m here");
        }
		else
			ab.SetInteger ("mov", 0);
    }
}