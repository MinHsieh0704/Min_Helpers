using Min_Helpers.AttributeHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Min_Helpers.VerificationCodeHelper
{
    /// <summary>
    /// VerificationCode
    /// </summary>
    public class VerificationCode
    {
        private string[] Fonts { get; } = new string[]
        {
            "0","1","2", "3", "4", "5", "6", "7", "8", "9",
            "a", "b", "c", "d", "e", "f", "g", "h", "i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","P","P","Q","R","S","T","U","V","W","X","Y","Z"
        };

        private Color[] ColorsFont { get; } = new Color[]
        {
            Color.Black, Color.Red, Color.DarkRed, Color.Blue, Color.DarkBlue, Color.Green, Color.DarkGreen, Color.Orange,
            Color.DarkOrange, Color.Brown, Color.Purple, Color.Sienna, Color.DarkGray
        };

        private Color[] ColorsNoise { get; } = new Color[]
        {
            Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Yellow, Color.Brown, Color.Purple, Color.Sienna,
            Color.LightBlue, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightYellow
        };

        private Color[] ColorsBackground { get; } = new Color[]
        {
            Color.WhiteSmoke, Color.Snow, Color.SeaShell, Color.Bisque, Color.BlanchedAlmond, Color.Cornsilk, Color.MintCream, Color.LightCyan, Color.LavenderBlush
        };

        private string[] FontStyles { get; } = new string[]
        {
            "Times New Roman", "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial"
        };

        /// <summary>
        /// Config
        /// </summary>
        public IVerificationCodeConfig Config { get; private set; }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="config"></param>
        public void Initialization(IVerificationCodeConfig config)
        {
            try
            {
                Validate.TryValidateObject(config);

                this.Config = config;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"verification code helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Encode
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, string> Encode()
        {
            try
            {
                int width = (this.Config.FontCount + 2) * this.Config.FontSpacing;

                Random random = new Random(Guid.NewGuid().GetHashCode());

                // 創建畫布
                using (Bitmap bitmap = new Bitmap(width, this.Config.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(this.ColorsBackground[random.Next(this.ColorsBackground.Length)]);

                        // 畫噪線 
                        for (int i = 0; i < 15; i++)
                        {
                            // 直線
                            graphics.DrawLine(new Pen(this.ColorsNoise[random.Next(this.ColorsNoise.Length)]), random.Next(width), random.Next(this.Config.Height), random.Next(width), random.Next(this.Config.Height));

                            // 點
                            graphics.DrawRectangle(new Pen(this.ColorsNoise[random.Next(this.ColorsNoise.Length)]), random.Next(width), random.Next(this.Config.Height), random.Next(2) + 1, random.Next(2) + 1);

                            // 弧線
                            Rectangle rectangle = new Rectangle(random.Next(width), random.Next(this.Config.Height), random.Next(1, width), random.Next(1, this.Config.Height));
                            graphics.DrawArc(new Pen(this.ColorsNoise[random.Next(this.ColorsNoise.Length)]), rectangle, (float)(360 / (i + 1)), (float)(360 / (i + 1)));
                        }

                        // 畫驗證碼字符串
                        string text = "";
                        for (int i = 1; i <= this.Config.FontCount; i++)
                        {
                            Font font = new Font(FontStyles[random.Next(FontStyles.Length)], this.Config.FontSize);
                            Color color = this.ColorsFont[random.Next(this.ColorsFont.Length)];
                            string str = this.Fonts[random.Next(this.Fonts.Length)];
                            text += str;

                            graphics.DrawString(str, font, new SolidBrush(color), (float)(i * this.Config.FontSpacing), (float)(this.Config.Height / 8));
                        }

                        string image = "";
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            bitmap.Save(memoryStream, ImageFormat.Png);
                            byte[] byteImage = memoryStream.ToArray();

                            image = Convert.ToBase64String(byteImage).ToString();
                        }

                        return new KeyValuePair<string, string>(text, image);
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"verification code helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Check
        /// </summary>
        /// <param name="text"></param>
        /// <param name="input"></param>
        public bool Check(string text, string input)
        {
            try
            {
                if (text.ToUpper() != input.ToUpper())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"verification code helper: {ex.Message}", ex);

                throw exception;
            }
        }
    }
}
