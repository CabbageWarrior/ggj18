using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
List<string> lettere = new List<string>(5);
public int minDelay;

public int maxDelay;
 Random random = new Random();
 int i=0;
 public int timer_cont ;
 public GameObject nota; 
 string lettera;
 public GameObject[] spawnPoints;
 GameObject new_instance;
 Vector3 offset;
	void Start () {
		offset= new Vector3(0F,0F,0F);
		lettere.Add("QWASZ");
		lettere.Add("ERDXC");
		lettere.Add("TYFGV");
		lettere.Add("UHJBN");
		lettere.Add("IOPKLM");
		

		
		
		
	}
	
	// Update is called once per frame
void Update () {
    i++;
	if (i>=timer_cont){
		bool succes = false;
		while(!succes){
		int randomSection = (int)Random.Range(0F, 5F);
		int randomChar = (int)Random.Range(0f,5f);
		Debug.Log("sei nel ciclo");
		lettera=lettere[randomSection][randomChar].ToString();
        Debug.Log(lettera);
		if("QWASZ".Contains(lettera)){
			Debug.Log("sei entrato nei qwasz");
			if(spawnPoints[0].transform.childCount == 0){
				
				new_instance=Instantiate(nota, spawnPoints[0].transform);
				
				new_instance.GetComponentInChildren<TextMesh>().text=lettera;
				succes=true;

			}
		}
		if("ERDXC".Contains(lettera)){
			if(spawnPoints[1].transform.childCount == 0){
				new_instance=Instantiate(nota, spawnPoints[1].transform);
				new_instance.GetComponentInChildren<TextMesh>().text=lettera;
				succes=true;
			}
		}
		if("TYFGV".Contains(lettera)){
			if(spawnPoints[2].transform.childCount == 0){
				new_instance=Instantiate(nota, spawnPoints[2].transform);
				new_instance.GetComponentInChildren<TextMesh>().text=lettera;
				succes=true;
			}
		}
		if("UHJBN".Contains(lettera)){
			if(spawnPoints[3].transform.childCount == 0){
				new_instance=Instantiate(nota, spawnPoints[3].transform);
				new_instance.GetComponentInChildren<TextMesh>().text=lettera;
				succes=true;
			}
		}
		if("IOPKLM".Contains(lettera)){
			if(spawnPoints[4].transform.childCount == 0){
				new_instance=Instantiate(nota, spawnPoints[4].transform);
				new_instance.GetComponentInChildren<TextMesh>().text=lettera;
				succes=true;
			}
		}
		succes=true;
		}
		succes=false;
		
		
		
		i=0;
		}
	}


}
