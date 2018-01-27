using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
Transform nota_transform;
public bool pressing;
Transform timer_transform;
float opacità_nota = 1f;
 float velocitaScomparitoria= 0.01f;
public GameObject input_timer;
SpriteRenderer sprite_nota;
SpriteRenderer sprite_timer;
GameObject timer;
public GameObject tokillachild;
Animator animation_reference;
string lettera;
float x = 1f;
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


 


 TextMesh text;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	void Start () {
	
    pressing=false;
	//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	lettera=gameObject.GetComponentInChildren<TextMesh>().text;
	animation_reference=GetComponent<Animator>();
	;
		Debug.Log(lettera);
	}
	
	void Update () {
		
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	
		if (!Input.GetKey(lettera.ToLower())){
		sprite_nota=gameObject.GetComponent<SpriteRenderer>();
		sprite_nota.color = new Color(1f,1f,1f,opacità_nota);
		opacità_nota= opacità_nota - velocitaScomparitoria;

			if (opacità_nota<=0F){
				GameObject.Destroy(gameObject.gameObject);
			
			}
		}else{
		
		if(sprite_nota){
		opacità_nota=1f;
		sprite_nota.color = new Color(1f,1f,1f,opacità_nota);
		pressing = true;
	    
		animation_reference.SetBool("isPressed", true);
		}

		 }
		 if(Input.GetKeyUp(lettera.ToLower())){
			Destroy(gameObject);
			pressing = false;
		}
//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<








//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
	}
	
}
