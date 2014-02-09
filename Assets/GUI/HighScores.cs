using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScores : MonoBehaviour {

	[Serializable] public class ScoreEntry {
		public string name;
		public int score;
	}
	public int i = 0;
	public List<ScoreEntry> highScores = new List<ScoreEntry>();
	public GUIText hsTable;
	public GameObject userInput;
	public GameObject userPrompt;
	public GUI menu;
	public bool printed = false;
	public bool named = false;


	public float blinktime = -10.0f;
	public float blinkperiod = 1.0f;
	public string blinkcursor = "";

	void SaveScores() {
		var b = new BinaryFormatter();
		var m = new MemoryStream();
		// save the scores
		b.Serialize(m, highScores);
		// add to player prefs
		PlayerPrefs.SetString("HighScores",Convert.ToBase64String(m.GetBuffer()));

	}

	// Use this for initialization
	void Start () {

		hsTable = GameObject.FindGameObjectWithTag("highScoreText").GetComponent<GUIText>();
		hsTable.text = "";
		userInput = GameObject.FindGameObjectWithTag("userInput"); //.GetComponent<GUIText>()
		menu = GameObject.FindGameObjectWithTag("menuRoot").GetComponent<GUI>() as GUI;
		userPrompt = GameObject.FindGameObjectWithTag("userPrompt"); //.GetComponent<GUIText>();

		// off at first
		userPrompt.SetActive(false);
		userInput.SetActive(false);

		// get the data
		var data = PlayerPrefs.GetString("HighScores");
		if(!string.IsNullOrEmpty(data)) {
			var b = new BinaryFormatter();
			// create a new memory stream with the data
			var m = new MemoryStream(Convert.FromBase64String(data));
			highScores = (List<ScoreEntry>)b.Deserialize(m);

		}else {
			highScores.Add(new ScoreEntry{name = "SomePlayer",score = 10});
		}
		// sort the values we pulled from the player prefs
		highScores = highScores.OrderByDescending(o=>o.score).ToList();
		Debug.Log("scores in start: "+ highScores.Count());

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= blinktime + blinkperiod) {
			blinktime = Time.time;
			if(blinkcursor == "|") {
				blinkcursor = "";
			}else {
				blinkcursor = "|";
			}
		}
		if(highScores.Count()>0){
				Debug.Log("lowest high score" + highScores[highScores.Count()-1].score);
			}
		Debug.Log("sharedbehavior current score" + SharedBehaviour.current.score);
		if(!printed) {
			if(!named) {
				if(highScores[highScores.Count()-1].score < SharedBehaviour.current.score) {
					Debug.Log("new high score!");
					userPrompt.SetActive(true);
					userInput.SetActive(true);

					foreach (char c in Input.inputString) {
						if (c == "\b"[0]){
							if (userInput.guiText.text.Length != 0){
								userInput.guiText.text = userInput.guiText.text.Replace("|","");
								userInput.guiText.text = userInput.guiText.text.Substring(0, userInput.guiText.text.Length - 1);								
							}
						}else{
							if (c == "\n"[0] || c == "\r"[0]){ // they've pressed enter
								userInput.guiText.text = userInput.guiText.text.Replace("|","");
								SharedBehaviour.current.playerName = userInput.guiText.text;
								highScores.Add(new ScoreEntry{name = SharedBehaviour.current.playerName, score = SharedBehaviour.current.score});							
								named = true;
								userPrompt.SetActive(false);
								userInput.SetActive(false);
								Debug.Log("User entered his name: " + userInput.guiText.text);
							}else{
								userInput.guiText.text += c;
								userInput.guiText.text = userInput.guiText.text.Replace("|","");

							}
						}
					}
					userInput.guiText.text = userInput.guiText.text.Replace("|","");
					userInput.guiText.text += blinkcursor;

				}
				else { // high scores are too high for this user
					displayHS();
				}
			}
			else { // named and stored, so we can display the new highscore
				displayHS();
			}



		}
		/*
		if(!printed) {
			// sort the highscores
			highScores = highScores.OrderByDescending(o=>o.score).ToList();
			Debug.Log("lowest high score" + highScores[highScores.Count()-1].score);
			Debug.Log("sharedbehavior current score" + SharedBehaviour.current.score);
			if(!named) {
				//check if the current score will go on the table
				if(highScores[highScores.Count()-1].score < SharedBehaviour.current.score) {
					Debug.Log("new high score!");
					userPrompt.SetActive(true);
					userInput.SetActive(true);
					foreach (char c in Input.inputString) {
						if (c == "\b"[0]){
							if (userInput.guiText.text.Length != 0){
								userInput.guiText.text = userInput.guiText.text.Substring(0, userInput.guiText.text.Length - 1);								
							}
						}else{
							if (c == "\n"[0] || c == "\r"[0]){ // they've pressed enter
								SharedBehaviour.current.playerName = userInput.guiText.text;
								highScores.Add(new ScoreEntry{name = SharedBehaviour.current.playerName, score = SharedBehaviour.current.score});							
								named = true;
								userPrompt.SetActive(false);
								userInput.SetActive(false);
								Debug.Log("User entered his name: " + userInput.guiText.text);
							}else{
								userInput.guiText.text += c;
								//userinput.guiText.text += blinkcursor;
							}
						}
					}
				}
				else { // score isn't high enough

					displayHS();
				}
			}
			// we changed to named and now we can display the HS
			displayHS();

		} // if printed is true, the text is already there, don't do any more
*/	
	}
	void displayHS() {
		//named = true; // we've taken care of it and just want to display the hs table
		//userInput.SetActive(false);
		//userPrompt.SetActive(false);
		// display the table!
		highScores = highScores.OrderByDescending(o=>o.score).ToList();
		int j = 0;
		int minscore = 0;
		// loop through and add the name and score to a GUIText
		foreach(ScoreEntry sc in highScores) {			
			if(j <= 4) {
				minscore = sc.score;
				hsTable.text = hsTable.text + sc.name + " : " + sc.score + "\n";
				//hsTable.transform.position = new Vector3(0,0,0);
				//Debug.Log("name:" + sc.name + " score " + sc.score);
				j++;
			}
		}
		//menu.state = "gameover";
		
		// get rid of all the entries that are lower than our last ( lowest ) hs entry
		Debug.Log("before removeall" + highScores.Count());
		highScores.RemoveAll(x => x.score < minscore);
		Debug.Log("after removeall" + highScores.Count());
		SaveScores();
		
		printed = true;

	}
}