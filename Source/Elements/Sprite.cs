namespace RAGENativeUI.Elements
{
    using System;
    using System.Drawing;

    using Rage;
    using Rage.Native;

    public class Sprite
    {
        public TextureDictionary TextureDictionary { get; set; }
        private string textureName;
        /// <exception cref="ArgumentNullException">When setting the property to a null value.</exception>
        public string TextureName { get { return textureName; } set { textureName = value ?? throw new ArgumentNullException($"The sprite {nameof(TextureName)} can't be null."); } }
        public SizeF Resolution
        {
            get
            {
                Vector3 tmp = NativeFunction.Natives.GetTextureResolution<Vector3>(TextureDictionary.Name, TextureName);
                return new SizeF(tmp.X, tmp.Y);
            }
        }
        public GameScreenRectangle Rectangle { get; set; }
        public float Rotation { get; set; }
        public Color Color { get; set; }
        public bool IsVisible { get; set; }

        public Sprite(TextureDictionary textureDictionary, string textureName, GameScreenRectangle rectangle, Color color)
        {
            TextureDictionary = textureDictionary;
            TextureName = textureName;
            Rectangle = rectangle;
            Color = color;
        }

        public Sprite(TextureDictionary textureDictionary, string textureName, GameScreenRectangle rectangle) : this(textureDictionary, textureName, rectangle, Color.White)
        {
        }


        public void Draw()
        {
            if (!IsVisible)
                return;

            Draw(TextureDictionary, TextureName, Rectangle, Rotation, Color);
        }


        public static void Draw(TextureDictionary textureDictionary, string textureName, GameScreenRectangle rectangle, float rotation, Color color)
        {
            if (!textureDictionary.IsLoaded)
                textureDictionary.Load();

            NativeFunction.Natives.DrawSprite(textureDictionary.Name, textureName, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rotation, color.R, color.G, color.B, color.A);
        }
    }
}

