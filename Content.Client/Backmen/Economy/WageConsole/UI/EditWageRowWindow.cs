﻿using Content.Client.UserInterface.Controls;
using Content.Shared.Backmen.Economy.WageConsole;
using Content.Shared.Backmen.Reinforcement;
using Content.Shared.FixedPoint;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Backmen.Economy.WageConsole.UI;

[GenerateTypedNameReferences]
public sealed partial class EditWageRowWindow : FancyWindow
{
    public event Action<uint, FixedPoint2> OnSaveEditedWageRow = (u, point2) => { };
    public UpdateWageRow State { get; set; }

    public EditWageRowWindow(OpenEditWageConsoleUi state)
    {
        RobustXamlLoader.Load(this);
        if (state.Row is null)
        {
            Close();
            State = default!;
            return;
        }
        State = state.Row;

        FromName.Text = Loc.GetString("wageconsole-row", ("name", State.FromName), ("account", State.FromAccount));
        ToName.Text = Loc.GetString("wageconsole-row", ("name", State.ToName), ("account", State.ToAccount));
        Wage.Text = State.Wage.ToString();
        SaveBtn.OnPressed += SaveBtnOnOnPressed;

        OpenCentered();
    }

    private void SaveBtnOnOnPressed(BaseButton.ButtonEventArgs obj)
    {
        if (Double.TryParse(Wage.Text, out var wage))
        {
            OnSaveEditedWageRow.Invoke(State.Id, wage);
        }
    }
}