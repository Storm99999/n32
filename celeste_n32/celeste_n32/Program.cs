// See https://aka.ms/new-console-template for more information
using celeste_n32;
using Microsoft.Win32;
using System.Text.Json;
Console.Title = "cệlệste softworks - n32";
WriteGradient(@$"

                                                       $$$$$$\   $$$$$$\  
                                                      $$ ___$$\ $$  __$$\ 
                                            $$$$$$$\  \_/   $$ |\__/  $$ |
                                            $$  __$$\   $$$$$ /  $$$$$$  |
                                            $$ |  $$ |  \___$$\ $$  ____/ 
                                            $$ |  $$ |$$\   $$ |$$ |      
                                            $$ |  $$ |\$$$$$$  |$$$$$$$$\ 
                                            \__|  \__| \______/ \________|
                              
                              
                              
");
var latest = Locator.Get();
WriteGradient("   [n32-o] Finding roblox. This will only take a millisecond.");
WriteGradient("   [n32-o] Locator has found roblox at " + latest + "!");
Thread.Sleep(1500);
string jsonContent = File.ReadAllText("ClientAppSettings.json");

try
{
    using (JsonDocument doc = JsonDocument.Parse(jsonContent))
    {
        PrintJson(doc.RootElement);
    }
}
catch (JsonException ex)
{
    WriteGradient($"Error parsing JSON: {ex.Message}");
}
if (!Directory.Exists(latest + "\\ClientSettings\\"))
{
    WriteGradient("   [n32-o] ClientSettings not found, creating");
    Directory.CreateDirectory(latest + "\\ClientSettings\\");
    File.WriteAllText(latest + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText("ClientAppSettings.json"));
    WriteGradient("   [n32-o] Optimization fflags written, continue");
}
else
{
    File.WriteAllText(latest + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText("ClientAppSettings.json"));
    WriteGradient("   [n32-o] Optimization fflags written, continue");
}

Thread.Sleep(1800);
Console.Clear();
WriteGradient(@$"

                                                       $$$$$$\   $$$$$$\  
                                                      $$ ___$$\ $$  __$$\ 
                                            $$$$$$$\  \_/   $$ |\__/  $$ |
                                            $$  __$$\   $$$$$ /  $$$$$$  |
                                            $$ |  $$ |  \___$$\ $$  ____/ 
                                            $$ |  $$ |$$\   $$ |$$ |      
                                            $$ |  $$ |\$$$$$$  |$$$$$$$$\ 
                                            \__|  \__| \______/ \________|
                              
                              
                              
");

WriteGradient("   [n32-o] Setting GPU Priority, this shouldn't take long!");
GraphicsPerformance(latest + "\\RobloxPlayerBeta.exe", 2);
Thread.Sleep(150);
WriteGradient("   [n32-o] All done, launch roblox and enjoy the (somewhat) smoother experience.");

Console.ReadLine();

static void PrintJson(JsonElement element, string indent = "")
{
    switch (element.ValueKind) //copied from old projecti hooppe TIHSO WKRS!!!
    {
        case JsonValueKind.Object:
            foreach (var property in element.EnumerateObject())
            {
                WriteGradient($"   [n32-o] written: {property.Name}:");
                PrintJson(property.Value, indent + "   ");
            }
            break;

        case JsonValueKind.Array:
            int index = 0;
            foreach (var item in element.EnumerateArray())
            {
                WriteGradient($"   [n32-o] written: {indent}[{index}]:");
                PrintJson(item, indent + "   ");
                index++;
            }
            break;

        case JsonValueKind.String:
            WriteGradient($"      {element.GetString()}");
            break;

        case JsonValueKind.Number:
            WriteGradient($"      {element.GetDouble()}");
            break;

        case JsonValueKind.True:
        case JsonValueKind.False:
            WriteGradient($"      {element.GetBoolean()}");
            break;

        case JsonValueKind.Null:
            WriteGradient($"{indent}null");
            break;

        default:
            WriteGradient($"{indent}Unknown type");
            break;
    }
}
static void GraphicsPerformance(string exePath, int gpuPreference)
{
    try
    {
        // Registry key path, this should work tho
        string registryPath = @"Software\Microsoft\DirectX\UserGpuPreferences";
        string exeName = System.IO.Path.GetFileName(exePath);

        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true))
        {
            if (key == null)
            {
            }

            string value = $"AutoHDREnable=1;GpuPreference={gpuPreference};";

            key.SetValue(exePath, value, RegistryValueKind.String);

            WriteGradient("   [n32-o] Roblox has been set to GPU-Priority [2] - High performance");
        }
    }
    catch (Exception ex)
    {
        WriteGradient($"   [n32-o] has encountered an error: {ex.Message}");
    }
}

static void WriteGradient(string text)
{
    int textLength = text.Length;

    for (int i = 0; i < textLength; i++)
    {
        if (i < textLength / 2)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        Console.Write(text[i]);
    }

    Console.ResetColor();
    Console.WriteLine();
}
