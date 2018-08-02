﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenCensus.Common;

namespace OpenCensus.Tags
{
    public abstract class TaggerBase : ITagger
    {
        public abstract ITagContext Empty { get; }

        public abstract ITagContext CurrentTagContext { get; }

        public abstract ITagContextBuilder EmptyBuilder { get; }

        public abstract ITagContextBuilder CurrentBuilder { get; }

        public abstract ITagContextBuilder ToBuilder(ITagContext tags);

        public abstract IScope WithTagContext(ITagContext tags);
    }
}
