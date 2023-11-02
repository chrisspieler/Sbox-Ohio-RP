using Sandbox.Services;
using Sandbox;
using System;
using Sandbox.UI;
using System.Collections.Generic;
using System.Linq;

namespace OhioRP;

public partial class OhioHud
{
	public CitizenPanelScene ScenePanel { get; set; }
	public Panel FurryText { get; set; }
	public int TotalSpins { get; set; }
	public int CurrentSessionSpins { get; set; }
	public Sound LipsyncSound { get; set; }
	public MusicPlayer MusicPlayer { get; set; }
	private List<PhonemeData> Phonemes { get; set; }

	public OhioHud()
	{
		TotalSpins = (int)Stats
			.LocalPlayer
			.Get( "spin_total" )
			.Value;
	}

	protected override void OnAfterTreeRender( bool firstTime )
	{
		base.OnAfterTreeRender( firstTime );

		if ( !firstTime )
			return;

		Action startLipsyncSound = () =>
		{
			LipsyncSound = Sound.FromScreen( "isolatedvocals" );
			ScenePanel.CurrentSound = LipsyncSound;
			LipsyncSound.SetVolume( 0.6f );
		};
		MusicPlayer = MusicPlayer.Play( FileSystem.Mounted, "sfx/IsolatedInstrumental.mp3" );
		MusicPlayer.Volume = 0.5f;
		MusicPlayer.Repeat = true;
		MusicPlayer.OnFinished = () => LipsyncSound.Stop();
		MusicPlayer.OnRepeated = startLipsyncSound;
		startLipsyncSound();

		ScenePanel.OnSpin += (_,_) => OnSpin();
		var soundMetadata = Json.Deserialize<SoundMetadata>( SoundMetadata.RawJson );
		ScenePanel.Phonemes = soundMetadata.Phonemes.ToList();
	}

	public override void Tick()
	{
		base.Tick();

		if ( LipsyncSound.IsPlaying )
		{
			var shiftedYaw = (ScenePanel.CitizenYaw + 120f) % 360f;
			LipsyncSound.SetVolume( (MathF.Sin( shiftedYaw / 360f * MathF.Tau) + 1) / 2 );
		}
	}

	private void OnSpin()
	{
		TotalSpins++;
		CurrentSessionSpins++;
		Stats.Increment("spin_total", 1.0 );
		StateHasChanged();

		if (CurrentSessionSpins >= 10 )
		{
			FurryText?.SetClass( "visible", true );
		}
	}

	public override void Delete( bool immediate = true )
	{
		Stats.Flush();
		base.Delete( immediate );
	}
}
