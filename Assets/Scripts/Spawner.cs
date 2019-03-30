using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Spawner : MonoBehaviour
{
	public float secsPerSpawn = 1.0f;

	public GameObject objectToSpawn;

	// Optional. If you want objects to spawn as children
	// of another object, set this.
	public Transform spawnedObjectsParent;

	private float timeSinceLastSpawn = 0f;
	private BoxCollider spawnArea;

	private bool isSpawning = true;

	void Start ()
	{
		spawnArea = GetComponent<BoxCollider> ();
	}

	void Update ()
	{
		if (isSpawning)
		{
			timeSinceLastSpawn += Time.deltaTime;

			if (timeSinceLastSpawn >= secsPerSpawn)
			{
				SpawnOne ();
			}
		}
	}

	public void SetSpawning (bool spawning)
	{
		isSpawning = spawning;
	}

	public bool IsSpawning ()
	{
		return isSpawning;
	}

	public void SpawnOne ()
	{
		timeSinceLastSpawn = 0f;
		Vector3 spawnPoint = RandomPointWithinBox (spawnArea.bounds);

		GameObject spawnedObject = Instantiate (objectToSpawn, spawnPoint, Quaternion.identity);
		if (spawnedObjectsParent != null)
		{
			spawnedObject.transform.parent = spawnedObjectsParent.transform;
		}
	}

	Vector3 RandomPointWithinBox (Bounds bounds)
	{
		Vector3 point = new Vector3 (
			Random.Range (-1f, 1f) * bounds.extents.x,
			Random.Range (-1f, 1f) * bounds.extents.y,
			Random.Range (-1f, 1f) * bounds.extents.z
		);
		return bounds.center + point;
	}
}
