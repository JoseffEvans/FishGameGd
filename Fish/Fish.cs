using Godot;
using System;

public partial class Fish : Sprite2D {
    Main Main;
    SpawnInfo Spawn;

    public float Speed = 300;
    
    public override void _Ready() {
        Main = (Main)GetParent();
        Spawn = Main.Spawn.LeftRightSpawn(this);
        Position = Spawn.SpawnPoint;
    }

    public override void _Process(double delta) {
        var movement = (Spawn.Goal - Position).Normalized() * (float)delta * Speed;

        if(movement.X < 0 != FlipH) 
            FlipH = !FlipH;

        Position += movement;

        if(
            Position.DistanceTo(Spawn.Goal) < 100 || 
            Position.DistanceTo(Main.Player.Position) < 100
        ) 
            QueueFree();
    }
}
