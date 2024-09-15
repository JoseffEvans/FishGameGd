using Godot;
using System;

public partial class Player : Sprite2D {

    public const string InputPlayerMoveUp = "PlayerMoveUp";
    public const string InputPlayerMoveDown = "PlayerMoveDown";
    public const string InputPlayerMoveLeft= "PlayerMoveLeft";
    public const string InputPlayerMoveRight= "PlayerMoveRight";

    public float Speed = 60;
    public float MouseInputLimit = 50;
    public Vector2 Velocity;

    Main Main;

    public override void _Ready() {
        Main = (Main)GetParent();
        Velocity = new Vector2(0,0);
    }

    public override void _Process(double delta) {
        var mouse = Main.Mouse
            .CalcMovementAndReset()
            .Limit(MouseInputLimit) 
            * ((float)delta * Speed);

        Velocity += mouse;
        Velocity *= 0.8f;

        if(Velocity.X < 0 != FlipH)
            FlipH = !FlipH;

        Position += Velocity;
        Rotation = Velocity.Normalized().Y * (FlipH ? -1 : 1);
    }

    Vector2 GetPlayerInput() => new Vector2(
        x: (Input.IsActionPressed(InputPlayerMoveRight) ? 1 : 0) +
           (Input.IsActionPressed(InputPlayerMoveLeft) ? -1 : 0),
        y: (Input.IsActionPressed(InputPlayerMoveUp) ? -1 : 0) +
           (Input.IsActionPressed(InputPlayerMoveDown) ? 1 : 0)
    ).Normalized();
}
