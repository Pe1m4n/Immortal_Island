using UnityEngine;

namespace Source.Fight.Enemies
{
    public class AnimationComponent
    {
        private const string STOP_ANIMATIONS_TRIGGER = "Clear";
        private const string GET_UP_TRIGGER = "GetUp";
        
        private readonly Animator _animator;

        public AnimationComponent(Animator animator)
        {
            _animator = animator;
        }

        public void StopAnimations()
        {
            _animator.SetTrigger(STOP_ANIMATIONS_TRIGGER);
        }

        public void GetUp()
        {
            _animator.SetTrigger(GET_UP_TRIGGER);
        }
    }
}