﻿// <copyright file="BinaryFormatBase.cs" company="OpenCensus Authors">
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
    public abstract class BinaryFormatBase : IBinaryFormat
    {
        internal static readonly NoopBinaryFormat NOOP_BINARY_FORMAT = new NoopBinaryFormat();

        internal static IBinaryFormat NoopBinaryFormat
        {
            get
            {
                return NOOP_BINARY_FORMAT;
            }
        }

        public abstract ISpanContext FromByteArray(byte[] bytes);

        public abstract byte[] ToByteArray(ISpanContext spanContext);
    }
}
