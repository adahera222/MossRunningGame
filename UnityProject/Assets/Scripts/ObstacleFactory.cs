using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class ObstacleFactory
{

	private Dictionary<string, ObjectPool> _objectPools;
	
	public ObstacleFactory()
	{
		_objectPools = new Dictionary<string, ObjectPool>();
		_objectPools.Add("crate", 		new ObjectPool(GameObject.Find("ProtoCrate"),		4));
		_objectPools.Add("coin",  		new ObjectPool(GameObject.Find("ProtoCoin"),		4));
		_objectPools.Add("fence", 		new ObjectPool(GameObject.Find("ProtoFence"),		8));
		_objectPools.Add("bush",  		new ObjectPool(GameObject.Find("ProtoBush"),		5));
		_objectPools.Add("brickwall",	new ObjectPool(GameObject.Find("ProtoBrickWall"),	4));
	}
	
	public GameObject CreateObstacle( string type )
	{
		ObjectPool pool = _objectPools[type];
		return GetObstacle (pool);
	}

	///////////////////////////////////////////////	
	
	private GameObject GetObstacle( ObjectPool pool )
	{
		GameObject obstacle = pool.getNextObject();
		var pos = pool.prototype.transform.position;
		obstacle.transform.position = new Vector3(pos.x,pos.y,pos.z);
		return obstacle;
	}

}