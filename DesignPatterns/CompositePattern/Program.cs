using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawable picture = new ComplexShape("picture");
            IDrawable sky = new ComplexShape("Sky");

            IDrawable cloud = new ComplexShape("Cloud");
            IDrawable circle = new Circle();
            cloud.AddChild(circle);
            cloud.AddChild(circle);
            cloud.AddChild(circle);

            IDrawable cloud2 = new ComplexShape("Cloud");
            cloud2.AddChild(circle);
            cloud2.AddChild(circle);
            cloud2.AddChild(circle);

            sky.AddChild(cloud);
            sky.AddChild(cloud2);

            IDrawable ground = new ComplexShape("Ground");
            ground.AddChild(new SimpleShape("Line"));

            picture.AddChild(sky);
            picture.AddChild(ground);

            picture.Draw(0);
        }
    }
}
