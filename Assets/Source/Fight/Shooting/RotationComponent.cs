using UnityEngine;

namespace Source.Fight
{
    public class RotationComponent
    {
        private readonly Camera _camera;
        private readonly Transform _transformToRotate;

        public RotationComponent(Camera camera, Transform transformToRotate)
        {
            _camera = camera;
            _transformToRotate = transformToRotate;
        }

        public void Update()
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = _camera.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (!Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                return;
            }
            
            _transformToRotate.LookAt(hit.point);
        }
    }
}