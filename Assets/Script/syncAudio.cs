using UnityEngine;
using System.Collections;

public class AudioSync : MonoBehaviour
{
	//set these in the inspector!
	public AudioSource main;
	public AudioSource sub;

	void Update()
	{
		sub.timeSamples = main.timeSamples;
	}
}