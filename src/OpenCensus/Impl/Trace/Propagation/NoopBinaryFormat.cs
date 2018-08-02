﻿// <copyright file="NoopBinaryFormat.cs" company="OpenCensus Authors">
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

namespace OpenCensus.Trace.Propagation
{
    using System;

    internal class NoopBinaryFormat : IBinaryFormat
    {
        public ISpanContext FromByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            return SpanContext.INVALID;
        }

        public byte[] ToByteArray(ISpanContext spanContext)
        {
           if (spanContext == null)
            {
                throw new ArgumentNullException(nameof(spanContext));
            }

            return new byte[0];
        }
    }
}
