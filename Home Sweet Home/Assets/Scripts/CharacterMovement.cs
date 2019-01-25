using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    
    public float speed = 10f;
    public float speedRotation = 4f;
    
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

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
        }

		if(Input.GetKey(KeyCode.W))
        {
			ab.SetInteger ("mov", 1);
			print ("m here");
        }
		else
			ab.SetInteger ("mov", 0);
    }
}