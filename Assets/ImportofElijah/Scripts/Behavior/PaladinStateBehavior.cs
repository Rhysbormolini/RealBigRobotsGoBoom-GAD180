using UnityEngine;
using System.Collections;

public class PaladinStateBehavior : StateMachineBehaviour {

	public PaladinStates behaviorState;
	public AudioClip soundEffect;

	public float horizontalForce;
	public float verticalForce;

	protected FighterPaladin fighter;

	override public void OnStateEnter(Animator animator, 
	                                  AnimatorStateInfo stateInfo, int layerIndex) {
		if (fighter == null) {
			fighter = animator.gameObject.GetComponent<FighterPaladin> ();
		}

		fighter.currentState = behaviorState;

		if (soundEffect != null) {
			fighter.playSound(soundEffect);
		}

		fighter.body.AddRelativeForce (new Vector3 (0, verticalForce, 0));
	}

	override public void OnStateUpdate(Animator animator, 
	                                   AnimatorStateInfo stateInfo, int layerIndex) {
		fighter.body.AddRelativeForce (new Vector3 (0, 0, horizontalForce));
	}
}
