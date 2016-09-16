using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class userInterface : MonoBehaviour {

    GameObject ammo;
    GameObject magazineLeft;
    GameObject healthSliderObject;
    Text ammoText;
    Text magazineText;
    Slider healthSlider;
    int bullets;
    GameObject thePlayer;
    Shoot shootScriptPlayer;
    playerHealth healthScript;
    float playerHealth;
    int magazine;




	// Use this for initialization
	void Start () {
        ammo = GameObject.Find("Ammo");
        magazineLeft = GameObject.Find("Magazine");
        healthSliderObject = GameObject.Find("HealthSlider");
        ammoText = ammo.GetComponent<Text>();
        magazineText = magazineLeft.GetComponent<Text>();
        thePlayer = GameObject.Find("Player");
        shootScriptPlayer = thePlayer.GetComponent<Shoot>();
        healthScript = thePlayer.GetComponent<playerHealth>();
        bullets = shootScriptPlayer.bullets;
        magazine = shootScriptPlayer.magazine;
        playerHealth = healthScript.currentHealth;
        healthSlider = healthSliderObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        playerHealth = healthScript.currentHealth;
        magazine = shootScriptPlayer.magazine;
        bullets = shootScriptPlayer.bullets;
        magazineText.text = magazine.ToString();
        ammoText.text = bullets.ToString();
        healthSlider.value = playerHealth;
    }
}
