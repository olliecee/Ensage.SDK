﻿// <copyright file="SelectionView.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Menu.Views
{
    using System;
    using System.Collections.Generic;

    using Ensage.SDK.Menu.Attributes;
    using Ensage.SDK.Menu.Entries;
    using Ensage.SDK.Menu.Items;

    using SharpDX;

    [ExportView(typeof(Slider))]
    public class SliderView : IView
    {
        private Vector2 textSize = Vector2.Zero;

        public void Draw(MenuBase context)
        {
            var item = (MenuItemEntry)context;

            var pos = context.Position;
            var size = context.RenderSize;

            var activeStyle = context.MenuConfig.GeneralConfig.ActiveStyle.Value;
            var styleConfig = activeStyle.StyleConfig;
            var border = styleConfig.Border;

            context.Renderer.DrawTexture(activeStyle.Item, new RectangleF(pos.X, pos.Y, size.X, size.Y));

            pos += new Vector2(border.Thickness[0], border.Thickness[1]);
            var font = styleConfig.Font;
            context.Renderer.DrawText(pos, context.Name, styleConfig.Font.Color, font.Size, font.Family);

            var propValue = item.PropertyBinding.GetValue<Slider>();
            pos.X = (context.Position.X + size.X) - border.Thickness[2] - textSize.X - styleConfig.TextSpacing;

            context.Renderer.DrawText(pos, propValue.ToString(), styleConfig.Font.Color, font.Size, font.Family);

            pos = context.Position;
            pos.X += ((float)(propValue.Value - propValue.MinValue) / (propValue.MaxValue - propValue.MinValue)) * size.X;
            context.Renderer.DrawLine(pos, pos + new Vector2(0, size.Y), styleConfig.SliderStyle.LineColor, styleConfig.SliderStyle.LineWidth);
        }

        public Vector2 GetSize(MenuBase context)
        {
            var totalSize = Vector2.Zero;
            var styleConfig = context.MenuConfig.GeneralConfig.ActiveStyle.Value.StyleConfig;

            var border = styleConfig.Border;
            totalSize.X += border.Thickness[0] + border.Thickness[2];
            totalSize.Y += border.Thickness[1] + border.Thickness[3];

            var item = (MenuItemEntry)context;
            var propValue = item.PropertyBinding.GetValue<Slider>();

            var font = styleConfig.Font;
            textSize = context.Renderer.MessureText(propValue.ToString(), font.Size, font.Family);
            totalSize.X += styleConfig.LineWidth + textSize.X;
            totalSize.Y += Math.Max(textSize.Y, styleConfig.ArrowSize.Y);

            return totalSize;
        }

        public void OnClick(MenuBase context, Vector2 clickPosition)
        {
            var pos = context.Position;
            var size = context.RenderSize;
            
            var styleConfig = context.MenuConfig.GeneralConfig.ActiveStyle.Value.StyleConfig;

            var item = (MenuItemEntry)context;
            var propValue = item.PropertyBinding.GetValue<Slider>();

            float percentage = (clickPosition.X - pos.X) / size.X;
            if (percentage >= 0 && percentage <= 1f)
            {
                propValue.Value = (int)Math.Round(percentage * (propValue.MaxValue - propValue.MinValue)) + propValue.MinValue;
            }
        }
    }
}