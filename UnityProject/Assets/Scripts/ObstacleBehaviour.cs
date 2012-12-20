using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {
	
	public bool garbageCollectable = true;
	public float speed = -0.15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		this.gameObject.transform.Translate( this.speed,0f,0f);
	
		// check collisions here? ow what?
		
		
		// check removal position
		
		Vector3 pos = this.gameObject.transform.position;
		if( pos.x < -20 )
		{
			this.speed = 0;
		}
	}
	
	/*void OnCollisionEnter( Collision collision )
	{
	}*/
	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log ("crate colliding with " + other);
	    //Debug.Log ("collision!");
		if(this.gameObject.audio)
		{
			if(!this.gameObject.audio.isPlaying)
			{
				this.gameObject.audio.Play();
			}
		}
	}
	
	void OnTriggerStay( Collider other )
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.gameObject.transform.position.x < this.gameObject.transform.position.x)
			{
				Vector3 pos = other.gameObject.transform.position;
				pos.x = pos.x + this.speed * 2.0f;		
				other.gameObject.transform.position = pos;
			}
		}		
	}
	
}
