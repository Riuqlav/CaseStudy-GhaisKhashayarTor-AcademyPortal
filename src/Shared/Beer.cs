namespace CaseStudy.Shared;

using System;
using System.Collections.Generic;
using JsonName = System.Text.Json.Serialization.JsonPropertyNameAttribute;

public partial class Beer : DBModel
{
    [JsonName("id")] public new long Id { get; set; }
    [JsonName("name")] public string Name { get; set; }
    [JsonName("tagline")] public string Tagline { get; set; }
    [JsonName("first_brewed")] public string FirstBrewed { get; set; }
    [JsonName("description")] public string Description { get; set; }
    [JsonName("image_url")] public Uri ImageUrl { get; set; }
    [JsonName("abv")] public double Abv { get; set; }
    [JsonName("ibu")] public double? Ibu { get; set; }
    [JsonName("target_fg")] public long TargetFg { get; set; }
    [JsonName("target_og")] public double TargetOg { get; set; }
    [JsonName("ebc")] public long? Ebc { get; set; }
    [JsonName("srm")] public double? Srm { get; set; }
    [JsonName("ph")] public double? Ph { get; set; }
    [JsonName("attenuation_level")] public double AttenuationLevel { get; set; }
    [JsonName("volume")] public BoilVolume Volume { get; set; }
    [JsonName("boil_volume")] public BoilVolume BoilVolume { get; set; }
    [JsonName("method")] public Method Method { get; set; }
    [JsonName("ingredients")] public Ingredients Ingredients { get; set; }
    [JsonName("food_pairing")] public List<string> FoodPairing { get; set; }
    [JsonName("brewers_tips")] public string BrewersTips { get; set; }
    [JsonName("contributed_by")] public string ContributedBy { get; set; }
}

public partial class BoilVolume
{
    [JsonName("value")] public double Value { get; set; }
    [JsonName("unit")] public string Unit { get; set; }
    public override string ToString() => $"{Value} {Unit}";
}

public partial class Ingredients
{
    [JsonName("malt")] public List<Malt> Malt { get; set; }
    [JsonName("hops")] public List<Hop> Hops { get; set; }
    [JsonName("yeast")] public string Yeast { get; set; }
}

public partial class Hop
{
    [JsonName("name")] public string Name { get; set; }
    [JsonName("amount")] public BoilVolume Amount { get; set; }
    [JsonName("add")] public string Add { get; set; }
    [JsonName("attribute")] public string Attribute { get; set; }
}

public partial class Malt
{
    [JsonName("name")] public string Name { get; set; }
    [JsonName("amount")] public BoilVolume Amount { get; set; }
}

public partial class Method
{
    [JsonName("mash_temp")] public List<MashTemp> MashTemp { get; set; }
    [JsonName("fermentation")] public Fermentation Fermentation { get; set; }
    [JsonName("twist")] public object? Twist { get; set; }
}

public partial class Fermentation
{
    [JsonName("temp")] public BoilVolume Temp { get; set; }
}

public partial class MashTemp
{
    [JsonName("temp")] public BoilVolume Temp { get; set; }
    [JsonName("duration")] public object Duration { get; set; }
}

