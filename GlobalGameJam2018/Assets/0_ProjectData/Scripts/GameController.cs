using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
List<string> lettere = new List<string>(5);
public int minDelay;
public int maxDelay;
 Random random = new Random();
	void Start () {
		lettere.Add("QWASZ");
		lettere.Add("ERDXC");
		lettere.Add("TYFGV");
		lettere.Add("UHJBN");
		lettere.Add("IOPKLM");


		
		
		
	}
	
	// Update is called once per frame
	void Update () {
   
		int randomSection = (int)Random.Range(0F, 5F);
		int randomChar = (int)Random.Range(0f,5f);
		
	}


}
