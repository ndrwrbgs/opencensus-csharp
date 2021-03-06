﻿// <copyright file="TagValue.cs" company="OpenCensus Authors">
// Copyright 2018, OpenCensus Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of theLicense at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenCensus.Tags
{
    using System;
    using OpenCensus.Utils;

    public sealed class TagValue : ITagValue
    {
        public const int MAX_LENGTH = 255;

        public string AsString { get; }

        internal TagValue(string asString)
        {
            this.AsString = asString ?? throw new ArgumentNullException(nameof(asString));
        }

        public static ITagValue Create(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return new TagValue(value);
        }

        public override string ToString()
        {
            return "TagValue{"
                + "asString=" + this.AsString
                + "}";
        }

        public override bool Equals(object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o is TagValue that)
            {
                return this.AsString.Equals(that.AsString);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int h = 1;
            h *= 1000003;
            h ^= this.AsString.GetHashCode();
            return h;
        }

        private static bool IsValid(string value)
        {
            return value.Length <= MAX_LENGTH && StringUtil.IsPrintableString(value);
        }
    }
}
