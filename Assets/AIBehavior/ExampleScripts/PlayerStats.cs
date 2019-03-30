using UnityEngine;
using UnityEngine.UI;


namespace AIBehaviorExamples
{
	public class PlayerStats : MonoBehaviour
	{
		public PlayerStatistics playerStat;

		public int playerNum;

		public RectTransform healthbar;
	    public float maxSize = 10;

	    public GameObject winCanvas;

	    public int startHP = 100;

		public int current_HP;
		public int maxHP;

		void Awake()
	    {
	        playerStat = GameManager.Instance.playerStats[playerNum];
	        healthbar = this.transform.GetChild(0).Find("Background").GetChild(0).gameObject.GetComponent<RectTransform>();
	        maxSize = healthbar.sizeDelta.x;
	        current_HP = (int)playerStat.HP + startHP;
			maxHP = current_HP;
			current_HP = maxHP;
			this.transform.localScale = playerStat.playerScale;
	    }

	    void Update() {
	    	// current_HP = (int)GetComponent<AIBehavior.AIBehaviors>().health;
	    	 if (current_HP <= 0) {
	            // Destroy(this.gameObject);
	        	winCanvas.SetActive(true);
	        	if (playerNum == 2) {
	        		winCanvas.transform.GetChild(0).GetComponent<Text>().text = "player " + (playerNum - 1).ToString() + " Won! Congratulation!"; 
	        	} else {
	        		winCanvas.transform.GetChild(0).GetComponent<Text>().text = "player " + (playerNum + 1).ToString() + " Won! Congratulation!"; 
	        	}
	        	
	        }
            healthbar.sizeDelta = new Vector2((float)current_HP/ maxHP * maxSize, healthbar.sizeDelta.y);
	    }

	    public void HealHP(int i) {
	    	Debug.Log("This is running");
	        if (current_HP + i > maxHP) {
	            current_HP = maxHP;
	        } else {
	            current_HP += i;
	        }
	    }

	    public float GetCur_HP()
	    {
	        return current_HP;
	    }
	}
}