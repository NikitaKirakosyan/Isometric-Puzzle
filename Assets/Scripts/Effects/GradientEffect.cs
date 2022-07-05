/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

namespace NikitaKirakosyan
{
    public class GradientEffect : MonoBehaviour
    {
        public Gradient gradient = null;
        [Range(0, 359)] public int angle = 0;

        public Image Image { get; private set; } = null;

        private void Awake()
        {
            Image = GetComponent<Image>();

            Sprite gradientSprite = null;
            if (Image.sprite != null)
            {
                gradientSprite = Sprite.Create(Image.sprite.texture, Image.sprite.rect, Image.sprite.pivot);
            }
            else
            {
                Image.type = Image.Type.Simple;
                Vector2Int textureSize = new Vector2Int(100, 100);
                Texture2D texture = new Texture2D(textureSize.x, textureSize.y, TextureFormat.RGBA32, true);
                gradientSprite = Sprite.Create(texture, new Rect(Vector2.zero, textureSize), textureSize / 2);
            }
            gradientSprite.name = "Gradiented Sprite";

            Image.sprite = GetGradientedSprite(gradientSprite, angle);
        }

        public Sprite GetGradientedSprite(Sprite sprite, int angle = 0)
        {
            if (angle != 180)
            {
                for (int x = 0; x < sprite.texture.width; x++)
                {
                    for (int y = 0; y < sprite.texture.height; y++)
                    {
                        float time = x / 100.0f;
                        Color color = gradient.Evaluate(time);
                        sprite.texture.SetPixel(x, y, color);
                    }
                }
            }
            else
            {
                for (int x = 0; x < sprite.texture.width; x++)
                {
                    for (int y = 0; y < sprite.texture.height; y++)
                    {
                        float time = y / 100.0f;
                        Color color = gradient.Evaluate(time);
                        sprite.texture.SetPixel(x, y, color);
                    }
                }
            }
            sprite.texture.Apply();

            return sprite;
        }
    }
}