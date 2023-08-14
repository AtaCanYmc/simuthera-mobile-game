using UnityEngine;

namespace Menus
{
    public class RotationFinal : MonoBehaviour
    {
        public float rotationSpeed, scaleSpeedX, scaleSpeedY;
        private float totalRotation = 0;
        private int isWin;

        public GameObject menu, Text, score, highscore;

        void Start()
        {
            isWin = PlayerPrefs.GetInt("isWin");
        }
        void FixedUpdate()
        {
            if (totalRotation < 360)
            {
                transform.Rotate(0, 0, -rotationSpeed);
                totalRotation += rotationSpeed;
                transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * scaleSpeedX, transform.localScale.y - Time.deltaTime * scaleSpeedY, transform.localScale.z);
            }
            else
            {
                Text.SetActive(true);
                score.SetActive(true);
                highscore.SetActive(true);
                menu.SetActive(true);
            }
        }
    }
}
