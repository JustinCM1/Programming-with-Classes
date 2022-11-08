using Raylib_cs;
using System.Numerics;

interface Shape {

    public string Name();
    public double Area();
    public Rectangle CollisionRect();
}

class GameObject {
    public Vector2 Position { get; set; } = new Vector2(0, 0);
    public Vector2 Velocity { get; set; } = new Vector2(0, 0);

    virtual public void Draw() {
        // Base game objects do not have anything to draw
    }

    virtual public void Move() {
        Vector2 NewPosition = Position;
        NewPosition.X += Velocity.X;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;
    }
}

class ColoredObject: GameObject {
    public Color Color { get; set; }

    public ColoredObject(Color color) {
        Color = color;
    }
}

class GameSquare: ColoredObject, Shape {
    int Side;

    public GameSquare(int side, Color color): base(color) {
        Side = side;
    }

    public string Name() {
        return "Square"; 
    }

    public double Area() {
        return Side * Side; 
    }

    public Rectangle CollisionRect() {
        return new Rectangle(Position.X, Position.Y, Side, Side);
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Side, Side, Color);
    }
}

class GameRectangle: ColoredObject {

    int Width;
    int Height;

    public GameRectangle(int w, int h, Color color): base(color) {
        Width = w;
        Height = h;
    }

    override public void Draw() {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, Width, Height, Color);
    }
}

class GameCircle: ColoredObject {

    int Radius;
    public GameCircle(int radius, Color color): base(color) {
        Radius = radius;
    }

    override public void Draw() {
        Raylib.DrawCircleV(Position, Radius, Color);
    }
}

class GameText: ColoredObject {
    string Text;

    public GameText(string text, Color color): base(color) {
        Text = text;
    }

    public override void Draw() {
        Raylib.DrawText(this.Text, (int)Position.X, (int)Position.Y, 20, this.Color);
    }
}