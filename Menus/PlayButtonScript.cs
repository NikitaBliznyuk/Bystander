using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour {

	public void RunScene()
	{
		SceneManager.LoadScene ("Beach test");
	}
}
