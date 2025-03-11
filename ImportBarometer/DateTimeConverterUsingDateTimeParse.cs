using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTimeOffset>
{
  public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    //Debug.Assert(typeToConvert == typeof(DateTime));
    return DateTimeOffset.Parse(reader.GetString() ?? string.Empty);
  }

  public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
  {
    writer.WriteStringValue(value.ToString());
  }
}
