﻿// <copyright file="RunningSpanStoreBase.cs" company="OpenCensus Authors">
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
    using System.Collections.Generic;

    public abstract class RunningSpanStoreBase : IRunningSpanStore
    {
        private static readonly IRunningSpanStore NOOP_RUNNING_SPAN_STORE = new NoopRunningSpanStore();

        internal static IRunningSpanStore NoopRunningSpanStore
        {
            get
            {
                return NOOP_RUNNING_SPAN_STORE;
            }
        }

        protected RunningSpanStoreBase()
        {
        }

        public abstract IRunningSpanStoreSummary Summary { get; }

        public abstract IList<ISpanData> GetRunningSpans(IRunningSpanStoreFilter filter);

        public abstract void OnEnd(ISpan span);

        public abstract void OnStart(ISpan span);
    }
}
