using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Ability : MonoBehaviour
{
	public PlayerMovement playerMovement;

	public Text[] abilityTexts = new Text[4];
    public Slider[] abilitySliders = new Slider[4];

	public float strengthOffset;
	public float agilityOffset;
	public float weaponOffset;
	public float HPOffset;

	public float strengthShapeOffset;
	public float agilityShapeOffset;

	public int strengthMaxIncrement;
	public int agilityMaxIncrement;
	public int weaponMaxIncrement;

    public int playerNum;

	public PlayerStatistics cur_Stats;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < abilityTexts.Length; i++) {
     		if (i == 0) {
     			abilityTexts[i].text = "Agility : " + cur_Stats.agility.ToString();
                abilitySliders[i].value = cur_Stats.agility;
     		} else if (i == 1) {
     			abilityTexts[i].text = "Strength : " + cur_Stats.strength.ToString();
                abilitySliders[i].value = cur_Stats.strength;
     		} else if (i == 2) {
     			abilityTexts[i].text = "Weapon : " + cur_Stats.weapon_Proficiency.ToString();
                abilitySliders[i].value = cur_Stats.weapon_Proficiency;
     		}
     	}   	
    }

   	public void weapon_Practice() {
   		if (playerMovement.currentTurn()) {
	    	int weaponIncrement = (int)Random.Range(1, weaponMaxIncrement);

    		AttackPowerChange(weaponIncrement, 0, 0);
    		
            cur_Stats.weapon_Proficiency += weaponIncrement;
    		
            playerMovement.PassTurnClick();
            
            anim.SetTrigger("Weapon_Practice");
   		}
    }

    public void agility_Training() {
    	if (playerMovement.currentTurn()) {
    		int agilityIncrement = (int)Random.Range(1, agilityMaxIncrement);

	    	AttackPowerChange(0, agilityIncrement, 0);

	    	cur_Stats.agility += agilityIncrement;

	    	playerMovement.PassTurnClick();

            Vector3 currentLocalScale = GetComponent<Transform>().localScale;
            // Fix this later -> Somehow later at some point/
            // GetComponent<Transform>().localScale = new Vector3(currentLocalScale.x, currentLocalScale.y, currentLocalScale.z * (1 - agilityShapeOffset));
            cur_Stats.playerScale = GetComponent<Transform>().localScale;
            
            anim.SetTrigger("Agility_Training");

    	}
    }

    public void strength_Training() {
    	if (playerMovement.currentTurn()) {
	    	int strengthIncrement = (int)Random.Range(1, strengthMaxIncrement);

	    	AttackPowerChange(0, 0, strengthIncrement);
	    	HPChange(strengthIncrement);

	    	cur_Stats.strength += strengthIncrement;

	    	playerMovement.PassTurnClick();

            Vector3 currentLocalScale = GetComponent<Transform>().localScale;
	    	GetComponent<Transform>().localScale = new Vector3(currentLocalScale.x * (1 + strengthShapeOffset), currentLocalScale.y, currentLocalScale.z);
            cur_Stats.playerScale = GetComponent<Transform>().localScale;

            anim.SetTrigger("Strength_Training");
    	}
    }

    private void HPChange(int strength) {
    	cur_Stats.HP += (strength * HPOffset);
        Debug.Log(cur_Stats.HP);
    }

    private void AttackPowerChange(int weapon, int agility, int strength) {
    	cur_Stats.attackPower += (weapon * weaponOffset + agility * agilityOffset + strength * strengthOffset);
    }

    public void SavePlayer() {
    	GameManager.Instance.playerStats[playerNum] = cur_Stats;
    }
}
