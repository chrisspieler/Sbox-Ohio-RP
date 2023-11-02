﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhioRP
{
	public struct SoundMetadata
	{
		public PhonemeData[] Phonemes { get; set; }
		internal static string RawJson = @"{
  ""phonemes"": [
    {
      ""phoneme"": 106,
      ""start"": 0.015,
      ""end"": 0.134
    },
    {
      ""phoneme"": 117,
      ""start"": 0.116,
      ""end"": 0.441
    },
    {
      ""phoneme"": 115,
      ""start"": 0.421,
      ""end"": 0.592
    },
    {
      ""phoneme"": 112,
      ""start"": 0.611,
      ""end"": 0.651
    },
    {
      ""phoneme"": 618,
      ""start"": 0.647,
      ""end"": 0.889
    },
    {
      ""phoneme"": 110,
      ""start"": 0.884,
      ""end"": 1.009
    },
    {
      ""phoneme"": 109,
      ""start"": 1.004,
      ""end"": 1.128
    },
    {
      ""phoneme"": 105,
      ""start"": 1.127,
      ""end"": 1.43
    },
    {
      ""phoneme"": 633,
      ""start"": 1.427,
      ""end"": 1.524
    },
    {
      ""phoneme"": 593,
      ""start"": 1.524,
      ""end"": 1.608
    },
    {
      ""phoneme"": 105,
      ""start"": 1.604,
      ""end"": 1.856
    },
    {
      ""phoneme"": 116,
      ""start"": 1.854,
      ""end"": 1.944
    },
    {
      ""phoneme"": 633,
      ""start"": 1.931,
      ""end"": 2.031
    },
    {
      ""phoneme"": 111,
      ""start"": 2.02,
      ""end"": 2.265
    },
    {
      ""phoneme"": 110,
      ""start"": 2.256,
      ""end"": 2.286
    },
    {
      ""phoneme"": 100,
      ""start"": 2.278,
      ""end"": 2.378
    },
    {
      ""phoneme"": 98,
      ""start"": 2.44,
      ""end"": 2.479
    },
    {
      ""phoneme"": 101,
      ""start"": 2.469,
      ""end"": 2.633
    },
    {
      ""phoneme"": 98,
      ""start"": 2.632,
      ""end"": 2.668
    },
    {
      ""phoneme"": 105,
      ""start"": 2.663,
      ""end"": 2.785
    },
    {
      ""phoneme"": 633,
      ""start"": 2.777,
      ""end"": 2.848
    },
    {
      ""phoneme"": 593,
      ""start"": 2.843,
      ""end"": 3.046
    },
    {
      ""phoneme"": 105,
      ""start"": 2.888,
      ""end"": 3.266
    },
    {
      ""phoneme"": 116,
      ""start"": 3.259,
      ""end"": 3.29
    },
    {
      ""phoneme"": 633,
      ""start"": 3.342,
      ""end"": 3.561
    },
    {
      ""phoneme"": 111,
      ""start"": 3.404,
      ""end"": 3.69
    },
    {
      ""phoneme"": 110,
      ""start"": 3.686,
      ""end"": 3.74
    },
    {
      ""phoneme"": 100,
      ""start"": 3.731,
      ""end"": 3.781
    },
    {
      ""phoneme"": 108,
      ""start"": 3.772,
      ""end"": 3.865
    },
    {
      ""phoneme"": 593,
      ""start"": 3.85,
      ""end"": 3.9240003
    },
    {
      ""phoneme"": 105,
      ""start"": 3.915,
      ""end"": 4.015
    },
    {
      ""phoneme"": 107,
      ""start"": 4.011,
      ""end"": 4.11
    },
    {
      ""phoneme"": 652,
      ""start"": 4.099,
      ""end"": 4.157
    },
    {
      ""phoneme"": 633,
      ""start"": 4.145,
      ""end"": 4.232
    },
    {
      ""phoneme"": 603,
      ""start"": 4.22,
      ""end"": 4.459
    },
    {
      ""phoneme"": 107,
      ""start"": 4.435,
      ""end"": 4.481
    },
    {
      ""phoneme"": 603,
      ""start"": 4.472,
      ""end"": 4.672
    },
    {
      ""phoneme"": 100,
      ""start"": 4.664,
      ""end"": 4.704
    },
    {
      ""phoneme"": 98,
      ""start"": 4.696,
      ""end"": 4.754
    },
    {
      ""phoneme"": 101,
      ""start"": 4.732,
      ""end"": 4.979
    },
    {
      ""phoneme"": 98,
      ""start"": 4.968,
      ""end"": 5.017
    },
    {
      ""phoneme"": 105,
      ""start"": 5.008,
      ""end"": 5.093
    },
    {
      ""phoneme"": 633,
      ""start"": 5.091,
      ""end"": 5.2
    },
    {
      ""phoneme"": 593,
      ""start"": 5.193,
      ""end"": 5.364
    },
    {
      ""phoneme"": 105,
      ""start"": 5.35,
      ""end"": 5.536
    },
    {
      ""phoneme"": 116,
      ""start"": 5.528,
      ""end"": 5.582
    },
    {
      ""phoneme"": 633,
      ""start"": 5.601,
      ""end"": 5.701
    },
    {
      ""phoneme"": 111,
      ""start"": 5.68,
      ""end"": 5.974
    },
    {
      ""phoneme"": 110,
      ""start"": 5.964,
      ""end"": 6.018
    },
    {
      ""phoneme"": 100,
      ""start"": 6.006,
      ""end"": 6.051
    },
    {
      ""phoneme"": 633,
      ""start"": 6.065,
      ""end"": 6.133
    },
    {
      ""phoneme"": 111,
      ""start"": 6.14,
      ""end"": 6.438
    },
    {
      ""phoneme"": 110,
      ""start"": 6.433,
      ""end"": 6.482
    },
    {
      ""phoneme"": 100,
      ""start"": 6.451,
      ""end"": 6.523
    },
    {
      ""phoneme"": 633,
      ""start"": 6.515,
      ""end"": 6.609
    },
    {
      ""phoneme"": 111,
      ""start"": 6.604,
      ""end"": 7.017
    },
    {
      ""phoneme"": 110,
      ""start"": 7.011,
      ""end"": 7.045
    },
    {
      ""phoneme"": 100,
      ""start"": 7.041,
      ""end"": 7.121
    }
  ]
}";
	}
}
