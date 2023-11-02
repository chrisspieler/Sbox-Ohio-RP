using Sandbox;
using Sandbox.Services;
using Sandbox.UI;
using System;
using System.Collections.Generic;

namespace OhioRP;
public partial class CitizenPanelScene : ScenePanel
{
	public event EventHandler OnSpin;
	public float SpinDegressPerSecond { get; set; } = 100f;

    public SceneModel CitizenModel { get; private set; }
	public List<PhonemeData> Phonemes { get; set; }
	public Sound CurrentSound { get; set; }

    public CitizenPanelScene()
    {
        AddClass("avatar");
        InitScene();
    }

    private void InitScene()
    {
		//Initialize Scene Settings
		RenderOnce = false;

        //Initialize World
        World?.Delete();
        World = new();

        //Initialize Lighting
        _ = new SceneLight(World, Vector3.Up * 128 + Vector3.Forward * 60, 100, new Color(1f, 0.85f, 0.71f) * 16.0f);

        //Initialize Citizen
        CitizenModel = new SceneModel(World, "models/citizen/citizen.vmdl", Transform.Zero);
        CitizenModel.SetAnimGraph("models/citizen/citizen.vanmgrph");
        CitizenModel.Update(RealTime.Delta);

		UpdateCamera();
	}

    [Event.Hotload]
    private void Update()
    {
        Cleanup();
        InitScene();
    }

    private void Cleanup()
    {
        CitizenModel?.Delete();
        CitizenModel = null;
    }

	private void UpdateCamera()
	{
		var eyePosition = new Vector3( 0, 0, 60 );
		var offset = new Vector3( 72, -20, -80 );

		Camera.Position = eyePosition + offset;
		Camera.Rotation = Rotation.LookAt( (eyePosition - Camera.Position).Normal, Vector3.Up );
		Camera.FieldOfView = 20f;
		Camera.ZNear = 0.1f;
		Camera.ZFar = 512.0f;
	}

	public float CitizenYaw { get; private set; } = 0f;

    public override void Tick()
    {
		UpdateCamera();

		CitizenYaw += SpinDegressPerSecond * RealTime.Delta;
		bool isPostLoop = CitizenYaw >= 360f;
		if ( isPostLoop )
		{
			OnSpin?.Invoke( this, null );
		}
		CitizenYaw %= 360f;
		CitizenModel.Rotation = CitizenModel.Rotation.Angles()
			.WithYaw( CitizenYaw )
			.ToRotation();
		if (CurrentSound.IsPlaying && Phonemes != null )
		{
			CitizenModel.UpdateLipsync( CurrentSound, Phonemes );
		}
		CitizenModel.Update( RealTime.Delta );
	}
}
