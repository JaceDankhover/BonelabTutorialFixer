using System.Reflection;
using TutorialFixer;
using MelonLoader;

[assembly: AssemblyTitle(TutorialFixer.Main.Description)]
[assembly: AssemblyDescription(TutorialFixer.Main.Description)]
[assembly: AssemblyProduct(TutorialFixer.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + TutorialFixer.Main.Author)]
[assembly: AssemblyVersion(TutorialFixer.Main.Version)]
[assembly: AssemblyFileVersion(TutorialFixer.Main.Version)]
[assembly: MelonInfo(typeof(TutorialFixer.Main), TutorialFixer.Main.Name, TutorialFixer.Main.Version, TutorialFixer.Main.Author, TutorialFixer.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.DarkYellow)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]