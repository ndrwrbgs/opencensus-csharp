﻿// <copyright file="CurrentTaggingState.cs" company="OpenCensus Authors">
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

    public sealed class CurrentTaggingState
    {

        private TaggingState currentState = TaggingState.ENABLED;
        private readonly object lck = new object();
        private bool isRead;

        public TaggingState Value
        {
            get
            {
                lock (lck)
                {
                    isRead = true;
                    return Internal;
                }
            }
        }

        public TaggingState Internal
        {
            get
            {
                lock (lck)
                {
                    return currentState;
                }
            }
        }

        // Sets current state to the given state.
        internal void Set(TaggingState state)
        {
            lock (lck)
            {
                if (isRead)
                {
                    throw new InvalidOperationException("State was already read, cannot set state.");
                }

                currentState = state;
            }
        }
    }
}
