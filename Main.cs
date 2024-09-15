using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D {

    public const string InputExit = "Exit";

    [Export]
    public Camera Camera;
    [Export]
    public Player Player;
    float SecondCounter;

    // Servics
    public Resources Resources;
    public Spawn Spawn;
    public MouseControl Mouse;

    public override void _Ready() {
        SecondCounter = 0;
        Resources = new Resources();
        Spawn = new Spawn(this);
        Mouse = new MouseControl(this);
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    public override void _Process(double delta) {
        var delatF = (float)delta;

        if(Input.IsActionPressed(InputExit))
            GetTree().Quit();

        SecondCounter += delatF;
        if(SecondCounter >= 0.01) {
            SecondCounter = 0;
            //AddChild(Resources.NewEnemy());
            //AddChild(Resources.NewFish());
            AddChild(Resources.NewOrangeFish());
        }
    }
}
