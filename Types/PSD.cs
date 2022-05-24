﻿using Newtonsoft.Json;

namespace NeurositySDK
{
    public class PSD
    {
        public int[] Freqs { get; set; }
        [JsonProperty("PSD")]
        public decimal[][] PSDValues { get; set; }
        public PSDInfo Info { get; set; }
        public string Label { get; set; }
    }
}