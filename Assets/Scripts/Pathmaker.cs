using UnityEngine;
using System.Collections;

public class Pathmaker : MonoBehaviour {

	public GameObject floorPrefab;
	public Transform pathmakerPrefab;
	Transform clones;
	GameObject clone;
	int counter = 0;
	int randomValue;
	Vector3 randomPosition;
	Vector3 yPositions;
	
	// Use this for initialization
	void Start () {
		randomValue = Random.Range (10, 50);
		randomPosition = new Vector3(Random.Range (-transform.position.x, transform.position.x),
		                             Random.Range (0, 3),
		                             Random.Range (-transform.position.z, transform.position.z));

	}
	
	// Update is called once per frame
	void Update () {
		if (counter < randomValue) { 
			float rand = Random.Range (0f, 1f);
			if (rand < 0.25f) {
				transform.Rotate(new Vector3(0, 90, 0));
			}
			else if (rand > 0.25f && rand < 0.5f) {
				transform.Rotate (new Vector3(0, -90, 0));
			}
			else if (rand > 0.96f && rand < 1.0f) {
				Instantiate (pathmakerPrefab, randomPosition, Quaternion.Euler (0, 0, 0));
			}
			//clone =
			clone = Instantiate (floorPrefab, transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			transform.Translate (0, 0, 5);
			counter++;

			if (clone.transform.position.y == 0) {
				clone.GetComponent<Renderer>().material.color = new Color (100f, 105f, 24f);
			}
			
			if (clone.transform.position.y == 1) {
				clone.GetComponent<Renderer>().material.color = new Color (25f, 0f, 55f);
			}
			
			if (clone.transform.position.y == 2) {
				clone.GetComponent<Renderer>().material.color = new Color (0f, 20f, 50f);
			}
		}
		else {
			Destroy(transform.gameObject);
		}
		
	}
}

