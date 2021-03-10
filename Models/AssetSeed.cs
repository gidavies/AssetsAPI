using System;
using System.Linq;

public static class AssetSeed
{
  public static void InitData(AssetContext context)
  {
    var rnd = new Random();
 
    var adjectives = new [] { "Tiny", "Average", "Large", "Humungus"};
    var materials = new [] { "Paper", "Wooden", "Concrete", "Plastic", "Granite", "Rubber" };
    var names = new [] { "Tank", "Ship", "Submarine", "Interceptor", "Helicopter", "Transport" };
    var services = new [] { "Army", "Navy", "Air Force"};
 
    context.Assets.AddRange(50.Times(x =>
    {
      var adjective = adjectives[rnd.Next(0, 4)];
      var material = materials[rnd.Next(0, 5)];
      var name = names[rnd.Next(0, 6)];
      var service = services[rnd.Next(0, 3)];
      var assetId = $"{x, -3:000}";
 
      return new Asset
      {
        AssetNumber = $"{service.First()}{name.First()}{assetId}",
        Name = $"{adjective} {material} {name}",
        Price = (double) rnd.Next(10000, 200000000),
        Service = service
      };
    }));
 
    context.SaveChanges();
  }
}