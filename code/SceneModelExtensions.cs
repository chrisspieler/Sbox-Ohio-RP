using Sandbox;
using System.Collections.Generic;
using System;

namespace OhioRP;

public static class SceneModelExtensions
{
	public static void UpdateLipsync(this SceneModel sceneModel, float elapsedTime, List<PhonemeData> phonemes )
	{
		AddVisemes( sceneModel, phonemes, elapsedTime, 0.08f );
	}

	private static void AddVisemes( SceneModel sceneModel, List<PhonemeData> phonemes, float t, float dt )
	{
		sceneModel.Morphs.ResetAll();

		int pcount = phonemes.Count;
		for ( int k = 0; k < pcount; k++ )
		{
			var phoneme = phonemes[k];
			float phonemeStartTime = phoneme.Start;
			float phonemeEndTime = phoneme.End;

			if ( t > phonemeStartTime && t < phonemeEndTime )
			{
				if ( k < pcount - 1 )
				{
					var next = phonemes[k + 1];
					float nextStartTime = next.Start;
					float nextEndTime = next.End;

					// Determine the blend length based on the current and next phoneme
					if ( nextStartTime == phonemeEndTime )
					{
						// No gap, increase the blend length to the end of the next phoneme
						dt = MathF.Max( dt, MathF.Min( nextEndTime - t, phonemeEndTime - phonemeStartTime ) );
					}
					else
					{
						// Dead space, increase the blend length to the start of the next phoneme
						dt = MathF.Max( dt, MathF.Min( nextStartTime - t, phonemeEndTime - phonemeStartTime ) );
					}
				}
				else
				{
					// Last phoneme in list, increase the blend length to the length of the current phoneme
					dt = MathF.Max( dt, phonemeEndTime - phonemeStartTime );
				}
			}

			float t1 = (phonemeStartTime - t) / dt;
			float t2 = (phonemeEndTime - t) / dt;

			// Check for overlap of the current time t with the phoneme duration
			if ( t1 < 1.0f && t2 > 0.0f )
			{
				t1 = MathF.Max( t1, 0 );
				t2 = MathF.Min( t2, 1 );

				float scale = (t2 - t1);
				AddViseme( sceneModel, phoneme.Phoneme, scale );
			}
		}
	}

	private static void AddViseme( SceneModel sceneModel, int phoneme, float scale )
	{
		if ( !sceneModel.IsValid() )
			return;

		var model = sceneModel.Model;
		var morphs = sceneModel.Morphs;

		for ( int i = 0; i < model.MorphCount; ++i )
		{
			var weight = model.GetPhonemeMorph( phoneme, i );
			if ( weight <= 0.0f )
				continue;

			weight *= scale;
			morphs.Set( i, morphs.Get( i ) + weight );
		}
	}

	[GameEvent.Client.Frame]
	public static void OnFrame()
	{
		Log.Info( "On frame!" );
	}
}
