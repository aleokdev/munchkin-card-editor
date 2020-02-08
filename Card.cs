using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Resources;

namespace munchkin_card_editor
{
    public interface ICardStyle
    {
        string StyleName { get; }

        Bitmap GetBaseBackImage();
        Bitmap GetBaseFrontImage();
        Bitmap GetEditedFrontImageFor(Card card);
    }

    public class OriginalDungeonStyle : ICardStyle
    {
        public string StyleName => "Original Dungeon Style";

        public Bitmap GetBaseBackImage()
        {
            return ImgResources.OriginalDungeonBack;
        }

        public Bitmap GetBaseFrontImage()
        {
            return ImgResources.OriginalDungeonFront;
        }

        public Bitmap GetEditedFrontImageFor(Card card)
        {
            Bitmap img = (Bitmap)GetBaseFrontImage().Clone();
            using (Graphics g = Graphics.FromImage(img))
            {
                using(Font font = new Font("Quasimodo", 24))
                {
                    PointF titlePos = new PointF(img.Width/2-g.MeasureString(card.Title, font).Width/2, 35);
                    g.DrawString(card.Title, font, new SolidBrush(Color.FromArgb(78, 29, 24)), titlePos);
                }
            }

            return img;
        }
    }

    public class Card
    {
        public Card()
        {
            Style.GetEditedFrontImageFor(this);
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public Bitmap EditedImage { get; set; }
        public ICardStyle Style { get; set; } = new OriginalDungeonStyle();

        public void UpdateImage() => EditedImage = Style.GetEditedFrontImageFor(this);
        public override string ToString() => Title;
    }
}
