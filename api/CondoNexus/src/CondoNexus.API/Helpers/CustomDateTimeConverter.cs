using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CondoNexus.API.Helpers;

// Personaliza a conversão de DateTime para a desserialização do JSON
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _dateFormat;

    // Construtor que recebe o formato de data como parâmetro
    public CustomDateTimeConverter(string dateFormat)
    {
        _dateFormat = dateFormat;
    }

    // Lê o valor da data do JSON e converte para DateTime usando o formato especificado
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString(), _dateFormat, CultureInfo.InvariantCulture);
    }

    // Escreve o valor da data no JSON usando o formato especificado
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_dateFormat, CultureInfo.InvariantCulture));
    }
}
