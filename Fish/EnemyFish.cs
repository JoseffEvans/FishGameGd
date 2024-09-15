using Godot;

public partial class EnemyFish : Sprite2D {

    Main Main;
    float Speed;
    SpawnInfo Spawn;

    public override void _Ready() {
        Main = (Main)GetParent();
        Speed = 100;
        Spawn = Main.Spawn.LeftRightSpawn(this);
        Position = Spawn.SpawnPoint;
    }

    public override void _Process(double delta) {
        var movement = (Main.Player.Position - Position).Normalized()
            * (Speed * (float)delta);

        if(movement.X < 0 != FlipH)
            FlipH = !FlipH;

        Position += movement;

        if(Position.DistanceTo(Main.Player.Position) < 100)
            QueueFree();
    }
}
 