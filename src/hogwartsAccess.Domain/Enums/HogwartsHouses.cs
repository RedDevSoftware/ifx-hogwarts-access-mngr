namespace Ifx.Services.hogwartsAccess.Domain.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HogwartsHouses
    {
        Gryffindor,
        Hufflepuff,
        Ravenclaw,
        Slytherin
    }
}
