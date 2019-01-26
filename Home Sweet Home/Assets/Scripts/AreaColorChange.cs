using UnityEngine;

public class AreaColorChange : MonoBehaviour {

    public Material[] mat1;
    public Material[] mat2;
    public GameObject[] players;
    bool ismat1 = true;

    private void OnTriggerEnter(Collider col)
    {
        if(ismat1)
            for (int i = 0; i < players.Length; i++)
            {
                mat1[i] = players[i].GetComponent<Renderer>().material;
                players[i].GetComponent<Renderer>().material = mat2[i];
                ismat1 = false;
           // gameObject.SetActive(false);
            }
        else
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponent<Renderer>().material = mat1[i];
                ismat1 = true;
                // gameObject.SetActive(false);
            }
    }

}
