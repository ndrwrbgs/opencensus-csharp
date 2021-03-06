﻿// <copyright file="SpanBuilderBase.cs" company="OpenCensus Authors">
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

namespace OpenCensus.Trace
{
    using System.Collections.Generic;
    using OpenCensus.Common;

    public abstract class SpanBuilderBase : ISpanBuilder
    {
        public abstract ISpanBuilder SetSampler(ISampler sampler);

        public abstract ISpanBuilder SetParentLinks(IList<ISpan> parentLinks);

        public abstract ISpanBuilder SetRecordEvents(bool recordEvents);

        public abstract ISpan StartSpan();

        public IScope StartScopedSpan()
        {
            return CurrentSpanUtils.WithSpan(this.StartSpan(), true);
        }

        // public void StartSpanAndRun(Runnable runnable)
        // {
        //    Span span = startSpan();
        //    CurrentSpanUtils.withSpan(span, /* endSpan= */ true, runnable).run();
        // }
        // public final<V> V startSpanAndCall(Callable<V> callable) throws Exception
        // {
        //    final Span span = startSpan();
        //    return CurrentSpanUtils.withSpan(span, /* endSpan= */ true, callable).call();
        // }
    }
}
