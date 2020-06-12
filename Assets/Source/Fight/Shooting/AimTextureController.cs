using UnityEngine.UI;

namespace Source.Fight
{
    public class AimTextureController
    {
        private readonly Image _barImage;

        public AimTextureController(Image barImage)
        {
            _barImage = barImage;
        }

        public void SetAimPower(float power)
        {
            _barImage.fillAmount = power;
        }
    }
}