using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public delegate void Change();

	public static GameManager Instance;
	public Player_Ability P1;
	public Player_Ability P2;
	public PlayerStatistics[] playerStats = new PlayerStatistics[3];

	void Awake () {
		if (Instance == null) {
			DontDestroyOnLoad(gameObject);
			Instance = this;
			this.playerStats[1] = new PlayerStatistics();
			this.playerStats[2] = new PlayerStatistics();
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}
	// currentTurn increases two time / 
	// thus total Turn also is 2 times the intended turn
	public int totalTurnUntilFight;
	public int totalTurn = 20;
	private int currentTotalTurn;

	void Start() {
		currentTotalTurn = 0;
		SceneManager.activeSceneChanged += ChangedActiveScene;
	}

	public void PlayButtonClick() {
		SceneManager.LoadScene("Raising Scene");
	}

	public void PlayTutorialText() {
		SceneManager.LoadScene("Tutorial Scene");
	}

	public void ReturnToOpeningScene() {
		SceneManager.LoadScene("OpeningScene");
	}

	public void TurnPassed() {
		currentTotalTurn++;
	}

	private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
        if (next.name == "Raising Scene") {
			this.P1 = GameObject.Find("P1").GetComponent<Player_Ability>();
			this.P2 = GameObject.Find("P2").GetComponent<Player_Ability>();
			P1.GetComponent<TurnClass>().ResetBool();
			P2.GetComponent<TurnClass>().ResetBool();
			P1.cur_Stats = new PlayerStatistics();
			P2.cur_Stats = new PlayerStatistics();
        }

    }


	void Update() {
		// Def can optimize by making a button or sth/ Separate the turn counting from GameManager
		if (currentTotalTurn >= totalTurnUntilFight && SceneManager.GetActiveScene().name == "Raising Scene") {
			P1.SavePlayer();
			P2.SavePlayer();
			totalTurnUntilFight = totalTurn;
			currentTotalTurn = 0;
			// SceneManager.LoadScene("Colloseum");
			SceneManager.LoadScene("Colloseum New");
		}
	}

	public int CurrentTotalTurn() {
		return currentTotalTurn / 2;
	}

	public int TotalTurnUntilFight() {
		return totalTurnUntilFight / 2;
	}
}

public class PlayerStatistics
{
	public PlayerStatistics() {
		HP = 0;
		weapon_Proficiency = 0;
		attackPower = 0;
		agility = 0;
		strength = 0;
		luck = 0;
		playerScale = Vector3.one;
	}

	public float HP;
	public float weapon_Proficiency;
	public float attackPower;
	public float agility;
	public float strength;
	public float luck;
	public Vector3 playerScale;
}
