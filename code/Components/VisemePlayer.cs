using Sandbox;
using System.Collections.Generic;
using System.Linq;

namespace OhioRP;

public class VisemePlayer : Component
{
	[Property] public SkinnedModelRenderer SingerModel { get; set; }

	private SingerTrack _track;
	private TimeSince _trackStartTime { get; set; }

	protected override void OnUpdate()
	{
		var phonemes = new List<PhonemeData>();
		if ( _track != null )
		{
			phonemes = _track.Phonemes.ToList();
		}

		SingerModel.SceneModel.UpdateLipsync( _trackStartTime, phonemes );
	}

	public void PlayTrack( SingerTrack track )
	{
		_track = track;
		_trackStartTime = 0f;
	}
}
