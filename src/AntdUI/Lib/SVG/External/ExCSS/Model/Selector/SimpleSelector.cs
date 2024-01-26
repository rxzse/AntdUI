﻿// THIS FILE IS PART OF ExCSS PROJECT
// THE ExCSS PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHT (C) TylerBrinks. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/TylerBrinks/ExCSS

using AntdUI.Svg.ExCSS.Model;
// ReSharper disable once CheckNamespace

namespace AntdUI.Svg.ExCSS
{
    public sealed class SimpleSelector : BaseSelector
    {
        private readonly string _code;
        internal static readonly SimpleSelector All = new SimpleSelector("*");

        public SimpleSelector(string selectorText)
        {
            _code = selectorText;
        }

        internal static SimpleSelector PseudoElement(string pseudoElement)
        {
            return new SimpleSelector("::" + pseudoElement);
        }

        internal static SimpleSelector PseudoClass(string pseudoClass)
        {
            return new SimpleSelector(":" + pseudoClass);
        }

        internal static SimpleSelector Class(string match)
        {
            return new SimpleSelector("." + match);
        }

        internal static SimpleSelector Id(string match)
        {
            return new SimpleSelector("#" + match);
        }

        internal static SimpleSelector AttributeUnmatched(string match)
        {
            return new SimpleSelector("[" + match + "]");
        }

        internal static SimpleSelector AttributeMatch(string match, string value)
        {
            var code = string.Format("[{0}=\"{1}\"]", match, GetValueAsString(value));
            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeNegatedMatch(string match, string value)
        {
            var code = string.Format("[{0}!=\"{1}\"]", match, GetValueAsString(value));
            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeSpaceSeparated(string match, string value)
        {
            var code = string.Format("[{0}~=\"{1}\"]", match, GetValueAsString(value));

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeStartsWith(string match, string value)
        {
            var code = string.Format("[{0}^=\"{1}\"]", match, GetValueAsString(value));

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeEndsWith(string match, string value)
        {
            var code = string.Format("[{0}$=\"{1}\"]", match, GetValueAsString(value));

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeContains(string match, string value)
        {
            var code = string.Format("[{0}*=\"{1}\"]", match, GetValueAsString(value));

            return new SimpleSelector(code);
        }

        internal static SimpleSelector AttributeDashSeparated(string match, string value)
        {
            var code = string.Format("[{0}|=\"{1}\"]", match, GetValueAsString(value));

            return new SimpleSelector(code);
        }

        internal static SimpleSelector Type(string match)
        {
            return new SimpleSelector(match);
        }

        private static string GetValueAsString(string value)
        {
            var containsSpace = false;

            for (var i = 0; i < value.Length; i++)
            {
                if (!value[i].IsSpaceCharacter())
                {
                    continue;
                }
                containsSpace = true;
                break;
            }

            if (!containsSpace)
            {
                return value;
            }

            if (value.IndexOf(Specification.SingleQuote) != -1)
            {
                return '"' + value + '"';
            }

            return "'" + value + "'";
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return _code;
        }
    }
}