using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Resources;
using System.Reflection;

public static class DictionaryExt
{
    public static TValue? GetOrNullable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? (TValue?)value : null;
    }

    public static TValue GetOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : null;
    }
}

namespace munchkin_card_editor
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    sealed class CardStyleProperties : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        public readonly string Name;

        // This is a positional argument
        public CardStyleProperties(string name)
        {
            Name = name;
        }
    }

    sealed public class EncapsulatedCardStyleType
    {
        public EncapsulatedCardStyleType(Type t)
        {
            Type = t;
            CustomName = t.GetCustomAttribute<CardStyleProperties>().Name;
        }

        public string CustomName { get; set; }
        public override string ToString() => CustomName;

        public Type Type { get; set; }
    }

    public interface ICardStyle
    {
        Bitmap GetBaseBackImage();
        Bitmap GetBaseFrontImage();
        Bitmap GetEditedFrontImageFor(Card card);
    }

    [CardStyleProperties("Original Dungeon Style")]
    public class OriginalDungeonStyle : ICardStyle
    {
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
                SizeF titleSize;
                using (Font font = new Font("Quasimodo", 32))
                {
                    RectangleF titleRect = new RectangleF(35, 35, img.Width - 70, img.Height);
                    titleSize = g.MeasureString(card.Title, font, titleRect.Size, new StringFormat() { Alignment = StringAlignment.Center });
                    g.DrawString(card.Title, font, new SolidBrush(Color.FromArgb(78, 29, 24)), titleRect, new StringFormat() { Alignment = StringAlignment.Center });
                }
                using (Font font = new Font("Quasimodo", 16))
                {
                    RectangleF descriptionRect = new RectangleF(35, titleSize.Height + 30, img.Width - 70, img.Height);
                    g.DrawString(card.Description, font, new SolidBrush(Color.FromArgb(78, 29, 24)), descriptionRect);
                }
            }

            return img;
        }
    }

    public enum CardCategory
    {
        Treasure,
        Dungeon
    }

    public class Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ScriptPath { get; set; }
        public CardCategory Category { get; set; }
        public Bitmap EditedImage { get; set; }
        public ICardStyle Style { get; set; } = new OriginalDungeonStyle();

        public void UpdateImage()
        {
            EditedImage?.Dispose();
            EditedImage = Style.GetEditedFrontImageFor(this);
        }

        public void SetStyleFromString(string str)
        {
            var results = from type in Assembly.GetExecutingAssembly().GetTypes()
                          where typeof(ICardStyle).IsAssignableFrom(type) && type.Name == str
                          select type;

            Style = (ICardStyle)Activator.CreateInstance(results.First());
        }

        public void SetDataFromDict(Dictionary<string, object> data)
        {
            Title = (string)data.GetOrNull("name") ?? "Card Name";
            Description = (string)data.GetOrNull("description") ?? "Card Description";
            ScriptPath = (string)data.GetOrNull("script") ?? "";
            Category = (string)data.GetOrNull("category") == "treasure" ? CardCategory.Treasure : CardCategory.Dungeon;
        }
        public override string ToString() => Title;
    }
}
