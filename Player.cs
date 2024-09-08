using Godot;
using System;

public partial class Player : Sprite2D {

    public const string InputPlayerMoveUp = "PlayerMoveUp";
    public const string InputPlayerMoveDown = "PlayerMoveDown";
    public const string InputPlayerMoveLeft= "PlayerMoveLeft";
    public const string InputPlayerMoveRight= "PlayerMoveRight";

    public float Speed = 60;
    public float MouseInputLimit = 20;

    Main Main;

    public override void _Ready() {
        Main = (Main)GetParent();
    }

    public override void _Process(double delta) {
        var movement = Main.Mouse
            .CalcMovementAndReset()
            .Limit(MouseInputLimit) 
            * (float)delta * Speed;

        if(movement.X < 0 != FlipH)
            FlipH = !FlipH;

        Position += movement;
    }

    Vector2 GetPlayerInput() => new Vector2(
        x: (Input.IsActionPressed(InputPlayerMoveRight) ? 1 : 0) +
           (Input.IsActionPressed(InputPlayerMoveLeft) ? -1 : 0),
        y: (Input.IsActionPressed(InputPlayerMoveUp) ? -1 : 0) +
           (Input.IsActionPressed(InputPlayerMoveDown) ? 1 : 0)
    ).Normalized();
}
