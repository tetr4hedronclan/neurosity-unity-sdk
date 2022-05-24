using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Linq;


namespace NeurositySDK
{
    public class CalmHandler : IMetricHandler
    {
        public Metrics Metric => Metrics.Awareness;
        public Action<float> OnCalmUpdated { get; set; }
        public string Label => "calm";

        public void Handle(string json)
        {
            BaseMetric metric = JsonConvert.DeserializeObject<BaseMetric>(json);
            var probability = metric.Probability;


            if(probability != null)
            {
                Debug.Log($"Handling {metric.Label} : Prediction: {probability}");
                OnCalmUpdated?.Invoke(probability);
            }
        }
    }
}