﻿// <copyright file="LinkList.cs" company="OpenCensus Authors">
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

namespace OpenCensus.Trace.Export
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class LinkList : ILinks
    {
        public static LinkList Create(IList<ILink> links, int droppedLinksCount)
        {
            if (links == null)
            {
                throw new ArgumentNullException(nameof(links));
            }

            List<ILink> copy = new List<ILink>(links);

            return new LinkList(copy.AsReadOnly(), droppedLinksCount);
        }

        internal LinkList(IList<ILink> links, int droppedLinksCount)
        {
            this.Links = links ?? throw new ArgumentNullException("Null links");
            this.DroppedLinksCount = droppedLinksCount;
        }

        public int DroppedLinksCount { get; }

        public IList<ILink> Links { get; }

        public override string ToString()
        {
            return "Links{"
                + "links=" + this.Links + ", "
                + "droppedLinksCount=" + this.DroppedLinksCount
                + "}";
        }

        public override bool Equals(object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o is LinkList that)
            {
                return this.Links.SequenceEqual(that.Links)
                     && (this.DroppedLinksCount == that.DroppedLinksCount);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int h = 1;
            h *= 1000003;
            h ^= this.Links.GetHashCode();
            h *= 1000003;
            h ^= this.DroppedLinksCount;
            return h;
        }
    }
}
