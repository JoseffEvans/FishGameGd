using Godot;
using System;

public partial class Camera : Camera2D {

    Main Main;
    float CameraSpeed = 100f;

    public override void _Ready() {
        Main = (Main)GetParent();
    }

    public override void _Process(double delta) {
        var diff = (Main.Player.Position - Position);
        var speed = ((float)delta * (diff.Length().Pow(2)*2)) /250;
        Position += diff.Normalized() * speed;
    }
}
