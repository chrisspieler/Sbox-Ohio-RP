using Sandbox;

namespace OhioRP;

[GameResource("Singer Track", "song", "A song including a vocal track, backing track, and phonemes.")]
public class SingerTrack : GameResource
{
	public SoundEvent VocalTrack { get; set; }
	public SoundEvent BackingTrack { get; set; }
	public PhonemeData[] Phonemes { get; set; }
}
