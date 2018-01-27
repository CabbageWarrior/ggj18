using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnFinish : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Note notina = animator.GetComponent<Note>();

        bool isStillPressing = notina.pressing;

        if (isStillPressing)
        { 
            string letter = notina.Lettera;

            KeyCode tastoGiusto = (KeyCode)System.Enum.Parse(typeof(KeyCode), letter);

            AudioCoro pippottinoCoro = new List<AudioCoro>(FindObjectsOfType<AudioCoro>()).Find(x => new List<KeyCode>(x.triggerButtons).Contains(tastoGiusto));

            pippottinoCoro.StartSfigatedAudio();
        }

        Destroy(animator.gameObject);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
