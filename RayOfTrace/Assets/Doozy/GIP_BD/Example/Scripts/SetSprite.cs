using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetSprite : MonoBehaviour {

	void Start () 
	{
		GetComponent<Image>().sprite = Resources.Load <Sprite> ("Sprites/128x128/"+gameObject.name.Split('_')[0]+"/"+gameObject.name);
	}
	
}
