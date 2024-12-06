using Content.Shared.Actions;
using Robust.Shared.GameStates;

namespace Content.Shared._Cats.Overlays;

[RegisterComponent, NetworkedComponent]
public sealed partial class ThermalVisionComponent : SwitchableOverlayComponent
{
    public override string? ToggleAction { get; set; } = "ToggleThermalVision";

    public override Color Color { get; set; } = Color.White; 
}

public sealed partial class ToggleThermalVisionEvent : InstantActionEvent;
