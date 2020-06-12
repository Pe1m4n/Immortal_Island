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

        public void SetAnimationsActive(bool active)
        {
            _animator.enabled = active;
            if (!active)
            {
                _animator.SetTrigger(STOP_ANIMATIONS_TRIGGER);
            }
            else
            {
                _animator.SetTrigger(GET_UP_TRIGGER);
            }
        }
    }
}