﻿// <copyright file="StyleRepository.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Menu
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Ensage.SDK.Menu.Styles;
    using Ensage.SDK.Menu.Styles.Elements;

    [Export]
    public class StyleRepository
    {
        [Import]
        public DefaultMenuStyle DefaultMenuStyle { get; set; }

        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<IMenuStyle> Styles { get; set; }

        public IMenuStyle GetStyle(string name)
        {
            return this.Styles.First(e => e.Name == name);
        }
    }
}