using Sandbox;
using Sandbox.Utility;
using System;

namespace OhioRP;

public class Singer : Component
{
	[Property] public GameObject SoundSource { get; set; }
	[Property, Range(0, 1)] public float FakeOcclusionScale { get; set; } = 0.8f;

	public event EventHandler TrackComplete;

	private SingerTrack _track;
	private SoundHandle _hSndVocals;
	private SoundHandle _hSndBacking;
	private bool _wasPlaying;

	protected override void OnUpdate()
	{
		if ( _wasPlaying && _hSndVocals.IsStopped && _hSndBacking.IsStopped )
		{
			_wasPlaying = false;
			TrackComplete?.Invoke( this, EventArgs.Empty );
		}
		var listenerDir = Sound.Listener.Rotation.Forward;
		var soundDir = SoundSource.Transform.Rotation.Forward;
		var normalDot = ( listenerDir.Dot( soundDir ) + 1 ) / 2;
		var occlusion = Easing.QuadraticInOut( normalDot ) * FakeOcclusionScale;
		_hSndVocals.Volume = 1 - occlusion;
	}

	public void PlayTrack( SingerTrack track )
	{
		_track = track;
		PlayTrack();
	}

	private void PlayTrack()
	{
		_hSndVocals.Stop( true );
		_hSndBacking.Stop( true );
		
		if ( _track == null )
			return;

		_hSndVocals = Sound.Play( _track.VocalTrack, SoundSource.Transform.Position );
		_hSndBacking = Sound.Play( _track.BackingTrack, SoundSource.Transform.Position );
		_wasPlaying = true;
	}
}
