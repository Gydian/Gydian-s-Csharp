using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseShape
{
    public string type = null;
    public const double PI = 3.14;
    public abstract string draw();
    public void erase()
    {
        Console.WriteLine("擦除图形");
    }
    public double area()
    {
        double s = 0,r=0,x=0,y=0;
        string p = "";
        switch(type)
        {
            case "三角形":
                Console.Write("输入底边:  ");
                p = Console.ReadLine();
                x = Double.Parse(p);
                Console.Write("输入高:  ");
                p = Console.ReadLine();
                y = Double.Parse(p);
                s = (x * y)/2;
                Console.WriteLine("三角形面积为：");
                break;
            case "圆形":
                Console.Write("please input r:  ");
                p = Console.ReadLine();
                r = Double.Parse(p);
                s = PI * r * r;
                Console.WriteLine("圆形面积为：");
                break;
            case "正方形":
                Console.Write("please input a:  ");
                p = Console.ReadLine();
                r = Double.Parse(p);
                s = r * r;
                Console.WriteLine("正方形面积为：");
                break;
            case "矩形":
                Console.Write("please input x:  ");
                p = Console.ReadLine();
                x= Double.Parse(p);
                Console.Write("please input y:  ");
                p = Console.ReadLine();
                y = Double.Parse(p);
                s = x * y;
                Console.WriteLine("矩形面积为：");
                break;
        }
        return s;
    }
}
public class triangle:BaseShape
{
    public override string draw()
    {
        return "画三角形";
    }
}
public class circle : BaseShape
{
    public override string draw()
    {
        return "画圆形";
    }
}
public class rectangle : BaseShape
{
    public override string draw()
    {
        return "画正方形";
    }
}
public class square : BaseShape
{
    public override string draw()
    {
       return"画矩形";
    }
}
public class ShapeFactory
{
   public static BaseShape createShape(string type)
    {
        BaseShape shape = null;
        switch (type)
        {
            case "三角形":
                shape = new triangle();
                shape.type = type;
                break;
            case "圆形":
                shape = new circle();
                shape.type = type;
                break;
            case "正方形":
                shape = new rectangle();
                shape.type = type;
                break;
            case "矩形":
                shape = new square();
                shape.type = type;
                break;
        }
        return shape;
    }
}


namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BaseShape triangle = ShapeFactory.createShape("三角形");
                BaseShape circle = ShapeFactory.createShape("圆形");
                BaseShape rectangle = ShapeFactory.createShape("正方形");
                BaseShape square = ShapeFactory.createShape("矩形");
                if (triangle != null)
                {

                    Console.WriteLine(triangle.draw());
                    Console.WriteLine(triangle.area());
                }
                if (circle!=null)
                {

                    Console.WriteLine(circle.draw());                    
                    Console.WriteLine(circle.area());
                }
                if (rectangle != null)
                {

                    Console.WriteLine(rectangle.draw());                   
                    Console.WriteLine(rectangle.area());
                }
                if (square!=null)
                {
                    Console.WriteLine(square.draw());                    
                    Console.WriteLine(square.area());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("您输入有错：" + ex.Message);
            }
        }
    }
}
