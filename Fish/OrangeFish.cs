using Godot;
using System;

public partial class OrangeFish : Sprite2D {
    Main Main;
    Random Random;

    public override void _Ready() {
        Main = (Main)GetParent();
        Random = new Random();

        var distance = Main.Camera.GetViewport().GetVisibleRect().Size.X 
            * (float)(Random.NextDouble() /*+ 1 * 3*/);

        var direction = new Vector2(
            (float)Random.NextDouble() * 2 - 1,
            (float)Random.NextDouble() * 2 - 1
        ).Normalized();

        Position = Main.Player.Position + (direction * distance);
    }

    public override void _Process(double delta) {}
}
