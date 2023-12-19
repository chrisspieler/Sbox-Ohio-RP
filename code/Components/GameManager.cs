using Sandbox;
using Sandbox.Diagnostics;
using Sandbox.Services;
using System;
using System.Linq;

namespace OhioRP;

public class GameManager : Component
{
	[Property] public Singer Singer { get; set; }
	[Property] public Spinner Spinner { get; set; }
	[Property] public VisemePlayer VisemePlayer { get; set; }
	[Property] public OhioHud OhioHud { get; set; }
	public int TotalSpins { get; private set; }
	public int SessionSpins { get; private set; }

	private SingerTrack _currentTrack;


	protected override void OnStart()
	{
		TotalSpins = (int)Stats
			.LocalPlayer
			.Get( "spin_total" )
			.Value;
		OhioHud.TotalSpins = TotalSpins;
		Spinner.YawSpinComplete += OnSpin;
		Singer.TrackComplete += ( _, _ ) => PlaySong( _currentTrack );
		var singerTrack = ResourceLibrary.GetAll<SingerTrack>().FirstOrDefault();
		if ( singerTrack == null )
		{
			Log.Error( "ResourceLibrary could not find any resource of type SingerTrack." );
		}
		_currentTrack = singerTrack;
		PlaySong( _currentTrack );
	}

	private void OnSpin( object sender, EventArgs args )
	{
		TotalSpins++;
		SessionSpins++;
		Stats.Increment( "spin_total", 1.0 );
		OhioHud.TotalSpins = TotalSpins;
		OhioHud.PlayerIsFurry = SessionSpins >= 10;
	}

	private void PlaySong( SingerTrack track )
	{
		Singer.PlayTrack( track );
		VisemePlayer.PlayTrack( track );
	}

	protected override void OnDestroy()
	{
		Stats.Flush();
	}
}
