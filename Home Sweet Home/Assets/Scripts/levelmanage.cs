using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanage : MonoBehaviour {
	
	// Use this for initialization

	public static bool res=true;

	public void StartGame () {
		SceneManager.LoadScene (1);
	}
}
