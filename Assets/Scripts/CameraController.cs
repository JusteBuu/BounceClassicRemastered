using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        public GameObject ball;

        private float _xOffset;
        private float _yPos;
        private float _zPos;

        private void Start()
        {
            var camPos = transform.position;
            var ballPos = ball.transform.position;

            _xOffset = camPos.x - ballPos.x;
            _yPos = camPos.y;
            _zPos = camPos.z;
        }

        private void LateUpdate()
        {
            if (ball != null)
            {
                var newX = ball.transform.position.x + _xOffset;
                transform.position = new Vector3(newX, _yPos, _zPos);
            }
        }
    }


