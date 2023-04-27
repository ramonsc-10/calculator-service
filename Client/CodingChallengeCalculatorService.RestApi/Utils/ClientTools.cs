using System.Text.Json;

namespace CodingChallengeCalculatorService.RestApi.Utils
{
    public static class ClientTools
    {
        public static void SerializeAsJson(object obj, Stream stream)
        {
            var streamWriter = new StreamWriter(stream);

            JsonSerializer.Serialize(streamWriter.BaseStream, obj, obj.GetType());

            streamWriter.Flush();
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
