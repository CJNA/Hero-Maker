using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPlayerActions
{
	public GameObject openingScreen;
	public PlayerControl playerControl;
	public Image[] images = new Image[6];

	public void Awake()
	{
		playerControl.Player.SetCallbacks(this);
	}

	public void OnEnable()
	{
		playerControl.Player.Enable();
	}

	public void OnDisable()
	{
		playerControl.Player.Disable();
	}

	public void OnEscape(InputAction.CallbackContext context)
	{
		Debug.Log("Display return menu");
		if (openingScreen) {
			if (!openingScreen.activeSelf) {
			Time.timeScale = 0.0f;
			openingScreen.SetActive(true);
			} else {
				openingScreen.SetActive(false);
				Time.timeScale = 1.0f;
			}
		}
	}

	public void OnSeek(InputAction.CallbackContext context)
	{	

	}

	public void OnFlee(InputAction.CallbackContext context)
	{
		
	}

	public void OnFleeItem(InputAction.CallbackContext context)
	{
		
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
    		for (int i = 0; i < 3; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[0].color = new Color32(255,255,255,255);

    	} else if (Input.GetKeyDown(KeyCode.Joystick1Button1)) {
    		for (int i = 0; i < 3; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[1].color = new Color32(255,255,255,255);
    	} else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) {
    		for (int i = 0; i < 3; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[2].color = new Color32(255,255,255,255);
    	} else if (Input.GetKeyDown(KeyCode.Joystick2Button0)) {
    		for (int i = 3; i < 6; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[3].color = new Color32(255,255,255,255);
    	} else if (Input.GetKeyDown(KeyCode.Joystick2Button1)) {
    		for (int i = 3; i < 6; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[4].color = new Color32(255,255,255,255);
    	} else if (Input.GetKeyDown(KeyCode.Joystick2Button2)) {
    		for (int i = 3; i < 6; i++) { 
    			images[i].color = new Color32(0,0,0,255);
    		}
    		images[5].color = new Color32(255,255,255,255);
    	}

        // Gamepad active_gamepad = Gamepad.current;

        // float horizontal_val = active_gamepad.leftStick.x.ReadValue();
        // float vertical_val = active_gamepad.leftStick.y.ReadValue();

        // bool a_pressed_this_frame = active_gamepad.aButton.wasPressedThisFrame;
        // bool b_pressed_this_frame = active_gamepad.bButton.wasPressedThisFrame;

        // List<Gamepad> game_pads = new List<Gamepad>(Gamepad.all);

        // foreach(Gamepad gp in game_pads)
        // {
        // 	Debug.Log(gp.name);
        // }
    }
}
