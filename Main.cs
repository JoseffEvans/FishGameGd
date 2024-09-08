using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D {

    public const string InputExit = "Exit";

    [Export]
    public Player Player;
    List<Sprite2D> Fish;

    float SecondCounter;
    Random Random;

    // Servics
    public Resources Resources;
    public Spawn Spawn;
    public MouseControl Mouse;

    public override void _Ready() {
        SecondCounter = 0;
        Fish = new List<Sprite2D>();
        Random = new Random();
        Resources = new Resources();
        Spawn = new Spawn(this);
        Mouse = new MouseControl(this);
    }

    public override void _Process(double delta) {
        var delatF = (float)delta;

        if(Input.IsActionPressed(InputExit))
            GetTree().Quit();

        SecondCounter += delatF;
        if(SecondCounter >= 0.01) {
            SecondCounter = 0;
            AddChild(Resources.NewEnemy());
            AddChild(Resources.NewFish());
        }
    }
}
