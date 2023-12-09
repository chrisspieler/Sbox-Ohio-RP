using Sandbox.Services;
using Sandbox;
using System;
using Sandbox.UI;
using System.Collections.Generic;

namespace OhioRP;

public partial class OhioHud
{
	public int TotalSpins { get; set; }
	public bool PlayerIsFurry { get; set; }

	protected override int BuildHash()
	{
		return HashCode.Combine( TotalSpins, PlayerIsFurry );
	}
}
