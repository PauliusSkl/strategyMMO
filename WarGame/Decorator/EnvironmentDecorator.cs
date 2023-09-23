namespace WarGame.Forms.Decorator;

public abstract class EnvironmentDecorator : EnvironmentComponent
{
    protected EnvironmentComponent _decorator;
    public void SetComponent(EnvironmentComponent decorator)
    {
        _decorator = decorator;
    }
    public override Image GetImage()
    {
        return _decorator.GetImage();
    }
}
