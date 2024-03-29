using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private bool gameRunning;
	private GameObject player;
	private PlayerBehaviour playerBehaviour;
	private TreadmillBehaviour treadmillBehaviour;
	private TextMesh scoreText;
	
	private LevelGenerator levelGenerator;
	
	void Start ()
	{
		this.player = GameObject.FindGameObjectWithTag("Player");

		GameObject treadmill = GameObject.Find ("Treadmill");
		this.treadmillBehaviour = (TreadmillBehaviour)treadmill.GetComponent("TreadmillBehaviour");

		this.levelGenerator = new LevelGenerator( treadmill );
		this.gameRunning = true;

		// Score TextMesh
		GameObject scoreText = GameObject.Find("ScoreText");
		this.scoreText = scoreText.GetComponent(typeof(TextMesh)) as TextMesh;

		// Listen for coin collection event
		this.playerBehaviour = this.player.GetComponent("PlayerBehaviour") as PlayerBehaviour;
		this.playerBehaviour.coinCollected += new PlayerBehaviour.CoinCollectedHandler( HandleCoinsCollected );
	}
	
	void Update ()
	{
		if(this.gameRunning)
		{
			this.levelGenerator.Update();
			this.CheckGameOver();
		}
		this.treadmillBehaviour.running = this.gameRunning;

	}

	public void HandleCoinsCollected( int total_coins )
	{
		SessionState.score = total_coins;
		this.scoreText.text = total_coins.ToString();
	}

	void CheckGameOver ()
	{
		if(this.player.transform.localPosition.x<-15)
		{
			this.gameRunning = false;
			Debug.Log ("Game Over");
			Application.LoadLevel("Menu");
		}
	}
}

