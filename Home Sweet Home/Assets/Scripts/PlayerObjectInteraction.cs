using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour {
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.50f))
        {
           // print("Forward - distance: " + hit.distance);

            if (Vector3.Dot(hit.transform.forward, transform.forward) < 0)
            {
                Interactable obj = hit.collider.gameObject.GetComponent<Interactable>();
                if (obj.type.Equals("Obj"))
                {
                    if (Input.GetKey(KeyCode.E))
                        print("Give further stuff");
                }

                if (obj.type.Equals("NPC"))
                {
                    if (Input.GetKey(KeyCode.E))
                        print("NPC detected");
                }
            }
        }
    }
}
