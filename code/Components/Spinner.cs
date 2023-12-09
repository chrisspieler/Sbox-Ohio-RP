using Sandbox;
using System;

namespace OhioRP;

public class Spinner : Component
{
	[Property] public Angles DegreesPerSecond { get; set; }
	public event EventHandler YawSpinComplete;
	private float _yawSpinProgress;

	protected override void OnUpdate()
	{
		var rotationDelta = DegreesPerSecond * Time.Delta;
		_yawSpinProgress += rotationDelta.yaw;
		if ( _yawSpinProgress >= 360f )
		{
			YawSpinComplete?.Invoke( this, EventArgs.Empty );
			_yawSpinProgress = 0f;
		}
		Transform.Rotation *= rotationDelta.ToRotation();
	}
}
