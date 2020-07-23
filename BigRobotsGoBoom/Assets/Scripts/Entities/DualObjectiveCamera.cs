using UnityEngine;
using System.Collections;

public class DualObjectiveCamera : MonoBehaviour {
	public Transform leftTarget;
	public Transform rightTarget;

	public float minDistance;

	// Update is called once per frame
	void Update () {
		float distanceBetweenTargets = Mathf.Abs (leftTarget.position.x - rightTarget.position.x) * 2;
		float centerPosition = (leftTarget.position.x + rightTarget.position.x)/ 2;

		transform.position = new Vector3 (
			centerPosition, transform.position.y,
			distanceBetweenTargets > minDistance? -distanceBetweenTargets: -minDistance
			);
	}
}
