using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {
	public bool paused = false;
	public string state = "start";
	public bool controls = false;

	public GameObject startmenu;
	public GameObject gamemenu;
	public GameObject controlsmenu;
	public GameObject userprompt;
	public GameObject userinput;
	public GameObject highscores;
	public GameObject countDown;
	public float gameStartedTime = 0.0f;
	public float blinktime = -10.0f;
	public float blinkperiod = 1.0f;
	public string blinkcursor = "";
	public float gameTimeLimit = 40.0f;
	// Use this for initialization
	void Start () {
		startmenu = GameObject.FindGameObjectWithTag("menuItems");
		gamemenu = GameObject.FindGameObjectWithTag("gameItems");
		controlsmenu = GameObject.FindGameObjectWithTag("controlItems");
		userprompt = GameObject.FindGameObjectWithTag("userPrompt");
		userinput = GameObject.FindGameObjectWithTag("userInput");
		highscores = GameObject.FindGameObjectWithTag("highScoreText");
		countDown = GameObject.FindGameObjectWithTag("countDown");


	}
	
	// Update is called once per frame
	void Update () {
		//countDown.guiText.text = (60.0f - Time.time).ToString();

		if(Time.time - gameStartedTime >= gameTimeLimit) {
			state = "highscores";
		}
		if(Time.time >= blinktime + blinkperiod) {
			blinktime = Time.time;
			if(blinkcursor == "|") {
				blinkcursor = "";
			}else {
				blinkcursor = "|";
			}
		}
		// turn on and off the correct menus
		switch (state){
		case "start":
			startmenu.SetActive(true);
			gamemenu.SetActive(false); // end the pause and turn off the menu
			userinput.SetActive(false);
			userprompt.SetActive(false);
			highscores.SetActive(false);
			countDown.SetActive(false);
			//controlsmenu.SetActive(false);
			break;

		case "gamemenu":
			gamemenu.SetActive(true);
			startmenu.SetActive(false);
			countDown.SetActive(true);
			break;

		//case "controls":
		//	controlsmenu.SetActive(true);
		//	gamemenu.SetActive(false);
		//	break;

		case "playing":
			if(gameStartedTime != 0.0f){
				countDown.guiText.text = (gameTimeLimit - Time.time + gameStartedTime).ToString();
			}else {
				gameStartedTime = Time.time;
			}

			startmenu.SetActive(false);
			gamemenu.SetActive(false);
			//controlsmenu.SetActive(false);
			countDown.SetActive(true);
			break;

		case "userinput":
			Debug.Log("case userinput");

			startmenu.SetActive(false);
			gamemenu.SetActive(false);
			controlsmenu.SetActive(false);
			highscores.SetActive(false);

			userprompt.SetActive(true);
			userinput.SetActive(true);
			foreach (char c in Input.inputString) {
				if (c == "\b"[0]){
					if (userinput.guiText.text.Length != 0){
						userinput.guiText.text = userinput.guiText.text.Substring(0, userinput.guiText.text.Length - 1);

					}
				}else{
					if (c == "\n"[0] || c == "\r"[0]){ // they've pressed enter
						SharedBehaviour.current.playerName = userinput.guiText.text;
						//
						state = "highscores";
						Debug.Log("User entered his name: " + userinput.guiText.text);
					}else{
						userinput.guiText.text += c;
						//userinput.guiText.text += blinkcursor;
					}
				}
			}
			break;



		case "highscores":
			Time.timeScale = 0.0f;
			userinput.SetActive(false);
			gamemenu.SetActive(false);
			startmenu.SetActive(false);
			countDown.SetActive(false);
			controls = false;
			highscores.SetActive(true);

			break;
		}


		if(controls) {
			controlsmenu.SetActive(true);
		}
		else {
			controlsmenu.SetActive(false);
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(controls) { // controls are on screen, escape to clear them
				controls = false;
			}
			else { // no controls on screen so deal with the other menus
				switch(state){
				case "gamemenu": // the menu is on, turn off and unpause
					state = "playing";
					Time.timeScale = 1.0f;
					break;
				case "playing": // we are in game, pause and bring up the menu
					state = "gamemenu";
					Time.timeScale = 0.0f;
					break;
				case "controls": // controls are on screen, turn to previous menu type
					controls = false;
					break;

				}
			}
		}
		joypadMenu();
	}

	public void joypadMenu() {
		if(Input.GetButtonDown("Fire1")) {
			Debug.Log ("Fire1");
			switch(state) {
			case "start":
				state = "playing";
				break;
			case "gamemenu":
				state = "playing";
				Time.timeScale = 1.0f;
				break;
			
			}
			if(controls) {
				controls = false;
			}
		}

		if(Input.GetButtonDown("Fire2")){			
			Debug.Log ("Fire2");
			if(state == "gamemenu" || state == "startmenu") {
				controls = !controls;
			}
			
		}
		
		if(Input.GetButtonDown("Fire3")){
			if(state == "playing") {
				state = "gamemenu";
				Time.timeScale = 0.0f;
			}
		}
		
		if(Input.GetButtonDown("Jump")){
			
			Debug.Log ("Jump");
			
		}
		

	}
}
