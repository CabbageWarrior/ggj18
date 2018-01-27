using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
Transform nota_transform;
Transform timer_transform;
float opacità_nota = 1f;
 float velocitaScomparitoria= 0.01f;
public GameObject input_timer;
SpriteRenderer sprite_nota;
SpriteRenderer sprite_timer;
GameObject timer;
float x = 1f;
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
List<string> lettere = new List<string>(5);
public int minDelay;
public int maxDelay;
 Random random = new Random();

 char lettera;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	void Start () {
	
    sprite_nota=gameObject.GetComponent<SpriteRenderer>();
	//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		lettere.Add("QWASZ");
		lettere.Add("ERDXC");
		lettere.Add("TYFGV");
		lettere.Add("UHJBN");
		lettere.Add("IOPKLM");

	}
	
	void Update () {
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		if (!Input.GetKey("space")){
		sprite_nota.color = new Color(1f,1f,1f,opacità_nota);
		opacità_nota= opacità_nota - velocitaScomparitoria;
		if (opacità_nota==0F){
			Destroy(gameObject);
		}
		}else{
		
		if(Input.GetKeyDown("space")){
			timer = Instantiate (input_timer, new Vector3(transform.position.x,transform.position.y + 0.5F, transform.position.z) , Quaternion.identity);
			sprite_nota=input_timer.GetComponent<SpriteRenderer>();
			
 		}
		opacità_nota=1f;
		sprite_nota.color = new Color(1f,1f,1f,opacità_nota);
		


		 }
		 if(Input.GetKeyUp("space")){
			Destroy(gameObject);
			Destroy(timer);
		}
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		int randomSection = (int)Random.Range(0F, 5F);
		int randomChar = (int)Random.Range(0f,5f);

		lettera=lettere[randomSection][randomChar];






//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	}
}
