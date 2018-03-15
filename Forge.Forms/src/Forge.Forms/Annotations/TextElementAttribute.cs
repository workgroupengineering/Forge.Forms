﻿using System;
using System.Runtime.CompilerServices;
using Forge.Forms.FormBuilding;
using Forge.Forms.FormBuilding.Defaults;

namespace Forge.Forms.Annotations
{
    /// <summary>
    /// Represents textual content in a form.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public abstract class TextElementAttribute : FormContentAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextElementAttribute"/> class.
        /// </summary>
        /// <param name="value">Text value. Accepts a string or a dynamic expression.</param>
        /// <param name="position">The relative position of this element.</param>
        protected TextElementAttribute(string value, int position) : base(position)
        {
            Value = value;
        }

        /// <summary>
        /// Element content. Accepts a string or a dynamic expression.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Push text to the right to align with icons. Accepts a boolean or a dynamic resource.
        /// </summary>
        public object IconPadding { get; set; }

        protected override void InitializeElement(FormElement element)
        {
            if (element is ContentElement contentElement)
            {
                contentElement.Content = Utilities.GetStringResource(Value);
                contentElement.IconPadding = Utilities.GetResource<bool>(IconPadding, false, Deserializers.Boolean);
            }
        }
    }

    /// <summary>
    /// Draws title text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class TitleAttribute : TextElementAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleAttribute"/> class.
        /// </summary>
        /// <param name="value">Text value. Accepts a string or a dynamic expression.</param>
        /// <param name="position">Do not provide a value for this argument.</param>
        public TitleAttribute(string value, [CallerLineNumber] int position = 0)
            : base(value, position)
        {
        }

        /// <summary>
        /// Displayed icon. Accepts a PackIconKind or a dynamic resource.
        /// </summary>
        public object Icon { get; set; }

        protected override FormElement CreateElement()
        {
            return new TitleElement
            {
                Icon = Utilities.GetIconResource(Icon)
            };
        }
    }

    /// <summary>
    /// Draws accented heading text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class HeadingAttribute : TextElementAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeadingAttribute"/> class.
        /// </summary>
        /// <param name="value">Text value. Accepts a string or a dynamic expression.</param>
        /// <param name="position">Do not provide a value for this argument.</param>
        public HeadingAttribute(string value, [CallerLineNumber] int position = 0)
            : base(value, position)
        {
        }

        /// <summary>
        /// Displayed icon. Accepts a PackIconKind or a dynamic resource.
        /// </summary>
        public object Icon { get; set; }

        protected override FormElement CreateElement()
        {
            return new HeadingElement
            {
                Icon = Utilities.GetIconResource(Icon)
            };
        }
    }

    /// <summary>
    /// Draws regular text.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class TextAttribute : TextElementAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextAttribute"/> class.
        /// </summary>
        /// <param name="value">Text value. Accepts a string or a dynamic expression.</param>
        /// <param name="position">Do not provide a value for this argument.</param>
        public TextAttribute(string value, [CallerLineNumber] int position = 0)
            : base(value, position)
        {
        }

        protected override FormElement CreateElement()
        {
            return new TextElement();
        }
    }
}