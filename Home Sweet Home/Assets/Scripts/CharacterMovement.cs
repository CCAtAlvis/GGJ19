using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    
    public float speed = 0.5f;
    public float speedRotation = 2f;
    
	Animator ab;
    private Rigidbody rb;



    void Start()
    {
		ab = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		float moveVertical = Input.GetAxis ("Vertical");
			if ( moveVertical< 0)
			moveVertical = 0;
		
		Vector3 movement = new Vector3(0, 0.0f, moveVertical);
        
        transform.Translate(movement * speed * Time.deltaTime);

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
        }

		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
			ab.SetInteger ("mov", 1);
        }
		else
			ab.SetInteger ("mov", 0);
    }
}