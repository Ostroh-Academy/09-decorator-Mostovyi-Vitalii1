using System;

// Базовий клас VideoStream
abstract class VideoStream
{
    public abstract void Show();
}

// Конкретна реалізація VideoStream
class BasicVideoStream : VideoStream
{
    public override void Show()
    {
        Console.WriteLine("Відтворення базового відео стріму");
    }
}

// Декоратор для графічних оверлеїв
abstract class VideoOverlayDecorator : VideoStream
{
    protected VideoStream _videoStream;

    public VideoOverlayDecorator(VideoStream videoStream)
    {
        _videoStream = videoStream;
    }

    public override void Show()
    {
        _videoStream.Show();
    }
}

// Конкретний декоратор для додавання логотипу
class LogoOverlayDecorator : VideoOverlayDecorator
{
    public LogoOverlayDecorator(VideoStream videoStream) : base(videoStream) { }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Додано логотип");
    }
}

// Конкретний декоратор для додавання нижнього титру
class TitleOverlayDecorator : VideoOverlayDecorator
{
    public TitleOverlayDecorator(VideoStream videoStream) : base(videoStream) { }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Додано нижній титр");
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        VideoStream basicStream = new BasicVideoStream();
        VideoStream decoratedStream = new LogoOverlayDecorator(basicStream);
        decoratedStream = new TitleOverlayDecorator(decoratedStream);
        decoratedStream.Show();
    }
}
