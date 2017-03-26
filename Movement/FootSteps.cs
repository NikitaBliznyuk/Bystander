using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {
	private AudioSource source;
	public AudioClip[] clips;
	public int clipNum = 0;
	private HeadBobbing headBobber;

	void Start () {
		headBobber = this.gameObject.GetComponent<HeadBobbing> ();
		source = this.gameObject.GetComponent<AudioSource> ();
		clips = this.gameObject.GetComponents<AudioClip> ();
	}

	void Update()
	{
		PlayFootStep (headBobber.midpoint);
	}

	public void PlayFootStep(float middlePos)
	{
		if (headBobber.curLocalPosition.y > middlePos) {
			clipNum = 0;
			source.clip = clips [clipNum];
			source.Play();
		} else if (headBobber.curLocalPosition.y  < middlePos){
			clipNum = 1;
			source.clip = clips [clipNum];
			source.Play();
		}
	}
}
