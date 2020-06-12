using UnityEngine;

namespace Source.Fight.Enemies
{
    public class AnimationBehavour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.IsName("Run"))
            {
                animator.GetComponent<Enemy>().NavigationComponent.GoToDestination();
            }
        }
    }
}