using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash: MonoBehaviour {

	void Awake() {

		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {

		Invoke ("Load", 2f);
	}

	void Load () {

		SceneManager.LoadScene (1);

	}

}
