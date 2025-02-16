﻿using System;

namespace UnityEngine.Perception.Randomization.Samplers
{
    /// <summary>
    /// Returns normally distributed random values bounded within a specified range
    /// https://en.wikipedia.org/wiki/Truncated_normal_distribution
    /// </summary>
    [Serializable]
    public class NormalSampler : ISampler
    {
        /// <summary>
        /// The mean of the normal distribution to sample from
        /// </summary>
        public float mean;

        /// <summary>
        /// The standard deviation of the normal distribution to sample from
        /// </summary>
        public float standardDeviation;

        /// <summary>
        /// A range bounding the values generated by this sampler
        /// </summary>
        public FloatRange range;

        /// <summary>
        /// Constructs a normal distribution sampler
        /// </summary>
        public NormalSampler()
        {
            range = new FloatRange(-1f, 1f);
            mean = 0;
            standardDeviation = 1;
        }

        /// <summary>
        /// Constructs a normal distribution sampler
        /// </summary>
        /// <param name="min">The smallest value contained within the range</param>
        /// <param name="max">The largest value contained within the range</param>
        /// <param name="mean">The mean of the normal distribution to sample from</param>
        /// <param name="standardDeviation">The standard deviation of the normal distribution to sample from</param>
        public NormalSampler(
            float min, float max, float mean, float standardDeviation)
        {
            range = new FloatRange(min, max);
            this.mean = mean;
            this.standardDeviation = standardDeviation;
        }

        /// <summary>
        /// Generates one sample
        /// </summary>
        /// <returns>The generated sample</returns>
        public float Sample()
        {
            var rng = SamplerState.CreateGenerator();
            return SamplerUtility.TruncatedNormalSample(
                rng.NextFloat(), range.minimum, range.maximum, mean, standardDeviation);
        }

        /// <summary>
        /// Validates that the sampler is configured properly
        /// </summary>
        public void Validate()
        {
            range.Validate();
        }
    }
}
