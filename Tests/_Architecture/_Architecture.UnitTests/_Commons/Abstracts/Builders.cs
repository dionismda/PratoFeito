namespace _Architecture.UnitTests._Commons.Abstracts;

public abstract class Builders<TBuilder, TObject>
    where TBuilder : new()
    where TObject : class
{
    protected Faker Bogus { get; }
    protected Faker<TObject> Builder { get; }

    public static TBuilder New()
    {
        return new TBuilder();
    }

    protected Builders()
    {
        Bogus = new Faker(locale: "pt_BR");
        Builder = new Faker<TObject>(locale: "pt_BR");
    }

    public abstract TObject Build();
}
