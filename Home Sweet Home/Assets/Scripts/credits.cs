using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {
	public float delay =0;
	public string NewLevel="MenuLevel";
	// Use this for initialization
	void Start () {
		Invoke ("caller", 10f);
	}
	public void caller(){
		SceneManager.LoadScene (NewLevel);

	}

	// Update is called once per frame

}
