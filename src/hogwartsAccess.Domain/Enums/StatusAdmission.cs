namespace Ifx.Services.hogwartsAccess.Domain.Enums
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAdmission
    {
        PENDING,
        INPROGRESS,
        APPROVED,
        REJECT
    }
}
