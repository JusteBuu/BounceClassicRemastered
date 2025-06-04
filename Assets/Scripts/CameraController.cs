using UnityEngine;


    public class CameraController : MonoBehaviour
    {
        public GameObject ball;

        private float xOffset;
        private float yPos;
        private float zPos;

        void Start()
        {
            Vector3 camPos = transform.position;
            Vector3 ballPos = ball.transform.position;

            xOffset = camPos.x - ballPos.x;
            yPos = camPos.y;
            zPos = camPos.z;
        }

        void LateUpdate()
        {
            if (ball != null)
            {
                float newX = ball.transform.position.x + xOffset;
                transform.position = new Vector3(newX, yPos, zPos);
            }
        }
    }


