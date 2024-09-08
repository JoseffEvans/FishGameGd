using Godot;

public partial class Fps : Label {
    public override void _Process(double delta) {
        Text = $"FPS: {1 / delta:F0}";
    }
}
